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
        Boolean isShootSoundStart = false;
        private void BossShootUpdate()
        {
            BossShoot1.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 139), (int)BossShooting.BackOffset.Y - 130);
            BossShoot2.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 478), (int)BossShooting.BackOffset.Y + 65);
            BossShoot3.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 643), (int)BossShooting.BackOffset.Y - 51);
            BossShoot4.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 635), (int)BossShooting.BackOffset.Y - 28);
            BossShoot5.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 635), (int)BossShooting.BackOffset.Y - 28);
            BossShoot6.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 632), (int)BossShooting.BackOffset.Y - 17);

            // Hero.CollisionRect = new Rectangle((int)(Hero.BackOffset.X), (int)(Hero.BackOffset.Y + 210), Hero.SourceTexture.Width/Hero.spriteSizeX, 15);
            //Hero.CollisionRect = new Rectangle((int)(Hero.BackOffset.X + 62), (int)(Hero.BackOffset.Y + 46), 49, 98);

            if (ShootStyle == 1)
            {
                //子弹1的碰撞判定
                BossShoot1.CollisionRect = new Rectangle((int)BossShoot1.BackOffset.X + BossShoot1CollisionRect[0], (int)(Boss.BackOffset.Y + BossShoot1CollisionRect[1]), BossShoot1CollisionRect[2], BossShoot1CollisionRect[3]);
                if (Hero.CollisionRect.Intersects(BossShoot1.CollisionRect))
                {

                   
                    if (isHeroNiuBility == false)
                    {
                        if (isHeroDefense == false)
                        {
                            Hero.HP -= HeroHPDec1;
                            HeroHighRunning.Visible = false;
                            HeroAttacked.BackOffset = Hero.BackOffset;
                            HeroAttacked.Visible = true;
                            isHeroNiuBility = true;
                            playTheHeroAttackedSound();
                        }
                        HeroDefenseShooted_fire.Visible = true;
                    }
                }
                BossShoot1.ShowingRect = BossShoot1.SourceRect(BossShoot1);
                BossShoot1.Visible = true;
                BossShoot1.iCount++;
                if (BossShoot1.iCount == 6)
                {
                    if (isShootSoundStart == false)
                    {
                        isShootSoundStart = true;
                        Audio.SEPlay("06");
                    }
                    BossShoot1.ObjectAnimation(BossShoot1);
                    BossShoot1.iCount = 0;
                    if (BossShoot1.Visible == false)
                    {
                        Audio.SEPlay("06");
                        BossShoot1.Visible = true;
                        BossShoot1.HP++;
                        if (BossShoot1.HP == 3)
                        {
                            isShootSoundStart = false;
                            BossShoot1.HP = 0;
                            BossShoot1.Visible = false;
                            ShootStyle = 0;
                        }
                    }
                }
            }
            if (ShootStyle == 2)
            {
                //子弹2的碰撞判定
                BossShoot2.CollisionRect = new Rectangle((int)BossShoot2.BackOffset.X, (int)(Boss.BackOffset.Y + 240), BossShoot2.SourceTexture.Width / 2, 10); ;
                BossShoot2.iCount++;
                if (Hero.CollisionRect.Intersects(BossShoot2.CollisionRect))
                {
                    
                    if (isHeroNiuBility == false)
                    {
                        if (isHeroDefense == false)
                        {
                            playTheHeroAttackedSound();
                            Hero.HP -= HeroHPDec2;
                            HeroHighRunning.Visible = false;
                            HeroAttacked.BackOffset = Hero.BackOffset;
                            HeroAttacked.Visible = true;
                            isHeroNiuBility = true;
                            HeroDefenseShooted_fire.Visible = true;
                        }
                    }

                }

                BossShoot2.ShowingRect = BossShoot2.SourceRect(BossShoot2);
                BossShoot2.Visible = true;
                if (BossShoot2.iCount == 6)
                {
                    if (isShootSoundStart == false)
                    {
                        isShootSoundStart = true;
                        Audio.SEPlay("06");
                    }
                    BossShoot2.ObjectAnimation(BossShoot2);
                    BossShoot2.iCount = 0;
                    if (BossShoot2.Visible == false)
                    {
                        Audio.SEPlay("06");
                        BossShoot2.Visible = true;
                        BossShoot2.HP++;
                        if (BossShoot2.HP == 3)
                        {
                            isShootSoundStart = false;
                            BossShoot2.HP = 0;
                            BossShoot2.Visible = false;
                            ShootStyle = 0;
                        }
                    }
                }
            }
            if (ShootStyle == 3)
            {
                if (BossShoot3.CurrentPositionX == 0 && BossShoot3.CurrentPositionY == 0)
                {
                    BossShoot3.CollisionRect = new Rectangle((int)BossShoot3.BackOffset.X + 550, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot3.CurrentPositionX == 1 && BossShoot3.CurrentPositionY == 0)
                {
                    BossShoot3.CollisionRect = new Rectangle((int)BossShoot3.BackOffset.X + 320, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot3.CurrentPositionX == 0 && BossShoot3.CurrentPositionY == 1)
                {
                    BossShoot3.CollisionRect = new Rectangle((int)BossShoot3.BackOffset.X + 75, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot3.CurrentPositionX == 1 && BossShoot3.CurrentPositionY == 1)
                {
                    BossShoot3.CollisionRect = new Rectangle((int)BossShoot3.BackOffset.X - 15, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                else
                {
                    BossShoot3.CollisionRect = new Rectangle((int)BossShoot3.BackOffset.X - 15, (int)(BossShoot3.BackOffset.Y + 160), 0, 0);

                }
                BossShoot3.ShowingRect = BossShoot3.SourceRect(BossShoot3);
                BossShoot3.Visible = true;
                BossShoot3.iCount++;
                if (Hero.CollisionRect.Intersects(BossShoot3.CollisionRect))
                {
                   
                    if (isHeroNiuBility == false)
                    {
                        if (isHeroDefense == false)
                        {
                            playTheHeroAttackedSound();
                            Hero.HP -= HeroHPDec3;
                            HeroHighRunning.Visible = false;
                            HeroAttacked.BackOffset = Hero.BackOffset;
                            HeroAttacked.Visible = true;
                            isHeroNiuBility = true;
                            HeroDefenseShooted_fire.Visible = true;
                        }
                    }
                }
                if (BossShoot3.iCount == 4)
                {
                    if (isShootSoundStart == false)
                    {
                        isShootSoundStart = true;
                        Audio.SEPlay("06");
                    }
                    BossShoot3.ObjectAnimation(BossShoot3);
                    BossShoot3.iCount = 0;
                    if (BossShoot3.Visible == false)
                    {
                        Audio.SEPlay("06");
                        BossShoot3.Visible = true;
                        BossShoot3.HP++;
                        if (BossShoot3.HP == 3)
                        {
                            isShootSoundStart = false;
                            BossShoot3.HP = 0;
                            BossShoot3.Visible = false;
                            ShootStyle = 0;
                        }
                    }
                }
            }
            if (ShootStyle == 4)
            {
                if (BossShoot4.CurrentPositionX == 0 && BossShoot4.CurrentPositionY == 0)
                {
                    BossShoot4.CollisionRect = new Rectangle((int)BossShoot4.BackOffset.X + 530, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot4.CurrentPositionX == 1 && BossShoot4.CurrentPositionY == 0)
                {
                    BossShoot4.CollisionRect = new Rectangle((int)BossShoot4.BackOffset.X + 380, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot4.CurrentPositionX == 0 && BossShoot4.CurrentPositionY == 1)
                {
                    BossShoot4.CollisionRect = new Rectangle((int)BossShoot4.BackOffset.X + 230, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot4.CurrentPositionX == 1 && BossShoot4.CurrentPositionY == 1)
                {
                    BossShoot4.CollisionRect = new Rectangle((int)BossShoot4.BackOffset.X + 80, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                else
                {
                    BossShoot4.CollisionRect = new Rectangle((int)BossShoot4.BackOffset.X + 80, (int)(BossShoot4.BackOffset.Y + 65), 0, 0);
                }
                BossShoot4.ShowingRect = BossShoot4.SourceRect(BossShoot4);
                BossShoot4.Visible = true;
                BossShoot4.iCount++;
                if (Hero.CollisionRect.Intersects(BossShoot4.CollisionRect))
                {
                 
                    if (isHeroNiuBility == false)
                    {
                        if (isHeroDefense == false)
                        {
                            playTheHeroAttackedSound();
                            Hero.HP -= HeroHPDec4;
                            HeroHighRunning.Visible = false;
                            HeroAttacked.BackOffset = Hero.BackOffset;
                            HeroAttacked.Visible = true;
                            isHeroNiuBility = true;
                            HeroDefenseShooted_fire.Visible = true;
                        }
                    }
                }
                if (BossShoot4.iCount == 4)
                {
                    if (isShootSoundStart == false)
                    {
                        isShootSoundStart = true;
                        Audio.SEPlay("06");
                    }
                    BossShoot4.ObjectAnimation(BossShoot4);
                    BossShoot4.iCount = 0;
                    if (BossShoot4.Visible == false)
                    {
                        Audio.SEPlay("06");
                        BossShoot4.Visible = true;
                        BossShoot4.HP++;
                        if (BossShoot4.HP == 3)
                        {
                            isShootSoundStart = false;
                            BossShoot4.HP = 0;
                            BossShoot4.Visible = false;
                            ShootStyle = 0;
                        }
                    }
                }
            }
            if (ShootStyle == 5)
            {
                if (BossShoot5.CurrentPositionX == 0 && BossShoot5.CurrentPositionY == 0)
                {
                    BossShoot5.CollisionRect = new Rectangle((int)BossShoot5.BackOffset.X + 565, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot5.CurrentPositionX == 1 && BossShoot5.CurrentPositionY == 0)
                {
                    BossShoot5.CollisionRect = new Rectangle((int)BossShoot5.BackOffset.X + 390, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot5.CurrentPositionX == 0 && BossShoot5.CurrentPositionY == 1)
                {
                    BossShoot5.CollisionRect = new Rectangle((int)BossShoot5.BackOffset.X + 250, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                if (BossShoot5.CurrentPositionX == 1 && BossShoot5.CurrentPositionY == 1)
                {
                    BossShoot5.CollisionRect = new Rectangle((int)BossShoot5.BackOffset.X + 110, (int)(Boss.BackOffset.Y + 240), ShootRectWidth, 10);
                }
                else
                {
                    BossShoot5.CollisionRect = new Rectangle((int)BossShoot5.BackOffset.X + 110, (int)(BossShoot5.BackOffset.Y + 175), 0, 0);
                }
                BossShoot5.ShowingRect = BossShoot5.SourceRect(BossShoot5);
                BossShoot5.Visible = true;
                BossShoot5.iCount++;
                if (Hero.CollisionRect.Intersects(BossShoot5.CollisionRect))
                {
                   
                    if (isHeroNiuBility == false)
                    {
                        if (isHeroDefense == false)
                        {
                            playTheHeroAttackedSound();
                            Hero.HP -= HeroHPDec5;
                            HeroHighRunning.Visible = false;
                            HeroAttacked.BackOffset = Hero.BackOffset;
                            HeroAttacked.Visible = true;
                            isHeroNiuBility = true;
                            HeroDefenseShooted_fire.Visible = true;
                        }
                    }
                }
                if (BossShoot5.iCount == 4)
                {
                    if (isShootSoundStart == false)
                    {
                        isShootSoundStart = true;
                        Audio.SEPlay("06");
                    }

                    BossShoot5.ObjectAnimation(BossShoot5);
                    BossShoot5.iCount = 0;
                    if (BossShoot5.Visible == false)
                    {
                        Audio.SEPlay("06");
                        BossShoot5.Visible = true;
                        BossShoot5.HP++;
                        if (BossShoot5.HP == 3)
                        {
                            isShootSoundStart = false;
                            BossShoot5.HP = 0;
                            BossShoot5.Visible = false;
                            ShootStyle = 0;
                        }
                    }
                }
            }
            if (ShootStyle == 6)
            {

                BossShoot6.CollisionRect = new Rectangle((int)BossShoot6.BackOffset.X, (int)(Boss.BackOffset.Y + 240), 685, 10);

                BossShoot6.ShowingRect = BossShoot6.SourceRect(BossShoot6);
                BossShoot6.Visible = true;
                BossShoot6.iCount++;
                if (Hero.CollisionRect.Intersects(BossShoot6.CollisionRect))
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
                if (BossShoot6.iCount == 6)
                {
                    if (isShootSoundStart == false)
                    {
                        isShootSoundStart = true;
                        Audio.SEPlay("06");
                    }
                    BossShoot6.ObjectAnimation(BossShoot6);
                    BossShoot6.iCount = 0;
                    if (BossShoot6.Visible == false)
                    {
                        Audio.SEPlay("06");
                        BossShoot6.Visible = true;
                        BossShoot6.HP++;
                        if (BossShoot6.HP == 3)
                        {
                            isShootSoundStart = false;
                            BossShoot6.HP = 0;
                            BossShoot6.Visible = false;
                            ShootStyle = 0;
                        }
                    }
                }
            }
        }

        public void playTheHeroAttackedSound()//主角被攻击的音效
        {
            Random rd = new Random();
            if ((int)rd.Next(1, 10) == 1)
            {
                Audio.SEPlay("25a");
            }
            if ((int)rd.Next(1, 10) == 2)
            {
                Audio.SEPlay("25b");
            }
            if ((int)rd.Next(1, 10) == 3)
            {
                Audio.SEPlay("25c");
            }
            if ((int)rd.Next(1, 10) == 4)
            {
                Audio.SEPlay("25d");
            }
            if ((int)rd.Next(1, 10) == 5)
            {
                Audio.SEPlay("25e");
            }
            if ((int)rd.Next(1, 10) == 6)
            {
                Audio.SEPlay("25f");
            }
            if ((int)rd.Next(1, 10) == 7)
            {
                Audio.SEPlay("25g");
            }
            if ((int)rd.Next(1, 10) == 8)
            {
                Audio.SEPlay("25h");
            }
            if ((int)rd.Next(1, 10) == 9)
            {
                Audio.SEPlay("25i");
            }
        }
    }
}
