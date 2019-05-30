using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;

namespace CryptoLibrary
{
    public class Crypto3
    {
        Dictionary<string, string> dictionaryEven = new Dictionary<string, string>();
        Dictionary<string, string> dictionaryOdd = new Dictionary<string, string>();
        Dictionary<string, string> dictionaryUs = new Dictionary<string, string>();
        ArrayList aList = new ArrayList();

        public Crypto3()    // Sinifin constructor metotudur.
        {
            DictionaryCift();
            DictionaryTek();
            Dictionary2us();
        }
        
        // SİFRELEME : Tablo + Playfair
        public String Encrypto(String plaintext)
        {
            String cipherText = ""; // Şifreli metnin ekleneceği yerdir.
            string text1 = plaintext.Trim().Replace(" ", string.Empty);
            string text = text1.ToUpper();  //B_K dönüşümü yapılmaktadır.
            char[] karakterler = text.ToArray(); // Karakterler adında char türünde bir dizi gonderiliyor.

            foreach (char karakter in karakterler)  //Fonksiyona verilen plaintext'in tutulduğu bölümdür.
                aList.Add(karakter);    //richTextBox2.Text += karakter.ToString();

            ArrayList newList = new ArrayList();
            newList = aList;    //Yeni bir listeye atıyoruz ve üzerinde işlem yapılmaktadır.

            for (int i = 1; i <= aList.Count; i++)  //Plaintext boyutu kadar ilerlemektedir.
            {
                int index = i;  //Encrypto_Even(aList[i - 1].ToString());
                if (index % 2 == 0 && ((index & (index - 1)) != 0))
                    cipherText += Encrypto_Even(aList[i - 1].ToString());
                else if (index % 2 != 0)
                    cipherText += Encrypto_Odd(aList[i - 1].ToString());
                else if (index != 0 && ((index & (index - 1)) == 0))
                    cipherText += Encrypto_Pow(aList[i - 1].ToString());

                aList[index - 1] = " "; //Listeyi boşaltma işlemidir.
            }

            Playfair sifrele = new Playfair();
            String playCipherText = sifrele.PlayFairSifre(cipherText);

            return playCipherText;
        }
  
        // DESİFRELEME : Playfair + Tablo
        public String Decrypto(String ciphertext)
        {
            Playfair sifrecoz = new Playfair();
            String playPlainText = sifrecoz.PlayFairDesifre(ciphertext);

            String plainText = "";  // Deşifrelenecek verinin gönderileceği yerdir.
            string text1 = playPlainText.Trim().Replace(" ", string.Empty);
            //Tüm öndeki ve sondaki geçerli bir dizideki belirtilen karakter kümesini kaldırır String nesne.
            string text = text1.ToUpper();
            char[] karakterler = text.ToArray();

            foreach (char karakter in karakterler)
                aList.Add(karakter);    // richTextBox2.Text += karakter.ToString();

            ArrayList newList = new ArrayList();
            newList = aList;

            for (int i = 1; i <= aList.Count; i++)
            {
                int index = i;

                if (index % 2 == 0 && ((index & (index - 1)) != 0))
                    plainText += Decrypto_Even(aList[i - 1].ToString());
                else if (index % 2 != 0)
                    plainText += Decrypto_Odd(aList[i - 1].ToString());
                else if (index != 0 && ((index & (index - 1)) == 0))
                    plainText += Decrypto_Pow(aList[i - 1].ToString());

                aList[index - 1] = " "; // Listeyi boşaltma işlemidir.
            }
            return plainText;
        }

        private String Encrypto_Odd(string karakter)
        {
            String value = "";
            foreach (KeyValuePair<string, string> item in dictionaryOdd)
            {
                if (item.Key == karakter)
                {
                    string s = item.Value;
                    value += s.ToString();
                    break;
                }
            }
            return value;
        }
        private String Encrypto_Even(string karakter)
        {
            String value = "";
            foreach (KeyValuePair<string, string> item in dictionaryEven)
            {
                if (item.Key == karakter)
                {
                    string s = item.Value;
                    value += s.ToString();
                    break;
                }
            }
            return value;
        }
        private String Encrypto_Pow(string karakter)
        {
            String value = "";
            foreach (KeyValuePair<string, string> item in dictionaryUs)
            {
                if (item.Key == karakter)
                {
                    string s = item.Value;
                    value += s.ToString();
                    break;
                }
            }
            return value;
        }

