using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoLibrary
{
    public class Crypto2
    {
        private int[] random_sayilar = new int[32];

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

        // ANAHTARA BAGIMLI random_sayilar[] URETILMEKTEDIR.
        public Crypto2()
        {
            for (int i = 0; i < SecretKey.Length; i++)
                random_sayilar[i] = SecretKey[i] % SecretKey.Length;
        }

        // BIR BILGISAYAR UZERINDEN SIFRELEME YAPMAK ICIN KULLANILABILIR.
        public string Encrypt(string input)
        {
            List<int> sayilar = new List<int>(); //Listeyi boşaltmayı sağlar.
            int current_length = SecretKey.Length - 1;
            int j = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (j > current_length) j = 0;

                //Console.WriteLine(input[i] + " " + SecretKey[j] + " " + SecretKey[current_length - j]);
                int current = int.Parse((input[i] + SecretKey[j] - SecretKey[current_length - j]).ToString());
                sayilar.Add(current);

                current_length = (current_length - random_sayilar[i % random_sayilar.Length]);

                if (current_length <= 0)
                    current_length = SecretKey.Length - 1 + current_length;

                j++;
            }

            string output = "";
            for (int i = 0; i < sayilar.Count; i++)
            {
                string binary = Convert.ToString(sayilar[i], 2);
                while (binary.Length < 8)
                    binary = "0" + binary;
                output += binary; // Output + binary
            }
            return output;
            // Karşı tarafa gönderilen binary değeri belirtir.
        }
        // SUNUCU - ISTEMCI MIMARISI ICIN KURGULANMISTIR.
        public string EncryptKey(string input, string key)
        {
            List<int> sayilar = new List<int>(); //Listeyi boşaltmayı sağlar.

            //string keyNoHash = key.Substring(0, key.Length - 64);

            int current_length = key.Length - 1;
            int j = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (j > current_length) j = 0;

                //Console.WriteLine(input[i] + " " + SecretKey[j] + " " + SecretKey[current_length - j]);
                int current = int.Parse((input[i] + key[j] - key[current_length - j]).ToString());
                sayilar.Add(current);

                current_length = (current_length - random_sayilar[i % random_sayilar.Length]);

                if (current_length <= 0)
                    current_length = key.Length - 1 + current_length;

                j++;
            }

            string output = "";
            for (int i = 0; i < sayilar.Count; i++)
            {
                string binary = Convert.ToString(sayilar[i], 2);
                while (binary.Length < 8)
                    binary = "0" + binary;
                output += binary; // Output + binary
            }
            return output;
            // Karşı tarafa gönderilen binary değeri belirtir.
        }

        // DEŞİFRELEME ICIN GELEN BİNARY DEGER PARÇALANIR.
        public string Decrypt(string input)
        {
            List<int> sayilar2 = new List<int>();

            int j = 0;
            int current_length = SecretKey.Length - 1;

            for (int i = 0; i < input.Length / 8; i++)
            {
                if (j > current_length) j = 0;

                string gelenDeger = input.Substring(i * 8, 8);
                int sonuc = 0;
                for (int artma = 0; artma < gelenDeger.Length; artma++)
                {
                    try
                    {
                        if (Int32.Parse(gelenDeger[artma].ToString()) == 1)
                            sonuc += (int)Math.Pow(2, gelenDeger.Length - 1 - artma);
                        else if (Int32.Parse(gelenDeger[artma].ToString()) > 1)
                            throw new Exception("Hatalı Giris");
                    }
                    catch
                    {
                        throw new Exception("Hatalı Giris");
                    }
                }

                // Burada listeye bağlı kalmamamız gerekmektedir.
                // Console.WriteLine(input[i] + " " + SecretKey[j] + " " + SecretKey[current_length - j]);
                // int current = (sayilar[i] + int.Parse((SecretKey[current_length - j] - SecretKey[j]).ToString()));
                int current = (sonuc + int.Parse((SecretKey[current_length - j] - SecretKey[j]).ToString()));
                sayilar2.Add(current);

                current_length = (current_length - random_sayilar[i % random_sayilar.Length]);
                if (current_length <= 0)
                    current_length = SecretKey.Length - 1 + current_length;

                j++;
            }

            string Output = "";
            for (int i = 0; i < sayilar2.Count; i++)
                Output = Output + (char)sayilar2[i]; //Console.Write((char)sayilar2[i]);

            sayilar2.Clear(); //Listedeki elemanlar kullanıldıktan sonra temizlendi.

            return Output; // Deşifrelenmiş veriyi gösterir.
        }
        // MESAJI COZECEK KISI, PAYLASILAN ANAHTARLA ISLEM YAPMAKTADIR.
        public string DecryptKey(string input, string key)
        {
            List<int> sayilar2 = new List<int>();

            //string keyNoHash = key.Substring(0, key.Length - 64);

            int j = 0;
            int current_length = key.Length - 1;

            for (int i = 0; i < input.Length / 8; i++)
            {
                if (j > current_length) j = 0;

                string gelenDeger = input.Substring(i * 8, 8);
                int sonuc = 0;
                for (int artma = 0; artma < gelenDeger.Length; artma++)
                {
                    try
                    {
                        if (Int32.Parse(gelenDeger[artma].ToString()) == 1)
                            sonuc += (int)Math.Pow(2, gelenDeger.Length - 1 - artma);
                        else if (Int32.Parse(gelenDeger[artma].ToString()) > 1)
                            throw new Exception("Hatalı Giris");
                    }
                    catch
                    {
                        throw new Exception("Hatalı Giris");
                    }
                }

                // Burada listeye bağlı kalmamamız gerekmektedir.
                // Console.WriteLine(input[i] + " " + SecretKey[j] + " " + SecretKey[current_length - j]);
                // int current = (sayilar[i] + int.Parse((SecretKey[current_length - j] - SecretKey[j]).ToString()));
                int current = (sonuc + int.Parse((key[current_length - j] - key[j]).ToString()));

                sayilar2.Add(current);

                current_length = (current_length - random_sayilar[i % random_sayilar.Length]);
                if (current_length <= 0)
                    current_length = key.Length - 1 + current_length;

                j++;
            }

            string Output = "";
            for (int i = 0; i < sayilar2.Count; i++)
                Output = Output + (char)sayilar2[i]; //Console.Write((char)sayilar2[i]);

            sayilar2.Clear(); //Listedeki elemanlar kullanıldıktan sonra temizlendi.

            return Output;
        }
    }
}