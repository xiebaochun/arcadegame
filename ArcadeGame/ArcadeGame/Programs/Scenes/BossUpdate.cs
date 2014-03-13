using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using WEngine;

namespace ArcadeGame.Programs.Scenes
{
    partial class Scene_Main
    {
       
        public int BossShootingIcount=0;
        public int BossShootingTime = 0;
        public int timeStopShootTime = 0;
        public Boolean isgotoHero = false;
        public float bulletSPX = 15;
        public Boolean isBossHitLand = false;
        private void BossUpdate()
        {
            
            //BossHP同步
            BossHP_01.ShowingRect = new Rectangle(0, 0, (int)(BossHP_01.SourceTexture.Width * ((float)Boss.HP / 1000)), BossHP_01.SourceTexture.Height);

            Boss1Killed.Shader.Visible = Boss1Killed.Visible;
            Boss2Killed.Shader.Visible = Boss2Killed.Visible;
            Boss1Killed.Shader.BackOffset.X = Boss1Killed.BackOffset.X;
            Boss2Killed.Shader.BackOffset.X = Boss2Killed.BackOffset.X;
            TakeOutGun.BackOffset = Boss.BackOffset;
            BossAttacked.BackOffset = BossAttacked.BackOffset;
            BossAttacked.BackOffset = Boss.BackOffset;
            BossAttacked.Z = Boss.Z;

           
            if (BossAttacked.Visible == true)
            {
                BossAttacked.iCount++;
                if(BossAttacked.iCount==theBossAttackedFrame)

                {
                    BossAttacked.iCount = 0;
                    BossAttacked.ObjectAnimation(BossAttacked);
                    
                }
                if (BossAttacked.Visible == false)
                {
                    Boss.Visible = true;
                }
            }
            if (explode.Visible == true)
            {
                if (isExplodeSoundStart == false)
                {
                    isExplodeSoundStart = true;
                    //Audio.SEPlay("05");
                }
                BossAttacked.Visible = true;
                if (Bus.SPX > 0)
                {
                    BackGround.SPX -= BackGroundSPXDec;
                    if (BackGround.SPX <= 0) BackGround.SPX = 0;
                    Bus.SPX -= BusSPXDec;

                }
                if (Hero.SPX <= 5)
                {
                    Hero.SPX += 0.03f;
                }
                Hero.BackOffset.X += Hero.SPX;
                // Hero.HP = 0;
                HeroGoToCenter(Boss);
                Boss1Killed.BackOffset = Boss.BackOffset;
                Boss2Killed.BackOffset = Boss.BackOffset;
                Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);
                Boss.SPY = 0;
                Boss.SPX = 0;
                time++;
                explode.BackOffset = Boss.BackOffset;
                if (time == 3)
                {
                    explode.iCount++;
                    explode.ObjectAnimation(explode);
                    if (explode.iCount == 50)
                    {
                        explode.isPool = false;
                    }
                    time = 0;
                }

            }
            if (explode.isPool == false&&Boss.Visible==true&&Boss.isPool==true)
            {
                isExplodeSoundStart = false;
                Audio.SEPlay("05");
                BossAttacked.Visible = false;
                Boss.isPool = false;
                LastExplode1.Visible = true;
                LastExplode2.HP = 1;
            }

            //if (BossAttacked.Visible == true)
            //{
            //    BossAttacked.iCount++;
            //    if (BossAttacked.iCount == 6)
            //    {
            //        BossAttacked.ObjectAnimation(BossAttacked);
            //        BossAttacked.iCount = 0;
            //    }
            //    if (BossAttacked.Visible == false)
            //    {
            //        Boss.Visible = true;
            //    }

            //}
            if (TakeOutGun.Visible == true)
            {
                TakeOutGun.iCount++;
                if (TakeOutGun.iCount == theBossTakeOutGunFrame)
                {
                    TakeOutGun.ObjectAnimation(TakeOutGun);
                    TakeOutGun.iCount = 0;
                }
                if (TakeOutGun.Visible == false)
                {
                    BossShooting.Visible = true;
                }
            }

            //if (AfterShooting.Visible == true)
            //{
            //    AfterShooting.iCount++;
            //    if (AfterShooting.iCount == 6)
            //    {
            //        AfterShooting.ObjectAnimation(AfterShooting);
            //        AfterShooting.iCount = 0;
            //    }

            //    if (AfterShooting.Visible == false)
            //    {
            //        BossShooting.Visible = true;
            //    }

