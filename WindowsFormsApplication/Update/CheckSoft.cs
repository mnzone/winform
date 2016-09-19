using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using Update.Common;
using Update.Models;

namespace Update
{
    public class CheckSoft
    {
        private String text;
        private Boolean overFlag;

        public void CheckUpdate(long build)
        {
            Soft soft = null;
            try {
                text = "正在连接服务器...";
                soft = NetApi.GetSoft(2);
            } catch (System.Net.WebException ex) {
                text = "获取数据时发生异常:" + ex.Message;
            }

            if(soft == null || soft.Build <= build){
                text = "未找到相关数据";
                overFlag = true;
                return;
            }

            text = "发现新版本!";
            Tools.AppConfigHelper.RootPath = Application.ExecutablePath;
            Tools.AppConfigHelper.SetAppSettingsValue("UpdateFlag", "true");
            Tools.AppConfigHelper.SetAppSettingsValue("Ver", soft.Version);
            Tools.AppConfigHelper.SetAppSettingsValue("UpdatePackageFileName", soft.Packages[0].Name);
            Tools.AppConfigHelper.SetAppSettingsValue("UpdatePackagePassword", soft.Packages[0].Password);

            String host = AppConfigHelper.GetAppSettingsValue("domain");
            String url = String.Format("{0}/api/product/service/download_package/{1}?access_token=123", host, soft.Packages[0].Id);
            text = "正在下载更新包...";
            DownloadFile(url, soft.Packages[0].Name + ".zip", null);
        }

        public Boolean IsOver() {
            return overFlag;
        }

        public String GetText() {
            return this.text;
        }

        /// <summary>        
        /// 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>
        /// <param name="Filename">下载后的存放地址</param>        
        /// <param name="Prog">用于显示的进度条</param>        
        /// 
        public void DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    text = "当前补丁下载进度" + percent.ToString() + "%";
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则text将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception e)
            {
                overFlag = true;
                Console.WriteLine("下载失败：" + e.Message);
            }
            text = "更新包下载完成，请重启软件进行更新。";
            overFlag = true;
        }
    }
}
