using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Utility
{
    public static class Encryption
    {
        /// <summary>
        /// Method which handles the encryption process of an input file based on a key
        /// </summary>
        /// <param name="plaintextFileName"></param>
        /// <param name="encryptedFileName"></param>
        /// <param name="key"></param>
        public static void Encrypt(string plaintextFileName, string encryptedFileName, string key) {

            FileStream plainTextFileStream = new FileStream(plaintextFileName,
                FileMode.Open, FileAccess.Read);

            FileStream encryptedFileStream = new FileStream(encryptedFileName,
                FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider desCrypto = new DESCryptoServiceProvider();
            desCrypto.Key = ASCIIEncoding.ASCII.GetBytes(key);
            desCrypto.IV = ASCIIEncoding.ASCII.GetBytes(key);

            ICryptoTransform encryptor = desCrypto.CreateEncryptor();

            CryptoStream cryptoStreamEncr = new CryptoStream(encryptedFileStream,
                encryptor, CryptoStreamMode.Write);

            byte[] byteArray = new byte[plainTextFileStream.Length];
            plainTextFileStream.Read(byteArray, 0, byteArray.Length);
            cryptoStreamEncr.Write(byteArray, 0, byteArray.Length);

            cryptoStreamEncr.Close();
            plainTextFileStream.Close();
            encryptedFileStream.Close();
        }

        /// <summary>
        /// Method which handles the Decryption process of an input file given that the key is known
        /// </summary>
        /// <param name="plaintextFileName"></param>
        /// <param name="encryptedFileName"></param>
        /// <param name="key"></param>
        public static void Decrypt(string plaintextFileName, string encryptedFileName, string key) {
            try
            {
                DESCryptoServiceProvider desCrypto = new DESCryptoServiceProvider();
                desCrypto.Key = ASCIIEncoding.ASCII.GetBytes(key);
                desCrypto.IV = ASCIIEncoding.ASCII.GetBytes(key);

                ICryptoTransform decryptor = desCrypto.CreateDecryptor();

                FileStream fileStreamDecrypt = new FileStream(encryptedFileName,
                    FileMode.Open, FileAccess.Read);

                CryptoStream cryptoStreamDecr = new CryptoStream(fileStreamDecrypt,
                    decryptor, CryptoStreamMode.Read);

                StreamWriter decryptWriter = new StreamWriter(plaintextFileName);
                decryptWriter.Write(new StreamReader(cryptoStreamDecr).ReadToEnd());
                decryptWriter.Flush();
                decryptWriter.Close();
            }
            finally {

            }
        }
    }
}