            //}
            //时间停止3时破碎动画
            if (timeStop3.Visible == true)
            {
                timeStop3.iCount++;
                if (timeStop3.iCount >= thebrokenframe)
                {
                    timeStop3.iCount = 0;
                    timeStop3.ObjectAnimation(timeStop3);

                }
                
            }
            //如果大山砸中boss
            if (mountain.BackOffset.Y >= Boss.BackOffset.Y-150)
            {
                
                //isTimeStop3 = false;
                //mountain.Visible = false;
                isGotoTimeStop3HillDownTalk =true;
                redShader.Visible = false;
                //mountain.BackOffset.Y = -mountain.SourceTexture.Height;
                //FarBackGround1.EndRedShadow();
                //FarBackGround2.EndRedShadow();
                //BackGround.EndRedShadow();

                //BackGround1.EndRedShadow();
                //Bus.EndRedShadow();
                //Bus1.EndRedShadow();
                //isgotoHero = true;
                if(mountain.Visible==true)
                {

                    if (mountain.Alpha == 1)
                    {
                        LastExplode1.BackOffset = new Vector2(Boss.BackOffset.X-237, Boss.BackOffset.Y-162);
                        LastExplode2.BackOffset = LastExplode1.BackOffset;
                        LastExplode1.Visible = true;
                    }
                Random random = new Random();
                int rx = random.Next(1,30);
                int ry = random.Next(1,30);
                BackGround.BackOffset.Y =ry-10;
                BackGround1.BackOffset.Y = ry-10;
                Bus.BackOffset.Y = Prefs.WindowSizeH - 528 + ry;
                Bus1.BackOffset.Y=Prefs.WindowSizeH-528+ry;
            
                mountain.Alpha-=0.01f;
                }
                if (mountain.Alpha <= 0)
                {
                    //isGotoTimeStop3RedDisappear = true;
                    
                    littleRedShader.Visible = false;
                    mountain.Visible = false;
                   timeStopBackSPX = 20;
                  Bus.SPX = -20;
                  Boss.SPX = -30;
                isgotoHero = true;
                }


                
                if (Hero.BackOffset.X >= 0)
                {
                   
                    isTimeStop3 = false;
                    isTimeStop = false;
                    mountain.BackOffset.Y = -mountain.SourceTexture.Height;
                    isgotoHero = false;
                    timeStopBackSPX = -10;
                    Bus.SPX = 10;
                    Boss.SPX = 10;
                    BackGround.SPX = 30;
                    bulletSPX = Bus.SPX + 10;
                    FarBackGround1.SPX = 1;
                    isBossComeBack = true;
                    GoToCenter(LastExplode1);
                    GoToCenter(LastExplode2);

                }
            }
            //时间停止1时子弹动画
           
