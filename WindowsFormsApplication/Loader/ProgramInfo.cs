using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Loader
{
    public class ProgramInfo
    {
        /// <summary>
        /// 获取文件版本
        /// </summary>
        /// <returns>版本号</returns>
        public string GetFileVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(asm.Location);
            return ver.FileVersion.Replace(".", "");
        }

        /// <summary>
        /// 获取产品版本
        /// </summary>
        /// <returns>版本号</returns>
        public string GetProductVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(asm.Location);
            return ver.ProductVersion;
        }

        /// <summary>
        /// 获取产品GUID
        /// </summary>
        /// <returns>GUID串</returns>
        public string GetProductGuid()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var attrs = asm.GetCustomAttributes(false).OfType<System.Runtime.InteropServices.GuidAttribute>();
            if (attrs.Any()) {
                return attrs.First().Value;
            }
            return null;
        }
    }
}
