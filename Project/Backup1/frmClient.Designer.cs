namespace Client_Tarafi
{
    partial class frmClient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGonderClient = new System.Windows.Forms.Button();
            this.txtMesajClient = new System.Windows.Forms.TextBox();
            this.lstMesajlarClient = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBaglan);
            this.panel1.Controls.Add(this.txtNick);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 75);
            this.panel1.TabIndex = 0;
            // 
            // btnBaglan
            // 
            this.btnBaglan.Location = new System.Drawing.Point(239, 6);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(75, 52);
            this.btnBaglan.TabIndex = 4;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(85, 38);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(133, 20);
            this.txtNick.TabIndex = 3;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(85, 6);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(133, 20);
            this.txtIp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nick : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Adresi : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGonderClient);
            this.panel2.Controls.Add(this.txtMesajClient);
            this.panel2.Controls.Add(this.lstMesajlarClient);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 308);
            this.panel2.TabIndex = 1;
            // 
            // btnGonderClient
            // 
            this.btnGonderClient.Location = new System.Drawing.Point(535, 275);
            this.btnGonderClient.Name = "btnGonderClient";
            this.btnGonderClient.Size = new System.Drawing.Size(75, 23);
            this.btnGonderClient.TabIndex = 5;
            this.btnGonderClient.Text = "Gönder";
            this.btnGonderClient.UseVisualStyleBackColor = true;
            this.btnGonderClient.Click += new System.EventHandler(this.btnGonderClient_Click);
            // 
            // txtMesajClient
            // 
            this.txtMesajClient.Location = new System.Drawing.Point(13, 277);
            this.txtMesajClient.Name = "txtMesajClient";
            this.txtMesajClient.Size = new System.Drawing.Size(506, 20);
            this.txtMesajClient.TabIndex = 4;
            // 
            // lstMesajlarClient
            // 
            this.lstMesajlarClient.FormattingEnabled = true;
            this.lstMesajlarClient.Location = new System.Drawing.Point(12, 6);
            this.lstMesajlarClient.Name = "lstMesajlarClient";
            this.lstMesajlarClient.Size = new System.Drawing.Size(598, 264);
            this.lstMesajlarClient.TabIndex = 3;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(619, 383);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmClient";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGonderClient;
        private System.Windows.Forms.TextBox txtMesajClient;
        private System.Windows.Forms.ListBox lstMesajlarClient;
    }
}

