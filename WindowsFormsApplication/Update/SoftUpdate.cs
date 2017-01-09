using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using DelegateLibrary;
using Tools;
using Update.Common;
using Update.Models;

namespace Update
{
    public class SoftUpdate
    {
        private UpdatedCallback updateStatusCallback;
        private UpdatedService updateService;
        private String applicationRootPath;
        private String updatePackagePath;
        private String backupPath;

        public UpdatedCallback UpdateStatusCallback
        {
            get
            {
                return updateStatusCallback;
            }

            set
            {
                updateStatusCallback = value;
            }
        }

        public UpdatedService UpdateService
        {
            get
            {
                return updateService;
            }

            set
            {
                updateService = value;
            }
        }

        public long check(long nowBuild)
        {
            this.applicationRootPath = Application.StartupPath + @"\";

            this.backupPath = String.Format(@"{0}\backup\", this.applicationRootPath);
            this.updatePackagePath = String.Format(@"{0}\update\", this.applicationRootPath);

            Soft soft = this.checkUpdate(nowBuild);
            if (soft == null)
            {
                return nowBuild;
            }

            if (!this.downloadPackage(soft))
            {
                return nowBuild;
            }

            this.unZipPackage(soft.Packages[0].Name, "update", soft.Packages[0].Password);

            UpdateInfo updateContent = this.getPackageConfig(soft.Packages[0].Name);
            this.update(updateContent);
            return soft.Build;
        }

        /// <summary>
        /// 检测是否有新版本
        /// </summary>
        /// <param name="build">当前版本</param>
        /// <returns>有新版本则返回软件信息，无新版本时则返回null</returns>
        public Soft checkUpdate(long build)
        {

            String softID = ConfigurationManager.AppSettings["SoftID"];
            IniFile file = new IniFile(String.Format("{0}/application.cache", Application.StartupPath));

            Soft soft = null;
            try
            {
                UpdateStatusCallback?.Invoke("正在连接服务器...", -1);
                soft = NetApi.GetSoft(Convert.ToInt32(softID), file.IniReadValue("AccessToken", "token"));
            }
            catch (System.Net.WebException ex)
            {
                UpdateStatusCallback?.Invoke("获取数据时发生异常:" + ex.Message, 1);
                return null;
            }

            if (soft == null || soft.Build <= build)
            {
                UpdateStatusCallback?.Invoke("未发现新版本", 0);
                return null;
            }

            UpdateStatusCallback?.Invoke("发现新版本!", -1);

            return soft;
        }

        /// <summary>
        /// 根据版本号下载更新包
        /// </summary>
        /// <param name="build">最新版更新包实体</param>
        private bool downloadPackage(Soft build)
        {
            IniFile file = new IniFile(String.Format("{0}/application.cache", Application.StartupPath));

            AppConfigHelper.RootPath = Application.StartupPath;
            
            String host = ConfigurationManager.AppSettings["domain"];
            String url = String.Format("{0}/api/product/download/{1}.json?access_token={2}", host, build.Packages[0].Id, file.IniReadValue("AccessToken", "token"));
            UpdateStatusCallback?.Invoke("正在下载更新包...", -1);

            String fileName = build.Packages[0].Name + ".zip";

            System.Windows.Forms.ProgressBar prog = null;
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
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
                    UpdateStatusCallback?.Invoke("当前补丁下载进度" + percent.ToString() + "%", -1);
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则text将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception e)
            {
                UpdateStatusCallback?.Invoke("下载失败：" + e.Message, 10);
                return false;
            }
            UpdateStatusCallback?.Invoke("更新包下载完成，请稍候...", 0);

            return true;
        }

        /// <summary>
        /// 解压更新包
        /// </summary>
        private void unZipPackage(String zipFile, String targetFile, String password)
        {
            ICSharpCode.SharpZipLib.Core.ProgressHandler progress = new ICSharpCode.SharpZipLib.Core.ProgressHandler(UnzipProgree);
            ICSharpCode.SharpZipLib.Core.CompletedFileHandler complated = new ICSharpCode.SharpZipLib.Core.CompletedFileHandler(UnzipCompleted);

            String file = String.Format(@"{0}\{1}.zip", Application.StartupPath, zipFile);
            ZipHelper.UnZip(file, targetFile, password, progress, 20, complated);
        }


        /// <summary>
        /// 获取升级包配置
        /// </summary>
        /// <param name="fileName">配置文件名</param>
        /// <returns>返回待升级对象实体</returns>
        private UpdateInfo getPackageConfig(String fileName)
        {
            String path = String.Format(@"{0}\update\{1}\list.xml", Application.StartupPath, fileName);
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;

            //获取更新信息
            XmlNode info = root.SelectSingleNode("/pagkage/info");

            UpdateInfo updateContent = new UpdateInfo();
            updateContent.Id = Convert.ToInt32(info["id"].InnerText);
            updateContent.Ver = info["ver"].InnerText;

            //获取文件列表
            XmlNodeList fileNodes = root.SelectNodes("/pagkage/files/file");
            updateContent.Items = new List<UpdateItem>();
            foreach (XmlNode file in fileNodes)
            {
                UpdateItem item = new UpdateItem();
                item.FileName = file["name"].InnerText;
                item.Title = file["title"].InnerText;
                item.Desc = file["desc"].InnerText;
                item.From = String.Format(file["from"].InnerText, this.updatePackagePath);
                item.To = String.Format(file["to"].InnerText, this.applicationRootPath);
                updateContent.Items.Add(item);
            }

            return updateContent;
        }

        
        /// <summary>
        /// 安装更新包
        /// </summary>
        /// <param name="info">更新包信息</param>
        private void update(UpdateInfo info)
        {
            foreach (UpdateItem file in info.Items)
            {
                if (!File.Exists(file.From))
                {
                    //文件不存在
                    continue;
                }
                else if (File.Exists(file.To))
                {
                    //备份文件
                    String target = String.Format(@"{0}{1}\", backupPath, info.Ver);
                    createDirectory(info.Ver);

                    if (!String.IsNullOrEmpty(file.Backup))
                    {
                        target += file.Backup;
                        createDirectory(info.Ver + "\\" + file.Backup);
                    }

                    target += file.FileName;
                    File.Move(file.To, target);
                }

                //升级
                File.Move(file.From, file.To);
            }
        }

        private void createDirectory(String path)
        {
            String[] paths = path.Split('\\');
            String tempPath = backupPath;
            foreach (String item in paths)
            {
                tempPath = String.Format(@"{0}\{1}", tempPath, item);
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
            }
        }

        #region 解压缩回调
        private void UnzipProgree(object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e)
        {
            UpdateStatusCallback?.Invoke(String.Format("正在解压：{0},已完成{1}%", e.Name, e.Processed), -1);
        }

        private void UnzipCompleted(object sender, ICSharpCode.SharpZipLib.Core.ScanEventArgs e)
        {
            UpdateStatusCallback?.Invoke(String.Format("正在解压：{0},已完成。", e.Name), -1);
        }

        #endregion
    }
}