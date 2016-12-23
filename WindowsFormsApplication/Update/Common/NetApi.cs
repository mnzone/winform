using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;
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
            
            HttpWebResponse response = Tools.HttpWebResponseUtility.CreateGetHttpResponse(url, null, 30000, "WinForm", null);
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String json = reader.ReadToEnd();

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
