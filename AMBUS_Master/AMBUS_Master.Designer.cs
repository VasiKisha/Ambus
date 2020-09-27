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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.buttonSerialOpen = new System.Windows.Forms.Button();
            this.comboBoxSerialBaud = new System.Windows.Forms.ComboBox();
            this.labelSerialBaud = new System.Windows.Forms.Label();
            this.comboBoxSerialName = new System.Windows.Forms.ComboBox();
            this.labelSerialName = new System.Windows.Forms.Label();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxRange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRadarStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.contextMenuStripComm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemClearWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSerial.SuspendLayout();
            this.tabControlComm.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStripComm.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSerial.Controls.Add(this.buttonSerialOpen);
            this.groupBoxSerial.Controls.Add(this.comboBoxSerialBaud);
            this.groupBoxSerial.Controls.Add(this.labelSerialBaud);
            this.groupBoxSerial.Controls.Add(this.comboBoxSerialName);
            this.groupBoxSerial.Controls.Add(this.labelSerialName);
            this.groupBoxSerial.Location = new System.Drawing.Point(622, 12);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(150, 129);
            this.groupBoxSerial.TabIndex = 0;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial";
            // 
            // buttonSerialOpen
            // 
            this.buttonSerialOpen.Location = new System.Drawing.Point(6, 99);
            this.buttonSerialOpen.Name = "buttonSerialOpen";
            this.buttonSerialOpen.Size = new System.Drawing.Size(138, 23);
            this.buttonSerialOpen.TabIndex = 4;
            this.buttonSerialOpen.Text = "Open";
            this.buttonSerialOpen.UseVisualStyleBackColor = true;
            this.buttonSerialOpen.Click += new System.EventHandler(this.buttonSerialOpen_Click);
            // 
            // comboBoxSerialBaud
            // 
            this.comboBoxSerialBaud.FormattingEnabled = true;
            this.comboBoxSerialBaud.Location = new System.Drawing.Point(6, 72);
            this.comboBoxSerialBaud.Name = "comboBoxSerialBaud";
            this.comboBoxSerialBaud.Size = new System.Drawing.Size(138, 21);
            this.comboBoxSerialBaud.TabIndex = 3;
            // 
            // labelSerialBaud
            // 
            this.labelSerialBaud.AutoSize = true;
            this.labelSerialBaud.Location = new System.Drawing.Point(3, 56);
            this.labelSerialBaud.Name = "labelSerialBaud";
            this.labelSerialBaud.Size = new System.Drawing.Size(32, 13);
            this.labelSerialBaud.TabIndex = 2;
            this.labelSerialBaud.Text = "Baud";
            // 
            // comboBoxSerialName
            // 
            this.comboBoxSerialName.FormattingEnabled = true;
            this.comboBoxSerialName.Location = new System.Drawing.Point(6, 32);
            this.comboBoxSerialName.Name = "comboBoxSerialName";
            this.comboBoxSerialName.Size = new System.Drawing.Size(138, 21);
            this.comboBoxSerialName.TabIndex = 1;
            this.comboBoxSerialName.SelectionChangeCommitted += new System.EventHandler(this.refreshCOM);
            // 
            // labelSerialName
            // 
            this.labelSerialName.AutoSize = true;
            this.labelSerialName.Location = new System.Drawing.Point(3, 16);
            this.labelSerialName.Name = "labelSerialName";
            this.labelSerialName.Size = new System.Drawing.Size(35, 13);
            this.labelSerialName.TabIndex = 1;
            this.labelSerialName.Text = "Name";
            // 
            // tabControlComm
            // 
            this.tabControlComm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlComm.Controls.Add(this.tabPageGeneral);
            this.tabControlComm.Controls.Add(this.tabPage1);
            this.tabControlComm.Location = new System.Drawing.Point(0, 0);
            this.tabControlComm.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabControlComm.Name = "tabControlComm";
            this.tabControlComm.SelectedIndex = 0;
            this.tabControlComm.Size = new System.Drawing.Size(616, 539);
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
            this.tabPageGeneral.Size = new System.Drawing.Size(608, 513);
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
            this.richTextBoxComm.Size = new System.Drawing.Size(594, 460);
            this.richTextBoxComm.TabIndex = 7;
            this.richTextBoxComm.Text = "";
            this.richTextBoxComm.TextChanged += new System.EventHandler(this.richTextBoxComm_TextChanged);
            this.richTextBoxComm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBoxComm_MouseDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(527, 19);
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
            this.textBoxData.Size = new System.Drawing.Size(343, 22);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxRange);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonRadarStart);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(608, 513);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Echo Radar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxRange
            // 
            this.textBoxRange.Location = new System.Drawing.Point(87, 19);
            this.textBoxRange.Name = "textBoxRange";
            this.textBoxRange.Size = new System.Drawing.Size(42, 20);
            this.textBoxRange.TabIndex = 3;
            this.textBoxRange.TextChanged += new System.EventHandler(this.textBoxRange_TextChanged);
            this.textBoxRange.Leave += new System.EventHandler(this.textBoxRange_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Range:";
            // 
            // buttonRadarStart
            // 
            this.buttonRadarStart.Location = new System.Drawing.Point(6, 6);
            this.buttonRadarStart.Name = "buttonRadarStart";
            this.buttonRadarStart.Size = new System.Drawing.Size(75, 34);
            this.buttonRadarStart.TabIndex = 1;
            this.buttonRadarStart.Text = "Start";
            this.buttonRadarStart.UseVisualStyleBackColor = true;
            this.buttonRadarStart.Click += new System.EventHandler(this.buttonRadarStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 468);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // contextMenuStripComm
            // 
            this.contextMenuStripComm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClearWindow});
            this.contextMenuStripComm.Name = "contextMenuStripComm";
            this.contextMenuStripComm.Size = new System.Drawing.Size(149, 26);
            // 
            // ToolStripMenuItemClearWindow
            // 
            this.ToolStripMenuItemClearWindow.Name = "ToolStripMenuItemClearWindow";
            this.ToolStripMenuItemClearWindow.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemClearWindow.Text = "Clear Window";
            this.ToolStripMenuItemClearWindow.Click += new System.EventHandler(this.ToolStripMenuItemClearWindow_Click);
            // 
            // AMBUS_Master
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlComm);
            this.Controls.Add(this.groupBoxSerial);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AMBUS_Master";
            this.ShowIcon = false;
            this.Text = "AMBUS Master";
            this.Load += new System.EventHandler(this.AMBUS_Master_Load);
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.tabControlComm.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStripComm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.Button buttonSerialOpen;
        private System.Windows.Forms.ComboBox comboBoxSerialBaud;
        private System.Windows.Forms.Label labelSerialBaud;
        private System.Windows.Forms.ComboBox comboBoxSerialName;
        private System.Windows.Forms.Label labelSerialName;
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRadarStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRange;
    }
}

