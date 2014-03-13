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
        public int[] EnemyPositionY = new int[8];

        private void Enemy1BackOffsetUpdate()
        {
            enemySp++;
            foreach (var enemy1 in Enemy1)
            {
                enemy1.Shader.Visible = enemy1.Visible;
                enemy1.Shader.BackOffset = enemy1.BackOffset;
                //enemy1.Z = enemy1.BackOffset.Y + enemy1.SourceTexture.Height;
                if (enemy1.Visible == true)
                {
                    if (enemy1.isMove == false)
                    {
                        enemy1.BackOffset.X -= Bus.SPX;
                    }
                    if (enemy1.isMove == true)
                    {
                       // enemy1.BackOffset.X -= (Bus.SPX + 1);
                        enemy1.BackOffset.X -= (Bus.SPX);
                    }
                    Hero.CollisionRect = new Rectangle((int)(Hero.BackOffset.X + 40), (int)(Hero.BackOffset.Y + 220), 140, 5);
                    //敌人1的碰撞判定区域
                    enemy1.CollisionRect = new Rectangle((int)enemy1.BackOffset.X + 50, (int)enemy1.BackOffset.Y + 250, 60, 5);
                    if (Hero.CollisionRect.Intersects(enemy1.CollisionRect))
                    {
                         Audio.SEPlay("21");
                        Audio.SEPlay("09");
                        isEnemy1HitLand = false;
                        foreach (var hs in HitSHaders)
                        {
                            if (hs.Visible == false)
                            {
                                hs.Visible = true;
                                break;
                            }

                        }
                        //HitShader.Visible = true;
                        enemy1.Visible = false;
                        enemyKilledCount++;
                        foreach (var enemy1Killed in Enemy1Killed)
                        {

                            if (enemy1Killed.Visible == false)
                            {
                                // enemy1Killed.BackOffset = enemy1.BackOffset;
                                enemy1Killed.Visible = true;
                                //产生Killing动画
                                enemy1Killed.BackOffset = new Vector2(enemy1.BackOffset.X + 30, enemy1.BackOffset.Y + (enemy1.SourceTexture.Height - enemy1Killed.SourceTexture.Height) - 20);
                                enemy1Killed.Shader.BackOffset.Y = enemy1.BackOffset.Y + 125;                            
                                //  enemy1Killing();
                                break;
                            }

                        }

                    }
                    if (enemy1.BackOffset.X < -enemy1.SourceTexture.Width / 3)
                    {
                        enemyOverCount++;
                        enemy1.Visible = false;
                    }
                }
                //enemyKilledUpdate(enemy1);
            }
            foreach (var enemy1 in Enemy2)
            {
                enemy1.Shader.Visible = enemy1.Visible;
                enemy1.Shader.BackOffset = enemy1.BackOffset;
               // enemy1.Z = enemy1.BackOffset.Y + enemy1.SourceTexture.Height;
                if (enemy1.Visible == true)
                {
                    if (enemy1.isMove == false)
                    {
                        enemy1.BackOffset.X -= Bus.SPX;
                    }
                    if (enemy1.isMove == true)
                    {
                        //enemy1.BackOffset.X -= (Bus.SPX + 1);
                        enemy1.BackOffset.X -= (Bus.SPX);
                    }
                    Hero.CollisionRect = new Rectangle((int)(Hero.BackOffset.X + 40), (int)(Hero.BackOffset.Y + 220), 140 , 5);
                    //敌人2的碰撞判定区域
                    enemy1.CollisionRect = new Rectangle((int)enemy1.BackOffset.X + 50, (int)enemy1.BackOffset.Y + 250, 60, 5);
                    if (Hero.CollisionRect.Intersects(enemy1.CollisionRect))
                    {
                       Random rd=new Random();
                       if((int)rd.Next(1,5)==1)
                       {
                         Audio.SEPlay("20a");
                       }
                       if ((int)rd.Next(1, 5) == 2)
                       {
                          Audio.SEPlay("20b"); 
                       }
                       if ((int)rd.Next(1, 5) == 3)
                       {
                          Audio.SEPlay("20c");
                       }
                       if ((int)rd.Next(1, 5) == 4)
                       {
                          Audio.SEPlay("20d");
                       }
                        
                        Audio.SEPlay("09");
                        isEnemy2HitLand = false;
                        foreach (var hs in HitSHaders)
                        {
                            if(hs.Visible==false)
                            {
                                hs.Visible=true;
                                break;
                            }
                        }
                       // HitShader.Visible = true;
                        enemy1.Visible = false;
                        enemyKilledCount++;
                        foreach (var enemy2Killed in Enemy2Killed)
                        {

                            if (enemy2Killed.Visible == false)
                            {


                                // enemy1Killed.BackOffset = enemy1.BackOffset;




                                enemy2Killed.Visible = true;
                                //产生Killing动画
                                enemy2Killed.BackOffset = new Vector2(enemy1.BackOffset.X + 30, enemy1.BackOffset.Y + (enemy1.SourceTexture.Height - enemy2Killed.SourceTexture.Height) - 20);
                                enemy2Killed.Shader.BackOffset.Y = enemy1.BackOffset.Y + 10;
                                //  enemy1Killing();
                                break;
                            }

                        }

                    }
                    if (enemy1.BackOffset.X < -enemy1.SourceTexture.Width / 3)
                    {
                        enemyOverCount++;
                        enemy1.Visible = false;
                    }
                }
                //enemyKilledUpdate(enemy1);
            }
             EnemyPresent();
            if (loopCount <= maxloopCount)
            {

                if (loopCount > maxloopCount && BossShooting.Visible == false && Boss1Killed.Visible == false)
                {
                    Boss.Visible = true;
                    //Boss出现
                }
            }
        }
    }
}
                          
                  