                foreach (var bullet in timeStopBullets)
                {
                    if (bullet.Visible == true)
                    {

                        bullet.iCount++;
                       
                        if (bullet.iCount >= theBulletFrame)
                        {
                            
                            bullet.iCount = 0;
                            bullet.ObjectAnimation(bullet);
                        }
                        bullet.BackOffset.X -= bulletSPX;
                        bullet.Z = bullet.BackOffset.Y + bullet.SourceTexture.Height / bullet.spriteSizeY;

                        bullet.CollisionRect = new Rectangle((int)bullet.BackOffset.X,(int) bullet.BackOffset.Y + bullet.SourceTexture.Height / bullet.spriteSizeY - 10, bullet.SourceTexture.Width / bullet.spriteSizeX, 10);
                        if (Hero.CollisionRect.Intersects(bullet.CollisionRect))
                        {
                            if (isHeroNiuBility == false)
                            {
                                if (isHeroDefense == false)
                                {
                                    playTheHeroAttackedSound();
                                    Hero.HP -= HeroHPDec6;
                                    HeroHighRunning.Visible = false;
                                    HeroAttacked.BackOffset = Hero.BackOffset;
                                    HeroAttacked.Visible = true;
                                    isHeroNiuBility = true;
                                    HeroDefenseShooted_fire.Visible = true;
                                }
                            }
                          
                        }
                    }
                 
                    
            } 
            if (isTimeStop == true)
                    {
                        //列车慢慢停止；
                       
                       
                            BackGround.SPX = Bus.SPX;
                       
                        FarBackGround1.SPX = 0;
                    }
            //是否产生红色背景并扩大
            if (isShowLittleRed == true)
            {
                littleRedShader.BackOffset = Boss.BackOffset+new Vector2(Boss.SourceTexture.Width / (Boss.spriteSizeX * 2), Boss.SourceTexture.Height / (Boss.spriteSizeY * 2));
                littleRedShader.Visible = true;
                littleRedShader.Scale += theRedShaerEnlargeSpeed;//0.8f;
                if (littleRedShader.Scale >=15)
                {
                    isShowLittleRed = false;
                }
            }
            //是否缩小背景并消失
            if (isEndLittleRed == true)
            {
                littleRedShader.Scale -= 0.5f;
                if (littleRedShader.Scale <=0.01f)
                {
                    isEndLittleRed = false;
                    littleRedShader.Visible = false;
                }
            }
            //最后大爆炸循环
            if (LastExplode1.Visible == true)
            {
                LastExplode1.iCount++;
                if (LastExplode1.iCount == theLastExplodeFrame)
                {
                    LastExplode1.ObjectAnimation(LastExplode1);
                  LastExplode1.iCount=0;
                }
                if(LastExplode1.Visible==false)
                {
                    LastExplode2.Visible=true;
                    Audio.SEPlay("05");
                }

            }
            if(LastExplode2.Visible==true)
            {
                LastExplode2.isPool = false;
               
                LastExplode2.iCount++;
                if (LastExplode2.iCount == theLastExplodeFrame)
                {

                    LastExplode2.ObjectAnimation(LastExplode2);
                    LastExplode2.iCount=0;
                }
            }
            Boss.iCount++;
            if (Boss.iCount == theBossFrame)//2
            {
                Boss.ObjectAnimation(Boss);
                if (BossShooting.Visible == true)
                {
                    BossShooting.iCount++;
                    if (BossShooting.iCount == 25)
                    {
                        BossShooting.isPool = false;
                        BossShooting.iCount = 0;
                    }
                    BossShooting.ObjectAnimation(BossShooting);
                    //时间停止
                    if (isTimeStop == true||isTimeStop2==true)
                    {
                        timeStopShootTime++;
                        if (timeStopShootTime >=10)
                        {
                            //redShader.EndRedShadow();
                            timeStopShootTime = 0;
                            foreach (var bullet in timeStopBullets)
                            {
                                if (bullet.Visible == false)
                                {
                                    bullet.Visible = true;
                                    bullet.BackOffset = BossShooting.BackOffset + new Vector2(-270, -62);
                                    break;
                                }
                            }
                        }
                        
                    }

                }
                if (isTimeStop == true)
                {
                    if (timeStopBullets[9].Visible == true)
                    {
                        //FarBackGround1.EndRedShadow();
                        //FarBackGround2.EndRedShadow();
                        //BackGround.EndRedShadow();

                        //BackGround1.EndRedShadow();
                        //Bus.EndRedShadow();
                        //Bus1.EndRedShadow();
                        isEndLittleRed = true;
                        littleRedShader.Scale -= 0.01f;
                        if (littleRedShader.Scale <= 0.01f)
                        {
                            littleRedShader.Visible = false;
                        }
                        isgotoHero = true;
                        timeStopBackSPX = 20;
                        Bus.SPX = -22;
                        Boss.SPX = -30;
                        bulletSPX = Bus.SPX;
                        if (Hero.BackOffset.X >= 0)
                        {
                            Hero.Shader.Visible = true;
                            isGotoTimeStop2HeroTalk = true;
                            isTimeStop = false;
                            isgotoHero = false;
                            timeStopBackSPX = -10;
                            Bus.SPX = 10;
                            Boss.SPX = 10;
                            BackGround.SPX = 30;
                            bulletSPX = Bus.SPX+10;
                            FarBackGround1.SPX = 1;
                            isBossComeBack = true;
                           
                        }

                    }
                }
                if (isTimeStop2 == true)
                {
                    if (timeStopBullets[9].Visible == true)
                    {
                        Boss.SPX = 5;
                       
                        if (Boss.BackOffset.X <= Prefs.WindowSizeW)
                        {
                            isStartStopTimeShoot = false;
                            isTimeStop2 = false;
                            isStartStop2 = false;
                            foreach (var bullet in timeStopBullets)
                            {
                                if (bullet.Visible == true)
                                {
                                    bullet.Visible = false;

                                }
                            }
                        }
                    }
                }
                Boss.iCount = 0;
            }
            //if (BossShooting.Visible == true)
            //{
            //    BossShootingIcount++;
            //    if (BossShootingIcount == 2)
            //    {
            //        BossShooting.ObjectAnimation(BossShooting);
            //        BossShooting.ShowingRect = BossShooting.SourceRect(BossShooting);
            //        BossShootingIcount = 0;
            //        if (BossShooting.CurrentPositionX == 3 && BossShooting.CurrentPositionY == 3)
            //        {
            //            BossShooting.Visible = false;
            //            BossShooting.isPool = false;
            //        }
            //    }

