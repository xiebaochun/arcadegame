using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using WEngine;
using Microsoft.Xna.Framework.Input;

namespace ArcadeGame.Programs.Scenes
{
    partial class Scene_Main
    {
        public DateTime DownPressedStartTime = DateTime.Now;
        public DateTime RightPressedStartTime = DateTime.Now;
        public DateTime LeftPressedStartTime = DateTime.Now;
        public Boolean IsDownPressed=false;
        public Boolean IsRightPressed = false;
        public Boolean IsLeftPressed = false;
        public int SikiAttackSkillEffectStyle = 0;
        public KeyState KeyState1;
        public KeyState KeyState2;
        public DateTime SikiAttackSkillEffectFlashing;
        float AlphaDec = 0.006f;
        public int pressedRepeatCount = 0;
        public int pressedRepeatCount1 = 0;
        public int ts1=0;
        public int ts2= 0;
        public int ts3 = 0;
        public int ts4 = 0;
        public int IsDownPressedTime;
        public int xinyueCount = 0;
        public int ElectricCount = 0;
        public Boolean isXinyue = false;
        public Boolean isChongfuzhan = false;
        public int ts5 = 0;
        public int ts6 = 0;
        public int ts7 = 0;
        public int ts8 = 0;
        public int ts9 = 0;
        public Boolean isFire = false;
        public Boolean isFire2 = false;
        public Boolean isElectric = false;
        public Boolean isElectric2 = false;
        public Boolean isQDown=false;
        public Boolean isWDown = false;
        public Boolean islianxuzhan = false;
        public Boolean islianxuzhan2 = false;
        public Boolean isGenerateElectricVisile = false;
        public Boolean isFireVisible = false;
        public Boolean isxinyueVisible = false;
        public Boolean ischongfuzhan = false;
        public int lianxuzhanCount = 0;
        public int lianxuzhanCount2 = 0;
        public int ShuRuTime = 50;
        public float FireTime = 0f;
        public int lianxuzhanType = 0;
        public int HeroSikiAttackSkillCount = 6;
        public int lianxuzhanCount3 = 0;
        public int lianxuzhanCount4 = 0;
        public Boolean isTimeStop = false;

