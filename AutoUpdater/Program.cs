using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace AutoUpdater
{
    class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }
            else if (args[0] == "update")
            {
                try
                {
                    string callExeName = args[1];
                    string updateFileDir = args[2];
                    string appDir = args[3];
                    string appName = args[4];
                    string appVersion = args[5];
                    string desc = args[6];
                    AutoUpdater.App app = new AutoUpdater.App();
                    UI.UpdateWindow downUI = new UI.UpdateWindow(callExeName, updateFileDir, appDir, appName, appVersion, desc);
                    app.Run(downUI);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
