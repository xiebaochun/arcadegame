using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArcadeGame.Programs.Sprites;
using WEngine;
using Microsoft.Xna.Framework;

namespace ArcadeGame.Programs.Scenes
{
    partial class Scene_Main
    {
        Sprite HeroPortrait;
        Sprite HeroName;
        Sprite HeroHP_01;
        Sprite HeroHP_02;


        private void HeroInitialize()
        {
            if (Prefs.Theme == 1)
            {
                Hero = new Sprite("Hero", true, true, 5, 0, 0, 3, 1);
            }
            else
            {
                Hero = new Sprite("Hero_T2", true, true, 5, 0, 0, 3, 1);
            }
            Hero.Shader = new Sprite_Base("HeroShader");
            Hero.Shader.BackOffset = Hero.BackOffset;
            Hero.Shader.Z =4;
            Hero.HP = 1000;
            Hero.BackOffset = new Vector2((Prefs.WindowSizeW - Hero.SourceTexture.Width) / 2, 400);
            Hero.Shader.BackOffset = Hero.BackOffset;
            Hero.isStart = false;
            Hero.ShowingRect = Hero.SourceRect(Hero);
            AddChild(Hero);
            AddChild(Hero.Shader);

            HeroPortrait = new Sprite("HeroPortrait", true, true, 5, 0, 0, 1, 1);
            HeroPortrait.BackOffset = new Vector2(20, 10);
            AddChild(HeroPortrait);

            HeroName = new Sprite("HeroName", true, true, 5, 0, 0, 1, 1);
            HeroName.BackOffset = new Vector2(60, 37);
            AddChild(HeroName);

            HeroHP_01 = new Sprite("HeroHP_01", true, true, 5, 0, 0, 1, 1);
            HeroHP_01.BackOffset = new Vector2(60, 10);
            HeroHP_01.ShowingRect = new Rectangle(0, 0, HeroHP_01.SourceTexture.Width, HeroHP_01.SourceTexture.Height);
            AddChild(HeroHP_01);

            HeroHP_02 = new Sprite("HeroHP_02", true, true, 4, 0, 0, 1, 1);
            HeroHP_02.BackOffset = new Vector2(60, 10);
            AddChild(HeroHP_02);

            if (Prefs.Theme == 1)
            {
                HeroAttack1 = new Sprite("HeroAttack1", false, true, 5, 0, 0, 2, 1);
            }
            else
            {
                HeroAttack1 = new Sprite("HeroAttack1_T2", false, true, 5, 0, 0, 2, 1);
            }
           
            HeroAttack1.ShowingRect = HeroAttack1.SourceRect(HeroAttack1);
            AddChild(HeroAttack1);


            if (Prefs.Theme == 1)
            {
                HeroAttack2 = new Sprite("HeroAttack2", false, true, 5, 0, 0, 2, 1);
            }
            else
            {
                HeroAttack2 = new Sprite("HeroAttack2_T2", false, true, 5, 0, 0, 2, 1);
            }
            HeroAttack2.ShowingRect = HeroAttack2.SourceRect(HeroAttack2);
            AddChild(HeroAttack2);

            redShader = new Sprite("redShader",false, true, 4, 0, 0, 1, 1);
            redShader.BackOffset = new Vector2(-450, -60);
            AddChild(redShader);

            HeroDefenseShooted_fire = new Sprite("HeroDefenseShooted_fire", false, false, 5, 0, 0, 3, 1);
            HeroDefenseShooted_fire.Alpha = 0.4f;
            HeroDefenseShooted_fire.ShowingRect = HeroDefenseShooted_fire.SourceRect(HeroDefenseShooted_fire);
            AddChild(HeroDefenseShooted_fire);

            SpeedUpShader = new Sprite("SpeedUpShader", false, false, 500, 0, 0, 6, 3);
            SpeedUpShader.BackOffset.X = Hero.BackOffset.X - 80;
            SpeedUpShader.BackOffset.Y = Hero.BackOffset.Y + 32;
            SpeedUpShader.ShowingRect = SpeedUpShader.SourceRect(SpeedUpShader);

            AddChild(SpeedUpShader);

            for (int i = 0; i < 3; i++)
            {
                HitShader = new Sprite("HitShader", false, false, 1000, 0, 0, 4, 4);
                HitShader.BackOffset.X = Hero.BackOffset.X - 70;
                HitShader.BackOffset.Y = Hero.BackOffset.Y - 55;
                HitShader.ShowingRect = HitShader.SourceRect(HitShader);

                AddChild(HitShader);
                HitSHaders.Add(HitShader);
            }


            if (Prefs.Theme == 1)
            {
                HeroHighRunning = new Sprite("HeroHighRunning", false, true, 5, 0, 0, 2, 1);
            }
            else
            {
                HeroHighRunning = new Sprite("HeroHighRunning_T2", false, true, 5, 0, 0, 2, 1);
            }
            
            HeroHighRunning.ShowingRect = HeroHighRunning.SourceRect(HeroHighRunning);
            AddChild(HeroHighRunning);


            if (Prefs.Theme == 1)
            {
                HeroAttacked = new Sprite("HeroAttacked", false, true, 5, 0, 0, 3, 1);
            }
            else
            {
                HeroAttacked = new Sprite("HeroAttacked_T2", false, true, 5, 0, 0, 3, 1);
            }
          
            HeroAttacked.ShowingRect = HeroAttacked.SourceRect(HeroAttacked);
            AddChild(HeroAttacked);


            if (Prefs.Theme == 1)
            {
                HeroKilling = new Sprite("HeroKilled1", false, false, 5, 0, 0, 3, 1);
                HeroKilled = new Sprite("HeroKilled", false, false, 5, 0, 0, 1, 1);
            }
            else
            {
                HeroKilling = new Sprite("HeroKilled1_T2", false, false, 5, 0, 0, 3, 1);
                HeroKilled = new Sprite("HeroKilled_T2", false, false, 5, 0, 0, 1, 1);
            }
            HeroKilling.ShowingRect = HeroKilling.SourceRect(HeroKilling);
            AddChild(HeroKilling);


           
            HeroKilled.ShowingRect = HeroKilled.SourceRect(HeroKilled);
            AddChild(HeroKilled);

            HeroKilledShader = new Sprite("HeroKilledShader", false, false, 4, 0, 0, 1, 1);
            HeroKilledShader.BackOffset = Hero.BackOffset;
            AddChild(HeroKilledShader);

            HeroAttackShader = new Sprite("HitShader", false, false,1000, 0, 0, 4, 4);
            HeroAttackShader.ShowingRect = HeroAttackShader.SourceRect(HeroAttackShader);
            AddChild(HeroAttackShader);

        }

