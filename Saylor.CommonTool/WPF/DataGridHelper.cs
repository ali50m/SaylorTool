using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Saylor.CommonTool.WPF
{
    public class DataGridHelper
    {
        /// <summary>
        /// 点击datagrid的行图标，返回该行的数据
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public static object GetCallRecordModelFromRow(DependencyObject btn)
        {
            try
            {
                if (btn != null)
                {
                    DataGridRow row = WpfElementHelper.FindParent<DataGridRow>(btn);
                    if (row != null)
                    {
                        return row.DataContext;
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
            return null;
        }
    }
}
