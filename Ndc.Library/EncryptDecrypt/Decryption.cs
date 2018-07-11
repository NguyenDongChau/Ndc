using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ndc.Library.EncryptDecrypt
{
    public class Decryption
    {
        private static byte[] _keyByte = { };
        //Default Key string    
        private static string Key;
        //Default initial vector
        private static byte[] _ivByte = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };

        public Decryption(string strKey)
        {
            Key = strKey;
        }

        /// <summary> 
        /// Decrypt a text string
        /// </summary> 
        /// <param name="value">Encrypted text</param> 
        /// <returns>Plain text</returns> 
        public static string Decrypt(string value)
        {
            return Decrypt(value, string.Empty);
        }

        /// <summary> 
        /// Decrypt a text string by key string
        /// </summary> 
        /// <param name="value">Encrypted text</param> 
        /// <param name="key">Key string</param> 
        /// <returns>Plain text</returns> 
        public static string Decrypt(string value, string key)
        {
            return Decrypt(value, key, string.Empty);
        }

        /// <summary> 
        /// Decrypt text by key with initialization vector 
        /// </summary> 
        /// <param name="value">Encrypted text</param> 
        /// <param name="key">Key string</param> 
        /// <param name="iv">Initialization vector</param> 
        /// <returns>Plain text</returns> 
        public static string Decrypt(string value, string key, string iv)
        {
            var decrptValue = string.Empty;
            if (string.IsNullOrEmpty(value)) return decrptValue;
            MemoryStream ms = null;
            CryptoStream cs = null;
            value = value.Replace(" ", "+");
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
                    _keyByte = Encoding.UTF8.GetBytes(key);
                }
                using (var des = new DESCryptoServiceProvider())
                {
                    var inputByteArray = Convert.FromBase64String(value);
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor
                        (_keyByte, _ivByte), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    var encoding = Encoding.UTF8;
                    decrptValue = encoding.GetString(ms.ToArray());
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
            return decrptValue;
        }
    }
}
