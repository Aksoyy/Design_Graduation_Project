namespace Server_Tarafi
{
    partial class frmServer
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.linkFilePath = new System.Windows.Forms.LinkLabel();
            this.KeyGonder = new System.Windows.Forms.Button();
            this.btOpenDialog = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGonderServer = new System.Windows.Forms.Button();
            this.txtMesajServer = new System.Windows.Forms.TextBox();
            this.lstMesajlarServer = new System.Windows.Forms.ListBox();
            this.btnLogShow = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogShow);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.linkFilePath);
            this.panel2.Controls.Add(this.KeyGonder);
            this.panel2.Controls.Add(this.btOpenDialog);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGonderServer);
            this.panel2.Controls.Add(this.txtMesajServer);
            this.panel2.Controls.Add(this.lstMesajlarServer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 396);
            this.panel2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(446, 207);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 14;
            // 
            // linkFilePath
            // 
            this.linkFilePath.AutoSize = true;
            this.linkFilePath.Location = new System.Drawing.Point(454, 44);
            this.linkFilePath.Name = "linkFilePath";
            this.linkFilePath.Size = new System.Drawing.Size(59, 13);
            this.linkFilePath.TabIndex = 13;
            this.linkFilePath.TabStop = true;
            this.linkFilePath.Text = "Dosya yolu";
            this.linkFilePath.Visible = false;
            this.linkFilePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFilePath_LinkClicked);
            // 
            // KeyGonder
            // 
            this.KeyGonder.Location = new System.Drawing.Point(445, 233);
            this.KeyGonder.Name = "KeyGonder";
            this.KeyGonder.Size = new System.Drawing.Size(165, 23);
            this.KeyGonder.TabIndex = 12;
            this.KeyGonder.Text = "KeyGonder";
            this.KeyGonder.UseVisualStyleBackColor = true;
            this.KeyGonder.Click += new System.EventHandler(this.KeyGonder_Click);
            // 
            // btOpenDialog
            // 
            this.btOpenDialog.Location = new System.Drawing.Point(535, 39);
            this.btOpenDialog.Name = "btOpenDialog";
            this.btOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.btOpenDialog.TabIndex = 11;
            this.btOpenDialog.Text = "Dosya Seç";
            this.btOpenDialog.UseVisualStyleBackColor = true;
            this.btOpenDialog.Visible = false;
            this.btOpenDialog.Click += new System.EventHandler(this.BtOpenDialog_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PlainText",
            "Crypto1",
            "Crypto2",
            "Crypto3"});
            this.comboBox1.Location = new System.Drawing.Point(445, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "Şifreleme Yöntemi Seçiniz";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gelen Mesaj: ";
            // 
            // btnGonderServer
            // 
            this.btnGonderServer.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonderServer.Location = new System.Drawing.Point(445, 262);
            this.btnGonderServer.Name = "btnGonderServer";
            this.btnGonderServer.Size = new System.Drawing.Size(165, 94);
            this.btnGonderServer.TabIndex = 2;
            this.btnGonderServer.Text = "Gönder";
            this.btnGonderServer.UseVisualStyleBackColor = true;
            this.btnGonderServer.Click += new System.EventHandler(this.BtnGonderServer_Click);
            // 
            // txtMesajServer
            // 
            this.txtMesajServer.Location = new System.Drawing.Point(13, 335);
            this.txtMesajServer.Name = "txtMesajServer";
            this.txtMesajServer.Size = new System.Drawing.Size(426, 20);
            this.txtMesajServer.TabIndex = 1;
            // 
            // lstMesajlarServer
            // 
            this.lstMesajlarServer.FormattingEnabled = true;
            this.lstMesajlarServer.Location = new System.Drawing.Point(12, 12);
            this.lstMesajlarServer.Name = "lstMesajlarServer";
            this.lstMesajlarServer.Size = new System.Drawing.Size(427, 316);
            this.lstMesajlarServer.TabIndex = 0;
            // 
            // btnLogShow
            // 
            this.btnLogShow.Location = new System.Drawing.Point(445, 361);
            this.btnLogShow.Name = "btnLogShow";
            this.btnLogShow.Size = new System.Drawing.Size(165, 23);
            this.btnLogShow.TabIndex = 15;
            this.btnLogShow.Text = "Log göster";
            this.btnLogShow.UseVisualStyleBackColor = true;
            this.btnLogShow.Click += new System.EventHandler(this.btnLogShow_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(622, 396);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(638, 435);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(638, 435);
            this.Name = "frmServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstMesajlarServer;
        private System.Windows.Forms.Button btnGonderServer;
        private System.Windows.Forms.TextBox txtMesajServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btOpenDialog;
        private System.Windows.Forms.Button KeyGonder;
        private System.Windows.Forms.LinkLabel linkFilePath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLogShow;
    }
}

