using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saylor.CommonTool.Threads
{
    public class ThreadHelper
    {
        /// <summary>
        /// 彻底结束一个线程，该方法会阻塞线程
        /// </summary>
        /// <param name="thread"></param>
        public static void FinishThread(Thread thread)
        {
            try
            {
                if (thread!=null)
                {
                    thread.Abort();
                    while (thread.ThreadState!=ThreadState.Aborted)
                    {
                        //当调用abort之后，如果thread的状态不为Aborted，主线程就一直在这里做循环，直到thread的状态变为Aborted
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
        }
    }


}
