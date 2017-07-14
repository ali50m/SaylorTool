using Saylor.CommonTool.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Saylor.CommonTool.Media
{
    public class AudioPlayer : IAudioPlayer
    {

        private SoundPlayer m_SoundPlayer = new SoundPlayer();

        bool _IsSoundStart=false;
        public bool IsSoundStart
        {
            get
            {
                return _IsSoundStart;
            }
            set
            {
                _IsSoundStart = value;
            }
        }

        int _TrackTag=0;
        public int TrackTag
        {
            get
            {
                return _TrackTag;
            }
            set
            {
                _TrackTag = value;
            }
        }

        int _DevIndex=0;
        public int DevIndex
        {
            get
            {
                return _DevIndex;
            }
            set
            {
                _DevIndex = value;
            }
        }
        public void ReceiveSound(byte[] CaptureData)
        {
            MemoryStream stream = new MemoryStream(CaptureData);
            m_SoundPlayer.Stream = stream;

        }

        public void SoundPlay()
        {
            try
            {
                if (m_SoundPlayer != null)
                {
                    m_SoundPlayer.PlayLooping();//新建线程播放音频
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
            }
           
            
        }

        public void SoundStop()
        {
            try
            {
                if (m_SoundPlayer != null)
                {
                    m_SoundPlayer.Stop();
                }
            }
            catch (Exception ex)
            {
               Log4NetHelper.WriteErrorLog(ex);
            }
        }

        public void SoundGoOn()
        {
            
        }

        public void SoundEnd()
        {
            IsSoundStart = false;
        }

        public void Reset()
        {
            m_SoundPlayer = new SoundPlayer();
            _IsSoundStart = false;
            _TrackTag = 0;
            _DevIndex = 0;
        }

        public bool PlaySound(string fileName)
        {
            try
            {
                m_SoundPlayer.SoundLocation = fileName;
                m_SoundPlayer.PlayLooping();
                return true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteErrorLog(ex);
                return false;
            }
        }

        
    }
}
