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
            this.lstMesajlarServer = new System.Windows.Forms.ListBox();
            this.txtMesajServer = new System.Windows.Forms.TextBox();
            this.btnGonderServer = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGonderServer);
            this.panel2.Controls.Add(this.txtMesajServer);
            this.panel2.Controls.Add(this.lstMesajlarServer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 367);
            this.panel2.TabIndex = 1;
            // 
            // lstMesajlarServer
            // 
            this.lstMesajlarServer.FormattingEnabled = true;
            this.lstMesajlarServer.Location = new System.Drawing.Point(12, 12);
            this.lstMesajlarServer.Name = "lstMesajlarServer";
            this.lstMesajlarServer.Size = new System.Drawing.Size(598, 316);
            this.lstMesajlarServer.TabIndex = 0;
            // 
            // txtMesajServer
            // 
            this.txtMesajServer.Location = new System.Drawing.Point(13, 335);
            this.txtMesajServer.Name = "txtMesajServer";
            this.txtMesajServer.Size = new System.Drawing.Size(506, 20);
            this.txtMesajServer.TabIndex = 1;
            // 
            // btnGonderServer
            // 
            this.btnGonderServer.Location = new System.Drawing.Point(535, 333);
            this.btnGonderServer.Name = "btnGonderServer";
            this.btnGonderServer.Size = new System.Drawing.Size(75, 23);
            this.btnGonderServer.TabIndex = 2;
            this.btnGonderServer.Text = "Gönder";
            this.btnGonderServer.UseVisualStyleBackColor = true;
            this.btnGonderServer.Click += new System.EventHandler(this.btnGonderServer_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(622, 367);
            this.Controls.Add(this.panel2);
            this.Name = "frmServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstMesajlarServer;
        private System.Windows.Forms.Button btnGonderServer;
        private System.Windows.Forms.TextBox txtMesajServer;
    }
}

