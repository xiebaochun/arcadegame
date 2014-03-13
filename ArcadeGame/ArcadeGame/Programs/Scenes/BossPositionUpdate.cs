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
        Boolean isBossNiubility = false;
        public int BossNiubilityTime=0;
        public Boolean isStartStopTimeShoot = false;
        public Boolean isBossComeBack = false;
        public int  BossShootingiCount=0;
        public Boolean isStartRed2 = false;
        public int showRedTime = 0;
        public Boolean isStartStop2 = false;
        public Boolean isShowLittleRed = false;
        public Boolean isEndLittleRed = false;
        public Boolean isStartHillDown = false;
       
        public void BossPositionUpdate()
        {
            Boss.Shader.Visible = Boss.Visible;
            Boss.Shader.BackOffset = Boss.BackOffset;
            BossShooting.Shader.Visible = BossShooting.Visible;
            BossShooting.Shader.BackOffset = Boss.BackOffset;

            //boss牛逼时间
            if (isBossNiubility == true)
            {
                BossNiubilityTime++;
                if (BossNiubilityTime ==theBossNiubilityTime)  //50)
                {
                    BossNiubilityTime = 0;
                    isBossNiubility = false;
                }
            }
            Boss.BackOffset.Y = MathHelper.Clamp(Boss.BackOffset.Y,
                                                       Prefs.WindowSizeH - Bus.SourceTexture.Height / 2 - Boss.SourceTexture.Height * 3 / 5,
                                                       Prefs.WindowSizeH - Boss.SourceTexture.Height * 16 / 15);
            if (Boss.Visible == true)
            {
                //如果boss不返回
                if (isBossComeBack == false)
                {
                    Boss.BackOffset.X += -Boss.SPX;
                    Boss.BackOffset.Y += -Boss.SPY;
                }
                //时间停止2
                if (isTimeStop2 == true)
                {
                    if (isStartStop2==false)
                    {
                        if (Boss.gotoCenterSlowly() == true)
                        {
                            if (isStartRed2 == false)
                            {
                                //FarBackGround1.StartRedShadow(Boss.BackOffset);
                                //FarBackGround2.StartRedShadow(Boss.BackOffset);
                                //BackGround.StartRedShadow(Boss.BackOffset);
                                //BackGround1.StartRedShadow(Boss.BackOffset);
                                //Bus.StartRedShadow(Boss.BackOffset);
                                //Bus1.StartRedShadow(Boss.BackOffset);
                                isShowLittleRed = true;
                                showRedTime++;
                                if (showRedTime >= 20)
                                {
                                    isStartStop2 = true;
                                    Boss.Z = 1;
                                    showRedTime = 0;
                                    isStartRed2 = true;
                                    isShowLittleRed = false;
                                    //FarBackGround1.EndRedShadow();
                                    //FarBackGround2.EndRedShadow();
                                    //BackGround.EndRedShadow();

                                    //BackGround1.EndRedShadow();
                                    //Bus.EndRedShadow();
                                    //Bus1.EndRedShadow();
                                }
                            }

                        }
                    }
                    if (isStartStop2==true)
                    {
                        if (isStartStopTimeShoot == false)
                        {
                            isEndLittleRed = true;
                            Boss.Z = 1;
                            Boss.Shader.Z = 1;
                            Boss.SPX = -10;
                            BossShooting.BackOffset = Boss.BackOffset;
                            if (Boss.BackOffset.X >=2000)
                            {
                                Boss.Z = 4;
                                Boss.Shader.Z = 4;
                                Boss.SPX = 0;
                                isStartStopTimeShoot = true;
                            }
                        }
                    }
                    
                    if (isStartStopTimeShoot == true)
                    {
                        if (Boss.BackOffset.Y >= Prefs.WindowSizeH - Boss.SourceTexture.Height * 16 / 15)
                        {

                            Boss.SPY = 0.6f;

                        }
                        if (Boss.BackOffset.Y <= Prefs.WindowSizeH - Bus.SourceTexture.Height / 2 - Boss.SourceTexture.Height * 3 / 5)
                        {
                            Boss.SPY = -1f;
                        }

                        BossShootingiCount++;
                        if (BossShootingiCount == 10)
                        {
                            if (BossShoot1.Visible == false && BossShoot2.Visible == false && BossShoot3.Visible == false && BossShoot4.Visible == false
                                && BossShoot5.Visible == false && BossShoot6.Visible == false)
                            {
                                Random St = new Random();
                                BossShooting.HP = St.Next(0, 100);
                                if (BossShooting.HP == 1 || BossShooting.HP == 20 || BossShooting.HP == 40 || BossShooting.HP == 60 || BossShooting.HP == 80 || BossShooting.HP == 99)
                                {


                                    if (Boss.HP > 0)
                                    {
                                        Boss.Visible = false;
                                        BossShooting.Visible = true;
                                        if (St.Next(0, 100) <= 5)
                                        {
                                            if (St.Next(1, 100) <= 2.5f)
                                            {
                                                Audio.SEPlay("31a");
                                            }
                                            else
                                            {
                                                Audio.SEPlay("31b");
                                            }
                                        }
                                        // TakeOutGun.Visible = true;
                                    }

                                }
                            }
                            BossShootingiCount = 0;
                        }
                    }
                }
                //时间停止1
                if (isTimeStop == true)
                {
                   
                    if (isStartStopTimeShoot == false)
                    {
                        if (Boss.gotoCenterSlowly() == true)
                        {
                            if (isTimeStop3 == false)
                            {
                                isStartStopTimeShoot = true;
                                BossShooting.Visible = true;
                                Boss.Visible = false;
                            }
                            //redShader.Visible = true;
                            //redShader.StartRedShadow(Boss.BackOffset);
                            //FarBackGround1.StartRedShadow(Boss.BackOffset);
                            //FarBackGround2.StartRedShadow(Boss.BackOffset);
                            //BackGround.StartRedShadow(Boss.BackOffset);
                            //BackGround1.StartRedShadow(Boss.BackOffset);
                            //Bus.StartRedShadow(Boss.BackOffset);
                            //Bus1.StartRedShadow(Boss.BackOffset);
                            if(redShader.Visible==false)
                            {
                            isShowLittleRed = true;
                            //isGotoTimeStop3HillDownTalk = true;
                            }
                            if (isTimeStop3 == true && isStartHillDown == true)
                            {
                                if (mountain.BackOffset.Y < Boss.BackOffset.Y - 150)
                                {
                                    mountain.BackOffset.X = redShader.BackOffset.X + 850;

                                    mountain.BackOffset.Y += 6;
                                    mountain.Visible = true;

                                    if (mountain.BackOffset.Y >= Boss.BackOffset.Y - 500)
                                    {
                                        //mountain.EndRedShadow();
                                        littleRedShader.Visible = false;
                                        redShader.Visible = true;
                                        if (timeStop3.Visible == false && timeStop3.HP == 0)
                                        {
                                            timeStop3.BackOffset = redShader.BackOffset + new Vector2(850, 100);
                                            timeStop3.Visible = true;
                                            timeStop3.HP = 1;
                                            littleRedShader.Visible = false;
                                            littleRedShader.Scale = 6;
                                            redShader.Visible = true;

                                        }
                                    }

                                }
                            }
                        }  
                      
                    }
                   
                    //时间停止时是否开始射击
                    if (isStartStopTimeShoot == true)
                    {
                        if (Boss.BackOffset.Y >= Prefs.WindowSizeH - Boss.SourceTexture.Height * 16 / 15)
                        {

                            Boss.SPY = 0.6f;

                        }
                        if (Boss.BackOffset.Y <= Prefs.WindowSizeH - Bus.SourceTexture.Height / 2 - Boss.SourceTexture.Height * 3 / 5)
                        {
                            Boss.SPY = -1f;
                        }
                       
                        BossShootingiCount++;
                        if (BossShootingiCount == 10)
                        {
                            if (BossShoot1.Visible == false && BossShoot2.Visible == false && BossShoot3.Visible == false && BossShoot4.Visible == false
                                && BossShoot5.Visible == false && BossShoot6.Visible == false)
                            {
                                Random St = new Random();
                                BossShooting.HP = St.Next(0, 100);
                                if (BossShooting.HP == 1 || BossShooting.HP == 20 || BossShooting.HP == 40 || BossShooting.HP == 60 || BossShooting.HP == 80 || BossShooting.HP == 99)
                                {


                                    if (Boss.HP > 0 && TalkBackGround.Visible == false)
                                    {
                                        Boss.Visible = false;
                                        BossShooting.Visible = true;
                                        if (St.Next(0, 100) <= 5)
                                        {
                                            if (St.Next(1, 100) <= 2.5f)
                                            {
                                                Audio.SEPlay("31a");
                                            }
                                            else
                                            {
                                                Audio.SEPlay("31b");
                                            }
                                        }
                                        // TakeOutGun.Visible = true;
                                    }

                                }
                            }
                            BossShootingiCount = 0;
                        }
                    }
                    
                }
                //如果不是时间停止时间
                if (isTimeStop == false&&isTimeStop2==false)
                {
                    if (isBossComeBack == false)
                    {
                        if (Boss.BackOffset.X <= Hero.BackOffset.X)
                        {
                            Boss.SPX = -1;
                            if (Boss.BackOffset.Y >= Prefs.WindowSizeH - Boss.SourceTexture.Height * 16 / 15)
                            {
                                Random r = new Random();
                                k = r.Next(0, 20);
                                if (k > 10)
                                {
                                    Boss.SPY = 0.3f;
                                }
                                if (k <= 10)
                                {
                                    Boss.SPY = -0.3f;
                                }

                            }
                            if (Boss.BackOffset.Y <= Prefs.WindowSizeH - Bus.SourceTexture.Height / 2 - Boss.SourceTexture.Height * 3 / 5)
                            {
                                Boss.SPY = -0.3f;
                            }
                        }

                        Boss.BackOffset.Y = MathHelper.Clamp(Boss.BackOffset.Y,
                                                            Prefs.WindowSizeH - Bus.SourceTexture.Height / 2 - Boss.SourceTexture.Height * 3 / 5,
                                                            Prefs.WindowSizeH - Boss.SourceTexture.Height * 16 / 15);
                        if (HeroKilling.Visible == true || HeroKilled.Visible == true)
                        {
                            Boss.SPX -= 0.3f;
                        }
                        if (HeroKilling.Visible == false && HeroKilled.Visible == false)
                        {
                            if (Boss.BackOffset.X >= Prefs.WindowSizeW + 12)
                            {
                                Boss.SPX = 1;
                                Boss.SPY = -0.3f;

                            }

                            BossShooting.BackOffset.X = Boss.BackOffset.X - 111;
                            BossShooting.BackOffset.Y = Boss.BackOffset.Y;

                            BossShooting.iCount++;
                            if (BossShooting.iCount == 10)
                            {
                                if (BossShoot1.Visible == false && BossShoot2.Visible == false && BossShoot3.Visible == false && BossShoot4.Visible == false
                                    && BossShoot5.Visible == false && BossShoot6.Visible == false)
                                {
                                    Random St = new Random();
                                    BossShooting.HP = St.Next(0, 100);
                                    if (BossShooting.HP == 1 || BossShooting.HP == 20 || BossShooting.HP == 40 || BossShooting.HP == 60 || BossShooting.HP == 80 || BossShooting.HP == 99)
                                    {
                                        if (BossShooting.HP == 40)
                                        {
                                            Boss.SPX = -1f;
                                        }
                                        if (BossShooting.HP == 60 || BossShooting.HP == 80 || BossShooting.HP == 99||BossShooting.HP == 1 || BossShooting.HP == 20)
                                        {
                                            Boss.SPX = 1f;
                                        }
                                      
                                        if (Boss.HP > 0 && TalkBackGround.Visible == false)
                                        { 
                                            Random r = new Random();
                                        ShootStyle = r.Next(1, (int)ShootStyleCount);
                                            Boss.Visible = false;
                                            BossShooting.Visible = true;
                                            // TakeOutGun.Visible = true;
                                        }
                                        // Hero.CollisionPoint = new Point((int)(Hero.Position.X + Hero.Render.Width / Hero.spriteSizeX/2), (int)Hero.Position.Y+Hero.Render.Height/2);
                                        //BossShooting.CollisionRect = new Rectangle((int)BossShooting.Position.X - ShootWidth, (int)BossShooting.Position.Y, ShootWidth, Hero.Render.Height / 2);
                                        //  if(BossShooting.CollisionRect.Contains(Hero.CollisionPoint))
                                        //  {
                                        //    HeroHP -= 30;
                                        //     if (HeroHP <= 0)
                                        //     {
                                        //    Hero.isAlive = false;
                                        //     }

                                        //  }
                                    }
                                }
                                BossShooting.iCount = 0;
                            }
                        }
                        //英雄（主角）的判定区域，+130表示判定区域的位置的X方向（往右）偏离主角位置130个像素，+220则是Y方向（往下）偏离主角220个像素，50表示判定区域的宽度，5表示判定区域的高度
                       // Hero.CollisionRect = new Rectangle((int)(Hero.BackOffset.X + 130), (int)(Hero.BackOffset.Y + 220), 50, 5);
                        Hero.CollisionRect = new Rectangle((int)(Hero.BackOffset.X) + HeroCollisionRect[0], (int)(Hero.BackOffset.Y) + HeroCollisionRect[1], HeroCollisionRect[2], HeroCollisionRect[3]);
                        //boss的判定区域，+27表示离boss位置的X方向（向右）偏离27个像素，+250表示Y方向（向下）偏离250个像素，230表示判定区域的宽度，5表示高度
                       // Boss.CollisionRect = new Rectangle((int)Boss.BackOffset.X + 27, (int)(Boss.BackOffset.Y + 250), 230, 5);
                        Boss.CollisionRect = new Rectangle((int)Boss.BackOffset.X + BossCollisionRect[0], (int)(Boss.BackOffset.Y + BossCollisionRect[1]), BossCollisionRect[2], BossCollisionRect[3]);
                        if (isBossNiubility == false)
                        {

                            if (Hero.CollisionRect.Intersects(Boss.CollisionRect) &&TalkBackGround.Visible==false)
                            {
                                //HeroHPDec1 += 20;
                                //HeroHPDec2 += 30;
                                //HeroHPDec3 += 30;
                                //HeroHPDec4 += 40;
                                //HeroHPDec5 += 50;
                                //HeroHPDec6 += 60;
                                Audio.SEPlay("08");
                                BossAttacked.Visible = true;
                                BossAttacked.BackOffset = Boss.BackOffset;
                                BossAttacked.ShowingRect = BossAttacked.SourceRect(BossAttacked);
                                Boss.Visible = false;
                                isBossNiubility = true;
                                HitShader.Visible = true;
                                //BossAttacked.Visible = true;
                                float k, g;
                                Random rd = new Random();
                                k = rd.Next(0, 20);
                                g = rd.Next(0, 20);
                                if (k > 10)
                                {

                                    if (g > 10)
                                    {
                                        Boss.BackOffset.Y -= 10;
                                        Boss.SPX = -5;
                                        Boss.SPY = 5f;
                                    }
                                    if (g <= 10)
                                    {
                                        Boss.BackOffset.Y += 10;
                                        Boss.BackOffset.X += 20;
                                        Boss.SPY = 0.5f;
                                    }
                                }
                                if (k <= 10)
                                {

                                    if (g > 10)
                                    {
                                        Boss.BackOffset.Y -= 10;
                                        Boss.SPX = -5;
                                        Boss.SPY = 1;
                                    }
                                    if (g < 10)
                                    {
                                        Boss.BackOffset.Y += 10;
                                        Boss.BackOffset.X += 20;
                                        Boss.SPY = -1;
                                    }
                                }
                                Boss.HP -= BossHPDec;
                                ShootStyleCount++;
                                ShootStyleCount = MathHelper.Clamp(ShootStyleCount, 0, 7);


                                if (Boss.HP <= 0)
                                {
                                    //Boss.Visible = false;
                                    //爆炸
                                    //Hero.isStart = false;
                                    explode.BackOffset = Boss.BackOffset;
                                    Boss1Killed.BackOffset = Boss.BackOffset;
                                    Boss2Killed.BackOffset = Boss.BackOffset;
                                    BossKilled.BackOffset = Boss.BackOffset;
                                    explode.Visible = true;
                                    // Boss1Killed.Visible= true;
                                    //Boss2Killed.Visible = true;
                                }
                            }
                        }
                    }
                }
                if (isBossComeBack == true)
                {
                    isStartStop2 = false;
                    isStartStopTimeShoot = false;
                    Boss.BackOffset.X -=20;
                    if (Boss.BackOffset.X < Prefs.WindowSizeW)
                    {
                        isBossComeBack = false;
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

        }
    }
}
