using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.Dictionary
{
    public class DictionaryHelper
    {

        /// <summary>
        /// 根据key取value
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValueByKey(Dictionary<string, string> dic,string key)
        {
            try
            {
                if (dic!=null&&dic.Keys.Contains(key))
                {
                    return dic[key];
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
                return null;
            }
            return null;
        }

        /// <summary>
        /// 添加键值对
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void AddKeyAndValue(Dictionary<string, string> dic, string key,string value)
        {
            try
            {
                if (dic != null && !dic.Keys.Contains(key))
                {
                    dic.Add(key,value);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
        }
    }
}
