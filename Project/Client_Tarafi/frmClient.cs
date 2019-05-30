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
using CryptoLibrary;
using System.Configuration;
using System.Security.Cryptography;
using LogHelperLib;

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
        StreamWriter serverWriter;
        BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream());
        StreamReader serverReader;
        frmClientLog log;

        private string m_ImageFilePath;
        private string dataPath = @"C:\";
        string simetricKey = "";
        bool isSecretKey = false;
        private void FrmClient_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.AcceptButton = btnBaglan;
            txtIp.Text = "192.168.2.52"; //"172.20.10.3";
            txtNick.Text = "aksoy";
            cbChoose.SelectedIndex = 0;
            //BtnBaglan_Click(null, null);
        }

        private void BtnBaglan_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;

            //Bağlanılacak Server'in IP'sini ve portu belirlendi.
            istemci = new TcpClient(txtIp.Text, 8082);
            LogWriter(txtIp.Text + " numarali ip adresine bağlanıldı.");
            //Veri alışverişi için NerworkStream tasarlandı.
            ns = istemci.GetStream();
            serverWriter = new StreamWriter(ns, Encoding.ASCII);
            serverReader = new StreamReader(ns, Encoding.ASCII);

            //Server'a bağlanıp network'ü yormamak için buradan nick ile tek bir harf
            //gönderilip server tarafında mesajın tamamı oluşturulabilirdi
            //Server'a ilk mesajı gönderildi.
            serverWriter.WriteLine(txtNick.Text + " isimli kullanici geldi.");
            //LogWriter(txtNick.Text + " isimli kullanici geldi.");

            //StreamWriter temizlendi.
            serverWriter.Flush();

            Thread th = new Thread(ServeriDinle);
            th.Start();
            this.AcceptButton = btnGonderClient;
        }

        void ServeriDinle()
        {
            while (true)
            {
                string serverdanGelenMesaj = serverReader.ReadLine(); // Okunan deger

                if (cbChoose.SelectedIndex == 1)
                {
                    if (!isSecretKey)
                    {
                        isSecretKey = true;
                        label3.Text = Crypto1.DecryptSecretKey(serverdanGelenMesaj);
                        simetricKey = label3.Text;
                        lstMesajlarClient.Items.Add("SecretKey başarılı şekilde alındı.");
                        LogWriter("SecretKey başarılı şekilde alındı.");
                    }
                    else
                    {
                        Crypto1 crypto1 = new Crypto1();
                        MessageBox.Show("Desifrelenecek verinin çozulecegi yolu seciniz.");

                        UnicodeEncoding ue = new UnicodeEncoding();
                        Byte[] buffer = Convert.FromBase64String(serverdanGelenMesaj);
                        byte[] plainText = crypto1.DecryptToByteArray(buffer, simetricKey);

                        //File.WriteAllBytes(@"C:\Users\Hknaksoyy\Desktop\cipherText.jpg", plainText);
                        //linkFilePath_LinkClicked(true);
                        File.WriteAllBytes(dataPath, plainText);
                        lstMesajlarClient.Items.Add("Desifreleme islemi tamamlandi");
                        LogWriter("Desifreleme islemi tamamlandi");
                    }
                }
                else if (cbChoose.SelectedIndex == 2)
                {
                    if (!isSecretKey)
                    {
                        isSecretKey = true;
                        label3.Text = Crypto2.DecryptSecretKey(serverdanGelenMesaj);
                        simetricKey = label3.Text;
                        LogWriter("Serverdan Gelen Mesaj: " + serverdanGelenMesaj);
                        LogWriter("Cozumlenmis Simetrik Sifre: " + simetricKey);
                        lstMesajlarClient.Items.Add("SecretKey başarılı şekilde alındı.");
                        LogWriter("SecretKey başarılı şekilde alındı.");
                    }
                    else
                    {
                        Crypto2 crypto2 = new Crypto2();
                        string decryptoHash = serverdanGelenMesaj.Substring((serverdanGelenMesaj.Length - 64), 64);
                        string data = serverdanGelenMesaj.Substring(0, (serverdanGelenMesaj.Length - 64));
                        if ( decryptoHash == ComputeSha256Hash(data))
                        {
                            lstMesajlarClient.Items.Add("Server: " + crypto2.DecryptKey(data, simetricKey));
                            label3.Text = serverdanGelenMesaj;
                            LogWriter(serverdanGelenMesaj);
                        }               
                    }
                }
                else if (cbChoose.SelectedIndex == 3)
                {
                    Crypto3 crypto3 = new Crypto3();
                    lstMesajlarClient.Items.Add("Server: " + crypto3.Decrypto(serverdanGelenMesaj));
                    label3.Text = serverdanGelenMesaj;
                    LogWriter(serverdanGelenMesaj);
                }
                else
                {
                    lstMesajlarClient.Items.Add("Server: " + serverdanGelenMesaj);
                    LogWriter("Server: " + serverdanGelenMesaj);
                }
            }
        }

        private void BtnGonderClient_Click(object sender, EventArgs e)
        {
            if (cbChoose.SelectedIndex == 1)
            {
                Crypto1 crypto1 = new Crypto1();
                //string key = "asdfgytasdfgytrfghtuytorfghtuyto";

                byte[] acikMetin = File.ReadAllBytes(m_ImageFilePath);
                byte[] sifreliMetin = crypto1.EncryptToByteArray(acikMetin, simetricKey);

                serverWriter.WriteLine(/*"UPLOAD_START_" +*/ Convert.ToBase64String(sifreliMetin) /*+ "_UPLOAD_END"*/);
                serverWriter.Flush();

                lstMesajlarClient.Items.Add("Dosya yolu : " + m_ImageFilePath + " gönderildi.");
                LogWriter("Dosya yolu : " + m_ImageFilePath + " gönderildi.");
            }
            else if (cbChoose.SelectedIndex == 2)
            {
                Crypto2 crypto2 = new Crypto2();

                string enryptoText = crypto2.EncryptKey(txtMesajClient.Text, simetricKey);
                enryptoText += ComputeSha256Hash(enryptoText);

                serverWriter.WriteLine(enryptoText);
                serverWriter.Flush();
                //CLIENT'IN KENDI LISTBOX'INA EKLEME ISLEMI
                lstMesajlarClient.Items.Add(txtNick.Text + ": " + txtMesajClient.Text);
                LogWriter(txtNick.Text + ": " + txtMesajClient.Text);
            }
            else if (cbChoose.SelectedIndex == 3)
            {
                Crypto3 crypto3 = new Crypto3();
                serverWriter.WriteLine(crypto3.Encrypto(txtMesajClient.Text));
                serverWriter.Flush();
                //CLIENT'IN KENDI LISTBOX'INA EKLEME ISLEMI
                lstMesajlarClient.Items.Add(txtNick.Text + ": " + txtMesajClient.Text);
                LogWriter(txtNick.Text + ": " + txtMesajClient.Text);
            }
            else
            {
                serverWriter.WriteLine(txtMesajClient.Text);
                serverWriter.Flush();
                lstMesajlarClient.Items.Add(txtNick.Text + ": " + txtMesajClient.Text);
                LogWriter(txtNick.Text + ": " + txtMesajClient.Text);
            }
            txtMesajClient.Clear();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbChoose.SelectedIndex;
            linkFilePath.Visible = index == 1;
            btOpenDialog.Visible = index == 1;
        }

        private void BtOpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files (*.jpeg)|*.jpg";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                m_ImageFilePath = dialog.FileName;
            }
        }

        private void LinkFilePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "image files (*.jpeg)|*.jpg";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dataPath = Path.GetDirectoryName(dialog.FileName.ToString());
                dataPath += "\\decrypto.jpg"; //m_ImageFilePath = dialog.FileName;
            }
        }

        private void btnLogShow_Click(object sender, EventArgs e)
        {
            log = new frmClientLog();
            log.Show();
        }

        private void LogWriter(string msg)
        {
            LogHelper.LogWrite(msg);
            if (log != null)
                log.writeLog(msg);
        }
    }
}