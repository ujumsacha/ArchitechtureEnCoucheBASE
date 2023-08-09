using System.Security.Cryptography;
using System.Text;

namespace ArchitechtureEnCoucheBASE.Extensions
{
    public static  class CryptoClass
    {
        public static string Encode(string _text)
        {
            try
            {
                string ourText = _text;
                string _key = "ffc2d6e5ce495f70c19fa7227fccfd6843ddef87";
                string privatekey = "53e60d967f6f61d0f997431c15e3fd39230d45a6";
                byte[] privatekeyByte = { };
                privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
                byte[] _keybyte = { };
                _keybyte = Encoding.UTF8.GetBytes(_key);
                byte[] inputtextbyteArray = System.Text.Encoding.UTF8.GetBytes(ourText);
                using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
                {
                    var memstr = new MemoryStream();
                    var crystr = new CryptoStream(memstr, dsp.CreateEncryptor(_keybyte, privatekeyByte), CryptoStreamMode.Write);
                    crystr.Write(inputtextbyteArray, 0, inputtextbyteArray.Length);
                    crystr.FlushFinalBlock();
                    return Convert.ToBase64String(memstr.ToArray());
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public static string Decrytp(string _Hashstring)
        {
            try
            {
                string ourText = _Hashstring;
                string _key = "ffc2d6e5ce495f70c19fa7227fccfd6843ddef87";
                string privatekey = "53e60d967f6f61d0f997431c15e3fd39230d45a6";
                byte[] privatekeyByte = { };
                privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
                byte[] _keybyte = { };
                _keybyte = Encoding.UTF8.GetBytes(_key);
                byte[] inputtextbyteArray = new byte[ourText.Replace(" ", "+").Length];
                //This technique reverses base64 encoding when it is received over the Internet.
                inputtextbyteArray = Convert.FromBase64String(ourText.Replace(" ", "+"));
                using (DESCryptoServiceProvider dEsp = new DESCryptoServiceProvider())
                {
                    var memstr = new MemoryStream();
                    var crystr = new CryptoStream(memstr, dEsp.CreateDecryptor(_keybyte, privatekeyByte), CryptoStreamMode.Write);
                    crystr.Write(inputtextbyteArray, 0, inputtextbyteArray.Length);
                    crystr.FlushFinalBlock();
                    return Encoding.UTF8.GetString(memstr.ToArray());
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
