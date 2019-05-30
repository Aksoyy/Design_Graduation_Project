using CryptoLibrary;
using LogHelperLib;
using System;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server_Tarafi
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent(); 
            // Form açıkken enter'a basınca verinin gonderilmesidir.
            this.AcceptButton = btnGonderServer;
        }

        TcpListener dinleyici;
        Socket sckKullanici;
        NetworkStream ns;
        StreamWriter clientWriter;
        BinaryReader binaryReader = new BinaryReader(new MemoryStream());
        private StreamReader clientReader;
        frmServerLog log;

        private byte[] m_CipherByteArray;
        private string m_ImageFilePath, dataPath;
        private string connectName;
        string simetricKey = "";
        bool isSecretKey = false;

        private void FrmServer_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; //cbChoose.SelectedIndex = 0;
            CheckForIllegalCrossThreadCalls = false;

            dinleyici = new TcpListener(8082);
            dinleyici.Start();

            // Dinle metodu içerisinde sonsuz döngü olacağı için bu işlemi thread'e alındı.
            Thread th = new Thread(Dinle);
            th.Start();
        }

        void Dinle()
        {
            // Bağlanan kullanıcı sckKullanici isimli Socket nesnesine alındı.
            sckKullanici = dinleyici.AcceptSocket();
            LogWriter("Kullanıcı geldi");

            // NetworkStream, ağ üzerine yazmak için kullanılır. 
            ns = new NetworkStream(sckKullanici);

            // Kullanıcıya mesaj göndermek ve almak için StreamWriter içe NetworkStream üzerine yazacağız.
            clientWriter = new StreamWriter(ns, Encoding.ASCII);
            clientReader = new StreamReader(ns, Encoding.ASCII);

            while (true)
            {
                string clienttanGelenMesaj = clientReader.ReadLine();

                if (comboBox1.SelectedIndex == 1)
                {
                    Crypto1 crypto1 = new Crypto1();

                    UnicodeEncoding ue = new UnicodeEncoding();
                    Byte[] buffer = Convert.FromBase64String(clienttanGelenMesaj);

                    byte[] plainText = crypto1.DecryptToByteArray(buffer, simetricKey);

                    File.WriteAllBytes(dataPath, plainText);
                    lstMesajlarServer.Items.Add("Desifreleme islemi tamamlandi");
                    LogWriter("Desifreleme islemi tamamlandi");

                    //File.WriteAllBytes(@"C:\Users\Hknaksoyy\Desktop\cipherText.jpg", plainText);
                    //LinkLabelLinkClickedEventArgs ex = new LinkLabelLinkClickedEventArgs();
                    //LinkFilePath_LinkClicked = true;
                    //this.LinkFilePath_LinkClicked += this.LinkFilePath_LinkClicked;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (!string.IsNullOrEmpty(clienttanGelenMesaj))
                    {
                        Crypto2 crypto2 = new Crypto2();
                        string decryptoHash = clienttanGelenMesaj.Substring((clienttanGelenMesaj.Length - 64), 64);
                        string data = clienttanGelenMesaj.Substring(0, (clienttanGelenMesaj.Length - 64));
                        if ( ComputeSha256Hash(data) == decryptoHash )
                        {
                            lstMesajlarServer.Items.Add(connectName + ": " + crypto2.DecryptKey(data, simetricKey));
                            label2.Text = clienttanGelenMesaj;
                            LogWriter(clienttanGelenMesaj);
                        }
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Crypto3 crypto3 = new Crypto3();
                    lstMesajlarServer.Items.Add(connectName + ": " + crypto3.Decrypto(clienttanGelenMesaj));
                    label2.Text = clienttanGelenMesaj;
                    LogWriter(clienttanGelenMesaj);
                }
                // Acik metin şeklinde iletimi saglar.
                else
                {
                    if (clienttanGelenMesaj.EndsWith(" isimli kullanici geldi."))
                    {
                        // Gelen kullanıcının tanımlanmasıdır.
                        Console.WriteLine(clienttanGelenMesaj);
                        connectName = clienttanGelenMesaj.Substring(0, clienttanGelenMesaj.Length - 24);
                        lstMesajlarServer.Items.Add(clienttanGelenMesaj);
                        LogWriter(clienttanGelenMesaj);
                    }
                    else
                    {
                        lstMesajlarServer.Items.Add(connectName + ": " + clienttanGelenMesaj);
                        LogWriter(connectName + ": " + clienttanGelenMesaj);
                    }
                }
            }
        }
   
        private void BtnGonderServer_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            { 
                if (!isSecretKey && !string.IsNullOrEmpty(txtMesajServer.Text))
                {
                    string publicKeyXML = String.Format(@"<RSAKeyValue>
                                                               <Modulus>{0}</Modulus>
                                                               <Exponent>{1}</Exponent>
                                                            </RSAKeyValue>",
                                                            ConfigurationSettings.AppSettings.Get("Modulus"),
                                                            ConfigurationSettings.AppSettings.Get("Exponent"));

                    string encryptSecretKey = Crypto2.EncryptSecretKey(txtMesajServer.Text, publicKeyXML);
                    LogWriter("Sifrelenecek Mesaj : " + txtMesajServer.Text);
                    LogWriter("Sifrelenmis Gizli Anahtar : " + encryptSecretKey);
                    clientWriter.WriteLine(encryptSecretKey);
                    clientWriter.Flush();
                    isSecretKey = true;
                }
                else
                {
                    Crypto1 crypto1 = new Crypto1();
                    byte[] acikMetin = File.ReadAllBytes(m_ImageFilePath);
                    byte[] sifreliMetin = crypto1.EncryptToByteArray(acikMetin, simetricKey);

                    clientWriter.WriteLine(/*"UPLOAD_START_" +*/ Convert.ToBase64String(sifreliMetin) /*+ "_UPLOAD_END"*/);
                    clientWriter.Flush();

                    lstMesajlarServer.Items.Add("Dosya yolu : " + m_ImageFilePath + " gönderildi.");
                    LogWriter("Dosya yolu : " + m_ImageFilePath + " gönderildi.");
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                //Gizli anahtarın paylaşımını sağlar.
                if (!isSecretKey && !string.IsNullOrEmpty(txtMesajServer.Text))
                {
                    string publicKeyXML = String.Format(@"<RSAKeyValue>
                                                               <Modulus>{0}</Modulus>
                                                               <Exponent>{1}</Exponent>
                                                            </RSAKeyValue>",
                                                            ConfigurationSettings.AppSettings.Get("Modulus"),
                                                            ConfigurationSettings.AppSettings.Get("Exponent"));
                    
                    string encryptSecretKey = Crypto2.EncryptSecretKey(txtMesajServer.Text, publicKeyXML);
                    LogWriter("Sifrelenecek Mesaj : " + txtMesajServer.Text);
                    LogWriter("Sifrelenmis Gizli Anahtar : " + encryptSecretKey);
                    clientWriter.WriteLine(encryptSecretKey);
                    clientWriter.Flush();
                    simetricKey = txtMesajServer.Text;
                    isSecretKey = true;
                }
                else
                {
                    Crypto2 crypto2 = new Crypto2();
                    string encrypted = crypto2.EncryptKey(txtMesajServer.Text,simetricKey);
                    //GONDERILEN KISIM
                    string encryptedHash = encrypted;
                    encryptedHash += ComputeSha256Hash(encrypted);
                    clientWriter.WriteLine(encryptedHash);
                    clientWriter.Flush();
                    //SERVER'IN KENDI LISTBOX'INA EKLEME ISLEMI
                    lstMesajlarServer.Items.Add("Server: " + txtMesajServer.Text);
                    LogWriter("Server: " + txtMesajServer.Text);
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Crypto3 crypto3 = new Crypto3();
                string encrypted = crypto3.Encrypto(txtMesajServer.Text);
                //GONDERILEN KISIM
                clientWriter.WriteLine(encrypted);
                clientWriter.Flush();
                //SERVER'IN KENDI LISTBOX'INA EKLEME ISLEMI
                lstMesajlarServer.Items.Add("Server: " + txtMesajServer.Text);
                LogWriter("Server: " + txtMesajServer.Text);
            }
            else
            {
                clientWriter.WriteLine(txtMesajServer.Text);
                clientWriter.Flush();
                lstMesajlarServer.Items.Add("Server: " + txtMesajServer.Text);
                LogWriter("Server: " + txtMesajServer.Text);

            }
            //GONDERIM ISLEMINDEN SONRA TEXT BOLGESI TEMIZLENIR.
            txtMesajServer.Clear();
        }
   
        //Kullanıcının şifrelenecek yolu seçtiği kısımdır.
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
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index == 1 || index == 2)
            { 
                if (!isSecretKey)
                {
                    lstMesajlarServer.Items.Add("İletisim İcin Secret Key giriniz");
                }
            }
            linkFilePath.Visible = index == 1;
            btOpenDialog.Visible = index == 1;
        }
        private void KeyGonder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                txtMesajServer.Text = textBox1.Text;
            }
            else
            {
                txtMesajServer.Text = "asdfgytasdfgytrfghtuytorfghtuyto";
            }
        }
        private string CheckControl(string text)
        {
            string textArray = null;
            if (!string.IsNullOrEmpty(text) && text.StartsWith("UPLOAD_START_"))
            {
                textArray = text.Substring(13, text.Length - 13);
                lstMesajlarServer.Items.Add(textArray);

                bool state = true;
                while (state)
                {
                    string temp = clientReader.ReadLine();
                    if (!string.IsNullOrEmpty(temp))
                    {
                        if (!temp.EndsWith("_UPLOAD_END"))
                        {
                            textArray += temp;
                        }
                        else
                        {
                            textArray += temp.Substring(0, temp.Length - 11);
                            state = false;
                        }
                    }
                }
                m_CipherByteArray = Encoding.ASCII.GetBytes(textArray);
                return null;
            }
            return text;
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

        private void btnLogShow_Click(object sender, EventArgs e)
        {
            log = new frmServerLog();
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