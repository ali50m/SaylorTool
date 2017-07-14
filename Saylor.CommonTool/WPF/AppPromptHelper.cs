using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Saylor.CommonTool.WPF
{
    public class AppPromptHelper
    {

        public static void Prompt(string text)
        {
            MessageBox.Show(text, "提示:", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        public static bool PromptWithReturn(string text)
        {
            if (MessageBoxResult.Yes == MessageBox.Show(text, "提示:", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool PromptWithReturn_delete()
        {
            if (MessageBoxResult.Yes == MessageBox.Show("您确定要删除吗?", "提示:", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void PromptWithNoAuthority()
        {
            Prompt("权限不足，请联系管理员！");
        }

        public static void PromptDeleteNull()
        {
            Prompt("请选择要删除的项！");
        }

        public static void PromptDeleteOrNot()
        {
            Prompt("请选择要删除的项！");
        }

        public static void PromptSaveSuccessfully()
        {
            Prompt("保存成功！");
        }

        public static void PromptSaveFailed()
        {
            Prompt("保存失败！");
        }
        public static void DeleteSuccessfully()
        {
            Prompt("删除成功！");
        }

        public static void DeleteFailed()
        {
            Prompt("删除失败！");
        }
    }
}
