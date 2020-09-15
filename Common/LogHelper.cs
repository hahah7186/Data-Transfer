using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Quickstarts.DataAccessClient
{
    //public class LoggerHelper
    //{
    //    /// <summary>
    //    /// 输出日志到Log4Net
    //    /// </summary>
    //    /// <param name="t"></param>
    //    /// <param name="ex"></param>
    //    #region static void WriteLog(Type t, Exception ex)

    //    public static void WriteLog(Exception ex)
    //    {
    //        log4net.ILog log = log4net.LogManager.GetLogger("LogisManager");
    //        log.Error("Error", ex);
    //    }

    //    #endregion

    //    /// <summary>
    //    /// 输出日志到Log4Net
    //    /// </summary>
    //    /// <param name="t"></param>
    //    /// <param name="msg"></param>
    //    #region static void WriteLog(Type t, string msg)

    //    public static void WriteLog(string msg)
    //    {
    //        log4net.ILog log = log4net.LogManager.GetLogger("LogisManager");
    //        log.Error(msg);
    //        log.Info(msg);
    //    }

    //    #endregion

    //}
    public class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void WriteLog(string info)
        {

            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }
    }
}
