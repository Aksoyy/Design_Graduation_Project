using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client_Tarafi
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        TcpClient istemci;
        NetworkStream ns;
        StreamWriter yaziciClient;
        StreamReader okuyucuClient;

        private void frmClient_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.AcceptButton = btnBaglan;
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;

            //bağlanacağımız server' ın IP' sini ve portunu yazdık.
            istemci = new TcpClient(txtIp.Text, 4108);


            //veri alışverişi için NerworkStream' i oluşturduk.
            ns = istemci.GetStream();

            yaziciClient = new StreamWriter(ns);

            okuyucuClient = new StreamReader(ns);

            //server' a bağlanınca kendi nick' imizi gönderiyoruz. Network' ü yormamak için buradan nick ile tek bir harf gönderilip, server tarafında mesajın tamamı oluşturulabilirdi.
            string ilkMesaj = txtNick.Text + " isimli kullanıcı geldi.";

            //server' a ilk mesajı gönderdik.
            yaziciClient.WriteLine(ilkMesaj);

            //streamWriter' ı temizledik.
            yaziciClient.Flush();


            Thread th = new Thread(serveriDinle);
            th.Start();
            this.AcceptButton = btnGonderClient;
        }

        void serveriDinle()
        {
            while (true)
            {
                string serverdanGelenMesaj = okuyucuClient.ReadLine();
                if (serverdanGelenMesaj != null)
                {
                    lstMesajlarClient.Items.Add("Server : " + serverdanGelenMesaj);
                }
            }
        }

        private void btnGonderClient_Click(object sender, EventArgs e)
        {
            yaziciClient.WriteLine(txtNick.Text + " : " + txtMesajClient.Text);

            yaziciClient.Flush();

            //server' a gönderilen mesajı client' ın kendi ekranındaki listBox' a da ekliyoruz.
            lstMesajlarClient.Items.Add("Ben : " + txtMesajClient.Text);
            txtMesajClient.Clear();
        }
    }
}