        private String Decrypto_Odd(string karakter)
        {
            String value = "";
            foreach (KeyValuePair<string, string> item in dictionaryOdd)
            {
                if (item.Value == karakter)
                {
                    string s = item.Key;
                    value += s.ToString();
                    break;
                }
            }
            return value;
        }
        private String Decrypto_Even(string karakter)
        {
            String value = "";
            foreach (KeyValuePair<string, string> item in dictionaryEven)
            {
                if (item.Value == karakter)
                {
                    string s = item.Key;
                    value += s.ToString();
                    break;
                }
            }
            return value;
        }
        private String Decrypto_Pow(string karakter)
        {
            String value = "";
            foreach (KeyValuePair<string, string> item in dictionaryUs)
            {
                if (item.Value == karakter)
                {
                    string s = item.Key;
                    value += s.ToString();
                    break;
                }
            }
            return value;
        }

        private void DictionaryCift()   // Table --> KEY to VALUE
        {
            dictionaryEven.Add("A", "N");
            dictionaryEven.Add("B", "F");
            dictionaryEven.Add("C", "A");
            dictionaryEven.Add("D", "U");
            dictionaryEven.Add("E", "P");
            dictionaryEven.Add("F", "M");
            dictionaryEven.Add("G", "E");
            dictionaryEven.Add("H", "S");
            dictionaryEven.Add("I", "B");
            dictionaryEven.Add("J", "B");
            dictionaryEven.Add("K", "L");
            dictionaryEven.Add("L", "Q");
            dictionaryEven.Add("M", "W");
            dictionaryEven.Add("N", "R");
            dictionaryEven.Add("O", "T");
            dictionaryEven.Add("P", "Y");
            dictionaryEven.Add("Q", "I");
            dictionaryEven.Add("R", "O");
            dictionaryEven.Add("S", "D");
            dictionaryEven.Add("T", "G");
            dictionaryEven.Add("U", "H");
            dictionaryEven.Add("V", "J");
            dictionaryEven.Add("W", "K");
            dictionaryEven.Add("X", "Z");
            dictionaryEven.Add("Y", "X");
            dictionaryEven.Add("Z", "C");
        }
        private void DictionaryTek()
        {
            dictionaryOdd.Add("A", "Q");
            dictionaryOdd.Add("B", "W");
            dictionaryOdd.Add("C", "E");
            dictionaryOdd.Add("D", "R");
            dictionaryOdd.Add("E", "T");
            dictionaryOdd.Add("F", "Y");
            dictionaryOdd.Add("G", "U");
            dictionaryOdd.Add("H", "I");
            dictionaryOdd.Add("I", "O");
            dictionaryOdd.Add("J", "O");
            dictionaryOdd.Add("K", "A");
            dictionaryOdd.Add("L", "S");
            dictionaryOdd.Add("M", "D");
            dictionaryOdd.Add("N", "F");
            dictionaryOdd.Add("O", "G");
            dictionaryOdd.Add("P", "H");
            dictionaryOdd.Add("Q", "J");
            dictionaryOdd.Add("R", "K");
            dictionaryOdd.Add("S", "L");
            dictionaryOdd.Add("T", "Z");
            dictionaryOdd.Add("U", "X");
            dictionaryOdd.Add("V", "C");
            dictionaryOdd.Add("W", "V");
            dictionaryOdd.Add("X", "B");
            dictionaryOdd.Add("Y", "N");
            dictionaryOdd.Add("Z", "M");
        }
        private void Dictionary2us()
        {
            dictionaryUs.Add("A", "N");
            dictionaryUs.Add("B", "M");
            dictionaryUs.Add("C", "B");
            dictionaryUs.Add("D", "V");
            dictionaryUs.Add("E", "C");
            dictionaryUs.Add("F", "X");
            dictionaryUs.Add("G", "Z");
            dictionaryUs.Add("H", "L");
            dictionaryUs.Add("I", "K");
            dictionaryUs.Add("J", "K");
            dictionaryUs.Add("K", "J");
            dictionaryUs.Add("L", "H");
            dictionaryUs.Add("M", "G");
            dictionaryUs.Add("N", "F");
            dictionaryUs.Add("O", "D");
            dictionaryUs.Add("P", "S");
            dictionaryUs.Add("Q", "A");
            dictionaryUs.Add("R", "P");
            dictionaryUs.Add("S", "O");
            dictionaryUs.Add("T", "I");
            dictionaryUs.Add("U", "U");
            dictionaryUs.Add("V", "Y");
            dictionaryUs.Add("W", "T");
            dictionaryUs.Add("X", "R");
            dictionaryUs.Add("Y", "E");
            dictionaryUs.Add("Z", "W");
        }
    }
}