using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Tools;
using Update.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Loader.Common
{
    public class NetApi
    {
        private static String domain = ConfigurationManager.AppSettings["domain"];
        private const String GetUrl = "/api/token";

        public static NetResult GetAccessToken(String appId, String appSecret)
        {
            Soft soft = null;
            String url = String.Format("{0}{1}.json", domain, GetUrl);

            String time = TimeStamp.GetNowTimeStamp().ToString();
            System.String nonce = Encryption.MD5(time);

            IDictionary<String, String> param = new Dictionary<String, String>();
            param.Add("app_id", appId);
            param.Add("nonce", nonce);
            param.Add("timestamp", time);
            param.Add("signature", Encryption.MD5(String.Format("{0}{1}{2}&key={3}", appId, nonce, time, appSecret)));

            String json = null;
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(url, param, 30000, "WinFormFeiyu", Encoding.UTF8, null);

                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                json = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            catch (System.Net.WebException e)
            {
                MessageBox.Show(e.Message, "获取Token时发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                reader?.Close();
                stream?.Close();
            }

            if (String.IsNullOrEmpty(json))
            {
                return null;
            }
            NetResult result = JsonHelper.DeserializeJsonToObject<NetResult>(json);

            return result;
        }
    }
}