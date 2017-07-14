using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Saylor.CommonTool.EncodeLib
{
    public class EncodeHelper
    {
        /// <summary>
        /// 将一串不包含“/u”的Unicode字符转换为一串汉字
        /// 比如  “9EC46D66”可以转换为  “黄浦”
        /// </summary>
        /// <param name="unicodeStr"></param>
        /// <returns></returns>
        public static string UnicodeWithoutUToChinese(string unicodeStr) 
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                MatchCollection mc = Regex.Matches(unicodeStr, ".{4}");
                if (mc != null && mc.Count > 0)
                {
                    foreach (Match match in mc)
                    {
                        sb.Append(Change4UnicodeTo1Word_1(match.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 将一串包含“/u”的Unicode字符转换为一串汉字
        /// 比如  “/u9EC4/u6D66”可以转换为  “黄浦”
        /// </summary>
        /// <param name="unicodeStr"></param>
        /// <returns></returns>
        public static string UnicodeWithUToChinese(string unicodeStr)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                MatchCollection mc = Regex.Matches(unicodeStr, "\\\\u([\\w{4}])");
                if (mc != null && mc.Count > 0)
                {
                    foreach (Match match in mc)
                    {
                        sb.Append(Change4UnicodeTo1Word_2(match.Value.Substring(2)));
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 将4个Unicode字符转换成一个汉字----方案一
        /// 比如  “9EC4”可以转换为  “黄”
        /// </summary>
        /// <param name="unicodeStr"></param>
        /// <returns></returns>
        public static string Change4UnicodeTo1Word_1(string unicodeStr) 
        {
            try
            {
                char temp = (char)int.Parse(unicodeStr,NumberStyles.HexNumber);
                return temp.ToString();
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
            return null;
        }

        /// <summary>
        /// 将4个Unicode字符转换成一个汉字----方案二
        /// 比如  “9EC4”可以转换为  “黄”
        /// </summary>
        /// <param name="unicodeStr"></param>
        /// <returns></returns>
        public static string Change4UnicodeTo1Word_2(string unicodeStr)
        {
            try
            {
                if (unicodeStr!=null&&unicodeStr.Length>=4)
                {
                    byte[] codes = new byte[2];
                    int code = Convert.ToInt32(unicodeStr.Substring(0, 2), 16);
                    int code2 = Convert.ToInt32(unicodeStr.Substring(2), 16);
                    codes[0] = (byte)code;
                    codes[1] = (byte)code2;
                    return Encoding.Unicode.GetString(codes); 
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
