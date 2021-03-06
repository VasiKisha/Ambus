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
    public partial class UPPSU : UserControl
    {
        public TabPage ParentTab { get; set; }
        public TabControl ParentTabControl { get; set; }
        public SerialPort SerialPort { get; set; } 

        public UPPSU(int height, int width)
        {
            InitializeComponent();
            Width = width;
            Height = height;
            Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (ParentTab == null) return;
            TabControl tabControlComm = ParentTabControl;
            tabControlComm.SelectTab(tabControlComm.SelectedIndex-1);
            tabControlComm.TabPages.Remove(ParentTab);
        }
    }
}
