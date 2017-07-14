using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.ValueConverter
{
    public class ByteArrayHelper
    {
        public static string ChangeToString(byte[] bData)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                int num = bData.Length;
                for (int i = 0; i < num; i++)
                {
                    string text = Convert.ToString(bData[i], 16);
                    if (1 == text.Length)
                    {
                        stringBuilder.Append("0" + text + ",");
                    }
                    else
                    {
                        stringBuilder.Append(text + ",");
                    }
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
                return null;
            }
            return null;
        }
    }
}
