
using Saylor.CommonTool.Log;
using SharpConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool
{
    public class AppConfigFileHelper
    {
        static Configuration  config = Configuration.LoadFromFile("config.ini");
        public static string GetAppConfig(string strKey)
        {
            foreach (string key in System.Configuration.ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return System.Configuration.ConfigurationManager.AppSettings[strKey];
                }
            }
            return "";
        }


        public static string GetAppConfigFromConfigFile(string strKey)
        {
            try
            {
                Section section = config["General"];
                return section[strKey].StringValue;
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
                return "";
            }
            
        }
    }
}
