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
        public void EnemyPresent()
        {
            if (loopCount <= 55)
            {
                if (enemySp >= 180)
                {
                    if (enemySp == 200)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[2]);
                           
                        }
                        Enemy1[0].Visible = true;
                    }
                    if (enemySp == 240)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 360)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 420)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 540)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    if (enemySp == 600)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[6]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    if (enemySp == 660)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[5]);
                        }
                        Enemy1[3].Visible = true;

                    }
                    if (enemySp == 720)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy2[3].Visible = true;


                    }
                    if (enemySp == 780)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[6]);
                            Enemy1[0].Visible = true;
                        }
                    }
                    if (enemySp == 840)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 900)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 960)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 1020)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[2]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    //if (enemySp == 1090)
                    //{
                    //    if (Enemy2[2].Visible == false)
                    //    {
                    //        Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                    //        EnemyPositionY[1]);
                    //    }
                    //    Enemy2[2].Visible = true;

                    //}
                    //加点配置！
                    if (enemySp == 1100)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[2]);
                        }
                        Enemy1[3].Visible = true;

                    }
                    if (enemySp == 1110)
                    {
                        if (Enemy1[4].Visible == false)
                        {
                            Enemy1[4].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[3]);
                        }
                        Enemy1[4].Visible = true;

                    }
                    if (enemySp == 1120)
                    {
                        if (Enemy1[5].Visible == false)
                        {
                            Enemy1[5].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[4]);
                        }
                        Enemy1[5].Visible = true;

                    }
                    if (enemySp == 1130)
                    {
                        if (Enemy1[6].Visible == false)
                        {
                            Enemy1[6].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[5]);
                        }
                        Enemy1[6].Visible = true;

                    }
                   
                    //if (enemySp == 1200)
                    //{
                    //    if (Enemy1[3].Visible == false)
                    //    {
                    //        Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                    //         EnemyPositionY[5]);
                    //    }
                    //    Enemy1[3].Visible = true;

                    //}
                    if (enemySp == 1330)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy2[3].Visible = true;


                    }
                    if (enemySp == 1340)
                    {
                        if (Enemy2[4].Visible == false)
                        {
                            Enemy2[4].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[4].Visible = true;


                    }
                   
                    if (enemySp == 1350)
                    {
                        if (Enemy2[6].Visible == false)
                        {
                            Enemy2[6].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[5]);
                        }
                        Enemy2[6].Visible = true;


                    }
                    if (enemySp == 1360)
                    {
                        if (Enemy2[7].Visible == false)
                        {
                            Enemy2[7].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy2[7].Visible = true;


                    }
                    if (enemySp == 1370)
                    {
                        if (Enemy2[8].Visible == false)
                        {
                            Enemy2[8].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[8].Visible = true;


                    }
                    
                    //if (enemySp >= 1440)
                    //{
                    //    if (Enemy1[0].Visible == false)
                    //    {
                    //        Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                    //        EnemyPositionY[3]);
                    //        Enemy1[0].Visible = true;
                    //    }
                    //}
                 
                    if (enemySp == 1480)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 1660)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 1720)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    if (enemySp == 1780)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[3]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    if (enemySp == 1840)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy1[3].Visible = true;

                    }
                    if (enemySp == 1990)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy2[3].Visible = true;


                    }

                    if (enemySp == 2100)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[1]);
                            Enemy1[0].Visible = true;
                        }
                    }
                    if (enemySp == 2160)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 2340)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 2400)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 2440)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    //////////////////////////
                    if (enemySp == 2520)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[1]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    if (enemySp == 2530)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[2]);
                        }
                        Enemy2[3].Visible = true;

                    }
                    if (enemySp == 2540)
                    {
                        if (Enemy2[4].Visible == false)
                        {
                            Enemy2[4].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[3]);
                        }
                        Enemy2[4].Visible = true;

                    }
                    if (enemySp == 2550)
                    {
                        if (Enemy2[5].Visible == false)
                        {
                            Enemy2[5].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[4]);
                        }
                        Enemy2[5].Visible = true;

                    }
                    if (enemySp == 2560)
                    {
                        if (Enemy2[4].Visible == false)
                        {
                            Enemy2[4].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[5]);
                        }
                        Enemy2[4].Visible = true;

                    }
                    if (enemySp == 2570)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[3].Visible = true;


                    }
                    if (enemySp == 2840)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[3]);
                            Enemy1[0].Visible = true;
                        }
                    }
                    if (enemySp == 2900)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    ///////////////////////////////////////////////////
                    if (enemySp == 2960)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 2970)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy1[2].Visible = true;
                    }
                    if (enemySp == 2980)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[5]);
                        }
                        Enemy1[3].Visible = true;
                    }
                    if (enemySp == 2990)
                    {
                        if (Enemy1[4].Visible == false)
                        {
                            Enemy1[4].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy1[4].Visible = true;
                    }
                    if (enemySp == 3000)
                    {
                        if (Enemy1[5].Visible == false)
                        {
                            Enemy1[5].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy1[5].Visible = true;
                    }
                   
                    //if (enemySp == 3080)
                    //{
                    //    if (Enemy1[2].Visible == false)
                    //    {
                    //        Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                    //         EnemyPositionY[7]);
                    //    }
                    //    Enemy1[2].Visible = true;

                    //}
                    if (enemySp == 3140)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[6]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    //if (enemySp == 3220)
                    //{
                    //    if (Enemy1[3].Visible == false)
                    //    {
                    //        Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                    //         EnemyPositionY[1]);
                    //    }
                    //    Enemy1[3].Visible = true;

                    //}
                    if (enemySp == 3280)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy2[3].Visible = true;


                    }
                 
                    if (enemySp == 3480)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 3540)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 3640)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 3740)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[2]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    if (enemySp == 3860)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[3]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    if (enemySp == 3960)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy1[3].Visible = true;

                    }
                    if (enemySp == 4020)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy2[3].Visible = true;


                    }

                    if (enemySp == 4120)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[4]);
                            Enemy1[0].Visible = true;
                        }
                    }
                    if (enemySp == 4300)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 4360)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 4420)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[5]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 4480)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[4]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    if (enemySp == 4540)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[6]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    if (enemySp == 4640)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy1[3].Visible = true;

                    }
                    if (enemySp == 4840)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[3].Visible = true;


                    }
                    if (enemySp == 4900)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[2]);
                            Enemy1[0].Visible = true;
                        }
                    }
                    if (enemySp == 4960)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[1]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 5020)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[7]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 5120)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 5220)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[1]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    if (enemySp == 5400)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[7]);
                        }
                        Enemy2[2].Visible = true;

                    }
                    if (enemySp == 5500)
                    {
                        if (Enemy1[3].Visible == false)
                        {
                            Enemy1[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy1[3].Visible = true;

                    }
                    if (enemySp == 5700)
                    {
                        if (Enemy2[3].Visible == false)
                        {
                            Enemy2[3].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[3].Visible = true;


                    }

                    if (enemySp == 5900)
                    {
                        if (Enemy1[0].Visible == false)
                        {
                            Enemy1[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[1]);
                            Enemy1[0].Visible = true;
                        }
                    }
                    if (enemySp == 6000)
                    {
                        if (Enemy2[0].Visible == false)
                        {
                            Enemy2[0].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[2]);
                        }
                        Enemy2[0].Visible = true;
                    }
                    if (enemySp == 6100)
                    {
                        if (Enemy1[1].Visible == false)
                        {
                            Enemy1[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[3]);
                        }
                        Enemy1[1].Visible = true;
                    }
                    if (enemySp == 6200)
                    {
                        if (Enemy2[1].Visible == false)
                        {
                            Enemy2[1].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy2[1].Visible = true;
                    }
                    if (enemySp == 6400)
                    {
                        if (Enemy1[2].Visible == false)
                        {
                            Enemy1[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                             EnemyPositionY[6]);
                        }
                        Enemy1[2].Visible = true;

                    }
                    if (enemySp == 6800)
                    {
                        if (Enemy2[2].Visible == false)
                        {
                            Enemy2[2].BackOffset = new Vector2(Prefs.WindowSizeW,
                            EnemyPositionY[1]);
                        }
                        Enemy2[2].Visible = true;
                        enemySp = 0;
                    }

                }//77个

            }
        }
    }
                   
}
                            
                
