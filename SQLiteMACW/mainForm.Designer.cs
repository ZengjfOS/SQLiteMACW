namespace SQLiteMACW
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.addMAC = new System.Windows.Forms.Button();
            this.macB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.macE = new System.Windows.Forms.TextBox();
            this.print = new System.Windows.Forms.Button();
            this.printer = new System.Drawing.Printing.PrintDocument();
            this.adbCmd = new System.Windows.Forms.Button();
            this.adbcmdShow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backMAC = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.qrcode = new System.Windows.Forms.PictureBox();
            this.macLV = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.currentMAC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.touchType = new System.Windows.Forms.ComboBox();
            this.displayType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.serialNo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrcode)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // addMAC
            // 
            this.addMAC.Location = new System.Drawing.Point(453, 18);
            this.addMAC.Name = "addMAC";
            this.addMAC.Size = new System.Drawing.Size(75, 21);
            this.addMAC.TabIndex = 0;
            this.addMAC.Text = "Add MAC";
            this.addMAC.UseVisualStyleBackColor = true;
            this.addMAC.Click += new System.EventHandler(this.addMACClick);
            // 
            // macB
            // 
            this.macB.Location = new System.Drawing.Point(82, 18);
            this.macB.Name = "macB";
            this.macB.Size = new System.Drawing.Size(119, 21);
            this.macB.TabIndex = 1;
            this.macB.Text = "00:00:00:00:00:00";
            this.macB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAC Begin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "MAC End:";
            // 
            // macE
            // 
            this.macE.Location = new System.Drawing.Point(288, 18);
            this.macE.Name = "macE";
            this.macE.Size = new System.Drawing.Size(119, 21);
            this.macE.TabIndex = 4;
            this.macE.Text = "00:00:00:00:00:00";
            this.macE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(69, 208);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 25);
            this.print.TabIndex = 6;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.printClick);
            // 
            // printer
            // 
            this.printer.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printerPrintPage);
            // 
            // adbCmd
            // 
            this.adbCmd.Location = new System.Drawing.Point(344, 167);
            this.adbCmd.Name = "adbCmd";
            this.adbCmd.Size = new System.Drawing.Size(70, 24);
            this.adbCmd.TabIndex = 7;
            this.adbCmd.Text = "ADB Write";
            this.adbCmd.UseVisualStyleBackColor = true;
            this.adbCmd.Click += new System.EventHandler(this.adbCmdClick);
            // 
            // adbcmdShow
            // 
            this.adbcmdShow.Location = new System.Drawing.Point(10, 20);
            this.adbcmdShow.Multiline = true;
            this.adbcmdShow.Name = "adbcmdShow";
            this.adbcmdShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.adbcmdShow.Size = new System.Drawing.Size(575, 143);
            this.adbcmdShow.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Check Read Back MAC: ";
            // 
            // backMAC
            // 
            this.backMAC.AutoSize = true;
            this.backMAC.Location = new System.Drawing.Point(212, 173);
            this.backMAC.Name = "backMAC";
            this.backMAC.Size = new System.Drawing.Size(107, 12);
            this.backMAC.TabIndex = 10;
            this.backMAC.Text = "00:00:00:00:00:00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.addMAC);
            this.groupBox1.Controls.Add(this.macB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.macE);
            this.groupBox1.Location = new System.Drawing.Point(12, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 45);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add MAC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.status);
            this.groupBox2.Controls.Add(this.adbcmdShow);
            this.groupBox2.Controls.Add(this.adbCmd);
            this.groupBox2.Controls.Add(this.backMAC);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 197);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADB To EEPROM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cleanAdbCmdShowClick);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(433, 173);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(47, 12);
            this.status.TabIndex = 11;
            this.status.Text = "Success";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.qrcode);
            this.groupBox3.Controls.Add(this.print);
            this.groupBox3.Location = new System.Drawing.Point(396, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 242);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MAC QRCode";
            // 
            // qrcode
            // 
            this.qrcode.Image = global::SQLiteMACW.Properties.Resources.aplexosQRCode;
            this.qrcode.InitialImage = null;
            this.qrcode.Location = new System.Drawing.Point(14, 22);
            this.qrcode.Name = "qrcode";
            this.qrcode.Size = new System.Drawing.Size(175, 176);
            this.qrcode.TabIndex = 5;
            this.qrcode.TabStop = false;
            // 
            // macLV
            // 
            this.macLV.GridLines = true;
            this.macLV.Location = new System.Drawing.Point(4, 22);
            this.macLV.Name = "macLV";
            this.macLV.Size = new System.Drawing.Size(378, 175);
            this.macLV.TabIndex = 14;
            this.macLV.UseCompatibleStateImageBehavior = false;
            this.macLV.View = System.Windows.Forms.View.Details;
            this.macLV.SelectedIndexChanged += new System.EventHandler(this.macLV_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.deleteDB);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.currentMAC);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.macLV);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 242);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database";
            // 
            // currentMAC
            // 
            this.currentMAC.AutoSize = true;
            this.currentMAC.Location = new System.Drawing.Point(125, 215);
            this.currentMAC.Name = "currentMAC";
            this.currentMAC.Size = new System.Drawing.Size(107, 12);
            this.currentMAC.TabIndex = 19;
            this.currentMAC.Text = "00:00:00:00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "Current MAC: ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.serialNo);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.displayType);
            this.groupBox5.Controls.Add(this.touchType);
            this.groupBox5.Location = new System.Drawing.Point(12, 315);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(590, 48);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Select Argument";
            // 
            // touchType
            // 
            this.touchType.FormattingEnabled = true;
            this.touchType.Location = new System.Drawing.Point(65, 18);
            this.touchType.Name = "touchType";
            this.touchType.Size = new System.Drawing.Size(49, 20);
            this.touchType.TabIndex = 0;
            // 
            // displayType
            // 
            this.displayType.FormattingEnabled = true;
            this.displayType.Location = new System.Drawing.Point(190, 18);
            this.displayType.Name = "displayType";
            this.displayType.Size = new System.Drawing.Size(69, 20);
            this.displayType.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Touch: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Display:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Serial No.:";
            // 
            // serialNo
            // 
            this.serialNo.Location = new System.Drawing.Point(352, 18);
            this.serialNo.Name = "serialNo";
            this.serialNo.Size = new System.Drawing.Size(62, 21);
            this.serialNo.TabIndex = 2;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 573);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "SQLiteMACW";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrcode)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addMAC;
        private System.Windows.Forms.TextBox macB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox macE;
        private System.Windows.Forms.PictureBox qrcode;
        private System.Windows.Forms.Button print;
        private System.Drawing.Printing.PrintDocument printer;
        private System.Windows.Forms.Button adbCmd;
        private System.Windows.Forms.TextBox adbcmdShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label backMAC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView macLV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label currentMAC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox displayType;
        private System.Windows.Forms.ComboBox touchType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox serialNo;
        private System.Windows.Forms.Label label7;
    }
}

