using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader
{
    static class Program
    {
        public static String loaderImage = "";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            String path = Application.StartupPath;
            loaderImage = path + System.Configuration.ConfigurationManager.AppSettings["bootstrapImage"];
            Image image = null;
            try { 
                image = Image.FromFile(loaderImage);
            }catch(System.IO.FileNotFoundException e){
                MessageBox.Show("文件丢失：" + e.Message, "加载错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLoader(image.Width, image.Height));
        }
    }
}
