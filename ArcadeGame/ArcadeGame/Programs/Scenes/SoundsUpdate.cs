using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEngine;

namespace ArcadeGame.Programs.Scenes
{
    public partial class Scene_Main
    {
        public int HeroSoundsIcount = 0;
        public int BossSoundsIcount = 0;
        public int BusSoundsIcount = 0;
        public int HeroHightRunningSoundsIcount = 0;
        bool isBossPlaySound = false;
        Boolean isBusPlaySound = false;
        public void SoundsUpdate()
      {
          #region 主角的音效
          if (Hero.Visible == true&&Hero.BackOffset.X>-30)
          {
              HeroSoundsIcount++;
              if (HeroSoundsIcount >= 10)
              {
                  HeroSoundsIcount = 0;
                  Audio.SEPlay("00");
              }
          }
          if (HeroHighRunning.Visible == true&&HeroHighRunning.BackOffset.X>-30)
          {
              HeroHightRunningSoundsIcount++;
              if (HeroHightRunningSoundsIcount >= 5)
              {
                  HeroHightRunningSoundsIcount = 0;
                  Audio.SEPlay("00");
              }
          }
         
          #endregion
          # region Boss的音效
          if (Boss.Visible == true && Boss.BackOffset.X < Prefs.WindowSizeW || BossShooting.Visible == true && Boss.BackOffset.X < Prefs.WindowSizeW)
          {
              if (isBossPlaySound == false)
              {
                  isBossPlaySound = true;
                  Audio.BGSPlay("10",false);
              }
              BossSoundsIcount++;
              if (BossSoundsIcount >= 800)
              {
                  BossSoundsIcount = 0;
                  Audio.BGSPlay("10",false);
              }
          }
          #endregion
          #region Bus的音效
          if (isBusPlaySound == false)
          {
              isBusPlaySound = true;
              Audio.SEPlay("12");
          }
          BusSoundsIcount++;
          if (BusSoundsIcount >= 800)
          {
              BusSoundsIcount = 0;
              Audio.SEPlay("12");
          }
          #endregion
          
            

          }
    }
}