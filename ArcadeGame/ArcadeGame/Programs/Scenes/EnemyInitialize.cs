using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArcadeGame.Programs.Sprites;
using Microsoft.Xna.Framework;
using WEngine;

namespace ArcadeGame.Programs.Scenes
{
    partial class Scene_Main
    {
        private void EnemyInitialize()
        {

            //敌人初始化
            for (int i = 0; i < 5; i++)
            {


                Sprite enemy1 = new Sprite("Enemy1", false, true, 5, Bus.SPX, 0, 3, 1);
                // enemy1.CurrentPositionX = 2;
                enemy1.BackOffset = new Vector2(Prefs.WindowSizeH, 560 - enemy1.SourceTexture.Height);
                enemy1.Shader = new Sprite_Base("Enemy1Shader");
                enemy1.Shader.Visible = false;
                enemy1.Shader.Z = 4;




                enemy1.CollisionRect = new Rectangle((int)enemy1.BackOffset.X,
                                                     (int)enemy1.BackOffset.Y + enemy1.SourceTexture.Height * 4 / 5,
                                                     2, enemy1.SourceTexture.Height / 5);

                enemy1.ShowingRect = enemy1.SourceRect(enemy1);
                enemy1.Z = enemy1.BackOffset.Y + 249;
                AddChild(enemy1);
                AddChild(enemy1.Shader);
                Enemy1.Add(enemy1);
            }

            for (int i = 0; i < 4; i++)
            {
                Sprite enemy1 = new Sprite("Enemy1", false, true, 6, Bus.SPX, 0, 3, 1);
                enemy1.Shader = new Sprite_Base("Enemy1Shader");
                enemy1.Shader.Visible = false;
                enemy1.Shader.Z = 4;

                // enemy1.CurrentPositionX = 2;

                enemy1.BackOffset = new Vector2(Prefs.WindowSizeH, 660 - enemy1.SourceTexture.Height);
                enemy1.CollisionRect = new Rectangle((int)enemy1.BackOffset.X,
                                                     (int)enemy1.BackOffset.Y + enemy1.SourceTexture.Height * 4 / 5,
                                                     2, enemy1.SourceTexture.Height / 5);
                AddChild(enemy1.Shader);
                enemy1.ShowingRect = enemy1.SourceRect(enemy1);
                enemy1.Z = enemy1.BackOffset.Y + 249;
                AddChild(enemy1);
                Enemy1.Add(enemy1);

            }
            for (int i = 0; i < 5; i++)
            {
                Sprite enemy2 = new Sprite("Enemy2", false, true, 5, Bus.SPX, 0, 3, 1);
                enemy2.Shader = new Sprite_Base("Enemy2Shader");
                enemy2.Shader.Visible = false;
                enemy2.Shader.Z = 5;


                enemy2.BackOffset = new Vector2(Prefs.WindowSizeH, 660 - enemy2.SourceTexture.Height);
                enemy2.CollisionRect = new Rectangle((int)enemy2.BackOffset.X,
                                                     (int)enemy2.BackOffset.Y + enemy2.SourceTexture.Height * 4 / 5,
                                                     2, enemy2.SourceTexture.Height / 5);

                enemy2.ShowingRect = enemy2.SourceRect(enemy2);
                enemy2.Z = enemy2.BackOffset.Y + 249;

                AddChild(enemy2);
                AddChild(enemy2.Shader);
                Enemy2.Add(enemy2);
            }
            for (int i = 0; i < 5; i++)
            {
                Sprite enemy2 = new Sprite("Enemy2", false, true, 4, Bus.SPX, 0, 3, 1);
                enemy2.Shader = new Sprite_Base("Enemy2Shader");
                enemy2.Shader.Visible = false;
                enemy2.Shader.Z = 4;

                enemy2.BackOffset = new Vector2(Prefs.WindowSizeH, 560 - enemy2.SourceTexture.Height);
                enemy2.CollisionRect = new Rectangle((int)enemy2.BackOffset.X,
                                                     (int)enemy2.BackOffset.Y + enemy2.SourceTexture.Height * 4 / 5,
                                                     2, enemy2.SourceTexture.Height / 5);
                enemy2.Z = enemy2.BackOffset.Y + 249;
                enemy2.ShowingRect = enemy2.SourceRect(enemy2);
                AddChild(enemy2);
                AddChild(enemy2.Shader);
                Enemy2.Add(enemy2);
            }

            //敌人Killed动画
            for (int i = 0; i < 12; i++)
            {
                Sprite enemy1Killed = new Sprite("enemy1Killed", false, false, 5, 3, 0, 2, 1);
                enemy1Killed.Shader = new Sprite_Base("Enemy1KilledShader");
                enemy1Killed.Shader.Visible = false;
                enemy1Killed.Shader.Z = 4;
                enemy1Killed.ShowingRect = enemy1Killed.SourceRect(enemy1Killed);
                AddChild(enemy1Killed);
                AddChild(enemy1Killed.Shader);
                Enemy1Killed.Add(enemy1Killed);

                Sprite enemy2Killed = new Sprite("enemy2Killed", false, false, 6, 3, 0, 2, 1);
                enemy2Killed.Shader = new Sprite_Base("Enemy2KilledShader");
                enemy2Killed.Shader.Visible = false;
                enemy2Killed.Shader.Z = 5;
                enemy2Killed.ShowingRect = enemy2Killed.SourceRect(enemy2Killed);
                AddChild(enemy2Killed);
                AddChild(enemy2Killed.Shader);
                Enemy2Killed.Add(enemy2Killed);
            }

           
        EnemyPositionY[0] =0; 
             EnemyPositionY[7] =Prefs.WindowSizeH - 528+310 + 27-250;
             EnemyPositionY[6] = Prefs.WindowSizeH - 528 + 310 + 2*27-250;
             EnemyPositionY[5] = Prefs.WindowSizeH - 528 + 310 + 3 * 27 - 250;
             EnemyPositionY[4] = Prefs.WindowSizeH - 528 + 310 + 4 * 27 - 250;
             EnemyPositionY[3] = Prefs.WindowSizeH - 528 + 310 + 5 * 27 - 250;
             EnemyPositionY[2] = Prefs.WindowSizeH - 528 + 310 + 6 * 27 - 250;
             EnemyPositionY[1] = Prefs.WindowSizeH - 528 + 310 + 7 * 27 - 250;
          
        }
    }
}
