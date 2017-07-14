using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.FileAndDirectory
{
    public class FileToolHelper
    {

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DeleteFile(string path) 
        {
            bool result = false;
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                } 

            }
            return result;
        }

        public static bool DeleteFile(FileInfo file)
        {
            bool result = false;
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }

            }
            return result;
        } 
    }
}
