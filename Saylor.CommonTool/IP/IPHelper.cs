using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool
{
    public class IPHelper
    {
        public static string GetAddressInterNetworkIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            //var a = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            return AddressIP;
        }

        public static IPAddress[] GetIPAddressList()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList;
        }


        /// <summary>
        /// 判断端口是否被占用
        /// 1:TCP  0:udp
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool PortInUse(int port,int type)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = null;
            switch (type)
            {
                case 0:
                    ipEndPoints = ipProperties.GetActiveUdpListeners();
                    break;
                case 1:
                    ipEndPoints = ipProperties.GetActiveTcpListeners();
                    break;
                default:
                    ipEndPoints = ipProperties.GetActiveTcpListeners();
                    break;

            }

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }
    }
}
