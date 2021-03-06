namespace AMBUS_Master
{
    partial class AMBUS_Master
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMBUS_Master));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControlComm = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.richTextBoxComm = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.labelCommand = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCOMState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBaud = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripComm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemClearWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.echoRadarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UPPSUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCRCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCRCAsHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideCRCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlComm.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripComm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // tabControlComm
            // 
            this.tabControlComm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlComm.Controls.Add(this.tabPageGeneral);
            this.tabControlComm.Location = new System.Drawing.Point(0, 27);
            this.tabControlComm.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabControlComm.Name = "tabControlComm";
            this.tabControlComm.SelectedIndex = 0;
            this.tabControlComm.Size = new System.Drawing.Size(784, 512);
            this.tabControlComm.TabIndex = 1;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.richTextBoxComm);
            this.tabPageGeneral.Controls.Add(this.buttonSend);
            this.tabPageGeneral.Controls.Add(this.textBoxData);
            this.tabPageGeneral.Controls.Add(this.textBoxCommand);
            this.tabPageGeneral.Controls.Add(this.textBoxAddress);
            this.tabPageGeneral.Controls.Add(this.labelData);
            this.tabPageGeneral.Controls.Add(this.labelCommand);
            this.tabPageGeneral.Controls.Add(this.labelAddress);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(776, 486);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "Console";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // richTextBoxComm
            // 
            this.richTextBoxComm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxComm.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxComm.Location = new System.Drawing.Point(8, 47);
            this.richTextBoxComm.Name = "richTextBoxComm";
            this.richTextBoxComm.Size = new System.Drawing.Size(762, 433);
            this.richTextBoxComm.TabIndex = 7;
            this.richTextBoxComm.Text = "";
            this.richTextBoxComm.TextChanged += new System.EventHandler(this.richTextBoxComm_TextChanged);
            this.richTextBoxComm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBoxComm_MouseDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(695, 19);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 22);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxData
            // 
            this.textBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxData.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.textBoxData.Location = new System.Drawing.Point(178, 19);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(511, 22);
            this.textBoxData.TabIndex = 5;
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.textBoxCommand.Location = new System.Drawing.Point(92, 19);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(80, 22);
            this.textBoxCommand.TabIndex = 4;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAddress.Location = new System.Drawing.Point(6, 19);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(80, 22);
            this.textBoxAddress.TabIndex = 3;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(175, 3);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(30, 13);
            this.labelData.TabIndex = 2;
            this.labelData.Text = "Data";
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Location = new System.Drawing.Point(89, 3);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(54, 13);
            this.labelCommand.TabIndex = 1;
            this.labelCommand.Text = "Command";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(6, 3);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(45, 13);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Address";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCOM,
            this.toolStripStatusLabelCOMState,
            this.toolStripStatusLabelBaud});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCOM
            // 
            this.toolStripStatusLabelCOM.AutoSize = false;
            this.toolStripStatusLabelCOM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelCOM.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabelCOM.Name = "toolStripStatusLabelCOM";
            this.toolStripStatusLabelCOM.Size = new System.Drawing.Size(50, 20);
            this.toolStripStatusLabelCOM.Text = "COM";
            this.toolStripStatusLabelCOM.Click += new System.EventHandler(this.toolStripStatusLabelCOM_Click);
            // 
            // toolStripStatusLabelCOMState
            // 
            this.toolStripStatusLabelCOMState.AutoSize = false;
            this.toolStripStatusLabelCOMState.Margin = new System.Windows.Forms.Padding(5, 3, 5, 2);
            this.toolStripStatusLabelCOMState.Name = "toolStripStatusLabelCOMState";
            this.toolStripStatusLabelCOMState.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabelCOMState.Text = "ComState";
            this.toolStripStatusLabelCOMState.Click += new System.EventHandler(this.toolStripStatusLabelCOMState_Click);
            // 
            // toolStripStatusLabelBaud
            // 
            this.toolStripStatusLabelBaud.AutoSize = false;
            this.toolStripStatusLabelBaud.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelBaud.Name = "toolStripStatusLabelBaud";
            this.toolStripStatusLabelBaud.Size = new System.Drawing.Size(80, 20);
            this.toolStripStatusLabelBaud.Text = "Baud";
            this.toolStripStatusLabelBaud.Click += new System.EventHandler(this.toolStripStatusLabelBaud_Click);
            // 
            // contextMenuStripComm
            // 
            this.contextMenuStripComm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClearWindow,
            this.showCRCToolStripMenuItem,
            this.showCRCAsHexToolStripMenuItem,
            this.hideCRCToolStripMenuItem});
            this.contextMenuStripComm.Name = "contextMenuStripComm";
            this.contextMenuStripComm.Size = new System.Drawing.Size(181, 114);
            // 
            // ToolStripMenuItemClearWindow
            // 
            this.ToolStripMenuItemClearWindow.Name = "ToolStripMenuItemClearWindow";
            this.ToolStripMenuItemClearWindow.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemClearWindow.Text = "Clear Window";
            this.ToolStripMenuItemClearWindow.Click += new System.EventHandler(this.ToolStripMenuItemClearWindow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.connectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.echoRadarToolStripMenuItem,
            this.UPPSUToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // echoRadarToolStripMenuItem
            // 
            this.echoRadarToolStripMenuItem.Image = global::AMBUS_Master.Properties.Resources.RadarChart_16x;
            this.echoRadarToolStripMenuItem.Name = "echoRadarToolStripMenuItem";
            this.echoRadarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.echoRadarToolStripMenuItem.Text = "EchoRadar";
            this.echoRadarToolStripMenuItem.Click += new System.EventHandler(this.echoRadarToolStripMenuItem_Click);
            // 
            // UPPSUToolStripMenuItem
            // 
            this.UPPSUToolStripMenuItem.Image = global::AMBUS_Master.Properties.Resources.PowerSupply_16x;
            this.UPPSUToolStripMenuItem.Name = "UPPSUToolStripMenuItem";
            this.UPPSUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UPPSUToolStripMenuItem.Text = "UPPSU";
            this.UPPSUToolStripMenuItem.Click += new System.EventHandler(this.UPPSUToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::AMBUS_Master.Properties.Resources.Connect_16x;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open COM Port";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::AMBUS_Master.Properties.Resources.Settings_16x;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // showCRCToolStripMenuItem
            // 
            this.showCRCToolStripMenuItem.Name = "showCRCToolStripMenuItem";
            this.showCRCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showCRCToolStripMenuItem.Text = "Show CRC";
            this.showCRCToolStripMenuItem.Click += new System.EventHandler(this.showCRCToolStripMenuItem_Click);
            // 
            // showCRCAsHexToolStripMenuItem
            // 
            this.showCRCAsHexToolStripMenuItem.Name = "showCRCAsHexToolStripMenuItem";
            this.showCRCAsHexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showCRCAsHexToolStripMenuItem.Text = "Show CRC as Hex";
            this.showCRCAsHexToolStripMenuItem.Click += new System.EventHandler(this.showCRCAsHexToolStripMenuItem_Click);
            // 
            // hideCRCToolStripMenuItem
            // 
            this.hideCRCToolStripMenuItem.Name = "hideCRCToolStripMenuItem";
            this.hideCRCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideCRCToolStripMenuItem.Text = "Hide CRC";
            this.hideCRCToolStripMenuItem.Click += new System.EventHandler(this.hideCRCToolStripMenuItem_Click);
            // 
            // AMBUS_Master
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControlComm);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AMBUS_Master";
            this.Text = "AMBUS Master";
            this.Load += new System.EventHandler(this.AMBUS_Master_Load);
            this.tabControlComm.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripComm.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripComm;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearWindow;
        private System.Windows.Forms.RichTextBox richTextBoxComm;
        private System.Windows.Forms.TabControl tabControlComm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem echoRadarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UPPSUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCOM;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBaud;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCOMState;
        private System.Windows.Forms.ToolStripMenuItem showCRCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCRCAsHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideCRCToolStripMenuItem;
    }
}

