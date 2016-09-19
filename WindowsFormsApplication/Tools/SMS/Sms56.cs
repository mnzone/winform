using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Tools.SMS
{
    public class Sms56 : ISms
    {
        private String user, userPwd;
        private String[] parms = null;

        public object SendSms(string msg, List<string> phone)
        {
            if(phone == null || phone.Count < 1){
                throw new Exception("手机号码为空！");
            }
            int row = 0;
            String url = String.Format("http://api.56dxw.com/sms/HttpInterface.aspx?comid={0}&username={1}&userpwd={2}&handtel={3}&sendcontent={4}&sendtime=&smsnumber={5}",
                parms[0], parms[1], parms[2], phone[0], System.Web.HttpUtility.UrlEncode(msg, System.Text.Encoding.GetEncoding("GB2312")), parms[3]);
            try {
                WebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url, null, 1000 * 30, null, null);
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
            String url = String.Format("http://api.56dxw.com/sms/HttpInterfaceR.aspx?comid={0}&username={1}&userpwd={2}&newpwd=&action=moneyc", parms[0], parms[1], parms[2]);
            try {
                WebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url , null, 1000 * 30, null, null);
                System.IO.Stream stream = response.GetResponseStream();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                String results = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
                row = Convert.ToInt32(results);
            }catch(Exception e){
                //throw e;
            }
            return row;
        }

        public int SearchSmsCount()
        {
            return SearchSmsCount(user, userPwd);
        }


        public void SetParameter(string[] args)
        {
            parms = args;
        }
    }
}
