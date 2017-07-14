using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.Exe
{
    public class ExeHelper
    {
        /// <summary>
        /// 启动一个exe
        /// </summary>
        /// <param name="exePath"></param>
        public static void StartExe(string exePath) 
        {
            try
            {
                System.Diagnostics.Process.Start(exePath);
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
        }

        /// <summary>
        /// 强制结束一个exe
        /// </summary>
        /// <param name="exePath"></param>
        public static void KillExe(string exePath)
        {
            try
            {
                foreach (var item in Process.GetProcessesByName(exePath))
                {
                    item.Kill();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
        }

        /// <summary>
        /// 结束一个exe
        /// </summary>
        /// <param name="exeProcessName">进程名称</param>
        /// 
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hwnd,int msg,int wParam,int lParam);
        const int WM_CLOSE = 0x0010;
        public static void FinishExe(string exeProcessName)
        {
            try
            {
                foreach (var item in System.Diagnostics.Process.GetProcesses())
                {
                    if (item.ProcessName == exeProcessName)
                    {
                        IntPtr ptr = item.MainWindowHandle;
                        SendMessage(ptr,WM_CLOSE,0,0);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
        }

        /// <summary>
        /// 判断进程是否挂死
        /// </summary>
        /// <param name="exeProcessName"></param>
        /// <returns></returns>
        public static bool IsDead(string exeProcessName) 
        {
            try
            {
                foreach (var item in System.Diagnostics.Process.GetProcesses())
                {
                    if (item.ProcessName == exeProcessName)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
            return true;
        }


        /// <summary>
        /// 应用是否已经启动
        /// </summary>
        /// <returns></returns>
        public static bool IsExeRun(string exeProcessName)
        {
            bool result = false;
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName(exeProcessName).Length > 1)
	            {
                    result = true;
	            }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
            return result;
        }
    }
}
