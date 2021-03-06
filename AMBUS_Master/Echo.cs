//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace AMBUS_Master
{
    public partial class Echo : UserControl
    {
        public TabPage ParentTab { get; set; }
        public TabControl ParentTabControl { get; set; }
        public SerialPort SerialPort { get; set; }
        public RichTextBox RichTextBoxComm { get; set; }

        Timer t = new Timer(); //radar timer

        int RADAR_WIDTH = 1600, RADAR_HEIGHT = 1600; //radar width x height

        Bitmap bmp;         //radar

        int beam_angle;     //angle of radar beam
        bool beam_dir;      //beam rotatio direction: 1 = clockwise, 0 = counted clockwise
        int beam_length;    //lenght of beam;
        double rLenght;     //relative lenght to detection point
        int range;
        int cx, cy;         //center of radar circle
        string address;
        int eCounter;

        public Echo(int height, int width)
        {
            InitializeComponent();
            Height = height;
            Width = width;
            Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            range = 2000;
            textBoxRange.Text = range.ToString();
        }

        private void Echo_Load(object sender, EventArgs e)
        {
            //radar initialization
            bmp = new Bitmap(RADAR_WIDTH + 1, RADAR_HEIGHT + 1);
            cx = RADAR_WIDTH / 2;
            cy = RADAR_HEIGHT / 2;
            beam_angle = 900;           //initial angle of hand
            beam_length = RADAR_WIDTH / 2;
            beam_dir = true;            //clockwise direction
            t.Interval = 100;           //interval between radar measurements
            eCounter = 0;
            address = "ECHO1";
            textBoxAddress.Text = address;
            ParentTab.Text = ("EchoRadar: " + address);
            t.Tick += new EventHandler(t_Tick);
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

        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            address = textBoxAddress.Text;
            if (address.Length > 8)
            {
                address = address.Substring(0, 8);
            }
            textBoxAddress.Text = address;
            ParentTab.Text = ("EchoRadar: " + address);
        }

        //Radar start/stop
        private void buttonRadarStart_Click(object sender, EventArgs e)
        {
            if (t.Enabled)
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

        private void t_Tick(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen == false) return;

            Pen p = new Pen(Color.Green, 4f);
            Graphics g = Graphics.FromImage(bmp);
            int x, y;           //coordinate of moving part of beam
            int dx, dy;         //coordinate of detection


            //control hardware
            byte[] packet = new byte[Ambus.PACKET_SIZE];
            if (beam_angle % 10 == 0)
            {
                string txt;
                packet = Ambus.GetPacket(address, "An", (beam_angle / 10).ToString());
                SerialPort.Write(packet, 0, Ambus.GetPacketLength(packet));
                RichTextBoxComm.AppendText(Ambus.PacketToString(packet), Color.HotPink);
                try
                {
                    txt = SerialPort.ReadLine() + '\n';
                    RichTextBoxComm.AppendText(txt, Color.Black);
                    if (eCounter > 0) eCounter--;
                }
                catch
                {
                    RichTextBoxComm.AppendText("ERROR: Timeout\r", Color.Red);
                    eCounter += 2;
                }

                packet = Ambus.GetPacket(address, "Dur?");
                SerialPort.Write(packet, 0, Ambus.GetPacketLength(packet));
                RichTextBoxComm.AppendText(Ambus.PacketToString(packet), Color.HotPink);
                try
                {
                    txt = SerialPort.ReadLine() + '\n';
                    RichTextBoxComm.AppendText(txt, Color.Black);
                    if (Ambus.GetAddress(txt) == Ambus.GetMyAddress() && Ambus.GetCommand(txt) == "Dur?")
                    {
                        int temp = int.Parse(Ambus.GetData(txt));
                        if (temp == 0) rLenght = 1;
                        else if (temp > range) rLenght = 1;
                        else rLenght = (double)temp / range;
                    }
                    if (eCounter > 0) eCounter--;
                }
                catch
                {
                    RichTextBoxComm.AppendText("ERROR: Timeout\r", Color.Red);
                    eCounter += 2;
                }
                if (eCounter > 10)
                {
                    buttonRadarStart_Click(sender, e);
                    RichTextBoxComm.AppendText("EchoRadar: " + address + " stopped\r", Color.Red);
                    ParentTabControl.SelectedIndex = 0;
                    eCounter = 0;
                }
            }

            //calculate x,y coordinate of beam
            if (beam_angle >= 0 && beam_angle <= 180)
            {
                x = cx + (int)(beam_length * Math.Sin(Math.PI * beam_angle / 1800));
                y = cy - (int)(beam_length * Math.Cos(Math.PI * beam_angle / 1800));
                dx = cx + (int)(beam_length * rLenght * Math.Sin(Math.PI * beam_angle / 1800));
                dy = cy - (int)(beam_length * rLenght * Math.Cos(Math.PI * beam_angle / 1800));
            }
            else
            {
                x = cx - (int)(beam_length * -Math.Sin(Math.PI * beam_angle / 1800));
                y = cy - (int)(beam_length * Math.Cos(Math.PI * beam_angle / 1800));
                dx = cx - (int)(beam_length * rLenght * -Math.Sin(Math.PI * beam_angle / 1800));
                dy = cy - (int)(beam_length * rLenght * Math.Cos(Math.PI * beam_angle / 1800));
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
            if (beam_angle >= 1700) beam_dir = false;
            if (beam_angle <= 100) beam_dir = true;
            if (beam_dir) beam_angle += 5;
            else beam_angle -= 5;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (ParentTab == null) return;
            TabControl tabControlComm = ParentTabControl;
            tabControlComm.SelectTab(tabControlComm.SelectedIndex - 1);
            tabControlComm.TabPages.Remove(ParentTab);
            t.Dispose();
        }
    }
}
