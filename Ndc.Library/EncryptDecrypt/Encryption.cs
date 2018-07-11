using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ndc.Library.EncryptDecrypt
{
    public class Encryption
    {
        private static byte[] _keyByte = { };
        //Default Key
        private static string Key; 
        //Default initial vector
        private static byte[] _ivByte = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };

        //Constructor
        public  Encryption(string strKey)
        {
            Key = strKey;
        }

        /// <summary>
        /// Encrypt a text string
        /// </summary>
        /// <param name="value">Plain text</param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string value)
        {
            return Encrypt(value, string.Empty);
        }

        /// <summary>
        /// Encrypt a text string by key string
        /// </summary>
        /// <param name="value">Plain text</param>
        /// <param name="key">Key string</param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string value, string key)
        {
            return Encrypt(value, key, string.Empty);
        }

        /// <summary>
        /// Encrypt a text string by key string with initialization vector
        /// </summary>
        /// <param name="value">Plain text</param>
        /// <param name="key">ZKey string</param>
        /// <param name="iv">Initialization vector</param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string value, string key, string iv)
        {
            var encryptValue = string.Empty;
            MemoryStream ms = null;
            CryptoStream cs = null;
            if (string.IsNullOrEmpty(value)) return encryptValue;
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _keyByte = Encoding.UTF8.GetBytes
                        (key.Substring(0, 8));
                    if (!string.IsNullOrEmpty(iv))
                    {
                        _ivByte = Encoding.UTF8.GetBytes
                            (iv.Substring(0, 8));
                    }
                }
                else
                {
                    _keyByte = Encoding.UTF8.GetBytes(Key);
                }
                using (DESCryptoServiceProvider des =
                    new DESCryptoServiceProvider())
                {
                    byte[] inputByteArray =
                        Encoding.UTF8.GetBytes(value);
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor
                        (_keyByte, _ivByte), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    encryptValue = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch
            {
                //TODO: write log 
            }
            finally
            {
                cs?.Dispose();
                ms?.Dispose();
            }
            return encryptValue;
        }
    }
}
