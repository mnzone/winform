using System;
using System.Text;
using System.Web.Security;

namespace Tools
{
    public class Encryption
    {
        /// <summary> 

        /// SHA1加密字符串 

        /// </summary> 

        /// <param name="source">源字符串</param> 

        /// <returns>加密后的字符串</returns> 

        public static string SHA1(string source)
        {

            return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "SHA1");

        }

        /// <summary> 

        /// MD5加密字符串 

        /// </summary> 

        /// <param name="source">源字符串</param> 

        /// <returns>加密后的字符串</returns> 

        public static string MD5(string source)
        {

            return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5"); ;

        }

        public static String Base64(String source)
        {
            byte[] bytes = Encoding.Default.GetBytes(source);
            return Convert.ToBase64String(bytes);
        }

    }
}
