using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEngine;
using ArcadeGame.Programs.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace ArcadeGame.Programs.Scenes
{
   public partial class Scene_Main:Scene_Base
    {
       Sprite Bus;
       Sprite Bus1;
       int enemyKilledCount;
       Sprite BackGround;
       Sprite BackGround1;
       Sprite FarBackGround1;
       Sprite FarBackGround2;
       public Sprite Boss;
       Sprite BossShooting;
       Sprite explode;
       Sprite Boss1Killed;

       Sprite BossHP_01;
       Sprite BossHP_02;
       Sprite BossPortrait_01;
       Sprite BossPortrait_02;
       Sprite BossName_01;
       Sprite BossName_02;
       Sprite Boss2Killed;
       Sprite BossKilled;
       Sprite BossShoot1;
       Sprite HeroKilledShader;
       Sprite HeroHighRunning;
       Sprite BossShoot2;
       Sprite BossShoot3;
       Sprite BossShoot4;
       Sprite BossShoot5;
       Sprite BossShoot6;
       Sprite explode2;
       Sprite SpeedUpShader;
       Sprite GameName;
       Sprite Ready;
       Sprite Victory;
       Sprite Siki;
       Sprite SikiAttack;
       Sprite SikiAttack2;
       Sprite HeroAttackShader;
     public  Sprite HeroAttackSkill1;
     public  Sprite HeroAttackSkill2;
       Sprite GameOver;
       Sprite HitShader;
       Sprite HeroAttacked;
       Sprite HeroAttack1;
       Sprite HeroAttack2;
       Sprite HeroKilling;
       Sprite HeroKilled;
       Sprite HeroDefenseShooted_fire;

       Sprite redShader;

       Sprite SikiAttackSkillEffect1;
       Sprite SikiAttackSkillEffect2;
       Sprite HeroDefense;
       Sprite xinyue;
       Sprite Fire;
       Sprite Fire_fire;
       Sprite generateElectric;
       Sprite Electric;
       Sprite reduceElectric;
       Sprite Electric_fire;
       Sprite lianxuzhan;
       Sprite generateAnger;
       Sprite AngerLoop;
       Sprite reduceAnger;

       Sprite zhaoshibiao;

       //时间停止3
       Sprite littleRedShader;
       //时间停止1
       //Sprite timeStopBullet;
       List<Sprite> timeStopBullets = new List<Sprite>();

       Sprite mountain;
       Sprite timeStop3;
       Sprite BackToHitBoss;
       Sprite BackToRestart;
       Sprite BossAttacked;
       Sprite TakeOutGun;
       Sprite_TextBox TestBox1;
       Sprite_TextBox TestBox2;
       Sprite_TextBox TextBox3;
       Sprite_TextBox TextBox4;
       Sprite_TextBox enemyKilledPercentBox;
       Sprite_TextBox misssEnemypercentBox;
       Vector2 BusVector;
       Sprite LastExplode1;
       Sprite LastExplode2;
       Song bgMusic;
       double time = 0;
       int ShootRectWidth = 60;
       int BossHPDec =50;
       int HeroHPDec1 =50;
       int HeroHPDec2 = 20;
       int HeroHPDec3 = 50;
       int HeroHPDec4 = 100;
       int HeroHPDec5 = 150;
       int HeroHPDec6 = 200;
       int ShootStyle = 0;
       int moveTime;
       float BackGroundSPXDec = 0;
       float BusSPXDec = 0.03f;
       float ShootStyleCount = 1;
       public int enemySP;
       int enemyOverCount = 0;
       public float k;
       float h, j=1,m=1;
       public List<Sprite> Enemy1Killed = new List<Sprite>();
       public List<Sprite> Enemy2Killed = new List<Sprite>();
       public List<Sprite> Enemy1 = new List<Sprite>();
       public List<Sprite> Enemy2 = new List<Sprite>();
       public List<Sprite> HitSHaders = new List<Sprite>();
       public Sprite Hero;
       int enemySp;
       Boolean isEnemy1HitLand = false;
       Boolean isEnemy2HitLand = false;
      // public AudioEngine audioEngine;
      // public SoundBank soundBank;
       //public WaveBank waveBank;
       //public Cue MyCue;
      
       public int loopCount = 0;
       public int maxloopCount = 56;
       public int enemyUpdateTime;
       public int test;
        public Scene_Main():base()
        {   
           //初始化背景
           // bgMusic = CommonItem.Content.Load<Song>(@"GameContent\Sounds\BGM\one.wav");
            BackGroundInitialize();
            HeroInitialize();
            EnemyInitialize();
            PlayNotice();
            BossInitialize();
            SikiInitialize();
            PortraitInitialize();

            TestBox1 = new Sprite_TextBox(1000, 50);
            TestBox1.Color = Color.Red;
            TestBox1.FontSize = 16;
            TestBox1.Z = 4;
            TestBox2 = new Sprite_TextBox(800, 50);
            TestBox2.Align = AlignType.Middle;
            TestBox2.Color = Color.Yellow;
            TestBox2.FontSize = 16;
            TestBox2.Z = 4;
            TextBox3 = new Sprite_TextBox(800, 50); 
            TextBox3.Color = Color.Green;
            TextBox3.Position = new Vector2(600, 350);
            TextBox3.FontSize = 16;
            TextBox3.Z = 900;
            TextBox4 = new Sprite_TextBox(800, 50);
            TextBox4.Color = Color.Green;
            TextBox4.Position = new Vector2(600, 450);
            TextBox4.FontSize = 16;
            TextBox4.Z = 900;
            BusVector = Bus1.BackOffset;
            AddChild(TextBox4);
            AddChild(TextBox3);
            AddChild(TestBox1);
            AddChild(TestBox2);

            enemyKilledPercentBox = new Sprite_TextBox(50, 40);
            enemyKilledPercentBox.Color = Color.Blue;
            enemyKilledPercentBox.Position = new Vector2(388, 10);
            enemyKilledPercentBox.FontSize = 16;
            enemyKilledPercentBox.Z = 1000;
            AddChild(enemyKilledPercentBox);

            misssEnemypercentBox = new Sprite_TextBox(50, 40);
            misssEnemypercentBox.Color = Color.SteelBlue;
            misssEnemypercentBox.Position = new Vector2(457, 10);
            misssEnemypercentBox.FontSize = 16;
            misssEnemypercentBox.Z = 1000;
            AddChild(misssEnemypercentBox);
           /* audioEngine = new AudioEngine("Content/BackGround.xgs");
            soundBank = new SoundBank(audioEngine,"Content/Sound Bank.xsb");
            waveBank = new WaveBank(audioEngine, "Content/Wave Bank.xwb");
            MyCue = soundBank.GetCue("BackGroud");

            //Cache.BGM("TheDawn");
           */
           //Cache.BGM("cirno-raw");
            //bgm = Cache.BGM("cirno-raw");
            //bgmInstance = bgm.CreateInstance();
            //bgmInstance.IsLooped = true;
            //Cache.BGM("one");
            //Cache.BGM("two");
            
        }

       
       //玩家提示初始化
        private void PlayNotice()
        {
            GameName = new Sprite("GameName",true,false,2000,0,0,1,1);
            GoToCenter(GameName);
            AddChild(GameName);
            GameOver = new Sprite("Over", false, false, 2000, 0, 0, 1, 1);
            GoToCenter(GameOver);
            GameOver.BackOffset.Y -=100;
            AddChild(GameOver);
            Victory = new Sprite("Victory", false, false, 2000, 0, 0, 1, 1);
            GoToCenter(Victory);
            AddChild(Victory);
            Ready = new Sprite("Ready", false, false, 2000, 0, 0, 1, 1);
            GoToCenter(Ready);
            AddChild(Ready);
        }
      public void  GoToCenter(Sprite sprite)
       {
           sprite.BackOffset.X = Prefs.WindowSizeW/ 2 - sprite.SourceTexture.Width / (sprite.spriteSizeX * 2);
           sprite.BackOffset.Y = Prefs.WindowSizeH / 2 - sprite.SourceTexture.Height / (sprite.spriteSizeY * 2);
       }
       
        private void ClsShooting()
        {
            BossShoot1 = new Sprite("Shoot1", false, false, 900, 0, 0, 3, 1);
            BossShoot2 = new Sprite("Shoot2", false, false, 900, 0, 0, 2, 2);
            BossShoot3 = new Sprite("Shoot3", false, false, 900, 0, 0, 2, 3);
            BossShoot4 = new Sprite("Shoot4", false, false, 900, 0, 0, 2, 3);
            BossShoot5 = new Sprite("Shoot5", false, false, 900, 0, 0, 2, 3);
            BossShoot6 = new Sprite("Shoot6", false, false, 900, 0, 0, 2, 2);
        }
        public void SpeedChange(Sprite sprite, bool UpOrDown, float PresSpeed,float k)
        {
            if (UpOrDown == true)
            {
               
                if (Bus.SPX <= PresSpeed)
                {
                     Bus.SPX +=k;
                }
                if (Bus.SPX >= PresSpeed)
                {
                    sprite.isSpeedChange = false;
                }
            }
            if (UpOrDown == false)
            {
               
                if (Bus.SPX >= PresSpeed)
                {
                     Bus.SPX -=k;
                }
                if (Bus.SPX <= PresSpeed)
                {
                    sprite.isSpeedChange = false;
                }
            }
        }
       


       
       

        private void enemyIsMoveUpdate()
        {
            Random r = new Random();
            moveTime++;
            if(moveTime==100)
            {
                foreach (var enemy1 in Enemy1)
                {
                    k = r.Next(0, 20);
                    if (k > 10)
                        enemy1.isMove = true;
                    if (k <= 10)
                    {
                        enemy1.isMove = false;
                        enemy1.CurrentPositionX = 0;
                        enemy1.ShowingRect = enemy1.SourceRect(enemy1);
                    }

                }
                foreach (var enemy1 in Enemy2)
                {
                    k = r.Next(0, 20);
                    if (k > 10)
                        enemy1.isMove = true;
                    if (k <= 10)
                    {
                        enemy1.isMove = false;
                        enemy1.CurrentPositionX = 0;
                    }
                }
                moveTime = 0;
            }
        }

       
        
       
        private void Enemy1Update()
        {
            foreach (var enemy1 in Enemy1)
            {
                enemy1.Z = enemy1.BackOffset.Y + 250;
              //  if(enemy1.isMove==true)
             //   enemy1.ObjectAnimation(enemy1);
               
            }
            foreach (var enemy2 in Enemy2)
            {
                enemy2.Z = enemy2.BackOffset.Y + 250;
               // if(enemy2.isMove==true)
               // enemy2.ObjectAnimation(enemy2);
            }
            
                
             
        }
        private void enemyKilledUpdate()
        {

            foreach (var enemyKilled in Enemy1Killed)
            {

                enemyKilled.Z = enemyKilled.BackOffset.Y + enemyKilled.SourceTexture.Height;
                if (enemyKilled.Visible == true)
                {
                    
                    enemyKilled.Shader.Visible = enemyKilled.Visible;
                    enemyKilled.Shader.BackOffset.X = enemyKilled.BackOffset.X;
                    //enemyKilled.Shader.BackOffset.Y = enemy.BackOffset.Y + 125;
                    enemyKilled.iCount+=0.1f;
                    enemyKilled.BackOffset.X += enemyKilled.SPX;
                    if (enemyKilled.SPX >= 0)
                    {
                        enemyKilled.BackOffset.Y = enemyKilled.BackOffset.Y - 10 * enemyKilled.iCount + (float)(5 * enemyKilled.iCount * enemyKilled.iCount);
                    }
                    if (enemyKilled.BackOffset.Y >= enemyKilled.Shader.BackOffset.Y-10)
                    {
                        if (isEnemy1HitLand == false)
                        {
                            isEnemy1HitLand = true;
                            Audio.SEPlay("03");
                        }
                        enemyKilled.CurrentPositionX = 1;
                        enemyKilled.ShowingRect = enemyKilled.SourceRect(enemyKilled);
                        enemyKilled.SPX = -Bus.SPX;
                        enemyKilled.iCount = 0;
                    }
                    if (enemyKilled.BackOffset.X <= -enemyKilled.SourceTexture.Width)
                    {
                      
                        enemyKilled.Visible = false;
                        enemyKilled.CurrentPositionX = 0;
                        enemyKilled.CurrentPositionY = 0;
                        enemyKilled.ShowingRect = enemyKilled.SourceRect(enemyKilled);
                        enemyKilled.SPX = 3;
                    }
                   
                }
            }
            foreach (var enemyKilled in Enemy2Killed)
            {

                enemyKilled.Z = enemyKilled.BackOffset.Y + enemyKilled.SourceTexture.Height;
                if (enemyKilled.Visible == true)
                {
                  
                
                enemyKilled.Shader.BackOffset.X = enemyKilled.BackOffset.X;
                enemyKilled.Shader.Visible = enemyKilled.Visible;
                    enemyKilled.iCount+=0.1f;
                    enemyKilled.BackOffset.X += enemyKilled.SPX;
                    if (enemyKilled.SPX >= 0)
                    {
                        enemyKilled.BackOffset.Y = enemyKilled.BackOffset.Y - 10 * enemyKilled.iCount + (float)(5 * enemyKilled.iCount * enemyKilled.iCount);
                    }
                    if (enemyKilled.BackOffset.Y >= enemyKilled.Shader.BackOffset.Y)
                    {
                        if (isEnemy2HitLand == false)
                        {
                            isEnemy2HitLand = true;
                            Audio.SEPlay("03");
                        }
                        enemyKilled.CurrentPositionX = 1;
                        enemyKilled.ShowingRect = enemyKilled.SourceRect(enemyKilled);
                        enemyKilled.SPX = -Bus.SPX;
                        enemyKilled.iCount = 0;
                    }
                    if (enemyKilled.BackOffset.X <= -enemyKilled.SourceTexture.Width)
                    {
                        
                        enemyKilled.Visible = false;
                        enemyKilled.CurrentPositionX = 0;
                        enemyKilled.CurrentPositionY = 0;
                        enemyKilled.ShowingRect = enemyKilled.SourceRect(enemyKilled);
                        enemyKilled.SPX =3;
                    }
                    
                }
                
            }
        }
       
        
       

        private void HeroGoToCenter(Sprite sprite)
        {

            if (j == 1)
            {
                h =sprite.BackOffset.Y;
                sprite.BackOffset.X = Prefs.WindowSizeW / 2 - sprite.SourceTexture.Width / (sprite.spriteSizeX*2);
               // sprite.BackOffset.Y = Prefs.WindowSizeH / 2 - sprite.SourceTexture.Height / (sprite.spriteSizeY * 2);
                m = sprite.BackOffset.X;
                j = sprite.BackOffset.Y - h;
                //Bus.BackOffset.Y += j;
               // Bus1.BackOffset.Y += j;
               
                j = 0;
            }
        }
       //the Sprites animation
        private void frameUpdate(LinkedList<Sprite> Sprites)
        {
            foreach(var sprite in Sprites)
            {
                sprite.iCount++;
                if (sprite.iCount >= 5)
                {
                    sprite.iCount = 0;
                    sprite.ObjectAnimation(sprite);
                }
                sprite.BackOffset.X -= sprite.SPX;
            }
        }
        private void BackGroundUpdate()
        {
            //Bus
            Bus.BackOffset.X -= Bus.SPX;
            Bus1.BackOffset.X -= Bus.SPX;
            if (isgotoHero == false)
            {
                if (Bus.BackOffset.X <= -Bus.SourceTexture.Width / 2)
                {
                    Bus.BackOffset.X = Bus1.SourceTexture.Width / 2;
                }


                if (Bus1.BackOffset.X <= -Bus1.SourceTexture.Width / 2)
                {
                    Bus1.BackOffset.X = Bus.SourceTexture.Width / 2;
                }
            }
            if (isgotoHero == true)
            {
                if (Bus.BackOffset.X >= Bus1.SourceTexture.Width / 2)
                {
                    Bus.BackOffset.X = -Bus1.SourceTexture.Width / 2;
                }


                if (Bus1.BackOffset.X >=Bus.SourceTexture.Width / 2)
                {
                    Bus1.BackOffset.X = -Bus.SourceTexture.Width / 2;
                }
            }
            Bus.iCount++;
            //中景
            BackGround.BackOffset.X -= BackGround.SPX;
            BackGround1.BackOffset.X -= BackGround.SPX;
            BackGround1.BackOffset.Y -= BackGround.SPY;
            BackGround.BackOffset.Y -= BackGround.SPY;
            //backGround和backGround1位置同步
           
            if (isgotoHero == false)
            {
                if (BackGround1.BackOffset.Y <= -(BackGround1.SourceTexture.Height - Prefs.WindowSizeH))
                {

                    BackGround.SPY = -0.1f;

                }
                if (BackGround.BackOffset.Y >= -150)
                {


                    BackGround.SPY = 0.2f;

                }

                if (BackGround.BackOffset.X <= -BackGround.SourceTexture.Width)
                {
                    loopCount++;
                    BackGround.BackOffset.X = BackGround1.BackOffset.X + BackGround1.SourceTexture.Width;
                }

                if (BackGround1.BackOffset.X <= -BackGround1.SourceTexture.Width)
                {
                    BackGround1.BackOffset.X = BackGround.BackOffset.X + BackGround.SourceTexture.Width;
                }
            }
            if (isgotoHero == true)
            {
                if (BackGround1.BackOffset.Y <= -(BackGround1.SourceTexture.Height - Prefs.WindowSizeH))
                {

                    BackGround.SPY = -0.1f;

                }
                if (BackGround.BackOffset.Y >= -150)
                {


                    BackGround.SPY = 0.2f;

                }

                if (BackGround.BackOffset.X >=BackGround.SourceTexture.Width)
                {
                    
                    BackGround.BackOffset.X = BackGround1.BackOffset.X - BackGround1.SourceTexture.Width;
                }

                if (BackGround1.BackOffset.X >=BackGround.SourceTexture.Width)
                {
                    BackGround1.BackOffset.X = BackGround.BackOffset.X - BackGround.SourceTexture.Width;
                }
            }
            //远景
            FarBackGround1.BackOffset.X -= FarBackGround1.SPX;
            FarBackGround2.BackOffset.X -= FarBackGround1.SPX;

            if (FarBackGround1.BackOffset.X <= -FarBackGround1.SourceTexture.Width)
            {
                FarBackGround1.BackOffset.X = FarBackGround1.SourceTexture.Width;
            }

            if (FarBackGround2.BackOffset.X <= -FarBackGround2.SourceTexture.Width)
            {
                FarBackGround2.BackOffset.X = FarBackGround2.SourceTexture.Width;
            }
          
        }
        
        public override void Draw()
        {
            base.Draw();
        }
        
            
       

    }
}
