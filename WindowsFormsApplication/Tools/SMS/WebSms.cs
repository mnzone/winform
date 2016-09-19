using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Tools.SMS
{
    public class WebSms : ISms
    {
        private String user, userPwd;

        public object SendSms(string msg, List<string> phone)
        {
            if(phone == null || phone.Count < 1){
                throw new Exception("手机号码列表为空！");
            }
            int row = 0;
            String phones = "";
            foreach(String item in phone){
                phones += item + "," ;
            }
            if(phones == null || phones.Length < 11){
                throw new Exception("手机号码有误！");
            }
            phones = phones.Substring(0, phones.Length - 1);
            String url = String.Format("http://120.132.132.133/WS/BatchSend2.aspx?CorpID={0}&Pwd={1}&Mobile={2}&Content={3}&Cell=&SendTime=", user, userPwd, phones, System.Web.HttpUtility.UrlEncode(msg, System.Text.Encoding.GetEncoding("GB2312")));
            try {
                WebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url , null, 1000 * 30, null, null);
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                String results = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
                row = Convert.ToInt32(results);
            }catch(Exception e){
                throw e;
            }
            return row;
        }

        public void SetUserInfo(string user, string userPwd)
        {
            this.user = user;
            this.userPwd = userPwd;
        }

        public int SearchSmsCount(string user, string userPwd)
        {
            int row = 0;
            String url = String.Format("http://120.132.132.133/WS/SelSum.aspx?CorpID={0}&Pwd={1}", user, userPwd);
            try {
                WebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url , null, 1000 * 30, null, null);
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                String results = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
                row = Convert.ToInt32(results);
            }catch(Exception e){
                throw e;
            }
            return row;
        }

        public int SearchSmsCount()
        {
            return SearchSmsCount(user, userPwd);
        }


        public void SetParameter(string[] args)
        {
            
        }
    }
}
