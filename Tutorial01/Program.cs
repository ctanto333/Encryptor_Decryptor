using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial01
{
    class Program
    {
        static void Main(string[] args)
        {
            //encryption();
            //decryption();
        }

        static void encryption()
        {
            try
            {
                string inputFile = @"C:\Users\ANTO\Desktop\temp\aes.mp4";
                string outputFile = @"C:\Users\ANTO\Desktop\temp\sea.mp4";


                string password = @"fenixedu"; // Your Key Here 8 digit
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
                Console.WriteLine("completed");
                Console.ReadKey();
            }

            catch
            {
                Console.WriteLine("error");
                Console.ReadKey();
            }
        }

        static void decryption()
        {
            string outputFile = @"C:\Users\ANTO\Desktop\temp\aes.mp4";
            string inputFile = @"C:\Users\ANTO\Desktop\temp\sea.mp4";

            string password = @"fenixedu"; // Your Key Here 8 digit

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
            Console.WriteLine("completed");
            Console.ReadKey();
        }
    }
}
        