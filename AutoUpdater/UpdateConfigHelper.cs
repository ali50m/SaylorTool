using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdater
{
    public class UpdateConfigHelper
    {

        public static void SetURL(string xmlurl, string zipurl, string unzipFoldName, string xmlFileName, string zipFileName) 
        {
            Constants.UnzipFoldName = unzipFoldName;
            Constants.XmlFileName = xmlFileName;
            Constants.ZipFileName = zipFileName;
            Constants.RemoteUrl_xml = xmlurl;
            Constants.RemoteUrl_zip = zipurl;
        }

        /// <summary>
        /// 检查是否使用更新功能
        /// </summary>
        /// <returns></returns>
        public static bool CheckUpdateMandatory()
        {
            bool result = true;
            try
            {
                bool isUseUpdate = true;
                string vision = "";
                result = ExecuteCheckUpdateMandatory(isUseUpdate, vision);
            }
            catch (Exception e)
            {
            }
            return result;
        }


        /// <summary>z
        /// 是否更新
        /// </summary>
        /// <param name="isUseUpdate">是否使用更新功能</param>
        /// <param name="vision"></param>
        /// <returns></returns>
        private static bool ExecuteCheckUpdateMandatory(bool isUseUpdate, string vision)
        {
            bool result = true;
            if (isUseUpdate == true &&IsLowwerThanMandatoryVision(vision))
            {
                result = false;
            }
            return result;
        }

        private static bool IsLowwerThanMandatoryVision(string vision)
        {
            bool result = false;

            try
            {
                if (!string.IsNullOrEmpty(vision))
                {
                    Version currentVersion = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductVersion);
                    Version mandatoryVision = new Version(vision);
                    if (currentVersion < mandatoryVision)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        public static string GetCurrentVersionStr()
        {
            string result = "未知";
            Version currentVersion = new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductVersion);
            if (currentVersion != null)
            {
                result = currentVersion.ToString();
            }
            return result;
        }
    }
}
