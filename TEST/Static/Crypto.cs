using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace TEST.Static
{
    public static class Crypto
    {

        public static string EncodeText(string _text)
        {
            try
            {
                string Password = "53e60d967f6f61d0f997431c15e3fd39230d45a6";
                var userBytes = Encoding.UTF8.GetBytes(_text); // UTF8 saves Space
                var userHash = MD5.Create().ComputeHash(userBytes);
                SymmetricAlgorithm crypt = Aes.Create(); // (Default: AES-CCM (Counter with CBC-MAC))
                crypt.Key = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password)); // MD5: 128 Bit Hash
                crypt.IV = new byte[16]; // by Default. IV[] to 0.. is OK simple crypt
                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(userBytes, 0, userBytes.Length); // User Data
                cryptoStream.Write(userHash, 0, userHash.Length); // Add HASH
                cryptoStream.FlushFinalBlock();
                var resultString = Convert.ToBase64String(memoryStream.ToArray());
                return resultString;
            }
            catch (Exception ex)
            {
                throw new Exception("erreur de cryptage");
            }

        }

        public static string Decrytp(string _Hashstring)
        {
            try
            {
                string Password = "53e60d967f6f61d0f997431c15e3fd39230d45a6";
                var encryptedBytes = Convert.FromBase64String(_Hashstring);
                SymmetricAlgorithm crypt = Aes.Create();
                crypt.Key = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password));
                crypt.IV = new byte[16];
                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                cryptoStream.FlushFinalBlock();
                var allBytes = memoryStream.ToArray();
                var userLen = allBytes.Length - 16;
                if (userLen < 0) throw new Exception("Invalid Len");   // No Hash?
                var userHash = new byte[16];
                Array.Copy(allBytes, userLen, userHash, 0, 16); // Get the 2 Hashes
                var decryptHash = MD5.Create().ComputeHash(allBytes, 0, userLen);
                if (userHash.SequenceEqual(decryptHash) == false) throw new Exception("Invalid Hash");
                var resultString = Encoding.UTF8.GetString(allBytes, 0, userLen);
                return resultString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
