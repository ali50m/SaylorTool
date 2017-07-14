using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Saylor.CommonTool.Regexe
{
    public class RegexHelper
    {
        public static bool IsValidPhone(string phone)
        {
            Regex regex = new Regex(@"[0-9]{11}");

            bool b = regex.IsMatch(phone);
            if (!b)
            {
                //AppPromptHelper.Prompt("无效的手机号码！");
            }
            return b;
        }

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?/d*[.]?/d*$");
        }
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?/d*$");
        }
        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^/d*[.]?/d*$");
        }

        public static bool IsPhone(string value)
        {
            return Regex.IsMatch(value, @"^[0-9]{1,11}$");
        }
    }
}
