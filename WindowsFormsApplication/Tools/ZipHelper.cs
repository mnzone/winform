
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class ZipHelper
    {
        #region 压缩

        /// <summary> 
        /// 递归压缩文件夹的内部方法 
        /// </summary> 
        /// <param name="folderToZip">要压缩的文件夹路径</param> 
        /// <param name="zipStream">压缩输出流</param> 
        /// <param name="parentFolderName">此文件夹的上级文件夹</param> 
        /// <returns></returns> 
        private static bool ZipDirectory(string folderToZip, ZipOutputStream zipStream, string parentFolderName)
        {
            bool result = true;
            string[] folders, files;
            ZipEntry ent = null;
            FileStream fs = null;
            Crc32 crc = new Crc32();

            try
            {
                ent = new ZipEntry(Path.Combine(parentFolderName, Path.GetFileName(folderToZip) + "/"));
                zipStream.PutNextEntry(ent);
                zipStream.Flush();

                files = Directory.GetFiles(folderToZip);
                foreach (string file in files)
                {
                    fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ent = new ZipEntry(Path.Combine(parentFolderName, Path.GetFileName(folderToZip) + "/" + Path.GetFileName(file)));
                    ent.DateTime = DateTime.Now;
                    ent.Size = fs.Length;

                    fs.Close();

                    crc.Reset();
                    crc.Update(buffer);

                    ent.Crc = crc.Value;
                    zipStream.PutNextEntry(ent);
                    zipStream.Write(buffer, 0, buffer.Length);
                }

            }
            catch
            {
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                if (ent != null)
                {
                    ent = null;
                }
                GC.Collect();
                GC.Collect(1);
            }

            folders = Directory.GetDirectories(folderToZip);
            foreach (string folder in folders)
                if (!ZipDirectory(folder, zipStream, folderToZip))
                    return false;

            return result;
        }

        /// <summary> 
        /// 压缩文件夹  
        /// </summary> 
        /// <param name="folderToZip">要压缩的文件夹路径</param> 
        /// <param name="zipedFile">压缩文件完整路径</param> 
        /// <param name="password">密码</param> 
        /// <returns>是否压缩成功</returns> 
        public static bool ZipDirectory(string folderToZip, string zipedFile, string password)
        {
            bool result = false;
            if (!Directory.Exists(folderToZip))
                return result;

            ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipedFile));
            zipStream.SetLevel(6);
            if (!string.IsNullOrEmpty(password)) zipStream.Password = password;

            result = ZipDirectory(folderToZip, zipStream, "");

            zipStream.Finish();
            zipStream.Close();

            return result;
        }

        /// <summary> 
        /// 压缩文件夹 
        /// </summary> 
        /// <param name="folderToZip">要压缩的文件夹路径</param> 
        /// <param name="zipedFile">压缩文件完整路径</param> 
        /// <returns>是否压缩成功</returns> 
        public static bool ZipDirectory(string folderToZip, string zipedFile)
        {
            bool result = ZipDirectory(folderToZip, zipedFile, null);
            return result;
        }

        /// <summary> 
        /// 压缩文件 
        /// </summary> 
        /// <param name="fileToZip">要压缩的文件全名</param> 
        /// <param name="zipedFile">压缩后的文件名</param> 
        /// <param name="password">密码</param> 
        /// <returns>压缩结果</returns> 
        public static bool ZipFile(string fileToZip, string zipedFile, string password)
        {
            bool result = true;
            ZipOutputStream zipStream = null;
            FileStream fs = null;
            ZipEntry ent = null;

            if (!File.Exists(fileToZip))
                return false;

            try
            {
                fs = File.OpenRead(fileToZip);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                fs = File.Create(zipedFile);
                zipStream = new ZipOutputStream(fs);
                if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
                ent = new ZipEntry(Path.GetFileName(fileToZip));
                zipStream.PutNextEntry(ent);
                zipStream.SetLevel(6);

                zipStream.Write(buffer, 0, buffer.Length);

            }
            catch
            {
                result = false;
            }
            finally
            {
                if (zipStream != null)
                {
                    zipStream.Finish();
                    zipStream.Close();
                }
                if (ent != null)
                {
                    ent = null;
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            GC.Collect();
            GC.Collect(1);

            return result;
        }

        /// <summary> 
        /// 压缩文件 
        /// </summary> 
        /// <param name="fileToZip">要压缩的文件全名</param> 
        /// <param name="zipedFile">压缩后的文件名</param> 
        /// <returns>压缩结果</returns> 
        public static bool ZipFile(string fileToZip, string zipedFile)
        {
            bool result = ZipFile(fileToZip, zipedFile, null);
            return result;
        }

        /// <summary> 
        /// 压缩文件或文件夹 
        /// </summary> 
        /// <param name="fileToZip">要压缩的路径</param> 
        /// <param name="zipedFile">压缩后的文件名</param> 
        /// <param name="password">密码</param> 
        /// <returns>压缩结果</returns> 
        public static bool Zip(string fileToZip, string zipedFile, string password)
        {
            bool result = false;
            if (Directory.Exists(fileToZip))
                result = ZipDirectory(fileToZip, zipedFile, password);
            else if (File.Exists(fileToZip))
                result = ZipFile(fileToZip, zipedFile, password);

            return result;
        }

        /// <summary> 
        /// 压缩文件或文件夹 
        /// </summary> 
        /// <param name="fileToZip">要压缩的路径</param> 
        /// <param name="zipedFile">压缩后的文件名</param> 
        /// <returns>压缩结果</returns> 
        public static bool Zip(string fileToZip, string zipedFile)
        {
            bool result = Zip(fileToZip, zipedFile, null);
            return result;

        }

        #endregion

        #region 解压

        /// <summary>
        /// 快速解压
        /// </summary>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="extractPath">解压路径</param>
        /// <param name="pwd">压缩密码</param>
        /// <param name="progressFun">进程</param>
        /// <param name="seconds">触发时间</param>
        public static void ExtractZipFile(string zipFilePath, string extractPath, string pwd, ProgressHandler progressFun, double seconds)
        {
            FastZipEvents events = new FastZipEvents();
            if (progressFun != null)
            {
                events.Progress = progressFun;
                events.ProgressInterval = TimeSpan.FromSeconds(seconds);
            }
            FastZip zip = new FastZip(events);

            zip.CreateEmptyDirectories = true;
            if (!string.IsNullOrEmpty(pwd))
                zip.Password = pwd;
            zip.UseZip64 = UseZip64.On;
            zip.RestoreAttributesOnExtract = true;
            zip.RestoreDateTimeOnExtract = true;
            zip.ExtractZip(zipFilePath, extractPath, FastZip.Overwrite.Always, null, "", "", true);
        }

        /// <summary>
        /// 快速解压
        /// </summary>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="extractPath">解压路径</param>
        /// <param name="pwd">密码</param>
        /// <param name="progressFun">进程</param>
        /// <param name="seconds">触发时间</param>
        /// <param name="completeFun">压缩过程中执行的函数</param>
        public static void UnZip(string zipFilePath, string extractPath, string pwd, ProgressHandler progressFun, double seconds, CompletedFileHandler completeFun)
        {
            FastZipEvents events = new FastZipEvents();
            if (progressFun != null)
            {
                events.Progress = progressFun;
                events.ProgressInterval = TimeSpan.FromSeconds(seconds);
            }
            if (completeFun != null)
            {
                events.CompletedFile = completeFun;
            }
            FastZip zip = new FastZip(events);

            zip.CreateEmptyDirectories = true;
            if (!string.IsNullOrEmpty(pwd))
                zip.Password = pwd;
            zip.UseZip64 = UseZip64.On;
            zip.RestoreAttributesOnExtract = true;
            zip.RestoreDateTimeOnExtract = true;
            zip.ExtractZip(zipFilePath, extractPath, FastZip.Overwrite.Always, null, "", "", true);
        }

        /// <summary>
        /// 获得压缩包内原文件总大小
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileFilter"></param>
        /// <param name="directoryFilter"></param>
        /// <returns></returns>
        public static long GetZipFileSize(string fileName, string fileFilter, string directoryFilter)
        {
            long b = 0;
            using (ZipFile zipFile = new ZipFile(fileName))
            {
                PathFilter localFileFilter = new PathFilter(fileFilter);
                PathFilter localDirFilter = new PathFilter(directoryFilter);

                if (zipFile.Count == 0)
                {
                    return 0;
                }
                for (int i = 0; i < zipFile.Count; ++i)
                {
                    ZipEntry e = zipFile[i];
                    if (e.IsFile)
                    {
                        string path = Path.GetDirectoryName(e.Name);
                        if (localDirFilter.IsMatch(path))
                        {
                            if (localFileFilter.IsMatch(Path.GetFileName(e.Name)))
                            {
                                b += e.Size;
                            }
                        }
                    }
                }
            }
            return b;
        }

        /// <summary>
        /// 获得MD5校验码
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetMD5(string filepath)
        {
            string returnStr = "";
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5byte = md5.ComputeHash(fs);
            int i, j;
            foreach (byte b in md5byte)
            {
                i = Convert.ToInt32(b);
                j = i >> 4;
                returnStr += Convert.ToString(j, 16);
                j = ((i << 4) & 0x00ff) >> 4;
                returnStr += Convert.ToString(j, 16);
            }
            fs.Dispose();
            return returnStr;
        }

        /// <summary>
        /// 解压缩特定文件名的文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="addres">解压缩路径</param>
        /// <param name="zipFileName">文件名称</param>
        /// <param name="pwd">解压缩包密码</param>
        public static void UnZip(string path, string addres, string zipFileName, string pwd)
        {
            ZipInputStream ZipStream = new ZipInputStream(System.IO.File.OpenRead(path));
            if (!string.IsNullOrEmpty(pwd))
                ZipStream.Password = pwd;
            ZipEntry fileEntry;
            while ((fileEntry = ZipStream.GetNextEntry()) != null)
            {
                string filename = Path.GetFileName(fileEntry.Name);
                if (filename == zipFileName)
                {
                    filename = addres + "\\" + filename;
                    FileStream streamWriter = System.IO.File.Create(filename);
                    int size = (int)fileEntry.Size;
                    byte[] buffer = new byte[size];

                    size = ZipStream.Read(buffer, 0, size);
                    streamWriter.Write(buffer, 0, size);
                    streamWriter.Close();
                }
            }
            ZipStream.Close();
        }

        #endregion
    }
}
