using System;
using System.Security.Cryptography;
using System.Text;

namespace StingRay.Utility.CommonOperation
{
    public class SecurityOperation
    {
        public static string Hash(String s)
        {
            HashAlgorithm Hasher = new SHA256CryptoServiceProvider();
            byte[] strBytes = Encoding.UTF8.GetBytes(s);
            byte[] strHash = Hasher.ComputeHash(strBytes);
            return BitConverter.ToString(strHash).Replace("-", "").ToLowerInvariant().Trim();
        }
        public static string GetHashedPassword(string Email, string password)
        {
            int iterationCount = 1000;
            string Salt = "." + Email + "." + iterationCount;
            string ToEncrypt = password + Salt;
            string encryptedPassword = SecurityOperation.Hash(ToEncrypt);
            return encryptedPassword;
        }

        public class TripleDES
        {
            #region SecurityKey
            const string SecurityKey = "$T!NGR@yC0mp|#%||#y!&#@b";
            #endregion

            /// <summary>
            /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
            /// </summary>
            /// <param name="toEncrypt">string to be encrypted</param>
            /// <param name="useHashing">use hashing? send to for extra secirity</param>
            /// <returns></returns>
            /// 
            public static string Encrypt(string toEncrypt, bool useHashing)
            {
                byte[] keyArray;
                var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

                // Get the key from config file
                var key = SecurityKey;
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = Encoding.UTF8.GetBytes(key);

                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                var cTransform = tdes.CreateEncryptor();
                var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            /// <summary>
            /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
            /// </summary>
            /// <param name="cipherString">encrypted string</param>
            /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
            /// <returns></returns>
            public static string Decrypt(string cipherString, bool useHashing)
            {
                byte[] keyArray;
                var toEncryptArray = Convert.FromBase64String(cipherString);

                var key = SecurityKey;
                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = Encoding.UTF8.GetBytes(key);

                var tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                var cTransform = tdes.CreateDecryptor();
                var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                return Encoding.UTF8.GetString(resultArray);
            }
        }
    }
}
