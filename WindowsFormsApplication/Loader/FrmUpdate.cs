using Loader.Common;
using Loader.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Loader
{
    public partial class FrmUpdate : Form
    {
        private String RUN_PATH = "";       //运行目录
        private String PG_ROOT_PATH = "";   //程序根目录
        private String BACKUP_PATH = "";    //备份目录
        private String UPDATE_PATH = "";    //更新文件目录

        private String updateFileName = "";
        private String ver = "";
        private UpdateInfo updateEntity = null;
        private List<UpdateItem> files = null;

        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {

            initPath();

            String fileName = AppConfigHelper.GetAppSettingsValue("UpdatePackageFileName");
            String password = AppConfigHelper.GetAppSettingsValue("UpdatePackagePassword");

            //解压文件
            unzip(fileName, "update", password);
            
            //解析升级配置文件，获得待升级文件列表
            getPackageConfig(fileName);
            //获取当前程序信息

            //替换需要升级的程序文件
            update();
            //升级完成
        }

        private void initPath() {
            RUN_PATH = Application.StartupPath;
            int index = RUN_PATH.LastIndexOf("\\");
            PG_ROOT_PATH = RUN_PATH.Substring(0, index);
            index = PG_ROOT_PATH.LastIndexOf("\\");
            PG_ROOT_PATH = PG_ROOT_PATH.Substring(0, index);

            RUN_PATH += "\\";
            BACKUP_PATH = String.Format(@"{0}\backup\", RUN_PATH);
            UPDATE_PATH = String.Format(@"{0}\update\", RUN_PATH);
        }

        #region 压缩及解压缩
        private void UnzipProgree(object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e) {
            this.labStatus.Text = String.Format("正在解压：{0},已完成{1}%", e.Name, e.Processed);
        }

        private void UnzipCompleted(object sender, ICSharpCode.SharpZipLib.Core.ScanEventArgs e) {
            this.labStatus.Text = String.Format("正在解压：{0},已完成。", e.Name);
        }

        /// <summary>
        /// 解压升级文件
        /// </summary>
        private void unzip(String zipFile, String targetFile, String password) {
            ICSharpCode.SharpZipLib.Core.ProgressHandler progress = new ICSharpCode.SharpZipLib.Core.ProgressHandler(UnzipProgree);
            ICSharpCode.SharpZipLib.Core.CompletedFileHandler complated = new ICSharpCode.SharpZipLib.Core.CompletedFileHandler(UnzipCompleted);

            String file = String.Format(@"{0}\{1}.zip", Application.StartupPath, zipFile);
            ZipHelper.UnZip(file, targetFile, password, progress, 20, complated);
        }

        /// <summary>
        /// 解压升级文件
        /// </summary>
        private void zip()
        {
            ver = DateTime.Now.ToString("yyyyMMddhhmmss");
            updateFileName = ver;
            ZipHelper.ZipDirectory("update", updateFileName + ".zip", "123456");
        }

        #endregion

        /// <summary>
        /// 获取升级包配置
        /// </summary>
        /// <param name="fileName">配置文件名</param>
        private void getPackageConfig(String fileName) {
            String path = String.Format(@"{0}\update\{1}\list.xml", Application.StartupPath, fileName);
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;

            //获取更新信息
            XmlNode info = root.SelectSingleNode("/pagkage/info");
            this.updateEntity = new UpdateInfo();
            this.updateEntity.Id = Convert.ToInt32(info["id"].InnerText);
            this.updateEntity.Ver = info["ver"].InnerText;

            //获取文件列表
            XmlNodeList fileNodes = root.SelectNodes("/pagkage/files/file");
            this.files = new List<UpdateItem>();
            foreach (XmlNode file in fileNodes) {
                UpdateItem item = new UpdateItem();
                item.FileName = file["name"].InnerText;
                item.Title = file["title"].InnerText;
                item.Desc = file["desc"].InnerText;
                item.From = String.Format(file["from"].InnerText, UPDATE_PATH);
                item.To = String.Format(file["to"].InnerText, RUN_PATH);
                this.files.Add(item);
            }
            this.updateEntity.Items = this.files;
        }

        /// <summary>
        /// 获取程序配置
        /// </summary>
        private void getProgramConfig() { }

        /// <summary>
        /// 升级
        /// </summary>
        private void update() {
            foreach (UpdateItem file in this.files) {
                if (! File.Exists(file.From)) {
                    //文件不存在
                    continue;
                }else if(File.Exists(file.To)){
                    //备份文件
                    String target = String.Format(@"{0}{1}\", BACKUP_PATH, updateEntity.Ver);
                    createDirectory(updateEntity.Ver);

                    if(! String.IsNullOrEmpty(file.Backup)){
                        target += file.Backup;
                        createDirectory(updateEntity.Ver + "\\" + file.Backup);
                    }
                    
                    target += file.FileName;
                    File.Move(file.To, target);
                }

                //升级
                File.Move(file.From, file.To);
            }

            AppConfigHelper.SetAppSettingsValue("UpdateFlag", "false");
            AppConfigHelper.SetAppSettingsValue("UpdatePackageFileName", "");
            AppConfigHelper.SetAppSettingsValue("UpdatePackagePassword", "");
            AppConfigHelper.SetAppSettingsValue("ver", updateEntity.Ver);
        }

        private void createDirectory(String path) {
            String[] paths = path.Split('\\');
            String tempPath = BACKUP_PATH;
            foreach(String item in paths){
                tempPath = String.Format(@"{0}\{1}", tempPath, item);
                if( ! Directory.Exists(tempPath)){
                    Directory.CreateDirectory(tempPath);
                }
            }
        }
    }
}