        private void SikiUpdate()
        {
            #region 位置同步处理
            Siki.BackOffset.X = Hero.BackOffset.X - 40;
            Siki.BackOffset.Y = Hero.BackOffset.Y;
            Siki.Z = Hero.Z - 5;
            SikiAttack.BackOffset = Siki.BackOffset;
            SikiAttack.Alpha = Siki.Alpha;
            SikiAttack.sourceRect = SikiAttack.SourceRect(SikiAttack2);
            SikiAttack2.BackOffset = Siki.BackOffset;
            SikiAttack2.Alpha = Siki.Alpha;
            SikiAttack2.sourceRect = SikiAttack.SourceRect(SikiAttack2);

           
            Siki.ShowingRect = Siki.SourceRect(Siki);
            SikiAttack.ShowingRect = Siki.SourceRect(SikiAttack);
            HeroAttackShader.BackOffset = Boss.BackOffset - new Vector2(100, 100);
            HeroAttackShader.ShowingRect = HeroAttackShader.SourceRect(HeroAttackShader);
            HeroAttackSkill1.ShowingRect = HeroAttackSkill1.SourceRect(HeroAttackSkill1);
            HeroAttackSkill2.ShowingRect = HeroAttackSkill2.SourceRect(HeroAttackSkill2);
            xinyue.Z = xinyue.BackOffset.Y + xinyue.SourceTexture.Height / xinyue.spriteSizeY;
            SikiAttackSkillEffect1.Z = SikiAttackSkillEffect1.BackOffset.Y + SikiAttackSkillEffect1.SourceTexture.Height / SikiAttackSkillEffect1.spriteSizeY;


            //必杀技同步


            //SikiAttackSkillEffect2.BackOffset = SikiAttackSkillEffect1.BackOffset;

            SikiAttackSkillEffect2.Z = Boss.Z + 1;
            //必杀技检测区域同步
            SikiAttackSkillEffect1.CollisionRect = new Rectangle((int)SikiAttackSkillEffect1.BackOffset.X, (int)SikiAttackSkillEffect1.BackOffset.Y + SikiAttackSkillEffect1.SourceTexture.Height / SikiAttackSkillEffect1.spriteSizeY, SikiAttackSkillEffect1.SourceTexture.Width, 5);
            #endregion
            Boss.CollisionRect = new Rectangle((int)Boss.BackOffset.X + 27, (int)(Boss.BackOffset.Y + 240), 230, 10);
            //if (Boss.Visible == true && HeroAttackSkill1.Visible == false && HeroAttackSkill2.Visible == false && Victory.Visible == false && GameOver.Visible == false&&HeroDefense.Visible==false&&SikiAttack.Visible==false&&SikiAttack2.Visible==false)
            //{
            //    Siki.Visible = true;
            //}
            if(HeroDefense.Visible==true||SikiAttack.Visible==true||SikiAttack2.Visible==true||lianxuzhan.Visible==true)
            {
                Siki.Visible=false;
            }
            //深度同步
            //Fire_fire.Z = Fire_fire.BackOffset.Y + Fire_fire.SourceTexture.Height / Fire_fire.spriteSizeY;
            //Electric_fire.Z = Electric.BackOffset.Y + Fire_fire.SourceTexture.Height / Electric_fire.spriteSizeY;
            Fire_fire.Z = Boss.Z + 1;
            Electric_fire.Z = Boss.Z + 1;

            #region 弑神透明度（三角函数）变化
            Siki.iCount += AlphaDec;
            Siki.Alpha = (float)Math.Sin(Siki.iCount);
            //Siki.Alpha = MathHelper.Clamp(Siki.Alpha, 0.2f, 0.8f);
            if (Siki.iCount >= MathHelper.Pi * 2 / 8)
            {
                AlphaDec = -0.006f;
            }
            if (Siki.iCount <= MathHelper.Pi * 1 / 16)
            {
                AlphaDec = 0.006f;
            }

            if (HeroKilling.Visible == true)
            {
                Siki.Visible = false;
            }
            #endregion
            SikiAttack.Z = Hero.Z + 1;
            SikiAttack2.Z = Hero.Z + 1;
            HeroAttackSkill1.Z = SikiAttack.Z;
            HeroAttackSkill2.Z = SikiAttack.Z;
            //玩家输入更新
            if (HeroHighRunning.Visible == true && Boss.Visible == true && HeroAttackSkill1.Visible == false && HeroAttackSkill2.Visible == false || HeroHighRunning.Visible == true && BossShooting.Visible == true && HeroAttackSkill1.Visible == false && HeroAttackSkill2.Visible == false)
            {

                if (Input.Trigger(Keys.Q))
                {
                    isQDown=true;
                       
                }
                if(isQDown==true)
                {
                    ts9++;
                    if (ts9 < 3)
                    {
                        if (Input.Trigger(Keys.W))
                        {
                            ts9 = 0;
                            isQDown = false;
                           
                            return;
                            
                        }
                    }
                    if (ts9 > 3)
                    {
                        ts9 = 0;
                        SikiAttack.Visible = true;
                        SikiAttack.BackOffset = Siki.BackOffset;
                        SikiAttack.ShowingRect = SikiAttack.SourceRect(SikiAttack);
                        HeroAttackSkill1.Visible = true;
                        HeroAttackSkill1.BackOffset.X = Siki.BackOffset.X - 24;
                        HeroAttack1.Visible = true;
                        HeroAttackSkill1.BackOffset.Y = Siki.BackOffset.Y + 40;
                        Siki.Visible = false;
                        isQDown = false;
                        if (islianxuzhan == true)
                        {
                            Random rd = new Random();
                            if (rd.Next(1, 10) < 5)
                            {
                                Audio.SEPlay("27a");
                            }
                            else
                            {
                                Audio.SEPlay("27b");
                            }
                            lianxuzhan.Visible = true;
                            SikiAttack.Visible = false;
                            lianxuzhan.BackOffset = Siki.BackOffset;
                            lianxuzhanType = 1;
                            
                        }
                    }


                }
                if (Input.Trigger(Keys.W))
                {
                    isWDown = true;
                }
                    
                if(isWDown==true)
                {
                    ts9++;
                    if (ts9 < 3)
                    {
                        if (Input.Trigger(Keys.Q))
                        {
                            ts9 = 0;
                            isWDown = false;
                            return;
                            
                        }
                    }
                    if (ts9 > 3)
                    {
                        ts9 = 0;
                        HeroAttackSkill2.Visible = true;
                        HeroAttackSkill2.BackOffset.X = Siki.BackOffset.X - 30;

                        HeroAttackSkill2.BackOffset.Y = Siki.BackOffset.Y - 200;
                       Siki.Visible = false;
                       HeroAttack1.Visible = true;
                       SikiAttack2.Visible = true;
                       SikiAttack2.BackOffset = Siki.BackOffset;
                       SikiAttack2.ShowingRect = SikiAttack2.SourceRect(SikiAttack2);
                        isWDown = false;
                        if (islianxuzhan == true)
                        {
                            Random rd = new Random();
                            if (rd.Next(1, 10) < 5)
                            {
                                Audio.SEPlay("27a");
                            }
                            else
                            {
                                Audio.SEPlay("27b");
                            }
                            lianxuzhan.Visible = true;
                            SikiAttack2.Visible = false;
                            lianxuzhan.BackOffset = Siki.BackOffset;
                            lianxuzhanType = 2;

                        }
                    }
                   
                }
            }

            if (HeroHighRunning.Visible == true && loopCount > maxloopCount && generateElectric.Visible == false &&
                Electric.Visible == false && reduceElectric.Visible == false && Fire.Visible == false && xinyue.Visible == false
                && SikiAttackSkillEffect1.Visible == false && SikiAttackSkillEffect2.Visible == false&&lianxuzhan.Visible==false  )
            {
                //火的输入判定
                if (Input.Trigger(Keys.Right))
                {
                    IsRightPressed = true;
                }
                if (IsRightPressed == true)
                {
                    ts5++;
                    if (ts5 <= ShuRuTime)
                    {
                        if (Input.Trigger(Keys.Left))
                        {
                            isFire = true;
                            IsRightPressed = false;
                        }
                    }
                    if (ts5 > ShuRuTime)
                    {
                        ts5 = 0;
                        IsRightPressed = false;
                    }
                }
                //电的输入判定
                //if (Input.Trigger(Keys.Left))
                //{
                //    IsLeftPressed = true;
                //}
                //if (IsLeftPressed == true)
                //{
                //    ts6++;
                //    if (ts6 <= ShuRuTime)
                //    {
                //        if (Input.Trigger(Keys.Right)&&IsDownPressed==false)
                //        {
                //            isElectric = true;
                //            IsLeftPressed = false;
                //        }
                //    }
                //    if (ts6 > ShuRuTime)
                //    {
                //        ts6 = 0;
                //        IsLeftPressed = false;
                //    }
                //}

                if (Input.Trigger(Keys.Down))
                {
                    IsDownPressed = true;

                }
                if (IsDownPressed == true)
                {
                    ts1++;

                    if (ts1 <= ShuRuTime)
                    {
                        if (Input.Trigger(Keys.Right))
                        {
                            xinyueCount++;
                            if (xinyueCount == 1)
                            {
                               
                                if (isFire == true&&isElectric==false)
                                {
                                    
                                    isFire2 = true;
                                    isFire = false;
                                }
                                if (isFire == false&&isFire2==false&&isElectric==false&&isElectric2==false)
                                {


                                    islianxuzhan = true;
                                    islianxuzhan2 = true;
                                } 
                                if (isElectric == true)
                                {
                                   
                                    isElectric = false;
                                    isElectric2 = true;
                                }
                            }
                            ts1 = 0;
                            if (xinyueCount == 2)
                            {
                               
                                IsRightPressed = true;
                                isXinyue = true;
                                xinyueCount = 0;
                                isChongfuzhan = false;
                                //islianxuzhan = false;
                            }

                        }
                        if (Input.Trigger(Keys.Left))
                        {
                            ElectricCount++;
                            ts1 = 0;
                            if (ElectricCount == 1&&isElectric2==false)
                            {

                                isChongfuzhan = true;
                            }

                            if (ElectricCount == 2)
                            {
                                isElectric2 = true;
                                IsLeftPressed = false;
                                ElectricCount = 0;
                                isChongfuzhan = false;
                            }
                        }
                    }
                    if (ts1 > ShuRuTime)
                    {
                        ts1 = 0;
                        IsDownPressed = false;
                        xinyueCount = 0;
                        ElectricCount = 0;
                    }

                }
                if (isElectric2 == true)
                {
                    isFire2 = false;
                    islianxuzhan = false;
                    islianxuzhan2 = false;
                    isXinyue = false;
                    isChongfuzhan = false;
                    
                    ts3++;
                    if (ts3 <= ShuRuTime)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            isElectric2 = false;
                            isElectric = false;
                            if (generateElectric.Visible == false)
                            {
                                Random rd = new Random();
                                if (rd.Next(1, 10) < 5)
                                {
                                    Audio.SEPlay("29a");
                                }
                                else
                                {
                                    Audio.SEPlay("29b");
                                }
                                Audio.SEPlay("02");

                                isGenerateElectricVisile=true;
                            }
                        }

                    }
                    if (ts3 > ShuRuTime)
                    {
                        ts3 = 0;
                        isElectric2 = false;
                        isElectric = false;
                    }
                }
                if (isFire2 == true)
                {
                    isElectric2 = false;
                    islianxuzhan = false;
                    islianxuzhan2 = false;
                    isXinyue = false;
                    isChongfuzhan = false;
                    ts7++;
                    if (ts7 <= ShuRuTime)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            isFire2 = false;
                            if (Fire.Visible == false)
                            {
                                isFireVisible=true;
                                Random rd = new Random();
                                if (rd.Next(1, 10) < 5)
                                {
                                    Audio.SEPlay("30a");
                                }
                                else
                                {
                                    Audio.SEPlay("30b");
                                }
                                Audio.SEPlay("01");
                               
                            }
                        }
                    }
                    if (ts7 > ShuRuTime)
                    {
                        ts7 = 0;
                        isXinyue = false;
                        isFire2 = false;
                    }

                }
                if (isChongfuzhan == true)
                {
                    isFire2 = false;
                    islianxuzhan = false;
                    islianxuzhan2 = false;
                    isXinyue = false;
                    isElectric2 = false;
                    ts2++;

                    if (ts2 <= ShuRuTime)
                    {


                        if (Input.Trigger(Keys.Q))
                        {
                            Audio.SEPlay("26a");
                            Audio.SEPlay("04");
                            if (SikiAttackSkillEffect1.Visible == false && SikiAttackSkillEffect2.Visible == false)
                            {
                                ts2 = 0;
                                SikiAttackSkillEffectStyle = 2;
                                IsRightPressed = false;
                                IsLeftPressed = false;
                                ischongfuzhan = true;
                               
                                SikiAttackSkillEffect1.SPX = 40;
                                pressedRepeatCount = 0;
                                isChongfuzhan = false;
                                isElectric = false;
                            }
                            isChongfuzhan = false;
                            isElectric = false;
                        }

                        if (Input.Trigger(Keys.W))
                        {
                            Audio.SEPlay("26b");
                            Audio.SEPlay("04");
                            if (SikiAttackSkillEffect1.Visible == false && SikiAttackSkillEffect2.Visible == false)
                            {
                                ts2 = 0;
                                SikiAttackSkillEffectStyle = 1;
                                IsRightPressed = false;
                                IsLeftPressed = false;
                                ischongfuzhan = true;
                                SikiAttackSkillEffect1.SPX = 20;
                                pressedRepeatCount = 0;
                                isChongfuzhan = false;
                                isElectric = false;
                            }
                            isChongfuzhan = false;
                            isElectric = false;
                        }




                    }

                    if (ts2 > ShuRuTime)
                    {
                        ts2 = 0;
                        IsRightPressed = false;
                        IsLeftPressed = false;
                        isChongfuzhan = false;
                    }

                }

              
                if (isXinyue == true)
                {
                    isElectric2 = false;
                    islianxuzhan = false;
                    islianxuzhan2 = false;
                    isFire2 = false;
                    isChongfuzhan = false;
                    xinyueCount = 0;
                    ts8++;
                    if (ts8 <= ShuRuTime)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            isXinyue = false;
                            if (xinyue.Visible == false)
                            {
                                Random rd = new Random();
                                if (rd.Next(1, 10) < 5)
                                {
                                    Audio.SEPlay("28a");
                                }
                                else
                                {
                                    Audio.SEPlay("28b");
                                }
                                Audio.SEPlay("04");
                                isxinyueVisible = true;
                                IsRightPressed = false;
                                isXinyue = false;
                            }
                        }
                    }
                    if (ts8 > ShuRuTime)
                    {
                        ts8 = 0;
                        isXinyue = false;
                    }

                }

            }

            #region 必杀技特效动画

            if (SikiAttackSkillEffect1.Visible == true )
            {
                //流星判定区域
                SikiAttackSkillEffect1.CollisionRect = new Rectangle((int)SikiAttackSkillEffect1.BackOffset.X, (int)SikiAttackSkillEffect1.BackOffset.Y+SikiAttackSkillEffect1.SourceTexture.Height/SikiAttackSkillEffect1.spriteSizeY-50, 50, 50);
                if (Boss.CollisionRect.Intersects(SikiAttackSkillEffect1.CollisionRect) && TalkBackGround.Visible == false)
                {
                    Boss.HP -= 10;
                    SikiAttackSkillEffect1.Visible = false;
                    SikiAttackSkillEffect2.Visible = true;
                }
                SikiAttackSkillEffect1.BackOffset.X += SikiAttackSkillEffect1.SPX;
                //SikiAttackSkillEffect2.BackOffset = SikiAttackSkillEffect1.BackOffset;
                //SikiAttackSkillEffect1.BackOffset.X += 1; 
                if (SikiAttackSkillEffect1.BackOffset.X > Prefs.WindowSizeW)
                {
                    
                    SikiAttackSkillEffect1.Visible = false;
                    
                }
                SikiAttackSkillEffect1.iCount++;
                if (SikiAttackSkillEffect1.iCount >= 3)
                {
                    SikiAttackSkillEffect1.iCount = 0;
                    SikiAttackSkillEffect1.ObjectAnimation(SikiAttackSkillEffect1);
                }


            }
            if (SikiAttackSkillEffect2.Visible == true)
            {
                SikiAttackSkillEffect2.BackOffset = Boss.BackOffset;
                SikiAttackSkillEffect2.iCount++;
                if (SikiAttackSkillEffect2.iCount == 3)
                {
                    SikiAttackSkillEffect2.iCount = 0;
                    SikiAttackSkillEffect2.ObjectAnimation(SikiAttackSkillEffect2);

                }

            }
            //雷电必杀技
            if (generateElectric.Visible == true)
            {
                generateElectric.Z = Hero.Z + 1;
                //generateElectric.BackOffset.X += generateElectric.SPX;
              
                  
              
                generateElectric.iCount++;
                if(generateElectric.iCount==2)
                {
                    generateElectric.iCount = 0;
                    generateElectric.ObjectAnimation(generateElectric);
                }
                if (generateElectric.Visible == false)
                {
                    Electric.Visible = true;
                    Electric.BackOffset = generateElectric.BackOffset;
                }
            }
            if (Electric.Visible == true)
            {
                //雷击判定区域
                Electric.CollisionRect = new Rectangle((int)Electric.BackOffset.X, (int)Electric.BackOffset.Y+657, Electric.SourceTexture.Width / Electric.spriteSizeX, 15);
                if (Boss.CollisionRect.Intersects(Electric.CollisionRect) && TalkBackGround.Visible == false)
                {
                    Boss.HP -= 10;
                    Electric_fire.Visible = true;
                }
                Electric.Z = Hero.Z + 1;
                Electric.BackOffset.X += Electric.SPX;
                Electric.HP++;
                if (Electric.HP >= 80)
                {
                    Electric.HP = 0;
                    Electric.Visible = false;
                    reduceElectric.Visible = true;
                    reduceElectric.BackOffset=Electric.BackOffset;

                }
                Electric.iCount++;
                if (Electric.iCount == 2)
                {
                    Electric.iCount = 0;
                    Electric.ObjectAnimation(Electric);
                }

            }
            if (reduceElectric.Visible == true)
            {
                reduceElectric.BackOffset.X += reduceElectric.SPX;
               
              
                reduceElectric.iCount++;
                if (reduceElectric.iCount == 2)
                {
                    reduceElectric.iCount = 0;
                    reduceElectric.ObjectAnimation(reduceElectric);
                }
            }
            if (Electric_fire.Visible == true)
            {
                Electric_fire.BackOffset = Boss.BackOffset;
                Electric_fire.iCount++;
                if (Electric_fire.iCount == 1)
                {
                    Electric_fire.iCount = 0;
                    Electric_fire.ObjectAnimation(Electric_fire);
                }
            }
            //新月必杀技动画
            if (xinyue.Visible == true)
            {
                xinyue.Z = Hero.Z + 1;
                xinyue.BackOffset.X += xinyue.SPX;
                
                if (xinyue.BackOffset.X >= Prefs.WindowSizeW)
                {
                    xinyue.Visible = false;

                }
                xinyue.iCount++;
                if (xinyue.iCount == 3)
                {
                    xinyue.iCount = 0;
                    xinyue.ObjectAnimation(xinyue);

                }
                //新月判定区域
                xinyue.CollisionRect = new Rectangle((int)xinyue.BackOffset.X, (int)xinyue.BackOffset.Y+xinyue.SourceTexture.Height/xinyue.spriteSizeY-30, xinyue.SourceTexture.Width/xinyue.spriteSizeX,30);
                if (xinyue.CollisionRect.Intersects(Boss.CollisionRect) && TalkBackGround.Visible == false)
                {
                    Boss.HP -= 10;
                    HeroAttackShader.Visible = true;
                }
            }
            //绘制火的动画；
            if (Fire.Visible == true)
            {
               
                Fire.BackOffset.X += Fire.SPX;
                if (Fire.HP != 1)
                { 
                    FireTime +=0.1f;
                    Fire.BackOffset.Y = Fire.BackOffset.Y - 50 * FireTime + (int)25 * FireTime * FireTime;

                }
                if(FireTime>=2)
                {
                    FireTime=0;
                    Fire.HP = 1;
                }
                if (Fire.BackOffset.X > Prefs.WindowSizeW)
                {
                    FireTime = 0;
                    Fire.Visible = false;
                    Fire.HP = 0;
                }
                Fire.iCount++;
                if (Fire.iCount == 3)
                {
                    Fire.iCount = 0;
                    Fire.ObjectAnimation(Fire);

                }
                //火的判定区域
                Fire.CollisionRect = new Rectangle((int)Fire.BackOffset.X, (int)Fire.BackOffset.Y+Fire.SourceTexture.Height/Fire.spriteSizeY-15, Fire.SourceTexture.Width / Fire.spriteSizeX, 15);
                if (Boss.CollisionRect.Intersects(Fire.CollisionRect) && TalkBackGround.Visible == false)
                {
                    Boss.HP -= 10;
                    Fire_fire.Visible = true;
                    Fire_fire.BackOffset = Boss.BackOffset;
                    Fire_fire.BackOffset.X += 50;
                }

            }
            //绘制火的火动画

            if (Fire_fire.Visible == true )
                {
                    Fire_fire.BackOffset = Boss.BackOffset;
                    Fire_fire.ObjectAnimation(Fire_fire);
                }
            
            #endregion
            //动画绘制
            if (lianxuzhan.Visible == true)
            {
                if (islianxuzhan2 == true)
                {
                    lianxuzhan.BackOffset.X += 1f;
                    lianxuzhan.Alpha = Siki.Alpha;

                    lianxuzhan.Z = Hero.Z + 1;

                    lianxuzhan.iCount++;
                    if (lianxuzhan.iCount == 3)
                    {
                        lianxuzhanCount++;
                        lianxuzhan.iCount = 0;
                        lianxuzhan.ObjectAnimation(lianxuzhan);
                        if (lianxuzhanType == 1)
                        {
                            if (lianxuzhanCount >= 15)
                            {

                                lianxuzhanCount = 0;
                                islianxuzhan2 = false;
                            }
                        }
                        if (lianxuzhanType == 2)
                        {
                            if (lianxuzhanCount >= 30)
                            {

                                lianxuzhanCount = 0;
                                islianxuzhan2 = false;
                            }
                        }
                    }
                }
                if (islianxuzhan2 == false)
                {
                    lianxuzhanCount4++;
                    lianxuzhan.Alpha -= 0.006f;
                    lianxuzhan.CurrentPositionX = 2;
                    lianxuzhan.ShowingRect = lianxuzhan.SourceRect(lianxuzhan);
                    if (lianxuzhanCount4>=30)
                    {
                        lianxuzhanCount4 = 0;
                        lianxuzhan.Visible = false;
                       
                    }
                }

            }
            if (HeroAttackSkill1.Visible == true)
            {
                HeroAttackSkill1.iCount++;
                if (islianxuzhan==true)
                {
                    HeroSikiAttackSkillCount = 1;
                    HeroAttackSkill1.BackOffset.X = lianxuzhan.BackOffset.X - 24;
                   
                    HeroAttackSkill1.BackOffset.Y = lianxuzhan.BackOffset.Y + 40;
                   
                }
                if (islianxuzhan==false)
                {
                    HeroSikiAttackSkillCount = 6;
                    HeroAttackSkill1.BackOffset.X = Siki.BackOffset.X - 24;
                   
                    HeroAttackSkill1.BackOffset.Y = Siki.BackOffset.Y + 40;
                    
                }
                if (HeroAttackSkill1.iCount>= HeroSikiAttackSkillCount)
                {
                    HeroAttackSkill1.ObjectAnimation(HeroAttackSkill1);
                    HeroAttackSkill1.iCount = 0;

                    if (HeroAttackSkill1.Visible == false)
                    {
                        if (islianxuzhan == true)
                        {
                            HeroAttackSkill2.Visible = true;
                            lianxuzhanCount3++;
                            if (lianxuzhanType == 1)
                            {
                                if (lianxuzhanCount3 >= 8)
                                {
                                    lianxuzhanCount3 = 0;
                                    islianxuzhan = false;
                                    HeroAttackSkill2.Visible = false;
                                }
                            }
                            if (lianxuzhanType == 2)
                            {
                                if (lianxuzhanCount3 >= 16)
                                {
                                    lianxuzhanCount3 = 0;
                                    islianxuzhan = false;
                                    HeroAttackSkill2.Visible = false;
                                }
                            }
                        }
                    }
                    if (HeroAttackSkill1.CurrentPositionX == 2 && HeroAttackSkill1.CurrentPositionY==0)
                    {
                        if (generateElectric.Visible == false && isGenerateElectricVisile == true && Fire.Visible == false && xinyue.Visible == false && SikiAttackSkillEffect1.Visible == false && ischongfuzhan == false && isFire2 == false && isXinyue == false && lianxuzhan.Visible == false)
                        {
                            isGenerateElectricVisile = false;
                            generateElectric.Visible = true;
                            generateElectric.BackOffset = Hero.BackOffset;
                            generateElectric.BackOffset.Y -= 450;
                        }
                        if (Fire.Visible == false && isFireVisible == true && Electric.Visible == false && generateElectric.Visible == false && xinyue.Visible == false && SikiAttackSkillEffect1.Visible == false && ischongfuzhan == false && isElectric2 == false
                           && isXinyue == false && lianxuzhan.Visible == false)
                        {

                            isFireVisible = false;
                            Fire.Visible = true;
                            Fire.BackOffset = Hero.BackOffset;
                            Fire.BackOffset.Y -= 20;
                        }
                        if (xinyue.Visible == false && isxinyueVisible == true && Fire.Visible == false && Electric.Visible == false && generateElectric.Visible == false && SikiAttackSkillEffect1.Visible == false && isElectric2 == false && isFire2 == false && ischongfuzhan == false && lianxuzhan.Visible == false)
                        {
                            isxinyueVisible = false;

                            xinyue.Visible = true;
                            xinyue.BackOffset = Hero.BackOffset;
                            xinyue.BackOffset.Y -= 90;
                        }
                        if (ischongfuzhan == true && SikiAttackSkillEffect1.Visible == false && isElectric2 == false && isFire2 == false && isXinyue == false&&lianxuzhan.Visible==false)
                        {
                            SikiAttackSkillEffect1.Visible = true;
                            ischongfuzhan = false;
                            SikiAttackSkillEffect1.BackOffset.X = Hero.BackOffset.X + 120;
                            SikiAttackSkillEffect1.BackOffset.Y = Hero.BackOffset.Y + 77;
                        }
                    }
            }

                

            }
            if (HeroAttackSkill2.Visible == true)
            {
                HeroAttackSkill2.iCount++;
                if (islianxuzhan==true)
                {
                    HeroSikiAttackSkillCount = 1;
                   
                    HeroAttackSkill2.BackOffset.X = lianxuzhan.BackOffset.X - 30;
                   
                    HeroAttackSkill2.BackOffset.Y = lianxuzhan.BackOffset.Y - 200;
                }
                if (islianxuzhan==false)
                {
                    HeroSikiAttackSkillCount = 6;
                   
                    HeroAttackSkill2.BackOffset.X = Siki.BackOffset.X - 30;
                  
                    HeroAttackSkill2.BackOffset.Y = Siki.BackOffset.Y - 200;
                }
                if (HeroAttackSkill2.iCount >= HeroSikiAttackSkillCount)
                {
                    HeroAttackSkill2.ObjectAnimation(HeroAttackSkill2);
                    HeroAttackSkill2.iCount = 0;

                    if (HeroAttackSkill2.Visible == false)
                    {
                        if (islianxuzhan == true)
                        {
                            HeroAttackSkill1.Visible = true;
                            lianxuzhanCount3++;
                            if (lianxuzhanType == 1)
                            {
                                if (lianxuzhanCount3>=8)
                                {
                                    lianxuzhanCount3 = 0;
                                    islianxuzhan = false;
                                    HeroAttackSkill1.Visible = false;
                                }
                            }
                            if (lianxuzhanType == 2)
                            {
                                if (lianxuzhanCount3 >= 16)
                                {
                                    lianxuzhanCount3 = 0;
                                    islianxuzhan = false;
                                    HeroAttackSkill1.Visible = false;
                                }
                            }
                        }
                    }

                 if (HeroAttackSkill2.CurrentPositionX == 2 && HeroAttackSkill2.CurrentPositionY == 0)
                        {
                            if (generateElectric.Visible == false && isGenerateElectricVisile == true && Fire.Visible == false && xinyue.Visible == false && SikiAttackSkillEffect1.Visible == false && ischongfuzhan == false && isFire2 == false && isXinyue == false && lianxuzhan.Visible == false)
                            {
                                isGenerateElectricVisile = false;
                                generateElectric.Visible = true;
                                generateElectric.BackOffset = Hero.BackOffset;
                                generateElectric.BackOffset.Y -= 450;
                            }
                            if (Fire.Visible == false && isFireVisible == true && Electric.Visible == false && generateElectric.Visible == false && xinyue.Visible == false && SikiAttackSkillEffect1.Visible == false && ischongfuzhan == false && isElectric2 == false && lianxuzhan.Visible == false
                               && isXinyue == false)
                            {

                                isFireVisible = false;
                                Fire.Visible = true;
                                Fire.BackOffset = Hero.BackOffset;
                                Fire.BackOffset.Y -= 20;
                            }
                            if (xinyue.Visible == false && isxinyueVisible == true && Fire.Visible == false && Electric.Visible == false && generateElectric.Visible == false && SikiAttackSkillEffect1.Visible == false && isElectric2 == false && isFire2 == false && ischongfuzhan == false && lianxuzhan.Visible == false)
                            {
                                isxinyueVisible = false;

                                xinyue.Visible = true;
                                xinyue.BackOffset = Hero.BackOffset;
                                xinyue.BackOffset.Y -= 90;
                            }
                            if (ischongfuzhan == true && SikiAttackSkillEffect1.Visible == false && isElectric2 == false && isFire2 == false && isXinyue == false && lianxuzhan.Visible == false)
                            {
                                SikiAttackSkillEffect1.Visible = true;
                                ischongfuzhan = false;
                                SikiAttackSkillEffect1.BackOffset.X = Hero.BackOffset.X + 120;
                                SikiAttackSkillEffect1.BackOffset.Y = Hero.BackOffset.Y + 77;
                            }
                        }
                    
                }
            }




            ///////////////
                    if (SikiAttack.Visible == true)
                    {
                        
                        SikiAttack.iCount++;
                        if (SikiAttack.iCount == 15)
                        {

                            SikiAttack.ObjectAnimation(SikiAttack);
                            SikiAttack.iCount = 0;


                            //if (SikiAttack.Visible == false)
                            //{
                            //    if (islianxuzhan == true)
                            //    {
                            //        SikiAttack2.Visible = true;
                            //        lianxuzhanCount2++;
                            //        if (lianxuzhanCount2 == 10)
                            //        {
                            //            SikiAttack.Visible = false;
                            //            lianxuzhanCount2 = 0;
                            //        }
                            //    }
                            //}
                        
                    
                }
            }
            if (SikiAttack2.Visible == true)
            {

                SikiAttack2.iCount++;
                if (SikiAttack2.iCount == 15)
                {

                    SikiAttack2.ObjectAnimation(SikiAttack2);
                    SikiAttack2.iCount = 0;


                    //if (SikiAttack2.Visible == false)
                    //{
                    //    if (islianxuzhan == true)
                    //    {
                    //        SikiAttack.Visible = true;
                    //        lianxuzhanCount2++;
                    //        if (lianxuzhanCount2 ==10)
                    //        {
                    //            SikiAttack2.Visible = false;
                    //            lianxuzhanCount2 = 0;
                    //        }
                    //    }
                    //}
                }
            }
            //必杀技动画




            if (HeroKilled.Visible == true)
            {


                Siki.Visible = false;
            }

            if (SikiAttack.Visible == false && SikiAttack2.Visible == false && Boss.Visible == true && HeroKilled.Visible == false && HeroHighRunning.Visible == true&&HeroDefense.Visible==false&&lianxuzhan.Visible==false || SikiAttack.Visible == false && SikiAttack2.Visible == false && BossShooting.Visible == true && HeroKilled.Visible == false && HeroHighRunning.Visible == true&&HeroDefense.Visible==false&&lianxuzhan.Visible==false)
            {
                Siki.Visible = true;
            }


            if (HeroAttackShader.Visible == true)
            {
                HeroAttackShader.iCount++;
                if (HeroAttackShader.iCount == 3)
                {
                    HeroAttackShader.ObjectAnimation(HeroAttackShader);
                    HeroAttackShader.iCount = 0;
                }
            }
            //横斩碰撞检测
            if (HeroAttackSkill1.Visible == true || HeroAttackSkill2.Visible == true)
            {
                //横斩判定区域
                HeroAttackSkill1.CollisionRect = new Rectangle((int)HeroAttackSkill1.BackOffset.X, (int)HeroAttackSkill1.BackOffset.Y + 100, 462, 35);
                //纵斩判定区域
                HeroAttackSkill2.CollisionRect = new Rectangle((int)HeroAttackSkill2.BackOffset.X, (int)HeroAttackSkill2.BackOffset.Y + HeroAttackSkill2.SourceTexture.Height / HeroAttackSkill2.spriteSizeY - 30, HeroAttackSkill2.SourceTexture.Width / HeroAttackSkill2.spriteSizeX, 30);
                Boss.CollisionRect = new Rectangle((int)Boss.BackOffset.X, (int)Boss.BackOffset.Y + Boss.SourceTexture.Height - 5, Boss.SourceTexture.Width / Boss.spriteSizeX, 5);
                if (Boss.CollisionRect.Intersects(HeroAttackSkill2.CollisionRect) && TalkBackGround.Visible == false || Boss.CollisionRect.Intersects(HeroAttackSkill2.CollisionRect) && TalkBackGround.Visible == false)
                {

                    HeroAttackShader.Visible = true;
                    Boss.HP -= 10;

                }
            }


        }
    }
}