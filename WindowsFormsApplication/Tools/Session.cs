using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Utils
    {
        public static String Replicate(String word, int count) {
            String replicateStr = "";
            for(int i = 0;i < count;i ++){
                replicateStr += word;
            }
            return replicateStr;
        }
    }

    public class LogTool {
        private static ILog log = null;

        public static void SetInfoLog(String msg, Exception e) {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace.ToString());
            if(log.IsInfoEnabled){
                if(e == null){
                    log.Info(msg);
                }else{
                    log.Info(msg, e);
                }                
            }
        }

        public static void SetErrLog(String msg, Exception e) {
            log = LogManager.GetLogger("LogFileAppender");
            if(log.IsErrorEnabled){
                if(e == null){
                    log.Error(msg);
                }else{
                    log.Error(msg, e);
                }                
            }
        }

        public static void SetWarnLog(String msg, Exception e) {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace.ToString());
            if(log.IsWarnEnabled){
                if(e == null){
                    log.Warn(msg);
                }else{
                    log.Warn(msg, e);
                }                
            }
        }

        public static void SetFatalLog(String msg, Exception e) {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace.ToString());
            if(log.IsFatalEnabled){
                if(e == null){
                    log.Fatal(msg);
                }else{
                    log.Fatal(msg, e);
                }                
            }
        }

        public static void SetDebugLog(String msg, Exception e) {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace.ToString());
            if(log.IsDebugEnabled){
                if(e == null){
                    log.Debug(msg);
                }else{
                    log.Debug(msg, e);
                }                
            }
        }

        public static void SetInfoLog(String msg) {
            SetInfoLog(msg, null);
        }

        public static void SetErrLog(String msg) {
            SetErrLog(msg, null);
        }

        public static void SetWarnLog(String msg) {
            SetWarnLog(msg, null);
        }

        public static void SetFatalLog(String msg) {
            SetFatalLog(msg, null);
        }

        public static void SetDebugLog(String msg) {
            SetDebugLog(msg, null);
        }
    }

    public class Session
    {
        private static Dictionary<string, object> session = new Dictionary<string, object>();

        public static void setAttribute(String key, Object value) {
            if (!session.ContainsKey(key)) {
                session.Add(key, value);
            } else {
                session[key] = value;
            }
        }

        public static Object getAttribute(String key) {
            if (!session.ContainsKey(key)) {
                return null;
            }
            return session[key];
        }
    }
}
