//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 

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
    public partial class CreateMessage : Form
    {
        public Message M = new Message();

        public CreateMessage()
        {
            InitializeComponent();
        }

        public CreateMessage(Message m)
        {
            InitializeComponent();
            textBoxName.Text = m.Name;
            textBoxAddress.Text = m.Address;
            textBoxCommand.Text = m.Command;
            textBoxData.Text = m.Data;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            M.Name = textBoxName.Text;
            M.Address = textBoxAddress.Text;
            M.Command = textBoxCommand.Text;
            M.Data = textBoxData.Text;
            if (M.Address == "" || M.Command == "") M.ShowName = "";
            else if (M.Data == "") M.ShowName = M.Name + " (" + M.Address + ";" + M.Command + ")";
            else M.ShowName = M.Name + " (" + M.Address + ";" + M.Command + ";" + M.Data + ")";
            
        }

        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            if (textBoxAddress.Text.Length > Ambus.ADDRESS_SIZE) textBoxAddress.Text = textBoxAddress.Text.Substring(0, Ambus.ADDRESS_SIZE);
        }

        private void textBoxCommand_Leave(object sender, EventArgs e)
        {
            if (textBoxCommand.Text.Length > Ambus.COMMAND_SIZE) textBoxCommand.Text = textBoxCommand.Text.Substring(0, Ambus.COMMAND_SIZE);
        }

        private void textBoxData_Leave(object sender, EventArgs e)
        {
            if (textBoxData.Text.Length > Ambus.DATA_SIZE) textBoxData.Text = textBoxData.Text.Substring(0, Ambus.DATA_SIZE);
        }
    }
}
