using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Audio;

namespace WEngine
{
    public enum BGMStatus
    {
        Stop,
        Pause,
        Playing,
        FadingIn,
        FadingOut,
    }
    
    public static class Audio
    {
        static SoundEffect bgm;
       public static SoundEffectInstance bgmInstance;
        static BGMStatus bgmStatus;
        static float fadeSpeed;
        static Dictionary<string, SoundEffectInstance> bgsInstances = new Dictionary<string, SoundEffectInstance>();
        static float _innerFadeVolume = 1f;
        static float _basicVolume = 1f;
        static float _bgmVolume = 1f;
        static float _seVolume = 1f;

        public static float BasicVolume
        {
            get
            {
                return _basicVolume;
            }

            set
            {
                _basicVolume = value;
                if (_basicVolume > 1) _basicVolume = 1;
                if (_basicVolume < 0) _basicVolume = 0;
            }
        }
        public static float BGMVolume
        {
            get
            {
                return _bgmVolume;
            }

            set
            {
                _bgmVolume = value;
                //setBGMVol();
            }
        }
        public static float SEVolume
        {
            get
            {
                return _seVolume;
            }

            set
            {
                _seVolume = value;
            }
        }

        public static void Update()
        {
            if(bgmInstance != null) setBGMVol();
            if (bgmStatus == BGMStatus.FadingIn)
            {
                _innerFadeVolume += fadeSpeed;
                if (_innerFadeVolume >= 1f)
                {
                    _innerFadeVolume = 1f;
                    bgmStatus = BGMStatus.Playing;
                }
            }
            else if (bgmStatus == BGMStatus.FadingOut)
            {
                _innerFadeVolume -= fadeSpeed;
                if (_innerFadeVolume <= 0f)
                {
                    _innerFadeVolume = 0f;
                    BGMStop();
                }
            }
        }

        public static void BGMPlay(string file,Boolean isLoop)
        {
            bgm = Cache.BGM(file);
            bgmInstance = bgm.CreateInstance();
            //setBGMVol();
            bgmInstance.IsLooped =isLoop;
            bgmInstance.Play();
            bgmStatus = BGMStatus.Playing;
        }
       
        public static void BGMPause()
        {
            bgmInstance.Pause();
            bgmStatus = BGMStatus.Pause;
        }
        public static void BGMResume()
        {
            bgmInstance.Resume();
            bgmStatus = BGMStatus.Playing;
        }
        public static void BGMStop()
        {
            if (bgmInstance != null)
            {
                bgmInstance.Stop();
                bgmStatus = BGMStatus.Stop;
            }
        }
        public static void BGMFadeIn(string file, int time)
        {
            _innerFadeVolume = 0f;
            BGMPlay(file,true);
            bgmStatus = BGMStatus.FadingIn;
            fadeSpeed = 1f / time;
            
        }
        public static void BGMFadeOut(int time)
        {
            _innerFadeVolume = 1f;
            bgmStatus = BGMStatus.FadingOut;
            fadeSpeed = 1f / time;
        }
        

        public static void SEPlay(string file)
        {
            SoundEffect se = Cache.SE(file);
            se.CreateInstance().Volume = _basicVolume * _seVolume;
            se.Play();
        }
        public static void BGSPlay(string file, bool isRepeat)
        {
            if (!bgsInstances.ContainsKey(file))
            {
                bgm = Cache.SE(file);
                SoundEffectInstance sf = bgm.CreateInstance();
                bgsInstances.Add(file, sf);
                bgsInstances[file].IsLooped = isRepeat;
                //bgsInstances[file].Play();
            }
            bgsInstances[file].Play();
        }
        public static void BGSStop(string file)
        {
            try
            {
                bgsInstances[file].Stop();
            }
            catch
            {
                return;
            }
        }
        static void setBGMVol()
        {
            bgmInstance.Volume = _bgmVolume * _basicVolume * _innerFadeVolume;
        }
        //循环节核心代码
        /*
        instance.SubmitBuffer(wf.Data,position,count/2);
        instance.SubmitBuffer(wf.Date,position,+count/2,count/2);
          position+=count;
         if(position+count>pover)
          {
          position=pastart;
           }
         */
    }
}
