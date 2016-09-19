using IPlugin;
using Loader.Common;
using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private long buildUI = 0;
        private long buildUpdate = 0;
        private long buildLoader = 0;
        private long buildModel = 0;
        private long buildTool = 0;

        private String module = "";
        private String main = "";

        private SkinEngine skin = null;


        public FrmLoader()
        {
            InitializeComponent();
            skin = new SkinEngine();
            skin.SkinFile = Application.StartupPath + @"\Assets\Skins\Calmness.ssk";
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
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_ACTIVATE);
            
            this.module = AppConfigHelper.GetAppSettingsValue("Module");
            this.main = AppConfigHelper.GetAppSettingsValue("Main");

            //获取所有DLL信息
            GetDllVersion();
            //检查更新
            LoadUpdate();
            //执行更新操作
            //进入系统
            //LoadUpdate();
            //
            //LoadLogin();
        }

        /// <summary>
        /// 获取必要库版本信息
        /// </summary>
        private void GetDllVersion() {
            this.labStatus.Text = "正在获取版本信息...";
            try {
                //获得UI库版本
                Type type = this.GetTypeObject(this.module, String.Format("{0}.ProgramInfo", this.module));
                buildUI = Convert.ToInt64(InvokeObject(type, "GetFileVersion"));

                //获得Update库版本
                type = this.GetTypeObject("Update", "Update.ProgramInfo");
                buildUpdate = Convert.ToInt64(InvokeObject(type, "GetFileVersion"));

                //获得Model库版本
                type = this.GetTypeObject("Models", "Models.ProgramInfo");
                buildModel = Convert.ToInt64(InvokeObject(type, "GetFileVersion"));

                //获得Tool库版本
                type = this.GetTypeObject("Tools", "Tools.ProgramInfo");
                buildTool = Convert.ToInt64(InvokeObject(type, "GetFileVersion"));
            }catch(System.IO.IOException e){
                MessageBox.Show(e.Message, "缺少必要文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
        }

        /// <summary>
        /// 检测程序是否有更新
        /// </summary>
        private void LoadUpdate() {
            this.labStatus.Text = "正在检查更新...";
            Type type = this.GetTypeObject("Update", "Update.CheckSoft");
            //获取方法
            MethodInfo main = type.GetMethod("CheckUpdate");
            //实例化对象
            Object obj = Activator.CreateInstance(type);

            main.Invoke(obj, new Object[] { buildUI });

            this.currentForm = type;
            this.currentObject = obj;
            this.currentMethod = type.GetMethod("IsOver");
            this.timerCheck.Start();
        }

        /// <summary>
        /// 处理更新包
        /// </summary>
        private void UpdateSoft() {
            this.labStatus.Text = "正在升级...";
            Type type = this.GetTypeObject("Update", "Update.SetupPackage");
            //获取方法
            MethodInfo main = type.GetMethod("Load");
            //实例化对象
            Object obj = Activator.CreateInstance(type);
            main.Invoke(obj, null);
            
            //开始查下一个操作
            this.currentForm = type;
            this.currentObject = obj;
            this.currentMethod = type.GetMethod("IsOver");
            this.timerCheck.Start();
        }

        /// <summary>
        /// 加载登录页
        /// </summary>
        private void LoadLogin() {
            this.labStatus.Text = "正在加载资源...";
            Type type = this.GetTypeObject(this.module, String.Format("{0}.{1}", this.module, this.main));
            //获取方法
            MethodInfo main = type.GetMethod("Start");
            //实例化对象
            Object obj = Activator.CreateInstance(type);
            main.Invoke(obj, null);
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            Object result = this.currentMethod.Invoke(this.currentObject, null);

            if ((Boolean)result)
            {
                timerCheck.Stop();
                if (this.currentForm.Name == "CheckSoft")
                {
                    bool updateFlag = Convert.ToBoolean(AppConfigHelper.GetAppSettingsValue("UpdateFlag"));
                    if (updateFlag) {
                        UpdateSoft();
                    }else{
                        this.Hide();
                        //更新完成进入系统
                        LoadLogin();
                    }
                }
                else if (this.currentForm.Name == "SetupPackage")
                {
                    this.Hide();
                    //更新完成进入系统
                    LoadLogin();
                }
            }
        }

        /// <summary>
        ///  获取指定Dll中的指定对象类型
        /// </summary>
        /// <param name="dllFileName">DLL文件名(如:abc.dll)</param>
        /// <param name="typeName">类型名称(如：People)</param>
        /// <returns></returns>
        private Type GetTypeObject(String dllFileName, String typeName) {
            Assembly assembly = Assembly.LoadFile(String.Format(@"{0}\{1}.dll", Application.StartupPath, dllFileName));
            Type type = assembly.GetType(typeName);
            return type;
        }

        /// <summary>
        /// 执行指定方法
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="methodName">方法名称</param>
        /// <returns>获取方法返回的值</returns>
        private Object InvokeObject(Type type, String methodName) {
            //获取方法
            MethodInfo getFileVer = type.GetMethod(methodName);
            //实例化对象
            Object programInfo = Activator.CreateInstance(type);
            return getFileVer.Invoke(programInfo, null);
        }

        private void InvokeObject(Type type, String methodName, Object[] param) {
            //获取方法
            MethodInfo main = type.GetMethod(methodName);
            //实例化对象
            Object obj = Activator.CreateInstance(type);
            main.Invoke(obj, param);
        }
    }
}
