using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace CryptoLibrary
{
    public class Crypto1
    {
        // ANAHTAR PAYLAŞIMI İÇİN GEREKLİ BOLUMDUR.
        private static string SecretKey { get; set; }
        public static string DecryptSecretKey(string encyptedSecretKey)
        {
            RSA rsa = new RSA();
            SecretKey = Encoding.Unicode.GetString(rsa.Decrypt(Convert.FromBase64String(encyptedSecretKey)));
            return SecretKey;
        }
        public static string EncryptSecretKey(string secretKey, string publicKeyXML)
        {
            SecretKey = secretKey;
            RSA rsa = new RSA();
            return Convert.ToBase64String(rsa.Encrypt(secretKey, publicKeyXML));
        }

        // BIR BILGISAYAR UZERINDEN SIFRELEME YAPMAK ICIN KULLANILABILIR.
        public void Encrypt(string file_path, string cipher_path, string key)
        {
            //FileStream input_file = new FileStream(file_path, FileMode.Open, FileAccess.Read);
            byte[] plainText = File.ReadAllBytes(file_path);
            ASCIIEncoding stringEnc = new ASCIIEncoding();
            byte[] skey = stringEnc.GetBytes(key);
            byte[] cipher = Encryption(plainText, skey);
            File.WriteAllBytes(cipher_path, cipher);
        }
        // SUNUCU - ISTEMCI MIMARISI ICIN KURGULANMISTIR.
        public byte[] EncryptToByteArray(byte[] mainByteArray, string key)
        {
            return Encryption(mainByteArray, Encoding.ASCII.GetBytes(key));
        }
        // MESAJ VE ANAHTAR BYTE ARRAY SEKLINDE ALINMISTIR.
        private byte[] Encryption(byte[] mess, byte[] key)
        {
            int num = 35; //Dosyanın bilgilerinin tutulduğu kısmı belirten header bölümüdür. 
            int numOfBlock = ((mess.Length - num) / 32); // Veri header çıkarılıp 32 byte'lik yapıya bolunur.
            byte[] cipher = new byte[mess.Length]; // Gelen mesaj uzunluğunda boş bir array tasarlanır. 

            for (int i = 0; (i < num); i++) // Ilk 35 byte direkt aktarilir.
                cipher[i] = mess[i];        // SEBEP: Dosya turunun degistirilmek istenmemesidir. 

            for (int i = 0; (i < numOfBlock); i++)
            {
                Byte[] cipherBlock = EncryptBlock // Bloklar sifrelenir.
                                    (SubArray(mess, ((i * 32) + num), (((i + 1) * 32) + (num - 1))), key);

                for (int j = 0; j < cipherBlock.Length; j++) // Sifrelenmis bloklar cipher'a aktarilir.
                    cipher[(num + (j + (32 * i)))] = cipherBlock[j];

                SHA256 mySHA256 = SHA256.Create();
                byte[] hash = mySHA256.ComputeHash(key);
                key = hash; // Kullanilan anahtarin degistirilme islemidir.
            }
            return cipher; // Sifrelenmis mesajı gonderme islemidir.
        }
        // BLOK SIFRELEMEDE KULLANILAN METOTTUR.
        private byte[] EncryptBlock(byte[] mess, byte[] key)
        {
            SHA256 mySHA256 = SHA256.Create();
            byte[] hash = mySHA256.ComputeHash(key);

            // Anahtarin hash'lenmis halidir.
            if ((mess.Length != hash.Length))
            {
                System.Console.WriteLine("ERROR -> Dizi boyutlari farklidir.");
                return null;
            }

            // Hash ve anahtar XOR'lanir. Daha sonra cikan sonucla mesaj bir daha XOR'lanır.
            return XOR(XOR(hash, key), mess);
        }

        // BIR BILGISAYAR UZERINDEN DESIFRELEME YAPMAK ICIN KULLANILABILIR.
        public void Decrypt(string cipher_path, string output_path, string key)
        {
            // Dosya okuma islemi yapilir. Daha sonra okunan dosya bitlere cevrilip cipher array'e gonderilir.
            FileStream cipher_file = new FileStream(cipher_path, FileMode.Open, FileAccess.Read);
            byte[] cipher = File.ReadAllBytes(cipher_path);
            ASCIIEncoding stringEnc = new ASCIIEncoding();
            byte[] skey = stringEnc.GetBytes(key);
            byte[] output = Decryption(cipher, skey);
            File.WriteAllBytes(output_path, output);
        }
        // SUNUCU - ISTEMCI MIMARISI ICIN KURGULANMISTIR.
        public byte[] DecryptToByteArray(byte[] cipherByteArray, string key)
        {
            return Decryption(cipherByteArray, Encoding.ASCII.GetBytes(key));
        }
        private byte[] Decryption(byte[] cipher, byte[] key)
        {
            int num = 35;
            int numOfBlock = (cipher.Length - num) / 32;
            byte[] output = new byte[cipher.Length];

            for (int i = 0; i < num; i++)
                output[i] = cipher[i];

            for (int i = 0; i < numOfBlock; i++)
            {
                byte[] outputBlock = DecryptBlock
                                    (SubArray(cipher, i * 32 + num, (i + 1) * 32 + num - 1), key);

                for (int j = 0; j < outputBlock.Length; j++)
                {
                    output[num + j + 32 * i] = outputBlock[j];
                }
                SHA256 mySHA256 = SHA256.Create();
                key = mySHA256.ComputeHash(key);
            }
            return output;
        }
        private byte[] DecryptBlock(byte[] cipher, byte[] key)
        {
            if (cipher.Length != key.Length)
            {
                return null;
            }

            SHA256 mySHA256 = SHA256.Create();
            byte[] hash = mySHA256.ComputeHash(key);

            return XOR(XOR(hash, key), cipher);
        }

        // SIFRELENECEK BLOGUN KONUMU BULMAYI SAGLAMAKTADIR.
        private byte[] SubArray(byte[] arr, int a, int b)
        {
            byte[] temp = new byte[((b - a) + 1)];
            int index = 0;
            for (int i = a; (i <= b); i++)
            {
                temp[index++] = arr[i];
            }
            return temp;
        }
        private byte[] XOR(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length];
            for (int i = 0; (i < c.Length); i++)
            {
                c[i] = ((byte)((a[i] ^ b[i]))); // XOR islemi yapilir.
            }
            return c;
        }
    }
}