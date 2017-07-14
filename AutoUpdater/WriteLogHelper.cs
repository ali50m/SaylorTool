using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdater
{
    class WriteLogHelper
    {
        static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();
        public static void WriteLog_server(string lastLine)
        {
            WriteLog(baseDirectory + string.Format("{0}_log.txt", DateTime.Now.ToString("yyyyMMdd")), lastLine);
        }
        public static void WriteLog(string directory,string lastLine)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(directory, true, Encoding.Default))
                {
                    streamWriter.Write(lastLine + "\r\n");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void WriteLog_client(string message, Exception ex)
        {

            DateTime dt = DateTime.Now;
            string filePath = Application.StartupPath + "/Log/" + dt.ToString("yyyy-MM-dd") + ".log";

            StreamWriter streamWriter;

            //检查日志文件
            if (!Directory.Exists(Application.StartupPath + "/Log/"))
            {
                Directory.CreateDirectory(Application.StartupPath + "/Log/");
            }

            if (!File.Exists(filePath))
            {
                streamWriter = File.CreateText(filePath);
            }
            else
            {
                streamWriter = File.AppendText(filePath);
            }


            //写入日志内容
            using (streamWriter)
            {
                streamWriter.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));
                streamWriter.WriteLine("输出信息：" + message);

                if (ex != null)
                {
                    streamWriter.WriteLine("异常信息：\r\n" + ex.ToString());
                    streamWriter.WriteLine("错误源：\r\n" + ex.Source);
                }
                streamWriter.WriteLine("\r\n");
                streamWriter.WriteLine("--------------------------------------------------------------------------");
                streamWriter.WriteLine("\r\n");
            }

        }
    }
}
