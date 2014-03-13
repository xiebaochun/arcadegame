using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using WEngine;
using Microsoft.Xna.Framework.Input;
using ArcadeGame.Programs.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace ArcadeGame.Programs.Scenes
{
    
   partial class Scene_Main
    {

       public GamePadDPad gamePadDPad;
       public Boolean isBossMusicStart = false;
       public override void Update()
       {
           
           if (GameOver.Visible == true || Victory.Visible == true)
           {
              // MyCue.Stop(AudioStopOptions.Immediate);
              
           }
           SpeedUpShader.BackOffset.X = Hero.BackOffset.X - 80;
           SpeedUpShader.BackOffset.Y = Hero.BackOffset.Y + 32;
           SpeedUpShader.ShowingRect = SpeedUpShader.SourceRect(SpeedUpShader);
           HitShader.BackOffset.X = Hero.BackOffset.X - 70;
           HitShader.BackOffset.Y = Hero.BackOffset.Y - 55;
           HitShader.ShowingRect = HitShader.SourceRect(HitShader);
      //     TestBox1.Text = "The Boss HP is:" + Boss.HP.ToString() + "    the Hero Speed is:" + Bus.SPX.ToString() + "\n The Hero HP is:" + Hero.HP.ToString() + "\n the explode visible:" + explode.Visible.ToString()
              
      //         + "\n the enemyKilledCoount:" + enemyKilledCount.ToString() + "\n Boss visible:" + Boss.Visible.ToString() + "\n The shootStyle:" + ShootStyle.ToString() + loopCount.ToString()+"\n"+HeroHighRunning.Visible.ToString()+generateElectric.Visible.ToString()+
      //          Electric.Visible.ToString()+ reduceElectric.Visible.ToString()+ Fire.Visible.ToString()+ xinyue.Visible.ToString()+
      //          SikiAttackSkillEffect1.Visible.ToString()+SikiAttackSkillEffect2.Visible.ToString()+HeroAttackSkill1.Visible.ToString()+HeroAttackSkill2.Visible.ToString()+ lianxuzhan.Visible.ToString()+"\n the enemy1 visible:"+Enemy1[0].Visible.ToString()+
      //          "\n the enemy[1] visible:"+Enemy1[1].Visible.ToString()+"\n the enemy[2] visible"+Enemy1[2].Visible.ToString()+"\n the enemy[3] visible"+Enemy1[3].Visible.ToString()+"\n the enemy[4] visible"+Enemy1[4].Visible.ToString()+"\n the enemy[5] visible"+Enemy1[5].Visible.ToString()
      //          +"\n the enemy[6] vislble"+Enemy1[6].Visible.ToString()+"\n the enemy[7] visible"+Enemy1[7].Visible.ToString()+"\n  the enemy[8] visible"+Enemy1[8].Visible.ToString();


      //TestBox2.Text = "the enemyPositionY:" + EnemyPositionY[0].ToString() + "\n" + EnemyPositionY[1].ToString() + "\n" + EnemyPositionY[2].ToString() + "\n" +
      //         EnemyPositionY[3].ToString() + "\n" + EnemyPositionY[4].ToString() + "\n" + EnemyPositionY[5].ToString() + "\n" + EnemyPositionY[6].ToString() + "\n" + EnemyPositionY[7].ToString()+
      //         "\n the gameTime;" + enemySp.ToString() + "\n the BossHPDec:" + BossHPDec.ToString() + "\n thie heroHPDec:" + HeroHPDec1.ToString() + "the boss PositionX:" + Boss.BackOffset.X.ToString() + "the SessionIndex" + SessionIndex.ToString() + "the isGotoHP90Talk" + isGotoHP90Talk.ToString() + "Continue.SPX" + Continue.SPX.ToString() + "\n Continue.Visible" + Continue.Visible.ToString();
           //TestBox2.Text = "the isGotoHP90Talk" + isGotoHP90Talk.ToString() + "Continue.SPX" + Continue.SPX.ToString() + "\n Continue.Visible" + Continue.Visible.ToString() + "the SessionIndex" + SessionIndex.ToString();
      //if (isHeroNiuBility == true)
      //{
      //    TextBox3.Text = "主角无敌时间！";
      //}
      //if (isHeroNiuBility == false)
      //{
      //    TextBox3.Text = "";
      //}

      //     if (isBossNiubility == true)
      //     {
      //         TextBox4.Text = "BOSS无敌时间！";
      //     }
      //     if (isBossNiubility ==false)
      //     {
      //         TextBox4.Text = "";
      //     }
           if (GameName.Visible == true)
           {
               if (GameName.iCount == 0)
               {
                   Audio.BGMPlay("koulin1", false);
               }
               GameName.iCount++;
               if (GameName.iCount == 200)
               {
                   GameName.Visible = false;
                   Ready.Visible = true;
                   GameName.iCount = 0;
               }

           }
           if (Ready.Visible == true)
           {
               if (Ready.iCount == 0)
               {
                   Audio.BGMPlay("koulin2", false);
               }
               Ready.iCount++;
               if (Ready.iCount == 100)
               {

                   Ready.Visible = false;
                   //MyCue.Play();
                   Hero.isStart = true;
                   //开始播放背景音乐
                   //Audio.BGMPlayLoop("bella_ciao.wav", new TimeSpan(0, 0, 0, 11, 171), new TimeSpan(0, 0, 2, 45, 270));
                   Audio.BGMPlay("one",false);
                   //MediaPlayer.Play(bgMusic);
                   //Audio.SEPlay("one");
                 

                   
               }
           }
           if (Victory.Visible == true)
           {
               BackGround.Alpha -= 0.01f;
               BackGround1.Alpha = BackGround.Alpha;
               FarBackGround1.Alpha = BackGround.Alpha;
               FarBackGround2.Alpha = BackGround.Alpha;
               Boss1Killed.Alpha = BackGround.Alpha;
               Boss2Killed.Alpha = BackGround.Alpha;
               if (BackGround.Alpha <= 0)
               {
                   Hero.Visible = false;
                   BackGround1.Visible = false;
                   BackGround.Visible = false;
                   FarBackGround1.Visible = false;
                   FarBackGround2.Visible = false;
                   Boss2Killed.Visible = false;
                   Boss1Killed.Visible = false;
                   if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                   CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.EndScene)) as Scene_Base;
               }
           }
           if (GameOver.Visible == true)
           {
             
               if (GameOver.iCount == 0)
               {
                   Audio.BGMPlay("koulin4", false);
               }
               
               GameOver.iCount = 1;
           }
          
           if (loopCount==52)
           {
             
               Audio.BGMPlay("two",true);
               //bgMusic = CommonItem.Content.Load<Song>(@"GameContent\Sounds\BGM\two.wav");
               //MediaPlayer.IsRepeating = true;
               //MediaPlayer.Play(bgMusic);
               loopCount++;

           }
          // if (Input.Press(Keys.Enter) || Ready.Visible == false && GameName.Visible == false && Victory.Visible == false && GameOver.Visible == false)
          // {

           //    Hero.isStart = true;
        //   }
           //按空格键暂停游戏
           if (Input.Trigger(Keys.Space)||CommonItem.gamePadState.Buttons.Start==ButtonState.Pressed&&CommonItem.preGamePadState.Buttons.Start==ButtonState.Released)
           {
            
              Audio.SEPlay("16");
               time++;
               if (time % 2 == 1)
               {
                   //MyCue.Pause();
                   Audio.BGMPause();
                 
                   //MediaPlayer.Pause();
                   Hero.isStart = false;
                   zhaoshibiao.Visible = true;
               }

               else
               {
                   //MyCue.Resume();
                   Audio.BGMResume();
                   //MediaPlayer.Resume();
                   Hero.isStart = true;
                   zhaoshibiao.Visible = false;
                   zhaoshibiao.BackOffset = new Vector2(0, 0);
               }

           }
           //招式表的移动
           if (zhaoshibiao.Visible == true)
           {
               if (Input.Press(Keys.Up))
               {
                   zhaoshibiao.SPX += 0.3f;
                   zhaoshibiao.BackOffset.Y += zhaoshibiao.SPX;
               }
               if (Input.Press(Keys.Down) )
               {
                   zhaoshibiao.SPX += 0.3f;
                   zhaoshibiao.BackOffset.Y -= zhaoshibiao.SPX;
               }
               if (Input.Press(Keys.Right))
               {
                   zhaoshibiao.SPX += 0.3f;
                   zhaoshibiao.BackOffset.X -= zhaoshibiao.SPX;
               }
               if (Input.Press(Keys.Left))
               {
                   zhaoshibiao.SPX += 0.3f;
                   zhaoshibiao.BackOffset.X += zhaoshibiao.SPX;
               }
               if (!Input.Press(Keys.Up) && !Input.Press(Keys.Down) && !Input.Press(Keys.Right) && !Input.Press(Keys.Left))
               {
                   zhaoshibiao.SPX = 2;
               }
               zhaoshibiao.BackOffset.X = MathHelper.Clamp(zhaoshibiao.BackOffset.X, -(zhaoshibiao.SourceTexture.Width - Prefs.WindowSizeW), 0);
               zhaoshibiao.BackOffset.Y = MathHelper.Clamp(zhaoshibiao.BackOffset.Y, Prefs.WindowSizeH - zhaoshibiao.SourceTexture.Height, 0);
           }
           //按P键跳过杂兵直接打Boss
           if(Input.Trigger(Keys.P))
           {
               loopCount = 50;
               enemySp = 6800;
           }
           //按下K键进行时间停止3
           if (Input.Trigger(Keys.K))
           {
               isTimeStop = true;
               isTimeStop3 = true;
               
               //mountain.StartRedShadow(mountain.BackOffset);
           }
           //按下L键进行时间停止2
           if (Input.Trigger(Keys.L))
           {
               isTimeStop2 = true;
               
           }
           //按下O键进行时间停止
           if (Input.Trigger(Keys.O))
           {
               isTimeStop = true;
              
               //FarBackGround1.StartRedShadow(Boss.BackOffset);
               //FarBackGround2.StartRedShadow(Boss.BackOffset);
               //BackGround.StartRedShadow(Boss.BackOffset);
               //BackGround1.StartRedShadow(Boss.BackOffset);
               //Bus.StartRedShadow(Boss.BackOffset);
               //Bus1.StartRedShadow(Boss.BackOffset);

           }
           if (isTimeStop == false)
           {
               //FarBackGround1.EndRedShadow();
               //FarBackGround2.EndRedShadow();
               //BackGround.EndRedShadow();

               //BackGround1.EndRedShadow();
               //Bus.EndRedShadow();
               //Bus1.EndRedShadow();
             
           }
           //主角和Boss伤害控制
           if (Input.Trigger(Keys.F1))
           {
               HeroHPDec1 += 100;
               BossHPDec += 100;
           }
           if (Input.Trigger(Keys.F2))
           {
               HeroHPDec1 -= 100;
               BossHPDec -= 100;
           }
           
           if (Hero.isStart == true)
           {
               //Hero加速

               HeroHighRunning.Z = Hero.BackOffset.Y + 223;
               Hero.Z = Hero.BackOffset.Y + 224;
               Boss.Z = Boss.BackOffset.Y + 249;
               BossShooting.Z = BossShooting.BackOffset.Y + 249;
               HeroAttacked.Z = HeroAttacked.BackOffset.Y + 250;
               HitShader.Z = Hero.Z + 1;
               BackGroundUpdate();
               PortraitUpdate();
               HeroUpdate();
               SikiUpdate();
               Enemy1BackOffsetUpdate();
               enemyUpdateTime++;
               BossUpdate();
               BossPositionUpdate();
               SoundsUpdate();
               BossShootUpdate();
               
               enemyKilledUpdate();
               if (enemyUpdateTime == 20)
               {
                   Enemy1Update();
                   enemyUpdateTime = 0;
               }
               enemyIsMoveUpdate();

           }
           #region 返讨
           if (GameOver.Visible == true)
           {

               BackToHitBoss.Visible = true;
               BackToRestart.Visible = true;
               if (Cursor.iCount == 0)
               {
                   Cursor.Visible = true;
               }

               if (Input.Trigger(Keys.Up))
               {
                   Cursor.BackOffset.Y = BackToHitBoss.BackOffset.Y;
               }
               if (Input.Trigger(Keys.Down) )
               {
                   Cursor.BackOffset.Y = BackToRestart.BackOffset.Y;
               }
               if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
               {
                   Cursor.Visible = false;

               }
               if (Cursor.Visible == false)
               {
                   Cursor.iCount++;
                   if (Cursor.iCount >= 60)
                   {
                       Cursor.iCount = 0;
                       if (Cursor.BackOffset.Y == BackToHitBoss.BackOffset.Y)
                       {
                           //返回去大Boss
                           Audio.SEPlay("24");
                           Hero.HP = 1000;
                           Hero.Shader.Visible = true;
                           Hero.isStart = true;
                           Hero.Visible = true;
                           Hero.BackOffset = new Microsoft.Xna.Framework.Vector2(300, 300);
                           HeroKilled.Visible = false;
                           HeroKilledShader.Visible = false;
                           Boss.Visible = true;
                           Boss1Killed.Visible = false;
                           Boss2Killed.Visible = false;
                           GameOver.Visible = false;
                           Boss.BackOffset.X = 1280;
                           BackToHitBoss.Visible = false;
                           BackToRestart.Visible = false;
                           Cursor.Visible = false;
                           Audio.BGMPlay("two", true);
                       }
                       if (Cursor.BackOffset.Y == BackToRestart.BackOffset.Y)
                       {
                           //返回重新开始游戏
                           //Hero.HP = 1000;
                           //loopCount = 0;
                           //enemyKilledCount = 0;
                           //enemyOverCount = 0;
                           //Hero.Shader.Visible = true;
                           //Boss.Visible = false;
                           //Boss.BackOffset.X = 1280;
                           //HeroKilled.Visible = false;
                           //HeroKilledShader.Visible = false;
                           //Hero.isStart = true;
                           //enemySp = 0;
                           //Hero.Visible = true;
                           //Hero.BackOffset = new Microsoft.Xna.Framework.Vector2(300, 300);
                           //GameOver.Visible = false;
                           //BackToHitBoss.Visible = false;
                           //BackToRestart.Visible = false;
                           //Cursor.Visible = false;
                           //Audio.BGMPlay("one",true);
                           Audio.SEPlay("23");
                           CommonItem.isPalyed = true;
                           if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                           CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.StartScene)) as Scene_Base;


                       }
                   }
               }
           }
           #endregion
           base.Update();

       }
    }
}
