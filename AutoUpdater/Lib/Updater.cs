using System;
using System.IO;
using System.Windows;


using System.Xml.Linq;

namespace AutoUpdater
{
    public class Updater
    {
        private static Updater _instance;
        public static Updater Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Updater();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 下载版本文档，并判断是否更新
        /// </summary>
        /// <param name="shouldShowPrompt"></param>
        public static void CheckUpdateStatus(bool shouldShowPrompt)
        {
            System.Threading.ThreadPool.QueueUserWorkItem((s) =>
            {
                string url = Constants.RemoteUrl_xml;
                var client = new System.Net.WebClient();
                client.DownloadDataCompleted += (x, y) =>
                {
                    try
                    {
                        MemoryStream stream = new MemoryStream(y.Result);
                        XDocument xDoc = XDocument.Load(stream);
                        UpdateInfo updateInfo = new UpdateInfo();
                        XElement root = xDoc.Element("UpdateInfo");
                        updateInfo.AppName = root.Element("AppName").Value;
                        updateInfo.AppVersion = root.Element("AppVersion") == null || string.IsNullOrEmpty(root.Element("AppVersion").Value) ? null : new Version(root.Element("AppVersion").Value);
                        updateInfo.RequiredMinVersion = root.Element("RequiredMinVersion") == null || string.IsNullOrEmpty(root.Element("RequiredMinVersion").Value) ? null : new Version(root.Element("RequiredMinVersion").Value);
                        updateInfo.Desc = root.Element("Desc").Value;
                        updateInfo.MD5 = Guid.NewGuid();

                        stream.Close();
                        Updater.Instance.StartUpdate(updateInfo, shouldShowPrompt);
                    }
                    catch
                    {
                    
                    }
                };
                client.DownloadDataAsync(new Uri(url));

            });

        }

        /// <summary>
        /// 判断是否更新，如果需要则直接更新
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <param name="shouldShowPrompt"></param>
        public void StartUpdate(UpdateInfo updateInfo,bool shouldShowPrompt)
        {
            if (updateInfo.RequiredMinVersion != null && Updater.Instance.CurrentVersion < updateInfo.RequiredMinVersion)
            {
                //当前版本比需要的版本小，不更新
                if (shouldShowPrompt)
                {
                    MessageBox.Show("当前版本低于更新需要的最低版本，请到官网下载最新版本。"); 
                }
                return;
            }

            if (Updater.Instance.CurrentVersion >= updateInfo.AppVersion)
            {
                //当前版本是最新的，不更新
                if (shouldShowPrompt)
                {
                    MessageBox.Show("已是最新版本，无需更新。"); 
                }
                return;
            }

            //有可能要更新AutoUpdater本身，所以要先关闭它
            AutoUpdater.Lib.ProcessHelper.KillProcess("AutoUpdater");
            //更新程序复制到缓存文件夹
            string appDir = GetAppDir();
            string updateFileDir = System.IO.Path.Combine(appDir, "Update");
            try
            {
                if (!Directory.Exists(updateFileDir))
                {
                    Directory.CreateDirectory(updateFileDir);
                }
                updateFileDir = System.IO.Path.Combine(updateFileDir, updateInfo.MD5.ToString());
                if (!Directory.Exists(updateFileDir))
                {
                    Directory.CreateDirectory(updateFileDir);
                }

                //启动更新程序
                string exePath = System.IO.Path.Combine(updateFileDir, "AutoUpdater.exe");
                File.Copy(System.IO.Path.Combine(appDir, "AutoUpdater.exe"), exePath, true);
                var info = new System.Diagnostics.ProcessStartInfo(exePath);
                info.UseShellExecute = true;
                info.WorkingDirectory = exePath.Substring(0, exePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
                info.Arguments = "update " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(CallExeName)) + " " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(updateFileDir)) + " " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(appDir)) + " " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(updateInfo.AppName)) + " " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(updateInfo.AppVersion.ToString())) + " " + (string.IsNullOrEmpty(updateInfo.Desc) ? "" : Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(updateInfo.Desc)));
                System.Diagnostics.Process.Start(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetAppDir()
        {
            string baseLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            return System.IO.Path.Combine(baseLocation.Substring(0, baseLocation.LastIndexOf(System.IO.Path.DirectorySeparatorChar)));
        }

        public bool UpdateFinished = false;

        private string _callExeName;
        public string CallExeName
        {
            get
            {
                if (string.IsNullOrEmpty(_callExeName))
                {
                    _callExeName = System.Reflection.Assembly.GetEntryAssembly().Location.Substring(System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1).Replace(".exe", "");
                }
                return _callExeName;
            }
        }

        /// <summary>
        /// 获得当前应用软件的版本
        /// </summary>
        public virtual Version CurrentVersion
        {
            get 
            {
                return new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductVersion); 
            }
        }

        /// <summary>
        /// 获得当前应用程序的根目录
        /// </summary>
        public virtual string CurrentApplicationDirectory
        {
            get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location); }
        }

        
    }
}
