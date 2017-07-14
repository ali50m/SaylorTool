using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.FileAndDirectory
{
    public class DirectoryToolHelper
    {
        /// <summary>
        /// 删除文件夹，包括子文件夹的内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DeleteDirectory(string path) 
        {
            bool result = false;
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
                
            }
            return result;
        }

        /// <summary>
        /// 删除所有的空的文件夹，如果自己为空，也删除
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void DeleteAllNullDirectory(DirectoryInfo dir) 
        {
            try
            {
                if (dir.Exists)
                {
                    if (dir.GetFileSystemInfos().Count()==0)
                    {
                        dir.Delete();
                    }
                    else
                    {
                        DirectoryInfo[] children = dir.GetDirectories();
                        if (children.Count() > 0)
	                    {
		                    foreach (var item in children)
                            {
                                DeleteAllNullDirectory(item);
                            }
	                    }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 删除所有的空的文件夹，如果自己为空，也删除
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void DeleteAllNullDirectory(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                DeleteAllNullDirectory(dir);
            }
            catch (Exception)
            {
            }
        }



        /// <summary>
        /// 获取文件夹下的所有文件，包括子文件夹的文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static List<FileInfo> GetAllFiles(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                return GetAllFiles(dir);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        /// <summary>
        /// 获取文件夹下的所有文件，包括子文件夹的文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static List<FileInfo> GetAllFiles(DirectoryInfo dir) 
        {
            try
            {
                List<FileInfo> result = new List<FileInfo>();
                if (dir.Exists)
                {
                    result.AddRange(dir.GetFiles());
                    var subdirs  = dir.GetDirectories();
                    if (subdirs.Count() != 0)
                    {
                        //递归
                        foreach (var item in subdirs)
                        {
                            result.AddRange(GetAllFiles(item));
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// 获取文件夹下面的所有文件目录（一级目录）
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryInfo> GetSubDirectory(DirectoryInfo dir) 
        {
            List<DirectoryInfo> result = new List<DirectoryInfo>();
            if (dir.Exists)
            {
                result.AddRange(dir.GetDirectories());
            }
            return result;
        }


        /// <summary>
        /// 获取文件夹下面的所有文件目录（一级目录）
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryInfo> GetSubDirectory(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            return GetSubDirectory(dir);
        }
    }
}
