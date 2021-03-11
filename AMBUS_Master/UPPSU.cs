//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace AMBUS_Master
{
    public partial class UPPSU : UserControl
    {
        public TabPage ParentTab { get; set; }
        public TabControl ParentTabControl { get; set; }
        public SerialPort SerialPort { get; set; }
        public RichTextBox RichTextBoxComm { get; set; }

        Timer t = new Timer();
        private string address;

        public UPPSU(int height, int width)
        {
            InitializeComponent();
            Width = width;
            Height = height;
            Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            address = "UPPSU";
        }

        private void UPPSU_Load(object sender, EventArgs e)
        {
            textBoxAddress.Text = address;
            ParentTab.Text = "UPPSU:" + address;

            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen == false)
            {
                buttonStart_Click(sender, e);
                return;
            }

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "SWITCH?");
            answer = QueryDevice(question);
            if (answer != null && Ambus.GetData(answer) == "ON")
            {
                labelHwSwitch.Text = "HW Switch ON";
                labelHwSwitch.ForeColor = Color.Green;
            }
            else if (answer != null && Ambus.GetData(answer) == "OFF")
            {
                labelHwSwitch.Text = "HW Switch OFF";
                labelHwSwitch.ForeColor = Color.Red;
            }
            else
            {
                labelHwSwitch.Text = "HW Switch";
                labelHwSwitch.ForeColor = Color.Gray;
            }

            question = Ambus.GetPacket(address, "OUTPUT?");
            answer = QueryDevice(question);
            if (answer != null && Ambus.GetData(answer) == "ON")
            {
                labelOutput.Text = "Enabled";
                labelOutput.ForeColor = Color.Black;
                labelOutput.BackColor = Color.LightGreen;
            }
            else if (answer != null && Ambus.GetData(answer) == "OFF")
            {
                labelOutput.Text = "Disabled";
                labelOutput.ForeColor = Color.Black;
                labelOutput.BackColor = Color.Red;
            }
            else
            {
                labelOutput.Text = "Output State";
                labelOutput.ForeColor = Color.Gray;
                labelOutput.BackColor = Color.White;
            }

            question = Ambus.GetPacket(address, "VOLT?");
            answer = QueryDevice(question);
            if(answer == null) labelReadV.Text = "----.----V";
            else labelReadV.Text = Ambus.GetData(answer) + "V";

            question = Ambus.GetPacket(address, "CURR?");
            answer = QueryDevice(question);
            if (answer == null) labelReadC.Text = "--.----A";
            else labelReadC.Text = Ambus.GetData(answer) + "A";

            question = Ambus.GetPacket(address, "MODE?");
            answer = QueryDevice(question);
            if (answer != null && Ambus.GetData(answer) == "CV")
            {
                labelCV.BackColor = Color.LightGreen;
                labelCV.ForeColor = Color.Black;
                labelCC.BackColor = Color.White;
                labelCC.ForeColor = Color.Gray;
            }
            else if (answer != null && Ambus.GetData(answer) == "CC")
            {
                labelCV.BackColor = Color.White;
                labelCV.ForeColor = Color.Gray;
                labelCC.BackColor = Color.LightGreen;
                labelCC.ForeColor = Color.Black;
            }
            else
            {
                labelCV.BackColor = Color.White;
                labelCV.ForeColor = Color.Gray;
                labelCC.BackColor = Color.White;
                labelCC.ForeColor = Color.Gray;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (ParentTab == null) return;
            t.Dispose();
            TabControl tabControlComm = ParentTabControl;
            tabControlComm.SelectTab(tabControlComm.SelectedIndex-1);
            tabControlComm.TabPages.Remove(ParentTab);
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            if (buttonEnable.Text == "Enable")
            {
                question = Ambus.GetPacket(address, "SWREM", "ON");
                answer = QueryDevice(question);
                if (answer == null || Ambus.GetData(answer) == "OFF")
                {
                    buttonEnable.Enabled = true;
                    buttonEnable.Text = "Enable";
                }
                else if (answer != null && Ambus.GetData(answer) == "ON")
                {
                    buttonEnable.Enabled = true;
                    buttonEnable.Text = "Disable";
                }
            }
            else
            {
                question = Ambus.GetPacket(address, "SWREM", "OFF");
                answer = QueryDevice(question);
                if (answer == null || Ambus.GetData(answer) == "OFF")
                {
                    buttonEnable.Enabled = true;
                    buttonEnable.Text = "Enable";
                }
                else if (answer != null && Ambus.GetData(answer) == "ON")
                {
                    buttonEnable.Enabled = true;
                    buttonEnable.Text = "Disable";
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (t.Enabled)
            {
                t.Stop();
                buttonStart.Text = "Start";
                labelHwSwitch.Text = "HW Switch";
                labelHwSwitch.ForeColor = Color.Gray;
                labelOutput.Text = "Output State";
                labelOutput.ForeColor = Color.Gray;
                labelOutput.BackColor = Color.White;
                labelReadV.Text = "----.----V";
                labelReadC.Text = "--.----A";
                buttonEnable.Enabled = false;
                labelCV.BackColor = Color.White;
                labelCV.ForeColor = Color.Gray;
                labelCC.BackColor = Color.White;
                labelCC.ForeColor = Color.Gray;
                numericUpDownSetV.Enabled = false;
                numericUpDownSetC.Enabled = false;
                numericUpDownCalVG.Enabled = false;
                numericUpDownCalVO.Enabled = false;
                numericUpDownCalIG.Enabled = false;
                numericUpDownCalIO.Enabled = false;
                buttonCalSave.Enabled = false;
                buttonCalReload.Enabled = false;
            }
            else
            {
                address = textBoxAddress.Text;
                if (address.Length > 8)
                {
                    address = address.Substring(0, 8);
                }
                textBoxAddress.Text = address;
                ParentTab.Text = "UPPSU: " + address;

                if (SerialPort.IsOpen == false) return;

                byte[] question = new byte[Ambus.PACKET_SIZE];
                string answer;
                decimal value;

                question = Ambus.GetPacket(address, "DEV?");
                answer = QueryDevice(question);
                if (answer == null) return;
                if (Ambus.GetData(answer) != "UPPSU") return;

                question = Ambus.GetPacket(address, "FW?");
                answer = QueryDevice(question);
                if (answer != null) labelFw.Text = "Firmware Version: " + Ambus.GetData(answer);

                question = Ambus.GetPacket(address, "SWREM?");
                answer = QueryDevice(question);
                if (answer == null || Ambus.GetData(answer) == "OFF")
                {
                    buttonEnable.Enabled = true;
                    buttonEnable.Text = "Enable";
                }
                else if (answer != null && Ambus.GetData(answer) == "ON")
                {
                    buttonEnable.Enabled = true;
                    buttonEnable.Text = "Disable";
                }

                numericUpDownSetV.Enabled = true;
                numericUpDownSetC.Enabled = true;

                question = Ambus.GetPacket(address, "SETV?");
                answer = QueryDevice(question);
                labelSetV.Text = "Voltage: " + Ambus.GetData(answer) + "V";
                question = Ambus.GetPacket(address, "SETC?");
                answer = QueryDevice(question);
                labelSetC.Text = "Current: " + Ambus.GetData(answer) + "A";

                numericUpDownCalVG.Enabled = true;
                numericUpDownCalVO.Enabled = true;
                numericUpDownCalIG.Enabled = true;
                numericUpDownCalIO.Enabled = true;
                buttonCalSave.Enabled = true;
                buttonCalReload.Enabled = true;

                buttonCalReload_Click(sender, e);

                t.Start();
                buttonStart.Text = "Stop";
            }
        }

        private string QueryDevice(byte[] bpacket)
        {
            if (SerialPort.IsOpen == false) return null;
            string txt;
            SerialPort.Write(bpacket, 0, Ambus.GetPacketLength(bpacket));
            RichTextBoxComm.AppendText(Ambus.PacketToString(bpacket), Color.HotPink);
            try
            {
                txt = SerialPort.ReadLine() + '\n';
                RichTextBoxComm.AppendText(txt, Color.Black);
                return txt;
            }
            catch
            {
                RichTextBoxComm.AppendText("ERROR: Timeout\r", Color.Red);
                return null;
            }
        }

        private void numericUpDownSetV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "SETV", numericUpDownSetV.Value.ToString());
            answer = QueryDevice(question);
            if (answer == null) return;
            labelSetV.Text = "Voltage: " + Ambus.GetData(answer) + "V";
        }

        private void numericUpDownSetV_Click(object sender, EventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Enter);
            numericUpDownSetV_KeyUp(sender, k);
        }

        private void numericUpDownSetC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "SETC", numericUpDownSetC.Value.ToString());
            answer = QueryDevice(question);
            if (answer == null) return;
            labelSetC.Text = "Current: " + Ambus.GetData(answer) + "A";
        }

        private void numericUpDownSetC_Click(object sender, EventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Enter);
            numericUpDownSetC_KeyUp(sender, k);
        }

        private void numericUpDownCalVG_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "CALVG", numericUpDownCalVG.Value.ToString());
            answer = QueryDevice(question);
        }

        private void numericUpDownCalVG_Click(object sender, EventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Enter);
            numericUpDownCalVG_KeyUp(sender, k);
        }

        private void numericUpDownCalVO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "CALVO", numericUpDownCalVO.Value.ToString());
            answer = QueryDevice(question);
        }

        private void numericUpDownCalVO_Click(object sender, EventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Enter);
            numericUpDownCalVO_KeyUp(sender, k);
        }

        private void numericUpDownCalIG_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "CALIG", numericUpDownCalIG.Value.ToString());
            answer = QueryDevice(question);
        }

        private void numericUpDownCalIG_Click(object sender, EventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Enter);
            numericUpDownCalIG_KeyUp(sender, k);
        }

        private void numericUpDownCalIO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;

            question = Ambus.GetPacket(address, "CALIO", numericUpDownCalIO.Value.ToString());
            answer = QueryDevice(question);
        }

        private void numericUpDownCalIO_Click(object sender, EventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Enter);
            numericUpDownCalIO_KeyUp(sender, k);
        }

        private void buttonCalReload_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            byte[] question = new byte[Ambus.PACKET_SIZE];
            string answer;
            decimal value;

            if (btn.Name == "buttonCalReload")
            {
                question = Ambus.GetPacket(address, "CALR");
                answer = QueryDevice(question);
            }

            question = Ambus.GetPacket(address, "CALVG?");
            answer = QueryDevice(question);
            if (decimal.TryParse(Ambus.GetData(answer), out value)) numericUpDownCalVG.Value = value;

            question = Ambus.GetPacket(address, "CALVO?");
            answer = QueryDevice(question);
            if (decimal.TryParse(Ambus.GetData(answer), out value)) numericUpDownCalVO.Value = value;

            question = Ambus.GetPacket(address, "CALIG?");
            answer = QueryDevice(question);
            if (decimal.TryParse(Ambus.GetData(answer), out value)) numericUpDownCalIG.Value = value;

            question = Ambus.GetPacket(address, "CALIO?");
            answer = QueryDevice(question);
            if (decimal.TryParse(Ambus.GetData(answer), out value)) numericUpDownCalIO.Value = value;
        }

        private void buttonCalSave_Click(object sender, EventArgs e)
        {
            byte[] question = new byte[Ambus.PACKET_SIZE];
            question = Ambus.GetPacket(address, "CALS");
            QueryDevice(question);
        }
    }
}
