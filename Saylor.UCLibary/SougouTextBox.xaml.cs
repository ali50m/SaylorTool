using Saylor.CommonTool.App;
using Saylor.CommonTool.Exe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Saylor.UCLibary
{
    /// <summary>
    /// SougouTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class SougouTextBox : TextBox
    {
        public SougouTextBox()
        {
            InitializeComponent();
        }

        private void SearchTB_GotFocus(object sender, RoutedEventArgs e)
        {
            ExeHelper.StartExe(AppHelper.AppStartupPath + @"\HandInput\1.1.0.282\handinput.exe");
        }

        private void SearchTB_LostFocus(object sender, RoutedEventArgs e)
        {
            ExeHelper.KillExe("handinput");
        }
    }
}
