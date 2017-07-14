using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config",Watch = true)]
namespace Saylor.CommonTool.Log
{
    public class Log4NetHelper
    {
        static ILog m_log;
        
        static Log4NetHelper()
        {
            m_log = LogManager.GetLogger("Logger");
            log4net.Config.XmlConfigurator.Configure();
        }


        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>


        public static void WriteErrorLog(Exception ex)
        {
            m_log.Error("Error", ex);
        }


        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>

        public static void WriteErrorLog(string msg)
        {
            m_log.Error(msg);
        }

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>

        public static void WriteInfoLog(string msg)
        {
            m_log.Info(msg);
        }



    }
}

