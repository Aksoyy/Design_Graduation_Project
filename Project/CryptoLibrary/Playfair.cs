using System;

namespace CryptoLibrary
{
    public class Playfair
    {
        // PESPESE AYNI KARAKTER KONTROLU + CIFT KARAKTER KONTROLU + TABLO KULLANIMI
        public String PlayFairSifre(String sifrelenecek_anahtar)
        {
            String cipherText = "";

            char[,] matris = { {'A','B','C','D','E'},
                               {'F','G','H','I','J'},
                               {'K','L','M','N','O'},
                               {'P','Q','R','S','T'},
                               {'U','V','W','X','Y'} };

            for (int artma = 1; artma < sifrelenecek_anahtar.Length; artma += 2)
            {
                if (sifrelenecek_anahtar.Substring(artma, 1) == sifrelenecek_anahtar.Substring(artma - 1, 1))
                {
                    String guncel = sifrelenecek_anahtar.Substring(0, artma);
                    guncel += "X";
                    guncel += sifrelenecek_anahtar.Substring(artma);
                    sifrelenecek_anahtar = guncel;
                }
            }

            //Sifrelenecek verinin cift karakterli olmasi saglanir.
            if (sifrelenecek_anahtar.Length % 2 != 0)
                sifrelenecek_anahtar += 'X';

            for (int a = 0; a < sifrelenecek_anahtar.Length; a += 2)
            {
                string sub = sifrelenecek_anahtar.Substring(a, 2);

                int satir1 = (Convert.ToInt32(Convert.ToChar(sub.Substring(0, 1))) - 65) / 5;
                int sutun1 = (Convert.ToInt32(Convert.ToChar(sub.Substring(0, 1))) - 65) % 5;
                int satir2 = (Convert.ToInt32(Convert.ToChar(sub.Substring(1, 1))) - 65) / 5;
                int sutun2 = (Convert.ToInt32(Convert.ToChar(sub.Substring(1, 1))) - 65) % 5;
                //Console.WriteLine(satir1 + " " + sutun1 + " " + satir2 + " " + sutun2);

                if (satir1 == satir2)
                {
                    cipherText += Convert.ToString(matris[satir1, (sutun1 + 1) % 5]);
                    cipherText += Convert.ToString(matris[satir2, (sutun2 + 1) % 5]);
                    //Console.WriteLine(test);
                }
                else if (sutun1 == sutun2)
                {
                    cipherText += Convert.ToString(matris[(satir1 + 1) % 5, sutun1]);
                    cipherText += Convert.ToString(matris[(satir2 + 1) % 5, sutun2]);
                   // Console.WriteLine(test);
                }
                else
                {
                    cipherText += Convert.ToString(matris[satir2, sutun1]);
                    cipherText += Convert.ToString(matris[satir1, sutun2]);
                   // Console.WriteLine(test);
                }
            }

            return cipherText;
        }

        // TABLO KULLANIMI
        public String PlayFairDesifre(String cozulecek_anahtar)
        {
            String plainText = "";

            char[,] matris = { {'A','B','C','D','E'},
                               {'F','G','H','I','J'},
                               {'K','L','M','N','O'},
                               {'P','Q','R','S','T'},
                               {'U','V','W','X','Y'} };

            // Deşifreleme de bu kontrole gerek yoktur.
            //if (cozulecek_anahtar.Length % 2 != 0)
            //    cozulecek_anahtar += 'X';

            for (int a = 0; a < cozulecek_anahtar.Length; a += 2)
            {
                string sub = cozulecek_anahtar.Substring(a, 2);

                int satir1 = (Convert.ToInt32(Convert.ToChar(sub.Substring(0, 1))) - 65) / 5;
                int sutun1 = (Convert.ToInt32(Convert.ToChar(sub.Substring(0, 1))) - 65) % 5;
                int satir2 = (Convert.ToInt32(Convert.ToChar(sub.Substring(1, 1))) - 65) / 5;
                int sutun2 = (Convert.ToInt32(Convert.ToChar(sub.Substring(1, 1))) - 65) % 5;
                //Console.WriteLine(satir1 + " " + sutun1 + " " + satir2 + " " + sutun2);

                if (satir1 == satir2)
                {                                               //(sutun1 - 1) % 5
                    plainText += Convert.ToString(matris[satir1, (sutun1 + 4) % 5]);
                    plainText += Convert.ToString(matris[satir2, (sutun2 + 4) % 5]);
                    // Console.WriteLine(test);
                }
                else if (sutun1 == sutun2)
                {
                    plainText += Convert.ToString(matris[(satir1 + 4) % 5, sutun1]);
                    plainText += Convert.ToString(matris[(satir2 + 4) % 5, sutun2]);
                    //  Console.WriteLine(test);
                }
                else
                {
                    plainText += Convert.ToString(matris[satir2, sutun1]);
                    plainText += Convert.ToString(matris[satir1, sutun2]);
                    // Console.WriteLine(test);
                }
            }
            return plainText;
        }
    }
}