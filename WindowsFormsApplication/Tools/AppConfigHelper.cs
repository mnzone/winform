using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class AppConfigHelper
    {
        private static ExeConfigurationFileMap setting;
        public static String RootPath;

        public static ConfigurationSection GetSection(String key = "appSettings")
        {
            if (setting == null)
            {
                setting = new ExeConfigurationFileMap();
                setting.ExeConfigFilename = RootPath + ".config";
            }
            Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(setting, ConfigurationUserLevel.None);

            return config.GetSection(key);
        }

        /// <summary>
        /// 获取某项配置值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetAppSettingsValue(String key)
        {
            List<string> list = new List<string>();
            AppSettingsSection section = (AppSettingsSection)GetSection();
            return section.Settings[key].Value;

        }

        /// <summary>
        /// 设置配置项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string SetAppSettingsValue(String key, String value)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            file.ExeConfigFilename = RootPath + ".config";
            Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            var myApp = (AppSettingsSection)config.GetSection("appSettings");
            myApp.Settings[key].Value = value;
            config.Save();
            return value;
        }
    }
}
