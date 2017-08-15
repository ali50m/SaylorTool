using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.GUID
{
    public class GuidHelper
    {
        /// <summary>
        /// 返回去掉“-”的小写字符串
        /// </summary>
        /// <returns></returns>
        public static string GetGUID()
        {
            
            return System.Guid.NewGuid().ToString("N");
        }
    }
}
