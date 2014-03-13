using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ArcadeGame.Programs.Scenes
{
    partial class Scene_Main
    {
      
       public Boolean isHeroDefense=false;
       public Boolean isHeroNiuBility = false;
       public int HeroNiubilityTime = 0;
       public int HeroDefenseTime = 0;
       public int timeStopBackSPX=-10;
       public Boolean isTimeStop2 = false;
       public Boolean isTimeStop3 = false;
       public Boolean isHeroHitLand = false;
       public Boolean isExplodeSoundStart = false;
       
        private void HeroUpdate()
        {
            HeroHighRunning.CollisionRect = Hero.CollisionRect;
            //主角HP同步
            HeroHP_01.ShowingRect = new Rectangle(0, 0, (int)(HeroHP_01.SourceTexture.Width * (((float)Hero.HP / 1000))), HeroHP_01.SourceTexture.Height);
            //被撞敌人百分比
            enemyKilledPercentBox.Text = (int)(((float)(enemyKilledCount) / 75) * 100) + @"%";
            misssEnemypercentBox.Text = (int)(((float)(enemyOverCount) / 75) * 100) + @"%";
            //时间停止
            if (isTimeStop == true)
            {
               Hero.SPX =timeStopBackSPX;
                Hero.BackOffset.X += Hero.SPX;
            }
           //主角防御状态下被攻击时火花位置同步
            HeroDefenseShooted_fire.BackOffset = Hero.BackOffset;
            //主角攻击状态的位置同步
            HeroAttack1.BackOffset = Hero.BackOffset;
            HeroAttack2.BackOffset = Hero.BackOffset;
            HeroAttack1.Z = HeroHighRunning.Z + 1;
            HeroAttack2.Z = HeroHighRunning.Z + 1;
            if (loopCount > maxloopCount)
            {
                //主角防御
                HeroDefense.ShowingRect = HeroDefense.SourceRect(HeroDefense);
                if (Input.Press(Keys.Q) && Input.Press(Keys.W))
                {
                    HeroDefense.BackOffset = Siki.BackOffset;
                    HeroDefense.Z = HeroHighRunning.Z + 1;
                    HeroDefense.Alpha = Siki.Alpha;
                    HeroDefense.Visible = true;
                    Siki.Visible = false;
                    isHeroDefense = true;
                    HeroDefense.iCount++;
                    if (HeroDefense.iCount == theHeroDefenseFrame)//6
                    {
                        HeroDefense.CurrentPositionY++;
                        HeroDefense.iCount = 0;
                        if (HeroDefense.CurrentPositionY == 3)
                        {
                            HeroDefense.CurrentPositionY = 2;
                        }
                        HeroDefense.ShowingRect = HeroDefense.SourceRect(HeroDefense);
                    }
                }
                if (!Input.Press(Keys.Q) || !Input.Press(Keys.W))
                {
                    if (isHeroDefense == true)
                    {
                        HeroDefense.iCount++;
                        if (HeroDefense.iCount == 6)
                        {
                            HeroDefense.iCount = 0;
                            HeroDefense.CurrentPositionY--;
                            HeroDefense.ShowingRect = HeroDefense.SourceRect(HeroDefense);
                            if (HeroDefense.CurrentPositionY == 0)
                            {
                                HeroDefense.Visible = false;
                                Siki.Visible = true;
                                isHeroDefense = false;
                            }
                        }
                        HeroDefenseTime++;
                        if (HeroDefenseTime >=10)
                        {
                            isHeroDefense = false;
                            HeroDefenseTime = 0;
                            HeroDefense.CurrentPositionY = 0;
                            HeroDefense.ShowingRect = HeroDefense.SourceRect(HeroDefense);
                        }
                    }
                    if (isHeroDefense == false)
                    {
                        HeroDefense.Visible = false;
                        Siki.Visible = true;
                        HeroDefense.CurrentPositionY = 0;
                        HeroDefense.ShowingRect = HeroDefense.SourceRect(HeroDefense);
                    }

                }
            }
            if (isHeroDefense == true)
            {
                HeroDefenseShooted_fire.BackOffset = Hero.BackOffset;
                if (HeroDefenseShooted_fire.Visible == true)
                {
                    HeroDefenseShooted_fire.iCount++;
                    if (HeroDefenseShooted_fire.iCount == theHeroDefenseShootedFrame)//6)
                    {
                        HeroDefenseShooted_fire.ObjectAnimation(HeroDefenseShooted_fire);
                        HeroDefenseShooted_fire.iCount = 0;
                    }
                }
            }
            if (HeroHighRunning.Visible == false)
            {
                HeroDefenseShooted_fire.Visible = false;
            }
            if (HeroKilled.Visible == true)
            {
                HeroHighRunning.Visible = false;
            }
            //主角牛逼时间
            if (isHeroNiuBility == true)
            {
                HeroNiubilityTime++;
                if (HeroNiubilityTime >=20)
                {
                    HeroNiubilityTime = 0;
                    isHeroNiuBility = false;
                }

            }
            HeroHighRunning.BackOffset = Hero.BackOffset;
            if (HeroAttacked.Visible == false && Hero.Visible == false && HeroHighRunning.Visible == false)
            {
                Hero.Shader.Visible = false;
            }
            
            Hero.Shader.BackOffset = Hero.BackOffset;
            HeroAttacked.BackOffset = Hero.BackOffset;
            Hero.iCount++;
            if (Hero.isSpeedChange == true)
            {
                SpeedChange(Hero, true, 10, 0.01f);
            }
            if (Bus.SPX >= 10 && HeroAttacked.Visible == false && Hero.HP > 0)
            {
                Hero.Visible = false;

                HeroHighRunning.Visible = true;
            }
            if (Bus.SPX < 10 && HeroAttacked.Visible == false)
            {
                Hero.Visible = true;

                HeroHighRunning.Visible = false;
            }
            if (Hero.HP <= 0 && explode2.isPool == true)
            {
                HeroHighRunning.Visible = false;
                Hero.Visible = true;
            }
            if (Hero.HP <= 0 && Hero.Visible == true && explode2.isPool == true)
            {
                if (isExplodeSoundStart == false)
                {
                    isExplodeSoundStart = true;
                    //Audio.SEPlay("05");
                }
                HeroGoToCenter(Hero);
                HeroKilling.BackOffset = Hero.BackOffset;
                HeroKilling.BackOffset.Y = Hero.BackOffset.Y + 100;
                Hero.HP = 0;
                Boss.BackOffset.X += 5;
                explode2.Visible = true;
                explode2.iCount++;
                explode2.BackOffset = Hero.BackOffset;
                explode2.ShowingRect = explode2.SourceRect(explode2);
                if (explode2.iCount == 2)
                {
                    explode2.SPX++;
                    explode2.ObjectAnimation(explode2);

                    if (explode2.SPX == 30)
                    {
                        Hero.Visible = false;
                        explode2.Visible = false;
                        explode2.isPool = false;
                        explode2.SPX = 0;
                        LastExplode1.Visible = true;
                        LastExplode2.HP = 2;
                        Audio.SEPlay("05");
                    }
                    explode2.iCount = 0;
                }
                if (Bus.SPX > 0)
                {
                    BackGround.SPX -= BackGroundSPXDec;
                    if (BackGround.SPX <= 0) BackGround.SPX = 0;
                    Bus.SPX -= (BusSPXDec);
                }
            }
            if (LastExplode2.isPool == false&&LastExplode2.HP==2)
            {
                FarBackGround1.SPX = 0;
                if (Bus.SPX > 0)
                {
                    BackGround.SPX -= BackGroundSPXDec;
                    if (BackGround.SPX <= 0)
                    {
                        BackGround.SPX = 0;
                        Bus.SPX -= (BusSPXDec - 0.01f);
                    }
                }
                Hero.Visible = false;
                HeroKilling.Visible = true;
                HeroKilledShader.BackOffset.X = HeroKilling.BackOffset.X+10;
                HeroKilledShader.BackOffset.Y = Bus.BackOffset.Y + (Hero.BackOffset.Y - (Prefs.WindowSizeH - 528)) + 130;
                HeroKilledShader.Visible = true;


                if (Hero.isStart == true)
                {
                    HeroKilling.iCount += 0.01f;
                    if (HeroKilling.isStart == false)
                    {
                        Bus.BackOffset.Y = (Prefs.WindowSizeH - 528) + 250 * HeroKilling.iCount - 50 * HeroKilling.iCount * HeroKilling.iCount;
                        Bus1.BackOffset.Y = (Prefs.WindowSizeH - 528) + 250 * HeroKilling.iCount - 50 * HeroKilling.iCount * HeroKilling.iCount;
                        BackGround.BackOffset.Y = 100 * HeroKilling.iCount - 25 * HeroKilling.iCount * HeroKilling.iCount - 200;
                        BackGround1.BackOffset.Y = 100 * HeroKilling.iCount - 25 * HeroKilling.iCount * HeroKilling.iCount - 200;

                        if (100 * HeroKilling.iCount > 250 && 80 * HeroKilling.iCount < 380)
                        {
                            if (isHeroHitLand == false)
                            {
                                isHeroHitLand = true;
                                Audio.SEPlay("03");
                            }
                            HeroKilling.CurrentPositionX = 2;
                            HeroKilling.ShowingRect = HeroKilling.SourceRect(HeroKilling);
                        }
                        if (100 * HeroKilling.iCount >= 500)
                        {
                            isHeroHitLand = false;
                            HeroKilling.CurrentPositionX = 1;
                            HeroKilling.ShowingRect = HeroKilling.SourceRect(HeroKilling);
                            HeroKilling.isStart = true;
                        }
                    }
                    if (HeroKilling.isStart == true)
                    {

                        Boss.SPX = -5;
                        if (Bus.SPX > 0)
                        {
                            Bus.SPX -= (BusSPXDec-0.028f);
                        }
                        HeroKilled.iCount += 0.01f;
                        if (60 * HeroKilled.iCount <= 180)
                        {
                            Bus.BackOffset.Y = (Prefs.WindowSizeH - 528) + 90 * HeroKilled.iCount - 30 * HeroKilled.iCount * HeroKilled.iCount;
                            Bus1.BackOffset.Y = (Prefs.WindowSizeH - 528) + 90 * HeroKilled.iCount - 30 * HeroKilled.iCount * HeroKilled.iCount;
                            BackGround.BackOffset.Y = 10 * HeroKilled.iCount - 2 * HeroKilled.iCount * HeroKilled.iCount - 200;
                            BackGround1.BackOffset.Y = 10 * HeroKilled.iCount - 2 * HeroKilled.iCount * HeroKilled.iCount - 200;

                        }

                        if (60 * HeroKilled.iCount >= 180)
                        {
                            if (isHeroHitLand == false)
                            {
                                isHeroHitLand = true;
                                Audio.SEPlay("03");
                            }
                            HeroKilling.CurrentPositionX = 1;
                            HeroKilling.ShowingRect = HeroKilling.SourceRect(HeroKilling);


                        }
                        if (60 * HeroKilled.iCount >= 200)
                        {
                            HeroKilled.CurrentPositionX = 0;//英雄被杀动画帧归零；
                            HeroKilled.CurrentPositionY = 0;
                            HeroKilling.CurrentPositionX = 0;//英雄正在被杀动画帧归零                           
                            HeroKilling.CurrentPositionY = 0;
                            HeroKilling.ShowingRect = HeroKilling.SourceRect(HeroKilling);
                            HeroKilled.iCount = 0;//计数器归零
                            HeroKilling.iCount = 0;
                            explode2.isPool = true;
                            LastExplode2.isPool = true;
                            HeroKilling.isStart = false;
                            LastExplode2.HP = 0;
                            HeroKilled.BackOffset = HeroKilling.BackOffset;
                            HeroKilled.BackOffset.Y = HeroKilling.BackOffset.Y + 10;
                            HeroKilledShader.BackOffset = HeroKilled.BackOffset;
                            HeroKilled.Visible = true;
                            HeroKilling.Visible = false;
                            Hero.isStart = false;
                            GameOver.Visible = true;

                            isHeroHitLand = false;
                            Audio.BGMStop();
                            
                        }


                    }
                }


            }
            if (Hero.iCount ==theHeroFrame)// 5)主角的动画帧数
            {
                HeroAttacked.iCount++;
                if (HeroAttacked.Visible == true)
                {
                    Hero.Shader.Visible = HeroAttacked.Visible;
                    HeroAttacked.ObjectAnimation(HeroAttacked);


                }
                HeroHighRunning.ObjectAnimation(HeroHighRunning);
                Hero.ObjectAnimation(Hero);
                Hero.iCount = 0;
            }
            if (HeroAttacked.iCount == 15)
            {
                HeroAttacked.isPool = false;
                HeroAttacked.iCount = 0;
            }
            if (HeroAttack1.Visible == true)
            {
                HeroHighRunning.Visible = false;

                HeroAttack1.iCount++;
                if (HeroAttack1.iCount >= 5)
                {
                    HeroAttack1.HP++;
                    HeroAttack1.iCount = 0;
                    HeroAttack1.ObjectAnimation(HeroAttack1);
                    if (HeroAttack1.HP >= 6)
                    {
                        HeroAttack1.HP = 0;
                        HeroAttack1.Visible = false;
                        HeroAttack2.Visible = true;
                    }
                }
            }
            if (HeroAttack2.Visible == true)
            {
                HeroAttack2.iCount++;
                if (HeroAttack2.iCount >= 5)
                {
                    HeroAttack2.HP++;
                    HeroAttack2.iCount = 0;
                    HeroAttack2.ObjectAnimation(HeroAttack2);
                    if (HeroAttack2.HP >= 10)
                    {
                        HeroAttack2.HP = 0;
                        HeroAttack2.Visible = false;
                        HeroHighRunning.Visible = true;
                    }
                }
            }
            if (HeroAttacked.Visible == false && HeroKilling.Visible == false && HeroKilled.Visible == false&&HeroAttack1.Visible==false&&HeroAttack2.Visible==false)
            {
                HeroHighRunning.Visible = true;
                HeroAttacked.isPool = true;
            }
            if (HeroAttacked.Visible == true)
            {
                Boss.SPX -= 0.1f;
                Hero.Visible = false;
                SpeedChange(Hero, false, 3, 0.1f);
            }
            if (Hero.Visible == true && HeroHighRunning.Visible == true)
            {
                SpeedUpShader.Visible = true;
                SpeedChange(Hero, true, 10, 0.03f);
            }
            //Control Hero

            HitSHaders[0].iCount++;

            if (HitSHaders[0].iCount == 1)
            {
                foreach (var hs in HitSHaders)
                {
                    hs.BackOffset.X = Hero.BackOffset.X - 70;
                   hs.BackOffset.Y = Hero.BackOffset.Y - 55;
                    if (hs.Visible == true)
                    {
                        hs.ObjectAnimation(hs);
                    }
                }
                HitSHaders[0].iCount = 0;
            }
            SpeedUpShader.ObjectAnimation(SpeedUpShader);
            if (Hero.HP != 0 && Boss1Killed.Visible == false && explode.Visible == false&&isHeroDefense==false&&isHeroNiuBility==false&&isTimeStop==false)
            {
                if (Input.Press(Keys.Down))
                {
                    Hero.BackOffset.Y += HeroUpOrDownSP;// 5f;
                }
                if (Input.Press(Keys.Up))
                {
                    Hero.BackOffset.Y -= HeroUpOrDownSP;// f;
                }
                if (Input.Press(Keys.Left))
                {
                    Hero.BackOffset.X -= HeroLeftSP;// 10f;
                }
                if (Input.Press(Keys.Right))
                {
                    SpeedUpShader.Visible = true;
                    Hero.BackOffset.X += HeroRightSP;// 5f;
                }
                //测试Hero and Boss HP Control
                if (Input.Press(Keys.H))
                {
                    Hero.HP += 10;
                }
                if (Input.Press(Keys.B))
                {
                    Boss.HP += 10;
                }
                Hero.BackOffset.Y = MathHelper.Clamp(Hero.BackOffset.Y, 300f, 495f);
                Hero.BackOffset.X = MathHelper.Clamp(Hero.BackOffset.X, 0f, 1000f);
            }

        }
        
    }
}
