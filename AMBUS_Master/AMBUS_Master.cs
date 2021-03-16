//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 
    
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.IO;
using System.Collections;
using System.Xml.Serialization;

namespace AMBUS_Master
{
    public partial class AMBUS_Master : Form
    {
        public static string COMport;
        public static int COMbaud;
        public static string MessageXmlPath;

        public AMBUS_Master()
        {
            InitializeComponent();

            string[] Buffer = SerialPort.GetPortNames();
            COMport = Buffer[0];
            COMbaud = 115200;
            MessageXmlPath = "Messages.xml";
            RichTextBoxExtensions.crcForm = Ambus.CRCFormat.HexCRC;
            listBoxCommands.DisplayMember = "ShowName";
            UpdateStatus();

            Debug.WriteLine("-------START DEBUG--------");
        }

        private void AMBUS_Master_Load(object sender, EventArgs e)
        {
            serialPort.Encoding = Encoding.GetEncoding(28591);
                        
            XmlSerializer x = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Message) });
            StreamReader reader = new StreamReader(MessageXmlPath);
            ArrayList list = (ArrayList)x.Deserialize(reader);
            reader.Close();
            foreach (Message item in list)
            {
                listBoxCommands.Items.Add(item);
            }
        }

        //public string GetString()
        //{
        //    return richTextBoxComm.Text;
        //}

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COMsettings comSettings = new COMsettings();
            DialogResult dr = comSettings.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                comSettings.Close();
            }
            else if (dr == DialogResult.OK)
            {
                UpdateStatus();
                comSettings.Close();
            }
        }

        public void UpdateStatus()
        {
            toolStripStatusLabelCOM.Text = COMport;
            toolStripStatusLabelBaud.Text = COMbaud.ToString();
            if (serialPort.IsOpen)
            {
                toolStripStatusLabelCOMState.Text = "Opened";
                toolStripStatusLabelCOMState.BackColor = Color.LightGreen;
            }
            else
            {
                toolStripStatusLabelCOMState.Text = "Closed";
                toolStripStatusLabelCOMState.BackColor = Color.Red;
            }
        }

        private void toolStripStatusLabelCOMState_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void toolStripStatusLabelCOM_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen) return;
            settingsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripStatusLabelBaud_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen) return;
            settingsToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                openToolStripMenuItem.Text = "Open COM Port";
                settingsToolStripMenuItem.Enabled = true;
                richTextBoxComm.AppendText("Serial port " + COMport + " closed\n", Color.Green);
            }
            else
            {
                try
                {
                    serialPort.PortName = COMport;
                    serialPort.BaudRate = COMbaud;
                    serialPort.ReadTimeout = 1000;
                    serialPort.Open();
                    openToolStripMenuItem.Text = "Close COM Port";
                    settingsToolStripMenuItem.Enabled = false;
                    richTextBoxComm.AppendText("Serial port " + COMport + " opened\n", Color.Green);
                }
                catch
                {
                    richTextBoxComm.AppendText("Serial port " + COMport + " opening error\n", Color.Red);
                }
            }
            UpdateStatus();
        }

        private void UPPSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage uppsuPage = new TabPage("UPPSU");
            tabControlComm.TabPages.Add(uppsuPage);

            UPPSU uppsuControl = new UPPSU(Height - 114, Width - 24);
            uppsuControl.ParentTab = uppsuPage;
            uppsuControl.ParentTabControl = tabControlComm;
            uppsuControl.SerialPort = serialPort;
            uppsuControl.RichTextBoxComm = richTextBoxComm;

            uppsuPage.Controls.Add(uppsuControl);
            tabControlComm.SelectTab(uppsuPage);
        }

        private void echoRadarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage echoPage = new TabPage("EchoRadar");
            tabControlComm.TabPages.Add(echoPage);

            Echo EchoControl = new Echo(Height - 114, Width - 24);
            EchoControl.ParentTab = echoPage;
            EchoControl.ParentTabControl = tabControlComm;
            EchoControl.SerialPort = serialPort;
            EchoControl.RichTextBoxComm = richTextBoxComm;

            echoPage.Controls.Add(EchoControl);
            tabControlComm.SelectTab(echoPage);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //open port check
            if (!serialPort.IsOpen) return;
            //int endOfPacket = 0;

            //packet composition
            byte[] packet = new byte[Ambus.PACKET_SIZE];
            packet = Ambus.GetPacket(textBoxAddress.Text, textBoxCommand.Text, textBoxData.Text);
            if (packet == null)
            {
                richTextBoxComm.AppendText("ERROR: Address and command must any character\n", Color.Red);
                return;
            }

            //querry
            serialPort.Write(packet, 0, Ambus.GetPacketLength(packet));
            richTextBoxComm.AppendText(Ambus.PacketToString(packet), Color.HotPink);

            //response
            string txt;
            try
            {
                txt = serialPort.ReadLine() + '\n';
                richTextBoxComm.AppendText(txt, Color.Black);
            }
            catch
            {
                richTextBoxComm.AppendText("ERROR: Timeout\r", Color.Red);
            }
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

        /*
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
        */
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            /*
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
            */
        }

        private void showCRCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxExtensions.crcForm = Ambus.CRCFormat.RawCRC;
        }

        private void showCRCAsHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxExtensions.crcForm = Ambus.CRCFormat.HexCRC;
        }

        private void hideCRCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxExtensions.crcForm = Ambus.CRCFormat.NoCRC;
        }

        private void listBoxCommands_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripListBox.Show(MousePosition.X, MousePosition.Y);
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ListBox lbc = (ListBox)sender;
                Point pt = new Point(e.X, e.Y);
                int index = lbc.IndexFromPoint(pt);
                if (index >= 0)
                {
                    lbc.DoDragDrop(lbc.Items[index], DragDropEffects.Move);
                }
            }
        }

        private void listBoxCommands_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBoxCommands_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxCommands.PointToClient(new Point(e.X, e.Y));
            int index = listBoxCommands.IndexFromPoint(point);
            if (index < 0) index = listBoxCommands.Items.Count - 1;
            object data = e.Data.GetData(typeof(Message));
            listBoxCommands.Items.RemoveAt(listBoxCommands.SelectedIndex);
            listBoxCommands.Items.Insert(index, data);
            listBoxCommands.SelectedIndex = index;
        }

        private void listBoxCommands_DoubleClick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) return;

            if (listBoxCommands.SelectedIndex == -1) return;
            byte[] packet = new byte[Ambus.PACKET_SIZE];
            Message selectedMessage = (Message)listBoxCommands.Items[listBoxCommands.SelectedIndex];
            if (selectedMessage.Data == "")
            {
                packet = Ambus.GetPacket(selectedMessage.Address, selectedMessage.Command);
            }
            else
            {
                packet = Ambus.GetPacket(selectedMessage.Address, selectedMessage.Command, selectedMessage.Data);
            }

            //querry
            serialPort.Write(packet, 0, Ambus.GetPacketLength(packet));
            richTextBoxComm.AppendText(Ambus.PacketToString(packet), Color.HotPink);

            //response
            string txt;
            try
            {
                txt = serialPort.ReadLine() + '\n';
                richTextBoxComm.AppendText(txt, Color.Black);
            }
            catch
            {
                richTextBoxComm.AppendText("ERROR: Timeout\r", Color.Red);
            }
        }

        private void createCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message M = new Message();
            M.Address = textBoxAddress.Text;
            M.Command = textBoxCommand.Text;
            M.Data = textBoxData.Text;
            CreateMessage createMessage = new CreateMessage(M);
            DialogResult dr = createMessage.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                createMessage.Close();
            }
            else if (dr == DialogResult.OK)
            {
                if (createMessage.M.ShowName != "") listBoxCommands.Items.Add(createMessage.M);
                createMessage.Close();
            }
        }

        private void deleteCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (listBoxCommands.SelectedIndex >= 0)
            {
                listBoxCommands.Items.RemoveAt(listBoxCommands.SelectedIndex);
            }
        }

        private void editCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedIndex == -1) return;

            CreateMessage createMessage = new CreateMessage((Message)listBoxCommands.SelectedItem);
            DialogResult dr = createMessage.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                createMessage.Close();
            }
            else if (dr == DialogResult.OK)
            {
                if (createMessage.M.ShowName != "") listBoxCommands.Items[listBoxCommands.SelectedIndex] = createMessage.M;
                createMessage.Close();
            }
        }

        private void sendCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxCommands_DoubleClick(sender, e);
        }

        private void showMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedIndex == -1) return;

            Message M = (Message)listBoxCommands.SelectedItem;
            textBoxAddress.Text = M.Address;
            textBoxCommand.Text = M.Command;
            textBoxData.Text = M.Data;
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem == null) return;
            listBoxCommands.Items.Add((Message)listBoxCommands.Items[listBoxCommands.SelectedIndex]);
        }

        private void AMBUS_Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArrayList list = new ArrayList();
            foreach (Message item in listBoxCommands.Items)
            {
                list.Add(item);
            }

            XmlSerializer x = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Message) });
            StreamWriter write = new StreamWriter(MessageXmlPath);
            x.Serialize(write, list);
            
            write.Close();
        }
    }

    public class Message
    {
        public string ShowName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Command { get; set; }
        public string Data { get; set; }
    }

    public static class RichTextBoxExtensions
    {
        public static Ambus.CRCFormat crcForm { get; set; }

        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            if (text == null) return;
            text = Ambus.ParsePacket(text, crcForm);
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            if (box.TextLength > 100000)
            {
                box.Clear();
                box.SelectionColor = Color.Red;
                box.AppendText("Removed excessive records...\r");
                box.SelectionColor = box.ForeColor;
            }
        }
    }
}
