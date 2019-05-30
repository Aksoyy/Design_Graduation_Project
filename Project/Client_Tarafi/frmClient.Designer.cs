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
            this.linkFilePath = new System.Windows.Forms.LinkLabel();
            this.btOpenDialog = new System.Windows.Forms.Button();
            this.cbChoose = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGonderClient = new System.Windows.Forms.Button();
            this.txtMesajClient = new System.Windows.Forms.TextBox();
            this.lstMesajlarClient = new System.Windows.Forms.ListBox();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLogShow = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(622, 75);
            this.panel1.TabIndex = 0;
            // 
            // btnBaglan
            // 
            this.btnBaglan.Location = new System.Drawing.Point(224, 6);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(83, 52);
            this.btnBaglan.TabIndex = 4;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.BtnBaglan_Click);
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
            this.panel2.Controls.Add(this.btnLogShow);
            this.panel2.Controls.Add(this.linkFilePath);
            this.panel2.Controls.Add(this.btOpenDialog);
            this.panel2.Controls.Add(this.cbChoose);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnGonderClient);
            this.panel2.Controls.Add(this.txtMesajClient);
            this.panel2.Controls.Add(this.lstMesajlarClient);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 336);
            this.panel2.TabIndex = 1;
            // 
            // linkFilePath
            // 
            this.linkFilePath.AutoSize = true;
            this.linkFilePath.Location = new System.Drawing.Point(458, 38);
            this.linkFilePath.Name = "linkFilePath";
            this.linkFilePath.Size = new System.Drawing.Size(59, 13);
            this.linkFilePath.TabIndex = 11;
            this.linkFilePath.TabStop = true;
            this.linkFilePath.Text = "Dosya yolu";
            this.linkFilePath.Visible = false;
            this.linkFilePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFilePath_LinkClicked);
            // 
            // btOpenDialog
            // 
            this.btOpenDialog.Location = new System.Drawing.Point(523, 33);
            this.btOpenDialog.Name = "btOpenDialog";
            this.btOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.btOpenDialog.TabIndex = 10;
            this.btOpenDialog.Text = "Dosya Seç";
            this.btOpenDialog.UseVisualStyleBackColor = true;
            this.btOpenDialog.Visible = false;
            this.btOpenDialog.Click += new System.EventHandler(this.BtOpenDialog_Click);
            // 
            // cbChoose
            // 
            this.cbChoose.FormattingEnabled = true;
            this.cbChoose.Items.AddRange(new object[] {
            "PlainText",
            "Crypto1",
            "Crypto2",
            "Crypto3"});
            this.cbChoose.Location = new System.Drawing.Point(457, 6);
            this.cbChoose.Name = "cbChoose";
            this.cbChoose.Size = new System.Drawing.Size(153, 21);
            this.cbChoose.TabIndex = 5;
            this.cbChoose.Text = "Şifreleme Yöntemi Seçiniz";
            this.cbChoose.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(9, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gelen Mesaj: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // btnGonderClient
            // 
            this.btnGonderClient.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonderClient.Location = new System.Drawing.Point(457, 194);
            this.btnGonderClient.Name = "btnGonderClient";
            this.btnGonderClient.Size = new System.Drawing.Size(153, 103);
            this.btnGonderClient.TabIndex = 5;
            this.btnGonderClient.Text = "Gönder";
            this.btnGonderClient.UseVisualStyleBackColor = true;
            this.btnGonderClient.Click += new System.EventHandler(this.BtnGonderClient_Click);
            // 
            // txtMesajClient
            // 
            this.txtMesajClient.Location = new System.Drawing.Point(13, 277);
            this.txtMesajClient.Name = "txtMesajClient";
            this.txtMesajClient.Size = new System.Drawing.Size(438, 20);
            this.txtMesajClient.TabIndex = 4;
            // 
            // lstMesajlarClient
            // 
            this.lstMesajlarClient.FormattingEnabled = true;
            this.lstMesajlarClient.Location = new System.Drawing.Point(12, 6);
            this.lstMesajlarClient.Name = "lstMesajlarClient";
            this.lstMesajlarClient.Size = new System.Drawing.Size(439, 264);
            this.lstMesajlarClient.TabIndex = 3;
            // 
            // ofDialog
            // 
            this.ofDialog.FileName = "openFileDialog1";
            // 
            // btnLogShow
            // 
            this.btnLogShow.Location = new System.Drawing.Point(457, 303);
            this.btnLogShow.Name = "btnLogShow";
            this.btnLogShow.Size = new System.Drawing.Size(153, 23);
            this.btnLogShow.TabIndex = 12;
            this.btnLogShow.Text = "Log göster";
            this.btnLogShow.UseVisualStyleBackColor = true;
            this.btnLogShow.Click += new System.EventHandler(this.btnLogShow_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(622, 411);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(638, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(638, 450);
            this.Name = "frmClient";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.FrmClient_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbChoose;
        private System.Windows.Forms.LinkLabel linkFilePath;
        private System.Windows.Forms.Button btOpenDialog;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.Button btnLogShow;
    }
}

