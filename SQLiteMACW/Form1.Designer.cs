namespace SQLiteMACW
{
    partial class Form1
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
            this.addMAC = new System.Windows.Forms.Button();
            this.macB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.macE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addMAC
            // 
            this.addMAC.Location = new System.Drawing.Point(200, 21);
            this.addMAC.Name = "addMAC";
            this.addMAC.Size = new System.Drawing.Size(75, 50);
            this.addMAC.TabIndex = 0;
            this.addMAC.Text = "Add MAC";
            this.addMAC.UseVisualStyleBackColor = true;
            this.addMAC.Click += new System.EventHandler(this.addMACClick);
            // 
            // macB
            // 
            this.macB.Location = new System.Drawing.Point(75, 21);
            this.macB.Name = "macB";
            this.macB.Size = new System.Drawing.Size(119, 21);
            this.macB.TabIndex = 1;
            this.macB.Text = "00:00:00:00:00:00";
            this.macB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAC Begin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "MAC End:";
            // 
            // macE
            // 
            this.macE.Location = new System.Drawing.Point(75, 50);
            this.macE.Name = "macE";
            this.macE.Size = new System.Drawing.Size(119, 21);
            this.macE.TabIndex = 4;
            this.macE.Text = "00:00:00:00:00:00";
            this.macE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 96);
            this.Controls.Add(this.macE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.macB);
            this.Controls.Add(this.addMAC);
            this.Name = "Form1";
            this.Text = "SQLiteMACW";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addMAC;
        private System.Windows.Forms.TextBox macB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox macE;
    }
}

