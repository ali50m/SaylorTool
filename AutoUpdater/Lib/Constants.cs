using System;
using System.Collections.Generic;
using System.Text;

namespace AutoUpdater
{
    public class Constants
    {
        public static string ZipFileName = "Update.zip";
        public static string XmlFileName = "Update.xml";
        public static string UnzipFoldName = "Update";
        public static string RemoteUrl_xml = string.Format("http://10.16.33.214:8090/Dispatcher_HP.APP/{0}", XmlFileName);
        public static string RemoteUrl_zip = string.Format("http://10.16.33.214:8090/Dispatcher_HP.APP/{0}", ZipFileName);
    }
}