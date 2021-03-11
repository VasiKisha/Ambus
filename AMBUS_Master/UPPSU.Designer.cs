//Copyright (c) 2020 VasiKisha
//All rights reserved.

//This source code is licensed under the MIT-style license found in the
//LICENSE file in the root directory of this source tree. 

namespace AMBUS_Master
{
    partial class UPPSU
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelReadV = new System.Windows.Forms.Label();
            this.labelReadC = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelCC = new System.Windows.Forms.Label();
            this.labelCV = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownSetC = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSetV = new System.Windows.Forms.NumericUpDown();
            this.labelSetC = new System.Windows.Forms.Label();
            this.labelSetV = new System.Windows.Forms.Label();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownCalIO = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalIG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalVO = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalVG = new System.Windows.Forms.NumericUpDown();
            this.buttonCalReload = new System.Windows.Forms.Button();
            this.buttonCalSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelFw = new System.Windows.Forms.Label();
            this.labelHwSwitch = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSetC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSetV)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalIG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalVO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalVG)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(746, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(21, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 29);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Universal Programmable Power Supply Unit";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(4, 48);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(45, 13);
            this.labelAddress.TabIndex = 3;
            this.labelAddress.Text = "Address";
            // 
            // labelReadV
            // 
            this.labelReadV.AutoSize = true;
            this.labelReadV.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelReadV.Location = new System.Drawing.Point(6, 23);
            this.labelReadV.Name = "labelReadV";
            this.labelReadV.Size = new System.Drawing.Size(131, 42);
            this.labelReadV.TabIndex = 4;
            this.labelReadV.Text = "----.----V";
            // 
            // labelReadC
            // 
            this.labelReadC.AutoSize = true;
            this.labelReadC.Font = new System.Drawing.Font("Arial Black", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelReadC.Location = new System.Drawing.Point(137, 23);
            this.labelReadC.Name = "labelReadC";
            this.labelReadC.Size = new System.Drawing.Size(111, 42);
            this.labelReadC.TabIndex = 5;
            this.labelReadC.Text = "--.----A";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 486);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelOutput);
            this.groupBox1.Controls.Add(this.labelCC);
            this.groupBox1.Controls.Add(this.labelCV);
            this.groupBox1.Controls.Add(this.labelReadV);
            this.groupBox1.Controls.Add(this.labelReadC);
            this.groupBox1.Location = new System.Drawing.Point(9, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 71);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // labelOutput
            // 
            this.labelOutput.BackColor = System.Drawing.Color.White;
            this.labelOutput.ForeColor = System.Drawing.Color.Gray;
            this.labelOutput.Location = new System.Drawing.Point(297, 19);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(76, 46);
            this.labelOutput.TabIndex = 8;
            this.labelOutput.Text = "Output State";
            this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCC
            // 
            this.labelCC.AutoSize = true;
            this.labelCC.BackColor = System.Drawing.Color.White;
            this.labelCC.ForeColor = System.Drawing.Color.Gray;
            this.labelCC.Location = new System.Drawing.Point(270, 48);
            this.labelCC.Name = "labelCC";
            this.labelCC.Size = new System.Drawing.Size(21, 13);
            this.labelCC.TabIndex = 7;
            this.labelCC.Text = "CC";
            // 
            // labelCV
            // 
            this.labelCV.AutoSize = true;
            this.labelCV.BackColor = System.Drawing.Color.White;
            this.labelCV.ForeColor = System.Drawing.Color.Gray;
            this.labelCV.Location = new System.Drawing.Point(270, 26);
            this.labelCV.Name = "labelCV";
            this.labelCV.Size = new System.Drawing.Size(21, 13);
            this.labelCV.TabIndex = 6;
            this.labelCV.Text = "CV";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownSetC);
            this.groupBox2.Controls.Add(this.numericUpDownSetV);
            this.groupBox2.Controls.Add(this.labelSetC);
            this.groupBox2.Controls.Add(this.labelSetV);
            this.groupBox2.Controls.Add(this.buttonEnable);
            this.groupBox2.Location = new System.Drawing.Point(394, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 71);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // numericUpDownSetC
            // 
            this.numericUpDownSetC.DecimalPlaces = 2;
            this.numericUpDownSetC.Enabled = false;
            this.numericUpDownSetC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSetC.Location = new System.Drawing.Point(109, 46);
            this.numericUpDownSetC.Name = "numericUpDownSetC";
            this.numericUpDownSetC.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownSetC.TabIndex = 11;
            this.numericUpDownSetC.Click += new System.EventHandler(this.numericUpDownSetC_Click);
            this.numericUpDownSetC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownSetC_KeyUp);
            // 
            // numericUpDownSetV
            // 
            this.numericUpDownSetV.DecimalPlaces = 2;
            this.numericUpDownSetV.Enabled = false;
            this.numericUpDownSetV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSetV.Location = new System.Drawing.Point(109, 19);
            this.numericUpDownSetV.Name = "numericUpDownSetV";
            this.numericUpDownSetV.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownSetV.TabIndex = 10;
            this.numericUpDownSetV.Click += new System.EventHandler(this.numericUpDownSetV_Click);
            this.numericUpDownSetV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownSetV_KeyUp);
            // 
            // labelSetC
            // 
            this.labelSetC.AutoSize = true;
            this.labelSetC.Location = new System.Drawing.Point(8, 48);
            this.labelSetC.Name = "labelSetC";
            this.labelSetC.Size = new System.Drawing.Size(41, 13);
            this.labelSetC.TabIndex = 4;
            this.labelSetC.Text = "Current";
            // 
            // labelSetV
            // 
            this.labelSetV.AutoSize = true;
            this.labelSetV.Location = new System.Drawing.Point(6, 22);
            this.labelSetV.Name = "labelSetV";
            this.labelSetV.Size = new System.Drawing.Size(43, 13);
            this.labelSetV.TabIndex = 3;
            this.labelSetV.Text = "Voltage";
            // 
            // buttonEnable
            // 
            this.buttonEnable.Enabled = false;
            this.buttonEnable.Location = new System.Drawing.Point(285, 19);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(88, 46);
            this.buttonEnable.TabIndex = 2;
            this.buttonEnable.Text = "Enable";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownCalIO);
            this.groupBox3.Controls.Add(this.numericUpDownCalIG);
            this.groupBox3.Controls.Add(this.numericUpDownCalVO);
            this.groupBox3.Controls.Add(this.numericUpDownCalVG);
            this.groupBox3.Controls.Add(this.buttonCalReload);
            this.groupBox3.Controls.Add(this.buttonCalSave);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 100);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calibration";
            // 
            // numericUpDownCalIO
            // 
            this.numericUpDownCalIO.Enabled = false;
            this.numericUpDownCalIO.Location = new System.Drawing.Point(278, 45);
            this.numericUpDownCalIO.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownCalIO.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            -2147483648});
            this.numericUpDownCalIO.Name = "numericUpDownCalIO";
            this.numericUpDownCalIO.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownCalIO.TabIndex = 16;
            this.numericUpDownCalIO.Click += new System.EventHandler(this.numericUpDownCalIO_Click);
            this.numericUpDownCalIO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownCalIO_KeyUp);
            // 
            // numericUpDownCalIG
            // 
            this.numericUpDownCalIG.DecimalPlaces = 2;
            this.numericUpDownCalIG.Enabled = false;
            this.numericUpDownCalIG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownCalIG.Location = new System.Drawing.Point(278, 19);
            this.numericUpDownCalIG.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCalIG.Name = "numericUpDownCalIG";
            this.numericUpDownCalIG.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownCalIG.TabIndex = 15;
            this.numericUpDownCalIG.Click += new System.EventHandler(this.numericUpDownCalIG_Click);
            this.numericUpDownCalIG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownCalIG_KeyUp);
            // 
            // numericUpDownCalVO
            // 
            this.numericUpDownCalVO.Enabled = false;
            this.numericUpDownCalVO.Location = new System.Drawing.Point(86, 45);
            this.numericUpDownCalVO.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownCalVO.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            -2147483648});
            this.numericUpDownCalVO.Name = "numericUpDownCalVO";
            this.numericUpDownCalVO.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownCalVO.TabIndex = 14;
            this.numericUpDownCalVO.Click += new System.EventHandler(this.numericUpDownCalVO_Click);
            this.numericUpDownCalVO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownCalVO_KeyUp);
            // 
            // numericUpDownCalVG
            // 
            this.numericUpDownCalVG.DecimalPlaces = 2;
            this.numericUpDownCalVG.Enabled = false;
            this.numericUpDownCalVG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownCalVG.Location = new System.Drawing.Point(86, 19);
            this.numericUpDownCalVG.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCalVG.Name = "numericUpDownCalVG";
            this.numericUpDownCalVG.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownCalVG.TabIndex = 13;
            this.numericUpDownCalVG.Click += new System.EventHandler(this.numericUpDownCalVG_Click);
            this.numericUpDownCalVG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownCalVG_KeyUp);
            // 
            // buttonCalReload
            // 
            this.buttonCalReload.Enabled = false;
            this.buttonCalReload.Location = new System.Drawing.Point(193, 71);
            this.buttonCalReload.Name = "buttonCalReload";
            this.buttonCalReload.Size = new System.Drawing.Size(180, 23);
            this.buttonCalReload.TabIndex = 9;
            this.buttonCalReload.Tag = "";
            this.buttonCalReload.Text = "Reload";
            this.buttonCalReload.UseVisualStyleBackColor = true;
            this.buttonCalReload.Click += new System.EventHandler(this.buttonCalReload_Click);
            // 
            // buttonCalSave
            // 
            this.buttonCalSave.Enabled = false;
            this.buttonCalSave.Location = new System.Drawing.Point(6, 71);
            this.buttonCalSave.Name = "buttonCalSave";
            this.buttonCalSave.Size = new System.Drawing.Size(180, 23);
            this.buttonCalSave.TabIndex = 8;
            this.buttonCalSave.Text = "Save";
            this.buttonCalSave.UseVisualStyleBackColor = true;
            this.buttonCalSave.Click += new System.EventHandler(this.buttonCalSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(200, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Current Offset";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Current Gain";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Voltage Offset";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Voltage Gain";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxAddress);
            this.groupBox4.Controls.Add(this.buttonStart);
            this.groupBox4.Controls.Add(this.labelFw);
            this.groupBox4.Controls.Add(this.labelHwSwitch);
            this.groupBox4.Controls.Add(this.labelAddress);
            this.groupBox4.Location = new System.Drawing.Point(394, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(379, 100);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Properties";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(55, 45);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddress.TabIndex = 7;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 71);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(149, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelFw
            // 
            this.labelFw.AutoSize = true;
            this.labelFw.Location = new System.Drawing.Point(253, 84);
            this.labelFw.Name = "labelFw";
            this.labelFw.Size = new System.Drawing.Size(90, 13);
            this.labelFw.TabIndex = 5;
            this.labelFw.Text = "Firmware Version:";
            // 
            // labelHwSwitch
            // 
            this.labelHwSwitch.BackColor = System.Drawing.Color.White;
            this.labelHwSwitch.ForeColor = System.Drawing.Color.Gray;
            this.labelHwSwitch.Location = new System.Drawing.Point(6, 19);
            this.labelHwSwitch.Name = "labelHwSwitch";
            this.labelHwSwitch.Size = new System.Drawing.Size(149, 20);
            this.labelHwSwitch.TabIndex = 4;
            this.labelHwSwitch.Text = "HW Switch State";
            this.labelHwSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UPPSU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "UPPSU";
            this.Size = new System.Drawing.Size(776, 486);
            this.Load += new System.EventHandler(this.UPPSU_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSetC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSetV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalIG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalVO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalVG)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelReadV;
        private System.Windows.Forms.Label labelReadC;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelCC;
        private System.Windows.Forms.Label labelCV;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelSetC;
        private System.Windows.Forms.Label labelSetV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCalReload;
        private System.Windows.Forms.Button buttonCalSave;
        private System.Windows.Forms.Label labelFw;
        private System.Windows.Forms.Label labelHwSwitch;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericUpDownCalIO;
        private System.Windows.Forms.NumericUpDown numericUpDownCalIG;
        private System.Windows.Forms.NumericUpDown numericUpDownCalVO;
        private System.Windows.Forms.NumericUpDown numericUpDownCalVG;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.NumericUpDown numericUpDownSetV;
        private System.Windows.Forms.NumericUpDown numericUpDownSetC;
    }
}
