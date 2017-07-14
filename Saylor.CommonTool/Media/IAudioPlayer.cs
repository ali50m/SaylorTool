using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.Media
{
    public interface IAudioPlayer
    {
        /// <summary>
        /// 标记当前的音频播放设备是否处于工作状态
        /// </summary>
        bool IsSoundStart { get; set; }  

        /// <summary>
        /// 使用的声道
        /// </summary>
        int TrackTag { get; set; }  
        /// <summary>
        /// 使用的声卡索引
        /// </summary>
        int DevIndex { get; set; }  

        /// <summary>
        /// 接收来自外部的音频数据，放到播放队列准备播放
        /// </summary>
        /// <param name="CaptureData"></param>
        void ReceiveSound(byte[] CaptureData);
        
        /// <summary>
        /// 播放
        /// </summary>
        void SoundPlay();
        
        /// <summary>
        /// 暂停
        /// </summary>
        void SoundStop();
        
        /// <summary>
        /// 继续
        /// </summary>
        void SoundGoOn();

        /// <summary>
        /// 一段音频全部播完停止
        /// </summary>
        void SoundEnd();

        /// <summary>
        /// 重置播放器中的参数：循环队列、写数据起点、声音组件
        /// </summary>
        void Reset();

        /// <summary>
        /// 播放文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool PlaySound(string fileName);



    }
}
