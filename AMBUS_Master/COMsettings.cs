using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMBUS_Master
{
    public partial class COMsettings : Form
    {
        

        public COMsettings()
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
            if (AMBUS_Master.COMbaud != 0) comboBoxSerialBaud.SelectedItem = AMBUS_Master.COMbaud.ToString();
            else comboBoxSerialBaud.SelectedItem = "115200";
            foreach(string s in Buffer)
            {
                if (s == AMBUS_Master.COMport) comboBoxSerialName.SelectedItem = AMBUS_Master.COMport;
            }
        }

        public void refreshCOM(object sender, EventArgs e)
        {
            if (comboBoxSerialName.SelectedItem.ToString() == "Refresh...")
            {
                string[] Buffer = System.IO.Ports.SerialPort.GetPortNames();
                comboBoxSerialName.Items.Clear();
                foreach (string i in Buffer) comboBoxSerialName.Items.Add(i);
                comboBoxSerialName.Items.Add("Refresh...");
                comboBoxSerialName.SelectedItem = Buffer[0];
            }
        }

        private void buttonStorno_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AMBUS_Master.COMport = comboBoxSerialName.Text;
            AMBUS_Master.COMbaud = int.Parse(comboBoxSerialBaud.Text);
        }
    }
}
