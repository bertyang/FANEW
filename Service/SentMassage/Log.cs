using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[assembly: log4net.Config.DOMConfigurator(ConfigFile = "Web.config", Watch = true)]

namespace SentMassage
{
    public class Log4Net
    {
        //private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Log4Net));
        private static log4net.ILog Log;
        private Log4Net() { }
        static Log4Net()
        {
            Log = log4net.LogManager.GetLogger(typeof(Log4Net));
            string logFileName = AppDomain.CurrentDomain.BaseDirectory + "bin\\log4net.xml";
            //string logFileName = AppDomain.CurrentDomain.BaseDirectory + AppConfig.LogConfigFile;
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logFileName));
        }

        #region 记录各种类型 log

        /// <summary>
        /// 记录log信息
        /// </summary>
        /// <param name="Info">消息</param>
        public static void LogInfo(string Info)
        {
            Log.Info("[" + Info + "]");
        }

        /// <summary>
        /// 记录错误日志到文件
        /// </summary>
        /// <param name="ErrorPlace">错误出处</param>
        /// <param name="ErrorMsg">错误内容</param>
        public static void LogError(string ErrorPlace, string ErrorMsg)
        {
            Log.Error("[" + ErrorPlace + "]" + ErrorMsg);
        }

        /// <summary>
        /// 记录调试日志到文件
        /// </summary>
        /// <param name="BugPlace">记录出处</param>
        /// <param name="BugMsg">记录内容</param>
        public static void LogBug(string BugPlace, string BugMsg)
        {
            Log.Debug("[" + BugPlace + "]" + BugMsg);
        }

        /// <summary>
        /// 记录警告日志到文件
        /// </summary>
        /// <param name="BugPlace">记录出处</param>
        /// <param name="BugMsg">记录内容</param>
        public static void LogWarn(string WarnPlace, string WarnMsg)
        {
            Log.Warn("[" + WarnPlace + "]" + WarnMsg);
        }

        #endregion
    }
}
