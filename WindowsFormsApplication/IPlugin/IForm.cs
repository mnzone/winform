using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPlugin
{
    public interface IForm
    {
        /// <summary>
        /// 启动窗体
        /// </summary>
        void Start();

        /// <summary>
        /// 停止窗体
        /// </summary>
        void Stop();

        /// <summary>
        /// 获取当前窗体正在执行的描述
        /// </summary>
        /// <returns>描述窗体进行操作的内容</returns>
        String GetProcessText();

        /// <summary>
        /// 是否可以进入下一个操作窗体
        /// </summary>
        /// <returns></returns>
        Boolean IsNext();
    }
}
