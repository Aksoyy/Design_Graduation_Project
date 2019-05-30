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

namespace Server_Tarafi
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();

            //form açıkken Enter' a basınca btnGonderServer tıklanacak.
            this.AcceptButton = btnGonderServer;
        }

        TcpListener dinleyici;
        Socket sckKullanici;
        NetworkStream ns;
        StreamWriter yazici;
        StreamReader okuyucu;


        private void frmServer_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //
            dinleyici = new TcpListener(4108);
            dinleyici.Start();


            //dinle metodu içerisinde sonsuz döngü olacağı için bu işlemi thread' e aldık
            Thread th = new Thread(dinle);
            th.Start();
        }


        void dinle()
        {
            //kullanıcı servera bağlandığında, bağlanan kullanıcıyı sckKullanici isimli Socket nesnesine aldık.
            sckKullanici = dinleyici.AcceptSocket();


            //NetworkStream, ağ üzerine yazmak için kullanılır. sckKullanici' ya veri göndereceğiz ve ondan gelen verileri alacağız.
            ns = new NetworkStream(sckKullanici);

            //kullanıcıya mesaj göndermek için StreamWriter içe NetworkStream üzerine yazacağız
            yazici = new StreamWriter(ns);

            //kullanıcıdan gelen mesajları okumak için StreamReader kullanıyoruz.
            okuyucu = new StreamReader(ns);

            //sonsuz döngü
            while (true)
            {
                string clienttanGelenMesaj = okuyucu.ReadLine();
                if (clienttanGelenMesaj != null)
                {
                    lstMesajlarServer.Items.Add(clienttanGelenMesaj);
                }
            }
            //döngü içerisinde sürekli streamReader' ile okuma yaptık, eğer msj null değil ise, client msj gönderdi demektir, gönderilen msji server' daki listBox' a ekledik.

        }

        private void btnGonderServer_Click(object sender, EventArgs e)
        {
            yazici.WriteLine(txtMesajServer.Text);
            
            //stream' i temizledik. daha sonra da msj gönderebileceğimiz için
            yazici.Flush();

            //Mesajı hem client' a göndermek hem de server ekranında göstermemiz lazım bu yüzden gönderilen mesajı serverın kendi listboxına da ekledik
            lstMesajlarServer.Items.Add("Server : " + txtMesajServer.Text);
            txtMesajServer.Clear();
        }
    }
}
