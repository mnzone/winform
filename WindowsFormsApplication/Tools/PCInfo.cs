using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Tools
{
    public class PCInfo
    {
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns></returns>
        public String GetCPUString() {
            string cpuinfo = "";//cpu序列号
            ManagementClass cimobject = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc) {
                cpuinfo = mo.Properties["processorid"].Value.ToString();
            }
            return cpuinfo;
        }

        /// <summary>
        /// 获取MAC地址
        /// </summary>
        /// <returns></returns>
        public String GetMac() {
            String mac = null;
            ManagementClass mc = new ManagementClass("win32_networkadapterconfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc) {
                if ((bool)mo["ipenabled"]){
                    mac = mo["macaddress"].ToString();
                }   
                mo.Dispose();
            }
            return mac;
        }

        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        /// <returns></returns>
        public String GetDisk() {
            string hdid ="";
            ManagementClass cimobject = new ManagementClass("win32_diskdrive");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc) {
                hdid = (string)mo.Properties["model"].Value;
            }
            return hdid;
        }
        
    }
}