            //    if (BossShooting.Visible == false)
            //    {
            //        BossShootingTime++;
            //       TakeOutGun.Visible = true;
            //       if (BossShootingTime >= 2)
            //        {
            //            TakeOutGun.Visible = false;
            //            BossShootingTime = 0;
            //            Boss.Visible = true;
            //            BossShooting.isPool = true;
            //        }
            //    }
            //}
            if (BossShooting.Visible == true)
            {
                Boss.BackOffset.X += -Boss.SPX;
                Boss.BackOffset.Y += -Boss.SPY;
                BossShooting.BackOffset.X = Boss.BackOffset.X - 111;
                BossShooting.BackOffset.Y = Boss.BackOffset.Y;
                Boss.BackOffset.Y = MathHelper.Clamp(Boss.BackOffset.Y,
                                                   Prefs.WindowSizeH - Bus.SourceTexture.Height / 2 - Boss.SourceTexture.Height * 3 / 5,
                                                   Prefs.WindowSizeH - Boss.SourceTexture.Height * 16 / 15);

            }

            if (BossShooting.Visible == false && Boss.HP > 0 && SessionIndex >= 3 && BossAttacked.Visible == false)
            {
                Boss.Visible = true;
                BossShooting.isPool = true;
            }

            if (Boss.isPool == false && LastExplode2.HP == 1)
            {
                FarBackGround1.SPX = 0;
                if (Bus.SPX > 0)
                {
                    BackGround.SPX -= BackGroundSPXDec;
                    if (BackGround.SPX <= 0) BackGround.SPX = 0;
                   
                       Bus.SPX -= BusSPXDec;
                    
                    
                    

                }

                /*if (Boss1Killed.iCount >=0)
                {
                    Boss1Killed.iCount += 0.1f;
                    Boss1Killed.BackOffset.X -=3;
                    Boss1Killed.BackOffset.Y = Boss1Killed.BackOffset.Y - 25 * Boss1Killed.iCount + 10 * Boss1Killed.iCount * Boss1Killed.iCount;
                    Boss2Killed.BackOffset.X += 2;
                    Boss2Killed.BackOffset.Y = Boss2Killed.BackOffset.Y - 24 * Boss1Killed.iCount + 10 * Boss1Killed.iCount * Boss1Killed.iCount;
                }
                if (2 * Boss1Killed.iCount > 3 && 2 * Boss1Killed.iCount < 4)
                {
                    Boss1Killed.CurrentPositionX = 1;
                    Boss2Killed.CurrentPositionX = 1;
                    Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                    Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);
                }
                if (2 * Boss1Killed.iCount >5.5)
                {
                    Boss1Killed.CurrentPositionX = 2;
                    Boss2Killed.CurrentPositionX = 2;
                    Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                    Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);
                }
                if (Boss2Killed.BackOffset.Y>=430)
                {

                  //  Boss1Killed.Visible = false;
                  //  Boss2Killed.Visible = false;
                    Boss1Killed.iCount =-1;
                    Hero.HP = 0;
                   
                }
                  */
                HeroKilling.iCount += 0.01f;
                if (Hero.isStart == true && LastExplode2.isPool == false&&LastExplode2.HP==1)
                {
                    if (Boss1Killed.HP != 100)
                    {
                        Boss1Killed.Visible = true;
                        Boss2Killed.Visible = true;
                        Boss1Killed.Shader.Visible = true;
                        Boss1Killed.Shader.BackOffset.X = Boss1Killed.BackOffset.X;

                        Boss1Killed.Shader.BackOffset.Y = Bus.BackOffset.Y + (Boss.BackOffset.Y - (Prefs.WindowSizeH - 528)) - 20;
                        Boss2Killed.Shader.Visible = true;
                        Boss2Killed.Shader.BackOffset.X = Boss2Killed.BackOffset.X;
                        Boss2Killed.Shader.BackOffset.Y = Bus.BackOffset.Y + (Boss.BackOffset.Y - (Prefs.WindowSizeH - 528)) - 20;
                        Boss1Killed.BackOffset.X += 1f;
                        Bus.BackOffset.Y = (Prefs.WindowSizeH - 528) + 200 * HeroKilling.iCount - 50 * HeroKilling.iCount * HeroKilling.iCount;
                        Bus1.BackOffset.Y = (Prefs.WindowSizeH - 528) + 200 * HeroKilling.iCount - 50 * HeroKilling.iCount * HeroKilling.iCount;
                        BackGround.BackOffset.Y = 100 * HeroKilling.iCount - 25 * HeroKilling.iCount * HeroKilling.iCount - 200;
                        BackGround1.BackOffset.Y = 100 * HeroKilling.iCount - 25 * HeroKilling.iCount * HeroKilling.iCount - 200;
                        if (100 * HeroKilling.iCount > 200 && 60 * HeroKilling.iCount < 380)
                        {
                          

                            Boss1Killed.CurrentPositionX = 1;
                            Boss2Killed.CurrentPositionX = 1;

                            Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                            Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);
                            if (HeroKilling.iCount > 390)
                            {
                                if (isBossHitLand == false)
                                {
                                    isBossHitLand = true;
                                    Audio.SEPlay("03");
                                }

                                Boss1Killed.CurrentPositionX = 2;
                                Boss2Killed.CurrentPositionX = 2;
                                Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                                Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);
                                isBossHitLand = false;
                            }

                        }
                    }
                    if (100 * HeroKilling.iCount >= 400)
                    {
                        Bus.SPX -= 0.015f;
                        Hero.Visible = false;
                        HeroHighRunning.Visible = false;
                        Siki.Visible = false;
                        SpeedUpShader.Visible = false;
                        Boss1Killed.HP = 100;
                        Boss1Killed.iCount += 0.01f;
                        Boss1Killed.CurrentPositionX = 2;
                        Boss2Killed.CurrentPositionX = 2;
                        Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                        Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);
                        Boss1Killed.Shader.Visible = true;
                        Boss1Killed.Shader.BackOffset.X = Boss1Killed.BackOffset.X;

