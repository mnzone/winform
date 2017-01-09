using DelegateLibrary;
using Sunisoft.IrisSkin;
using System;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Loader.Common;
using Newtonsoft.Json.Linq;
using Tools;
using Update;
using Update.Models;
using AppConfigHelper = Tools.AppConfigHelper;

namespace Loader
{
    public partial class FrmLoader : Form
    {
        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);

        //dwflag的取值如下
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        //从左到右显示
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        //从右到左显示
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        //从上到下显示
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        //从下到上显示
        public const Int32 AW_CENTER = 0x00000010;
        //若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口

        public const Int32 AW_HIDE = 0x00010000;
        //隐藏窗口，缺省则显示窗口
        public const Int32 AW_ACTIVATE = 0x00020000;
        //激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        public const Int32 AW_SLIDE = 0x00040000;
        //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        public const Int32 AW_BLEND = 0x00080000;
        //透明度从高到低

        //当前正在使用的窗体对象
        private Type currentForm = null;

        private Object currentObject = null;
        private MethodInfo currentMethod = null;
        
        private String module = "";
        private String main = "";

        private SkinEngine skin = null;

        private String SoftID = ConfigurationManager.AppSettings["SoftID"];
        private String AppID = ConfigurationManager.AppSettings["AppID"];
        private long SoftBuild = Convert.ToInt64(ConfigurationManager.AppSettings["SoftBuild"]);
        private String AppSecret = ConfigurationManager.AppSettings["AppSecret"];
        private String GUID = ConfigurationManager.AppSettings["GUID"];


        public FrmLoader()
        {
            InitializeComponent();
            skin = new SkinEngine();
            skin.SkinFile = Application.StartupPath + @"\Assets\Skins\Calmness.ssk";
            CheckForIllegalCrossThreadCalls = false;
        }

        public FrmLoader(int width, int height)
        {
            InitializeComponent();
            //设置背景图片
            try {
                this.BackgroundImage = Image.FromFile(Program.loaderImage);
            }catch(System.IO.FileNotFoundException e){
                MessageBox.Show(e.Message, "Loader错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
            //设置窗体大小
            this.Width = width;
            this.Height = height;
        }

        private void FrmLoader_Load(object sender, EventArgs e)
        {
            loadINI();
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_ACTIVATE);
            
            this.module = Common.AppConfigHelper.GetAppSettingsValue("Module");
            this.main = Common.AppConfigHelper.GetAppSettingsValue("Main");

            //检查更新
            Thread mainThread = new Thread(checkUpdate);
            mainThread.Start();
        }

        private void loadINI()
        {
            IniFile iniFile = new IniFile(String.Format("{0}/application.cache", Application.StartupPath));
            String expired = iniFile.IniReadValue("AccessToken", "expired");
            if (String.IsNullOrEmpty(expired)
                || Convert.ToInt64(expired) < TimeStamp.GetNowTimeStamp())
            {
                String[] token = GetAccessToken(AppID, AppSecret);
                if (token == null)
                {
                    return;
                }
                iniFile.IniWriteValue("AccessToken", "token", token[0]);
                iniFile.IniWriteValue("AccessToken", "expired", token[1]);
            }

        }

        public static String[] GetAccessToken(String appId, String appSecret)
        {
            NetResult result = NetApi.GetAccessToken(appId, appSecret);
            if (result == null || result.Status == "err")
            {
                return null;
            }
            JObject item = result.Data as JObject;

            return new String[] { item["access_token"].ToString(), item["access_expired"].ToString() };
        }

        private void checkUpdate()
        {
            CallbackMsg runMsg = this.setLableInfo;
            Invoke(runMsg, "正在检查更新...");
            SoftUpdate update = new SoftUpdate();
            update.UpdateStatusCallback = this.setLableInfo;
            long build = update.check(SoftBuild);
            if (build > SoftBuild)
            {
                //修改SoftBuild值
                AppConfigHelper.RootPath = Application.ExecutablePath;
                AppConfigHelper.SetAppSettingsValue("SoftBuild", build.ToString());
            }
            Invoke(runMsg, "hidden");

            //更新完成进入系统
            Invoke(runMsg, "正在加载资源...");
            Invoke(runMsg, "BootMain");
        }

        private void setLableInfo(String text, int code)
        {
            CallbackMsg runMsg = this.setLableInfo;
            Invoke(runMsg, text);
        }

        /// <summary>
        /// 设置状态标签内容
        /// </summary>
        /// <param name="text"></param>
        private void setLableInfo(String text)
        {
            if (text == "hidden")
            {
                this.Hide();
                return;
            }
            else if (text == "BootMain")
            {
                Type type = ReflectionTools.GetTypeObject(Application.StartupPath, this.module, String.Format("{0}.{1}", this.module, this.main));
                //获取方法
                MethodInfo main = type.GetMethod("Start");
                //实例化对象
                Object obj = Activator.CreateInstance(type);
                main.Invoke(obj, null);
                return;
            }
            this.labStatus.Text = text;
        }
    }
}
