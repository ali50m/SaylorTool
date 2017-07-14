using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AutoUpdater.Lib
{
    class ProcessHelper
    {
        public static void KillProcess(string processName) 
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (var p in processes)
            {
                p.Kill();
            }
        }


        /// <summary>
        /// 结束一个exe
        /// </summary>
        /// <param name="exeProcessName">进程名称</param>
        /// 
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
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
                        SendMessage(ptr, WM_CLOSE, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