        private void BackGroundInitialize()
        {
            Bus = new Sprite("Bus", true, true, 3, 0, 0, 1, 1);
            Bus.BackOffset = new Vector2(-10, Prefs.WindowSizeH - 528);
            AddChild(Bus);
            Bus1 = new Sprite("Bus", true, true, 3, 0, 0, 1, 1);
            Bus1.BackOffset = new Vector2(Bus.SourceTexture.Width/2 -10, Prefs.WindowSizeH - 528);
            AddChild(Bus1);

            BackGround = new Sprite("BackGround1", true, true, 2, 30, 0.2f, 1, 1);
            BackGround.BackOffset = new Vector2(0, 0);
            AddChild(BackGround);

            BackGround1 = new Sprite("BackGround2", true, true, 2, 30, 0.3f, 1, 1);
            BackGround1.BackOffset = new Vector2(BackGround.SourceTexture.Width, 0);
            AddChild(BackGround1);

            FarBackGround1 = new Sprite("farBackGround1", true, true, 1, 1, 0, 1, 1);
            FarBackGround1.BackOffset = new Vector2(0, 0);
            AddChild(FarBackGround1);

            FarBackGround2 = new Sprite("farBackGround2", true, true, 1, 1, 0, 1, 1);
            FarBackGround2.BackOffset = new Vector2(FarBackGround1.SourceTexture.Width, 0);
            AddChild(FarBackGround2);

        }
    }
    
}
