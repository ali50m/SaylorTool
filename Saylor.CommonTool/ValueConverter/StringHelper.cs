using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.ValueConverter
{
    public class StringHelper
    {
        /// <summary>
        /// 将字符串转化为int，如果失败返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ChangeToInt(string str) 
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// 将字符串转化为double，如果失败返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ChangeToDouble(string str)
        {
            double result = 0;
            try
            {
                result = Convert.ToDouble(str);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// 将字符串转化为short，如果失败返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static short ChangeToShort(string str)
        {
            short result = 0;
            try
            {
                result = Convert.ToInt16(str);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }


        /// <summary>
        /// 将字符串转化为bool，如果失败返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ChangeToBool(string str)
        {
            bool result = false;
            try
            {
                result = Convert.ToBoolean(str);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


        /// <summary>
        /// 判断字符串是否为空或空白
        /// </summary>
        /// <returns></returns>
        public static bool IsNull(string str) 
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    result = true;
                }
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
