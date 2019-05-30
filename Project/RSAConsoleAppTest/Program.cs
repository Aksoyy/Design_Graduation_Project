﻿using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RSAConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string privateKeyXML = "<RSAKeyValue><Modulus>pzhjEmHIRrMdmH3AhMRg59q1mby0UmHqLUwUPgAcsaBTP7qGTcz2sfY0BaQmyXt4jSAOm80G4IBJ5RCEiMt4iw==</Modulus><Exponent>AQAB</Exponent><P>+EU1cXJ05UZR0ETMhXyuWSK9a+WR6nNJf7Uzdd9yXFM=</P><Q>rG0vHp94kVQ0OZSPc2KdjKUbJ+AFQmbDVArwVDCOq+k=</Q><DP>6R/7vgpuz7fHLRzdO19HS7W+Tqmj6ZXV51BcAQwPk7c=</DP><DQ>dTkpfq02H79aXgcU24Ig0DxzUNGpYbJRezKQnvwAEvk=</DQ><InverseQ>ArANLF6mYdTwij8RtVMM718tp6a2ca7rcUMVdmsn28M=</InverseQ><D>A2DUP47SKPt9YZNIzGXbP1Pfz1dMnU11Ga0ry4TdD4mRJTHTY6pEQDT35SUgKFcFtA6ZoLI90VuLy3ss2TvdwQ==</D></RSAKeyValue>";
            string publicKeyXML = "<RSAKeyValue><Modulus>pzhjEmHIRrMdmH3AhMRg59q1mby0UmHqLUwUPgAcsaBTP7qGTcz2sfY0BaQmyXt4jSAOm80G4IBJ5RCEiMt4iw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            */
            string privateKeyXML = "<RSAKeyValue><Modulus>nQCG7efrwYV+bZUkhpepY1OOBbSMHiMGWLIK7swD2j9WyO/E83pLWyCmyKkGXTL9/dXznWJbUbD+IH/QH37e1MdA5Q0XU2UV5R4s1SnB3CKZVz2vpJnVYU+T5xrCwIaZTNIjNdgA4pY+5/XBA9/7vW6OhG6457OXIzdwFUOZ/taVW35zM8Q2H4/JAYjtzDt6+9ffYXwKnkmSGHBZAv1MAEhuQtW0AO1jfsCxIy6kO4D/w/X7hBzQN22PDnHlpS8HTs+0lSgnJca9RG+jXmJnj5nl7Zgi3IoZMcQN5a6uS4MpjaUtOsU0GweatKSRq/BV3GhuiSGHLObwpii9yFYSRxu62d5q8AuKbGCRe40kfWEw2pQ5Bx8pzpmpNiFc/TEKsAUVr3zZdyFoTn9LVnxqAF6O7VcE5e+5qK9J2DbFHnrGqpOjvbDmt6RGYT2g5zO8wuSO38co4GGnppTrQwWUSvrr98Ld3/TmbaiPvN8pxI1vE2IBtWzUR3HcST8Tod+dfrRgqwTe74AGYlksGSzgYQ7go0oepkNjFYxvOCWQrgL3+RYwvAKAsHklkrWp66hmIJ4F1xgcqsEDMCc9BPhHzmICS0LuzTpoQEO2/M8G9i97cqzJP1ebL9TpshG9WxxDLCIlU+YWvzplfVr4hJepn/APgJYtLCvInj5XwCSeTZE=</Modulus><Exponent>AQAB</Exponent><P>/qbeCQoLAFcv/TK56EaWoO1lpUhUJKTbgvH3LR8i5T0BO+Iu+DuHwUu6QtfwKNLilSAGm+TP8gbm3r/jNF6u+zIV4XNs7rCS5tcf3F9sf9A4TMdVY2bvBAL0JE3U1A2tLIghJ/M26Ov42EySrQTcFyzASql+NWKgqD1aOe26BiyYNyaYoSNYMfRJgf9AFLDPiQey9hqXTmIGP67zdvGtUV/CiBmgeXRJzccYo8l3yKL7RF8eM8zL7ESyzQ8TkUCdi9BVCGqtgys8uzYpAtk5RdiZhRKZ3wEDnpvgt6EG6L8vQe7Xtjct5UWO6GxhzcMFME2vP/LPpXXMf+pX/E81ow==</P><Q>ndVQV/BpfQHgmhlwZzuhimjKV8hHvg1+b//PludUfEfiBNgVeHqUpCiRJH83s0Ez9xKsjm3TCgouWz/PenH4okhoyb4KyvFldYHYAplAc8eeWO1RgArpDfAJYfJNY4N+7BGTwQaHBro12ALmluT/skFtkGdGnyCT7sYsB3C68AX4OQxqAPfE0klp2l9PAKKwYB7sSt5JPnoiIGOALVtf2soCWPqsia2TMlVjbLl+GM1cDvYNzGIp98cwzmT76ad3t+AsiuUscT1KtnIuz/f3J0UbZu44slK9MZ9YLaGDwjgix//datLQ58NBdLMHkf9XRlYQZm2eiZQZDg4afURbOw==</Q><DP>bEzLYUzEIQDzh9tq9T4QEaDk+cYpAuyZ7ra5SJdVX+jx/WXUU/39Xle2f3cWzEXj10gnh2VoiqYkydcR6dPa1zoV1Cwix+CQmVwkULTEkBcd2olr5zp/rFUVP9taCFVIsQe0Eil90NGKo3LtbmgCslh170rmQg4QBX0SQlC4LKgKlGn1v5IokBY0rPTBbAtGOCDuG3xznQJTZgIhyRQ/gbwYH4nGleC/AqUJ9Z5ZMxsdgZZyYdVXZMRSxqMCz2OLnUqc31d/M6nPyk7eYjfAA9R6df3TMuRbhbkFeRMivRmSH5hUZUpSWo+al36AmeG28zQWtDuv086likE/6i5FwQ==</DP><DQ>CHmOwdoP3/180OlyxqhGCUeNLd98MrFIy7zBqcmsGKxHb5kmtfxnBNWEzZ/jHsXug2LGTzOIdG6NhKrNejaqchRPRB3nOHRzzTZ2odUWx+C9GOtNSAHN98ieyFqZWzGRXB2pgGDYWT0gbQPi29FaBXlL58gT27GFH/oWHSQpdX/sjyuieYDUWbJFc8tQU6lorRCcAX0kE629LV4KYOUaJYZZT+vN3eqrD7XUC9997NkCC2+c2A+hT0Or1DlJ6Ybrf70SxzZ9B2uSGm/RIauf4sTsLr+13aVhsUtsEa8tgv0+qNyNSBIf04IBfsGqM2Wxiv5ODSHvtFV2bvHE7FsCRw==</DQ><InverseQ>kvXMrQboHKRYxCl1o6XDPCoNYQK3F4aYau4qhv7AQkWd81FrKsBMYuYY+xfG8N+0qCEfAz2BT0zGrGeAkqFv1g8GYXDYlR4OO1dJ1IH7+LuO+Sm1M92AkWWPn6cOFkiQKJnRdZNZlHC7nleSGFI34KV6q7GVHPcAvfBe/oTBXh6gpIhG9kYkH6f7/WUV7rgxArvrXKmi7j52nnRTZiTJhLEwegRFy9hySpiBuqwRrWhkwoJL/Dpub/6I4JhhkxarB4wHOGBHg8KCPWoXTcG3DiPYVtDPCSoxQHEn0g+1KEMOgnxgZYPN80iP1UpoIByue2to+JGVhP/lwy241UqzCQ==</InverseQ><D>QXNrzJgnn1iAeTx4qqdlFSRLC7PVyeZ+CdHHXv+sB3rqOgBC0eHEsmutO+/C2G2elwhvc8gCG882UeQWplqkmH2sXxCTDdARTZ/DvuWWjKfb1xO/OlZrLxMWrHxqfgpetDjSNusii1NpTBgWbAAfGTySq0DhUq56rlK5JhQ1iZh5UVgovIbqrUOq3znvMHoHbh/zXtdwMcan4gpMAUQJQADx/mjKjqxoEvpPnkQecTP46/+K5+t/HexNfA8dVjyBxmgudxPzJftxAauspndNhv74bJFEzz2+/REnXf3xaUd3tjYK4fo+G5qS8wW8OLqLgMQEeKSCjsSDxDEt1OuU2GYQgTtc/hUsHICOpiyUjlfCHeXAEtx1TCsIQ6PcoxH9THz7Q2gfAP9j3TpKMHnk9wIcMqBZfDHJsBdwXq8LydW9oHxZzzMi9L8OiSPN6+K7wcT+AkNkFVHtFaEo1BcuE9zzwCzHvysDOn0RhV2eSfIUEZusrBBDlCGpxbgwpFV2n3fKtOzfh8rUwaZgJVZmA6JPpskNdxv9qbgZwE3HHLEP65HMlbVeGbjWghs9X66e3liFx/3EueZ4LfAESdsHYcvy+qp9EBu5XJotQrhlzliV7boFk9shAnYoKhnR5T2mCniXpJ6vDzVIMlHtBTzL60QeGKOfbgCEncfhIybP5hU=</D></RSAKeyValue>";
            string publicKeyXML = "<RSAKeyValue><Modulus>nQCG7efrwYV+bZUkhpepY1OOBbSMHiMGWLIK7swD2j9WyO/E83pLWyCmyKkGXTL9/dXznWJbUbD+IH/QH37e1MdA5Q0XU2UV5R4s1SnB3CKZVz2vpJnVYU+T5xrCwIaZTNIjNdgA4pY+5/XBA9/7vW6OhG6457OXIzdwFUOZ/taVW35zM8Q2H4/JAYjtzDt6+9ffYXwKnkmSGHBZAv1MAEhuQtW0AO1jfsCxIy6kO4D/w/X7hBzQN22PDnHlpS8HTs+0lSgnJca9RG+jXmJnj5nl7Zgi3IoZMcQN5a6uS4MpjaUtOsU0GweatKSRq/BV3GhuiSGHLObwpii9yFYSRxu62d5q8AuKbGCRe40kfWEw2pQ5Bx8pzpmpNiFc/TEKsAUVr3zZdyFoTn9LVnxqAF6O7VcE5e+5qK9J2DbFHnrGqpOjvbDmt6RGYT2g5zO8wuSO38co4GGnppTrQwWUSvrr98Ld3/TmbaiPvN8pxI1vE2IBtWzUR3HcST8Tod+dfrRgqwTe74AGYlksGSzgYQ7go0oepkNjFYxvOCWQrgL3+RYwvAKAsHklkrWp66hmIJ4F1xgcqsEDMCc9BPhHzmICS0LuzTpoQEO2/M8G9i97cqzJP1ebL9TpshG9WxxDLCIlU+YWvzplfVr4hJepn/APgJYtLCvInj5XwCSeTZE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            /*
            var privateKey = new RSACryptoServiceProvider();
            privateKey.FromXmlString(privateKeyXML);

            var publicKey = new RSACryptoServiceProvider();
            publicKey.FromXmlString(publicKeyXML);

            string data = "asdfgytasdfgytrfghtuytorfghtuyto";
            Console.WriteLine(data);
            byte[] encrypted = publicKey.Encrypt(Encoding.ASCII.GetBytes(data), false);
            var decryptedArray = privateKey.Decrypt(encrypted, false);
            string decryptedStr = Encoding.ASCII.GetString(decryptedArray);
            */
            //string data = "asdfgytasdfgytrfghtuytorfghtuyto";
            string data = "asdfgytasdfgytrfghtuytorfghtuyto";
            Console.WriteLine(data);
            //Crypto2.PublicKeyXML = publicKeyXML;
            //string encData = Crypto2.EncryptSecretKey(data);
            CryptoLibrary.RSA rsa = new CryptoLibrary.RSA();
            var encData =  rsa.Encrypt(data, publicKeyXML);

            Console.WriteLine("decryptedStr\n" + Encoding.Unicode.GetString(rsa.Decrypt(encData)));
            Console.ReadLine();

        }
    }
}
