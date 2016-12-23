using System;
using System.IO;

namespace MemberCard.Common
{
    public class FileTools
    {

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="msg">日志内容</param>
        /// <returns></returns>
        public static bool Writer(String fileName, String msg)
        {
            bool flag = false;

            //判断目录是否存在 
            int index = fileName.LastIndexOf("/");
            System.IO.Directory.CreateDirectory(fileName.Substring(0, index));

            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine(msg);
                flag = true;
            }

            return flag;
        }
    }
}