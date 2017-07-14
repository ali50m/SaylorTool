using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.LogTool
{
    public class LogFileOperation
    {
        public const long MaxFileSize = 5000000;

		public static string logFileName;

		public static string errorFileName;

		public static string LogFileName
		{
			get
			{
				return LogFileOperation.logFileName;
			}
			set
			{
				LogFileOperation.logFileName = value;
			}
		}

		public static string ErrorFileName
		{
			get
			{
				return LogFileOperation.errorFileName;
			}
			set
			{
				LogFileOperation.errorFileName = value;
			}
		}

		static LogFileOperation()
		{
            InitFile();
		}



		private static void InitFile()
		{
            string dateTimeStr = DateTime.Now.ToString("yyyyMMdd");
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Log";
            DirectoryOperation.CheckDirectory(directoryName);
            LogFileOperation.errorFileName = string.Format("{0}\\{1}error.txt", directoryName, dateTimeStr);
            LogFileOperation.logFileName = string.Format("{0}\\{1}log.txt", directoryName, dateTimeStr);

            DirectoryOperation.CheckDirectory(LogFileOperation.logFileName);
		}

		public static bool DeleteFile(string sFileName)
		{
			bool result;
			try
			{
				if (File.Exists(sFileName))
				{
					File.Delete(sFileName);
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public static long GetFileSize(string sFileName)
		{
			long result;
			try
			{
				FileInfo fileInfo = new FileInfo(sFileName);
				result = fileInfo.Length;
			}
			catch (Exception)
			{
				result = 0L;
			}
			return result;
		}


        /// <summary>
        /// 检查文件的大小，文件大于指定的大小（5M）,则删除文件
        /// </summary>
        /// <param name="sFileName"></param>
		public static void CheckFile(string sFileName)
		{
            if (LogFileOperation.GetFileSize(sFileName) > MaxFileSize)
			{
				LogFileOperation.DeleteFile(sFileName);
			}
		}

		public static void SaveLog(string sReport, string sFileName)
		{
			try
			{
				LogFileOperation.CheckFile(sFileName);
				StreamWriter streamWriter;
				
                
                if (!File.Exists(sFileName))
				{
					streamWriter = File.CreateText(sFileName);
				}
				else
				{
					streamWriter = File.AppendText(sFileName);
				}
				streamWriter.WriteLine(sReport);
				streamWriter.Flush();
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}

		public static void SaveLog(string sReport)
		{
			if (LogFileOperation.logFileName == null || LogFileOperation.logFileName == "")
			{
				LogFileOperation.InitFile();
			}
			LogFileOperation.SaveLog(sReport, LogFileOperation.logFileName);
		}

		public static void Debug(string sReport)
		{
		}

		public static void ShowError(string sFileName, string Procedure, string ErrorDescript)
		{
			try
			{
				LogFileOperation.CheckFile(sFileName);
				StreamWriter streamWriter;
				if (!File.Exists(sFileName))
				{
					streamWriter = File.CreateText(sFileName);
				}
				else
				{
					streamWriter = File.AppendText(sFileName);
				}
				streamWriter.WriteLine("*** Error Encountered " + DateTime.Now.ToString() + "***");
				streamWriter.WriteLine("Description: " + ErrorDescript);
				streamWriter.WriteLine("Procedure: " + Procedure);
				streamWriter.WriteLine("");
				streamWriter.Flush();
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}

		public static void ShowError(string Procedure, string ErrorDescript)
		{
			if (LogFileOperation.errorFileName == null || LogFileOperation.errorFileName == "")
			{
				LogFileOperation.InitFile();
			}
			LogFileOperation.ShowError(LogFileOperation.errorFileName, Procedure, ErrorDescript);
		}

       
    }
}
