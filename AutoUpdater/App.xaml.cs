using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace AutoUpdater
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string themeName = ConfigManage.CurrentTheme;
            App.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri(string.Format("../Theme/{0}/Style.xaml", themeName), UriKind.Relative)) as ResourceDictionary);
        }
    }
}
