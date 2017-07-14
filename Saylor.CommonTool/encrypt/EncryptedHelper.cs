using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.encrypt
{
    public class EncryptedHelper
    {
        public static string GetMD5(string input)
        {
            string output = string.Empty;
            try
            {
                byte[] data = Encoding.Default.GetBytes(input);
                MD5 md5 = new MD5CryptoServiceProvider();
                output = BitConverter.ToString(md5.ComputeHash(data));
            }
            catch (Exception)
            {

            }
            return output;
        }

        /// <summary>
        /// 获取MD5，转换为小写且不带中间的破折号
        /// </summary>
        /// <returns></returns>
        public static string GetMD5ToLowerCaseWithoutDash(string input)
        {
            string output = string.Empty;
            output = GetMD5(input);
            output = output.Replace("-","");
            return output.ToLower();
        }
    }
}
