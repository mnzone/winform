using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Tools;
using Update.Models;

namespace Update.Common
{
    public class NetApi
    {
        private static String domain = ConfigurationManager.AppSettings["domain"];
        private const String GetUrl = "/api/product/check_update/";

        public static Soft GetSoft(int id, String token)
        {   
            Soft soft = null;
            String url = String.Format("{0}{1}{2}.json?access_token={3}", domain, GetUrl, id, token);
            
            String json = null;
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                HttpWebResponse response = Tools.HttpWebResponseUtility.CreateGetHttpResponse(url, null, 30000,
                    "WinForm", null);
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                json = reader.ReadToEnd();
            }
            catch (System.Net.WebException e)
            {
                MessageBox.Show(e.Message, "更新异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                reader?.Close();
                stream?.Close();
            }

            NetResult result = JsonHelper.DeserializeJsonToObject<NetResult>(json);
            if (result.Status == "succ")
            {
                JObject item = result.Data as JObject;
                soft = new Soft(item);
            }

            return soft;
        }
    }
}
