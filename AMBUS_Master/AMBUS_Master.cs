using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AMBUS_Master
{
    public partial class AMBUS_Master : Form
    {
        Timer t = new Timer(); //radar timer
    
        int RADAR_WIDTH = 1600, RADAR_HEIGHT = 1600; //radar width x height

        Bitmap bmp; //radar

        int beam_angle;     //angle of radar beam
        bool beam_dir;      //beam rotatio direction: 1 = clockwise, 0 = counted clockwise
        int beam_length;    //lenght of beam;
        double rLenght;      //relative lenght to detection point
        int range;
        int cx, cy;         //center of radar circle
        int radarStart;     //radar operation on/off

        public AMBUS_Master()
        {
            InitializeComponent();
            string[] Buffer = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string i in Buffer) comboBoxSerialName.Items.Add(i);
            comboBoxSerialName.Items.Add("Refresh...");
            comboBoxSerialName.SelectedItem = Buffer[0];
            comboBoxSerialBaud.Items.AddRange(new object[] 
            {
                "600",
                "1200",
                "2400",
                "4800",
                "9600",
                "14400",
                "19200",
                "38400",
                "56000",
                "57600",
                "115200"
            });
            comboBoxSerialBaud.SelectedItem = "115200";

            range = 2000;
            textBoxRange.Text = range.ToString();

            Debug.WriteLine("-------START DEBUG--------");
        }

        private void AMBUS_Master_Load(object sender, EventArgs e)
        {

            //radar initialization
            bmp = new Bitmap(RADAR_WIDTH + 1, RADAR_HEIGHT + 1);
            cx = RADAR_WIDTH / 2;
            cy = RADAR_HEIGHT / 2;
            beam_angle = 900;        //initial angle of hand
            beam_length = RADAR_WIDTH / 2;
            beam_dir = true;        //clockwise direction
            t.Interval = 100;        //interval between radar measurements
            t.Tick += new EventHandler(this.t_Tick);
            serialPort.Encoding = System.Text.Encoding.GetEncoding(1252);
        }

        public string GetString()
        {
            return richTextBoxComm.Text;
        }

        public void refreshCOM(object sender, EventArgs e)
        {
            if(comboBoxSerialName.SelectedItem.ToString() == "Refresh...")
            {
                string[] Buffer = System.IO.Ports.SerialPort.GetPortNames();
                comboBoxSerialName.Items.Clear();
                foreach (string i in Buffer) comboBoxSerialName.Items.Add(i);
                comboBoxSerialName.Items.Add("Refresh...");
                comboBoxSerialName.SelectedItem = Buffer[0];
            }
        }

        private void buttonSerialOpen_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                buttonSerialOpen.Text = "Open";
                comboBoxSerialBaud.Enabled = true;
                comboBoxSerialName.Enabled = true;
                richTextBoxComm.AppendText("Serial port " + comboBoxSerialName.Text + " closed\n", Color.Green);
                //buttonRadarStart.Enabled = false;
                //t.Stop();
                //buttonRadarStart.Text = "Start";
            }
            else
            {
                try
                {
                    serialPort.PortName = comboBoxSerialName.Text;
                    serialPort.BaudRate = int.Parse(comboBoxSerialBaud.Text);
                    serialPort.ReadTimeout = 1000;
                    serialPort.Open();
                    buttonSerialOpen.Text = "Close";
                    comboBoxSerialName.Enabled = false;
                    comboBoxSerialBaud.Enabled = false;
                    richTextBoxComm.AppendText("Serial port " + comboBoxSerialName.Text + " opened\n", Color.Green);
                    //buttonRadarStart.Enabled = true;
                }
                catch
                {
                    richTextBoxComm.AppendText("Serial port " + comboBoxSerialName.Text + " opening error\n", Color.Red);
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //kontrola otevření portu
            if (!serialPort.IsOpen) return;

            //sestavení packetu
            byte[] packet = new byte[Ambus.PACKET_SIZE];
            packet = Ambus.GetPacket(textBoxAddress.Text, textBoxCommand.Text, textBoxData.Text);
            

            //dotaz
            serialPort.Write(packet, 0, packet.Length);
            richTextBoxComm.AppendText(Encoding.UTF8.GetString(packet), Color.HotPink);
           
            //richTextBoxComm.AppendText(BitConverter.ToString(packet));

            //odpoved
            //try
            //{
            //    richTextBoxComm.AppendText(serialPort.ReadLine());
            //    richTextBoxComm.AppendText(Environment.NewLine);
            //}
            //catch (TimeoutException)
            //{
            //    richTextBoxComm.AppendText("Error, Device " + textBoxAddress.Text + " not responding\n", Color.Red);
            //    return;
            //}
        }

        private void richTextBoxComm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripComm.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void ToolStripMenuItemClearWindow_Click(object sender, EventArgs e)
        {
            richTextBoxComm.Clear();
        }

        private void richTextBoxComm_TextChanged(object sender, EventArgs e)
        {
            richTextBoxComm.ScrollToCaret();
        }

        private delegate void SafeCallDelegate(string text, Color color);

        private void SetText(string text, Color color)
        {
            if(richTextBoxComm.InvokeRequired)
            {
                SafeCallDelegate d = new SafeCallDelegate(SetText);
                Invoke(d, new object[] { text, color });
            }
            else
            {
                richTextBoxComm.AppendText(text, color);

            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string txt;
            try
            {
                txt = serialPort.ReadLine() + '\n';
                SetText(txt, Color.Black);
                //Debug.WriteLine("Address: " + Ambus.GetAddress(txt));
                //Debug.WriteLine("Command: " + Ambus.GetCommand(txt));
                //Debug.WriteLine("Data: " + Ambus.GetData(txt));
                if (Ambus.GetAddress(txt) == Ambus.GetMyAddress() && Ambus.GetCommand(txt) == "Dur?")
                {
                    int temp = int.Parse(Ambus.GetData(txt));
                    if (temp == 0) rLenght = 1;
                    else if (temp > range) rLenght = 1;
                    else rLenght = ((double)temp / range);
                    //rLenght /= 2;
                }
            }
            catch
            {
                //SetText("Error, Device " + textBoxAddress.Text + " not responding\n", Color.Red);
            }

            
        }

        private void textBoxRange_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRange_Leave(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(textBoxRange.Text, out i))
            {
                if (i > 30000) textBoxRange.Text = "30000";
                else if (i < 100) textBoxRange.Text = "100";
                range = int.Parse(textBoxRange.Text);
            }
            else textBoxRange.Text = range.ToString();
        }

        //Radar start/stop
        private void buttonRadarStart_Click(object sender, EventArgs e)
        {
            if (t.Enabled )
            {
                t.Stop();
                buttonRadarStart.Text = "Start";
            }
            else
            {
                t.Start();
                buttonRadarStart.Text = "Stop";
            }
        }

        //radar control
        private void t_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false) return;

            Pen p = new Pen(Color.Green, 4f);
            Graphics g = Graphics.FromImage(bmp);
            int x, y;           //coordinate of moving part of beam
            int dx, dy;         //coordinate of detection
            

            //control hardware
            byte[] packet = new byte[Ambus.PACKET_SIZE];
            if (beam_angle % 10 == 0)
            {
                packet = Ambus.GetPacket("ECHO1", "An", (beam_angle / 10).ToString());
                serialPort.Write(packet, 0, packet.Length);
                richTextBoxComm.AppendText(Encoding.UTF8.GetString(packet), Color.HotPink);
                packet = Ambus.GetPacket("ECHO1", "Dur?");
                serialPort.Write(packet, 0, packet.Length);
                richTextBoxComm.AppendText(Encoding.UTF8.GetString(packet), Color.HotPink);
            }
            Debug.WriteLine(rLenght);
            //

            //calculate x,y coordinate of beam
            if ( beam_angle >= 0 && beam_angle <= 180 )
            {
                x = cx + (int)(beam_length * Math.Sin(Math.PI * beam_angle / 1800));
                y = cy - (int)(beam_length * Math.Cos(Math.PI * beam_angle / 1800));
                dx = cx + (int)(beam_length* rLenght * Math.Sin(Math.PI * beam_angle / 1800));
                dy = cy - (int)(beam_length* rLenght * Math.Cos(Math.PI * beam_angle / 1800));
            }
            else
            {
                x = cx - (int)(beam_length * -Math.Sin(Math.PI * beam_angle / 1800));
                y = cy - (int)(beam_length * Math.Cos(Math.PI * beam_angle / 1800));
                dx = cx - (int)(beam_length*rLenght * -Math.Sin(Math.PI * beam_angle / 1800));
                dy = cy - (int)(beam_length*rLenght * Math.Cos(Math.PI * beam_angle / 1800));
            }

            //draw circles
            g.DrawEllipse(p, 0, 0, RADAR_WIDTH, RADAR_HEIGHT); //bigger circle
            g.DrawEllipse(p, RADAR_WIDTH / 4, RADAR_HEIGHT / 4, RADAR_WIDTH / 2, RADAR_HEIGHT / 2);

            //draw perpendicular line
            g.DrawLine(p, new Point(cx, 0), new Point(cx, RADAR_HEIGHT));
            g.DrawLine(p, new Point(0, cy), new Point(RADAR_WIDTH, cy));

            //draw beam
            p.Width = 10;
            g.DrawLine(p, new Point(dx, dy), new Point(x, y));

            //draw detection
            p.Color = Color.LightGreen;
            g.DrawLine(p, new Point(cx, cy), new Point(dx, dy));

            //fade beam
            g.FillRectangle(new SolidBrush(Color.FromArgb(5, Color.Black)), 0, 0, RADAR_WIDTH, RADAR_HEIGHT);

            //load bitmap into picturebox1
            pictureBox1.Image = bmp;
            
            //dispose
            p.Dispose();
            g.Dispose();

            //update
            if (beam_angle >= 1700)beam_dir = false;
            if (beam_angle <= 100) beam_dir = true;
            if (beam_dir) beam_angle+=5;
            else beam_angle-=5;
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public static class Ambus
    {
        private static string myAddress = "MASTER";
        public const char START_OF_PACKET = '$';
        public const char SEPARATOR = ';';
        public const char END_OF_PACKET = '\n';
        public const byte SUBSTITUTE = 0x1A;
        public const int ADDRESS_SIZE = 8;
        public const int COMMAND_SIZE = 8;
        public const int DATA_SIZE = 32;
        public const int CRC_SIZE = 1;
        public const int PACKET_SIZE = ADDRESS_SIZE + COMMAND_SIZE + DATA_SIZE + CRC_SIZE + 5;

        public static void SetMyAddress(string address)
        {
            myAddress = address;
        }

        public static string GetMyAddress()
        {
            return myAddress;
        }

        public static byte[] GetPacket(string address, string command)
        {
            int i = 0;
            byte[] packet = new byte[PACKET_SIZE];

            if (address.Length > ADDRESS_SIZE) address = address.Substring(0, ADDRESS_SIZE);
            if (command.Length > COMMAND_SIZE) command = command.Substring(0, COMMAND_SIZE);

            packet[i++] = Convert.ToByte(START_OF_PACKET);
            foreach (char c in address)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            foreach (char c in command)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            packet[i++] = Checksum(packet);
            packet[i++] = Convert.ToByte(END_OF_PACKET);

            return packet;
        }

        public static byte[] GetPacket(string address, string command, string data)
        {
            int i = 0;
            byte[] packet = new byte[PACKET_SIZE];

            if (address.Length > ADDRESS_SIZE) address = address.Substring(0, ADDRESS_SIZE);
            if (command.Length > COMMAND_SIZE) command = command.Substring(0, COMMAND_SIZE);
            if (data.Length > DATA_SIZE) data = data.Substring(0, DATA_SIZE);

            packet[i++] = Convert.ToByte(START_OF_PACKET);
            foreach (char c in address)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            foreach (char c in command)
            {
                packet[i++] = Convert.ToByte(c);
            }
            packet[i++] = Convert.ToByte(SEPARATOR);
            if (data != "")
            {
                foreach (char c in data)
                {
                    packet[i++] = Convert.ToByte(c);
                }
                packet[i++] = Convert.ToByte(SEPARATOR);
            }
            packet[i++] = Checksum(packet);

            packet[i++] = Convert.ToByte(END_OF_PACKET);

            return packet;
        }

        public static bool ValidatePacket(byte[] packet)
        {
            int sop = -1, eop = -1;
            int[] sep = new int[3];
            sep[0] = -1;
            sep[1] = -1;
            sep[2] = -1;
            int isep = 0;
            int position = 0;

            foreach (char b in packet)
            {
                if (b == START_OF_PACKET)
                {
                    if (sop != -1) return false;
                    sop = position;
                }
                if (b == SEPARATOR) 
                {
                    if (isep > 2) return false;
                    sep[isep++] = position;
                }
                if (b == END_OF_PACKET) 
                {
                    if (eop != -1) return false;
                    eop = position;
                }
                position++;
            }

            //Debug.WriteLine("Validation: ");
            //Debug.WriteLine("Start of packet position: {0}", sop);
            //Debug.WriteLine("Separator position: {0}, {1}, {2}", sep[0], sep[1], sep[2]);
            //Debug.WriteLine("End of packet position: {0}", eop);

            if (sop != 0) return false;
            if (sep[0] - sop < 2) return false;
            if (sep[1] - sep[0] < 2) return false;

            if (sep[2] == -1)   //no data
            {
                if (eop - sep[1] != 2) return false;
            }
            else                //with data
            {
                if (sep[2] - sep[1] < 2) return false;
                if (eop - sep[2] != 2) return false;
            }

            byte[] temp = new byte[eop - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = packet[i];
            }

            if (packet[eop - 1] != Checksum(temp))
            {
                Debug.WriteLine("checksum is incorrect: {0}, {1}", packet[eop - 1], Checksum(temp));
                return false;
            }

            return true;
        }

        public static bool ValidatePacket(string packet)
        {
            int sop = -1, eop = -1;
            int[] sep = new int[3];
            sep[0] = -1;
            sep[1] = -1;
            sep[2] = -1;
            int isep = 0;
            int position = 0;

            foreach (char b in packet)
            {
                if (b == START_OF_PACKET)
                {
                    if (sop != -1) return false;
                    sop = position;
                }
                if (b == SEPARATOR)
                {
                    if (isep > 2) return false;
                    sep[isep++] = position;
                }
                if (b == END_OF_PACKET)
                {
                    if (eop != -1) return false;
                    eop = position;
                }
                position++;
                //Debug.WriteLine("{0:X}",Convert.ToByte(b));
            }

            //Debug.WriteLine("Validation: ");
            //Debug.WriteLine("Start of packet position: {0}", sop);
            //Debug.WriteLine("Separator position: {0}, {1}, {2}", sep[0], sep[1], sep[2]);
            //Debug.WriteLine("End of packet position: {0}", eop);

            if (sop != 0) return false;
            if (sep[0] - sop < 2) return false;
            if (sep[1] - sep[0] < 2) return false;

            if (sep[2] == -1)   //no data
            {
                if (eop - sep[1] != 2) return false;
            }
            else                //with data
            {
                if (sep[2] - sep[1] < 2) return false;
                if (eop - sep[2] != 2) return false;
            }

            if (packet[eop - 1] != Checksum(packet.Substring(0,eop-1)))
            {
                Debug.WriteLine("checksum is incorrect: {0:X}, {1:X}", Convert.ToByte(packet[eop - 1]), Convert.ToByte(Checksum(packet.Substring(0, eop - 1))));
                return false;
            }

            return true;
        }

        public static string GetAddress(byte[] packet)
        {
            if (!ValidatePacket(packet)) return "";

            int sep = 0;
            int position = 0;

            foreach(byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep = position;
                    break;
                }
                position++;
            }

            return Encoding.UTF8.GetString(packet, 1, sep - 1);
        }

        public static string GetAddress(string packet)
        {
            if (!ValidatePacket(packet)) return "";

            int sep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep = position;
                    break;
                }
                position++;
            }

            return packet.Substring(1, sep - 1);
        }

        public static string GetCommand(byte[] packet)
        {
            if (!ValidatePacket(packet)) return "";

            int[] sep = new int[2];
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if(b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 2) break;
                }
                position++;
            }

            return Encoding.UTF8.GetString(packet, sep[0] + 1, sep[1] - sep[0] - 1);
        }

        public static string GetCommand(string packet)
        {
            if (!ValidatePacket(packet)) return "";

            int[] sep = new int[2];
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 2) break;
                }
                position++;
            }

            return packet.Substring(sep[0] + 1, sep[1] - sep[0] - 1);
        }

        public static string GetData(byte[] packet)
        {
            if (!ValidatePacket(packet)) return "";
            int[] sep = new int[3];
            sep[2] = -1;
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 3) break;
                }
                position++;
            }

            if (sep[2] == -1) return "";
            return Encoding.UTF8.GetString(packet, sep[1] + 1, sep[2] - sep[1] - 1);
        }

        public static string GetData(string packet)
        {
            if (!ValidatePacket(packet)) return "";
            int[] sep = new int[3];
            sep[2] = -1;
            int isep = 0;
            int position = 0;

            foreach (byte b in packet)
            {
                if (b == SEPARATOR)
                {
                    sep[isep++] = position;
                    if (isep >= 3) break;
                }
                position++;
            }

            if (sep[2] == -1) return "";
            return packet.Substring(sep[1] + 1, sep[2] - sep[1] - 1);
        }

        private static byte Checksum(byte[] data)
        {
            int sum = 0;

            foreach(byte b in data)
            {
                sum = (sum + b) % 255;
            }

            if (sum == Convert.ToByte(START_OF_PACKET)) return SUBSTITUTE;      //osetreni zakazaneho znaku dolar $
            if (sum == Convert.ToByte(SEPARATOR)) return SUBSTITUTE;            //osetreni zakazaneho znaku středník ;
            //pridat ošetření zakázaného znaku nový rádek: \n
            return (byte)sum;
        }

        private static char Checksum(string data)
        {
            int sum = 0;

            foreach(char b in data)
            {
                sum = (sum + b) % 255;
            }

            if (sum == Convert.ToByte(START_OF_PACKET)) return Convert.ToChar(SUBSTITUTE);      //osetreni zakazaneho znaku dolar $
            if (sum == Convert.ToByte(SEPARATOR)) return Convert.ToChar(SUBSTITUTE);            //osetreni zakazaneho znaku středník ;
            //pridat ošetření zakázaného znaku nový rádek: \n
            return Convert.ToChar(sum);
        }
    }
}
