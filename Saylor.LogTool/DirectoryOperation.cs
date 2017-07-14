using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.LogTool
{
    public class DirectoryOperation
    {
        /// <summary>
        /// 检查目录是否存在，不存在则创建新目录
        /// </summary>
        /// <param name="path"></param>
        public static void CheckDirectory (string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        }


    }
}
