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
        private void BossInitialize()
        {

            Boss = new Sprite("Boss_000", false,true, 5, 1, 0.3f, 3, 1);
            Boss.ShowingRect = Boss.SourceRect(Boss);
            Boss.HP = 1000;
            Boss.BackOffset = new Vector2(Prefs.WindowSizeW, Prefs.WindowSizeH - Boss.SourceTexture.Height);
            Boss.Shader = new Sprite_Base("BossShader");
            
            Boss.Shader.Visible = false;
            Boss.Shader.Z = 4;
            Boss.Shader.BackOffset = Boss.BackOffset;
            Boss.CollisionRect = new Rectangle((int)Boss.BackOffset.X + 27, (int)(Boss.BackOffset.Y + 27), 245, 222);
            AddChild(Boss);
            AddChild(Boss.Shader);
            for (int i = 0; i <= 9; i++)
            {

                Sprite timeStopBullet = new Sprite("timeStopBullet", false, true, 6, 15, 0, 4, 2);
                timeStopBullet.ShowingRect = timeStopBullet.SourceRect(timeStopBullet);
                AddChild(timeStopBullet);
                timeStopBullets.Add(timeStopBullet);
            }


            BossPortrait_01 = new Sprite("BossPortrait_01", true, true, 1000, 0, 0, 1, 1);
            BossPortrait_01.BackOffset = new Vector2(20, Prefs.WindowSizeH - 100);
            AddChild(BossPortrait_01);

            BossPortrait_02 = new Sprite("BossPortrait_02", true, true, 1000, 0, 0, 1, 1);
            BossPortrait_02.BackOffset = new Vector2(20, Prefs.WindowSizeH - 50);
            AddChild(BossPortrait_02);

            BossHP_01 = new Sprite("BossHP_01", true, true, 999, 0, 0, 1, 1);
            BossHP_01.BackOffset = new Vector2(130, Prefs.WindowSizeH - 70);
            AddChild(BossHP_01);

            BossHP_02 = new Sprite("BossHP_02", true, true, 998, 0, 0, 1, 1);
            BossHP_02.BackOffset = new Vector2(130, Prefs.WindowSizeH - 70);
            AddChild(BossHP_02);

            BossName_01 = new Sprite("BossName_01", true, true, 1000, 0, 0, 1, 1);
            BossName_01.BackOffset = new Vector2(60, Prefs.WindowSizeH - 90);
            AddChild(BossName_01);

            BossName_02 = new Sprite("BossName_02", true, true, 1000, 0, 0, 1, 1);
            BossName_02.BackOffset = new Vector2(60, Prefs.WindowSizeH - 40);
            AddChild(BossName_02);

            littleRedShader = new Sprite("littleRedShader", false, false, 4, 0, 0, 1, 1);
            littleRedShader.Origin = new Vector2(littleRedShader.SourceTexture.Width, littleRedShader.SourceTexture.Height) / 2;
            littleRedShader.Scale = 0.01f;
            AddChild(littleRedShader);

            timeStop3 = new Sprite("timeStop3", false, false, 5, 0, 0, 3, 4);
            timeStop3.ShowingRect = timeStop3.SourceRect(timeStop3);
            AddChild(timeStop3);

            mountain = new Sprite("mountain", false, true, 4, 0, 0, 1, 1);
            mountain.BackOffset.Y = -mountain.SourceTexture.Height;
           
            mountain.ShowingRect = mountain.SourceRect(mountain);
            AddChild(mountain);

            BossShooting = new Sprite("BossShooting", false,true, 5, Boss.SPX, Boss.SPY,2,5);
            BossShooting.ShowingRect = BossShooting.SourceRect(BossShooting);
            BossShooting.Shader = new Sprite_Base("BossShader");
            BossShooting.Shader.Visible = false;
            BossShooting.Shader.BackOffset = BossShooting.BackOffset;
            BossShooting.Shader.Z = 4;
            AddChild(BossShooting);
            AddChild(BossShooting.Shader);

            explode = new Sprite("Explode", false, true, 900, 0, 0, 7, 4);
            explode.ShowingRect = explode.SourceRect(explode);
            AddChild(explode);
            explode2 = new Sprite("Explode", false, true, 900, 0, 0, 7, 4);
            explode2.ShowingRect = explode2.SourceRect(explode2);
            AddChild(explode2);

            LastExplode1= new Sprite("LastExplode1", false,false, 900, 0, 0, 2, 3);
            LastExplode2 = new Sprite("LastExplode2", false, true, 900, 0, 0, 2, 3);
            GoToCenter(LastExplode1);
            GoToCenter(LastExplode2);
            LastExplode1.ShowingRect = LastExplode1.SourceRect(LastExplode1);
            LastExplode2.ShowingRect = LastExplode2.SourceRect(LastExplode2);
            AddChild(LastExplode1);
            AddChild(LastExplode2);

            Boss1Killed = new Sprite("Boss1Killed", false, false, 5, 0, 0, 3, 1);
            Boss1Killed.sourceRect = Boss1Killed.SourceRect(Boss1Killed);
            Boss1Killed.Shader = new Sprite_Base("Boss1KilledShader");
            Boss1Killed.Shader.Visible = false;
            Boss1Killed.Shader.Z = 4;
            AddChild(Boss1Killed);
            AddChild(Boss1Killed.Shader);

            Boss2Killed = new Sprite("Boss2Killed", false, false, 5, 0, 0, 3, 1);
            Boss2Killed.sourceRect = Boss2Killed.SourceRect(Boss2Killed);
            Boss2Killed.Shader = new Sprite_Base("Boss1KilledShader");
            Boss2Killed.Shader.Visible = false;
            Boss2Killed.Shader.Z = 4;
            AddChild(Boss2Killed);
            AddChild(Boss2Killed.Shader);

            BossKilled = new Sprite("BossKilled", false, true, 5, 0, 0, 1, 1);
            BossKilled.sourceRect = BossKilled.SourceRect(BossKilled);

            BossKilled.Shader = new Sprite_Base("BossKilledShader");
            BossKilled.Shader.Visible = false;
            BossKilled.Shader.Z = 3;
            AddChild(BossKilled);
            AddChild(BossKilled.Shader);

            BossAttacked = new Sprite("BossAttacked", false, false, 5, 0, 0, 3, 1);
            BossAttacked.ShowingRect = BossAttacked.SourceRect(BossAttacked);
            AddChild(BossAttacked);

            //AfterShooting = new Sprite("AfterShooting", false, false, 5, 0, 0, 3, 2);
            //AddChild(AfterShooting);

            TakeOutGun = new Sprite("TakeOutGun", false, false, 5, 0, 0, 1, 1);
            TakeOutGun.ShowingRect = TakeOutGun.SourceRect(TakeOutGun);
            AddChild(TakeOutGun);

            BossShoot1 = new Sprite("Shoot1", false, false, 900, 0, 0, 3, 1);
            BossShoot2 = new Sprite("Shoot2", false, false, 900, 0, 0, 2, 2);
            BossShoot3 = new Sprite("Shoot3", false, false, 900, 0, 0, 2, 3);
            BossShoot4 = new Sprite("Shoot4", false, false, 900, 0, 0, 2, 3);
            BossShoot5 = new Sprite("Shoot5", false, false, 900, 0, 0, 2, 3);
            BossShoot6 = new Sprite("Shoot6", false, false, 900, 0, 0, 2, 2);
            BossShoot1.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 139), (int)BossShooting.BackOffset.Y - 130);
            BossShoot2.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 478), (int)BossShooting.BackOffset.Y + 65);
            BossShoot3.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 643), (int)BossShooting.BackOffset.Y - 51);
            BossShoot4.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 635), (int)BossShooting.BackOffset.Y - 28);
            BossShoot5.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 635), (int)BossShooting.BackOffset.Y - 28);
            BossShoot6.BackOffset = new Vector2((int)(BossShooting.BackOffset.X - 632), (int)BossShooting.BackOffset.Y - 17);
            AddChild(BossShoot1);
            AddChild(BossShoot2);
            AddChild(BossShoot3);
            AddChild(BossShoot4);
            AddChild(BossShoot5);
            AddChild(BossShoot6);

        }

        
    }
}
