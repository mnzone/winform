using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tools;
using Update.Models;

namespace Update.Common
{
    public class NetApi
    {
        private static String domain = ConfigurationManager.AppSettings["domain"];
        private const String baseUrl = "/api";
        private const String ProductBaseUrl = baseUrl + "/product/service";
        private const String GetUrl = ProductBaseUrl + "/get";

        private const String GetPackageUrl = ProductBaseUrl + "/download_package";

        public static Soft GetSoft(int id)
        {
            Soft soft = null;
            String url = String.Format("{0}{1}/{2}", domain, GetUrl, id);

            IDictionary<String, Object> param = new Dictionary<String, Object>();
            param.Add("access_token", "123456");

            HttpWebResponse response = Tools.HttpWebResponseUtility.CreateGetHttpResponse(url, param, 30000, "WinForm", null);
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
