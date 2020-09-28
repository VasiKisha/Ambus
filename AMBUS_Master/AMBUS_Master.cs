//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 
    
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AMBUS_Master
{
    public partial class AMBUS_Master : Form
    {
        Timer t = new Timer(); //radar timer
    
        int RADAR_WIDTH = 1600, RADAR_HEIGHT = 1600; //radar width x height

        Bitmap bmp;         //radar

        int beam_angle;     //angle of radar beam
        bool beam_dir;      //beam rotatio direction: 1 = clockwise, 0 = counted clockwise
        int beam_length;    //lenght of beam;
        double rLenght;     //relative lenght to detection point
        int range;
        int cx, cy;         //center of radar circle

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
            beam_angle = 900;           //initial angle of hand
            beam_length = RADAR_WIDTH / 2;
            beam_dir = true;            //clockwise direction
            t.Interval = 100;           //interval between radar measurements
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
                }
                catch
                {
                    richTextBoxComm.AppendText("Serial port " + comboBoxSerialName.Text + " opening error\n", Color.Red);
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //open port check
            if (!serialPort.IsOpen) return;

            //packet composition
            byte[] packet = new byte[Ambus.PACKET_SIZE];
            packet = Ambus.GetPacket(textBoxAddress.Text, textBoxCommand.Text, textBoxData.Text);
            
            //querry
            serialPort.Write(packet, 0, packet.Length);
            richTextBoxComm.AppendText(Encoding.UTF8.GetString(packet), Color.HotPink);
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
                if (Ambus.GetAddress(txt) == Ambus.GetMyAddress() && Ambus.GetCommand(txt) == "Dur?")
                {
                    int temp = int.Parse(Ambus.GetData(txt));
                    if (temp == 0) rLenght = 1;
                    else if (temp > range) rLenght = 1;
                    else rLenght = (double)temp / range;
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
}