                        Boss1Killed.Shader.BackOffset.Y = Bus.BackOffset.Y + (Boss.BackOffset.Y - (Prefs.WindowSizeH - 528));
                        Boss2Killed.Shader.Visible = true;
                        Boss2Killed.Shader.BackOffset.X = Boss2Killed.BackOffset.X;
                        Boss2Killed.Shader.BackOffset.Y = Bus.BackOffset.Y + (Boss.BackOffset.Y - (Prefs.WindowSizeH - 528));
                        if (60 * Boss1Killed.iCount < 180)
                        {
                            isBossHitLand = false;
                            Bus.BackOffset.Y = (Prefs.WindowSizeH - 528) + 90 * Boss1Killed.iCount - 30 * Boss1Killed.iCount * Boss1Killed.iCount;
                            Bus1.BackOffset.Y = (Prefs.WindowSizeH - 528) + 90 * Boss1Killed.iCount - 30 * Boss1Killed.iCount * Boss1Killed.iCount;
                            BackGround.BackOffset.Y = 10 * Boss1Killed.iCount - 2 * Boss1Killed.iCount * Boss1Killed.iCount - 200;
                            BackGround1.BackOffset.Y = 10 * Boss1Killed.iCount - 2 * Boss1Killed.iCount * Boss1Killed.iCount - 200;
                        }
                        if (60 * Boss1Killed.iCount >= 180)
                        {
                           
                            Boss1Killed.Shader.BackOffset = Boss1Killed.BackOffset;
                            Boss2Killed.Shader.BackOffset = Boss2Killed.BackOffset;

                            Boss1Killed.ShowingRect = Boss1Killed.SourceRect(Boss1Killed);
                            Boss2Killed.ShowingRect = Boss2Killed.SourceRect(Boss2Killed);

                        }
                        if (60 * Boss1Killed.iCount >= 220)
                        {
                            if (isBossHitLand == false)
                            {
                                isBossHitLand = true;
                                Audio.SEPlay("03");
                            }
                            Hero.isStart = false;
                            Victory.Visible = true;
                            Audio.BGMStop();
                            Audio.BGMPlay("koulin3",false);            
                        }

                    }


                }







            }
            /* if (Boss1Killed.Visible == false && explode.Visible == false && Boss.Visible == false && BossShooting.Visible == false && enemyKilledCount >= 19)
             {
                 //BossKilled.BackOffset = Boss1Killed.BackOffset;
                 BossKilled.Visible = true;
                 BossKilled.Shader.Visible = BossKilled.Visible;
                 BossKilled.Shader.BackOffset = BossKilled.BackOffset;
                 Hero.HP = 0;
                 Hero.BackOffset.X +=5;
                 Hero.Shader.BackOffset = Hero.BackOffset;
                
                     BossKilled.BackOffset.X -= 3;
                       Bus.BackOffset.X -= 1;
                       Bus1.BackOffset.X -= 1;
                       BackGround.BackOffset.X -= 1;
                       BackGround1.BackOffset.X -= 1;
                     

                     if (BossKilled.BackOffset.X <=Prefs.WindowSizeW/2-Boss1Killed.SourceTexture.Width/6)
                     {
                         Hero.isStart = false;
                     }
           
             } */


        }
    }
}
