using System;
using System.IO;
using System.Security.Cryptography;



namespace mk_management.common
{
    public class Crypto
    {
        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                Rijndael alg = Rijndael.Create();
                alg.Key = Key;
                alg.IV = IV;

                CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(clearData, 0, clearData.Length);
                cs.Close();

                byte[] encryptedData = ms.ToArray();

                return encryptedData;
            }
        }

        public static string Encrypt(string clearText, string Password = "")
        {
            if (string.IsNullOrEmpty(clearText))
                return clearText;

            if (Password == "")
                Password = "STRENCRYPT";

            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);

            using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
        }

        private static byte[] Encrypt(byte[] clearData, string Password = "")
        {
            using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
            {
                return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
            }
        }


        private static void Encrypt(string fileIn, string fileOut, string Password = "")
        {
            using (FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
                    {

                        Rijndael alg = Rijndael.Create();
                        alg.Key = pdb.GetBytes(32);
                        alg.IV = pdb.GetBytes(16);

                        CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);
                        int bufferLen = 4096;
                        byte[] buffer = new byte[bufferLen];
                        int bytesRead;

                        do
                        {
                            bytesRead = fsIn.Read(buffer, 0, bufferLen);
                            cs.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead != 0);

                        cs.Close();
                    }
                }
                fsIn.Close();
            }
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Rijndael alg = Rijndael.Create();
                alg.Key = Key;
                alg.IV = IV;

                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();

                byte[] decryptedData = ms.ToArray();
                return decryptedData;
            }
        }

        public static string Decrypt(string cipherText, string Password = "")
        {

            if (Password == "")
                Password = "STRENCRYPT";

            cipherText = cipherText.Trim();

            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                var resultado = System.Text.Encoding.Unicode.GetString(decryptedData);
                return resultado;
            }
        }

        private static byte[] Decrypt(byte[] cipherData, string Password = "")
        {
            using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
            {
                return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
            }
        }

        private static void Decrypt(string fileIn, string fileOut, string Password)
        {
            using (FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
                    {

                        Rijndael alg = Rijndael.Create();
                        alg.Key = pdb.GetBytes(32);
                        alg.IV = pdb.GetBytes(16);

                        CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

                        int bufferLen = 4096;
                        byte[] buffer = new byte[bufferLen];
                        int bytesRead;

                        do
                        {
                            bytesRead = fsIn.Read(buffer, 0, bufferLen);
                            cs.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead != 0);

                        cs.Close();
                    }
                }

                fsIn.Close();
            }

        }

    }
}

