namespace AMBUS_Master
{
    partial class COMsettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMsettings));
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxSerialBaud = new System.Windows.Forms.ComboBox();
            this.labelSerialBaud = new System.Windows.Forms.Label();
            this.comboBoxSerialName = new System.Windows.Forms.ComboBox();
            this.labelSerialName = new System.Windows.Forms.Label();
            this.buttonStorno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 92);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(138, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboBoxSerialBaud
            // 
            this.comboBoxSerialBaud.FormattingEnabled = true;
            this.comboBoxSerialBaud.Location = new System.Drawing.Point(156, 25);
            this.comboBoxSerialBaud.Name = "comboBoxSerialBaud";
            this.comboBoxSerialBaud.Size = new System.Drawing.Size(138, 21);
            this.comboBoxSerialBaud.TabIndex = 3;
            // 
            // labelSerialBaud
            // 
            this.labelSerialBaud.AutoSize = true;
            this.labelSerialBaud.Location = new System.Drawing.Point(153, 9);
            this.labelSerialBaud.Name = "labelSerialBaud";
            this.labelSerialBaud.Size = new System.Drawing.Size(32, 13);
            this.labelSerialBaud.TabIndex = 2;
            this.labelSerialBaud.Text = "Baud";
            // 
            // comboBoxSerialName
            // 
            this.comboBoxSerialName.FormattingEnabled = true;
            this.comboBoxSerialName.Location = new System.Drawing.Point(12, 25);
            this.comboBoxSerialName.Name = "comboBoxSerialName";
            this.comboBoxSerialName.Size = new System.Drawing.Size(138, 21);
            this.comboBoxSerialName.TabIndex = 1;
            this.comboBoxSerialName.SelectionChangeCommitted += new System.EventHandler(this.refreshCOM);
            // 
            // labelSerialName
            // 
            this.labelSerialName.AutoSize = true;
            this.labelSerialName.Location = new System.Drawing.Point(12, 9);
            this.labelSerialName.Name = "labelSerialName";
            this.labelSerialName.Size = new System.Drawing.Size(35, 13);
            this.labelSerialName.TabIndex = 1;
            this.labelSerialName.Text = "Name";
            // 
            // buttonStorno
            // 
            this.buttonStorno.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStorno.Location = new System.Drawing.Point(156, 92);
            this.buttonStorno.Name = "buttonStorno";
            this.buttonStorno.Size = new System.Drawing.Size(138, 23);
            this.buttonStorno.TabIndex = 4;
            this.buttonStorno.Text = "Storno";
            this.buttonStorno.UseVisualStyleBackColor = true;
            this.buttonStorno.Click += new System.EventHandler(this.buttonStorno_Click);
            // 
            // COMsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonStorno;
            this.ClientSize = new System.Drawing.Size(307, 135);
            this.Controls.Add(this.buttonStorno);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxSerialBaud);
            this.Controls.Add(this.labelSerialName);
            this.Controls.Add(this.labelSerialBaud);
            this.Controls.Add(this.comboBoxSerialName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "COMsettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxSerialBaud;
        private System.Windows.Forms.Label labelSerialBaud;
        private System.Windows.Forms.ComboBox comboBoxSerialName;
        private System.Windows.Forms.Label labelSerialName;
        private System.Windows.Forms.Button buttonStorno;
    }
}