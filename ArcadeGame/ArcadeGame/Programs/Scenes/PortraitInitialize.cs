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
        Sprite Boss1Portrait_01;
        Sprite Boss1Portrait_02;
        Sprite Boss1Portrait_03;
        Sprite Boss2Portrait_01;
        Sprite Boss2Portrait_02;
        Sprite Boss2Portrait_03;
        Sprite HeroTalkPortrait_01;
        Sprite HeroTalkPortrait_02;
        Sprite HeroTalkPortrait_03;
        Sprite npc1Portrait;
        Sprite npc2Portrait;
        Sprite  MixBossPortrait_03;
        Sprite Cursor;
        
        private void PortraitInitialize()
        {
            BackToHitBoss = new Sprite("BackToHitBoss", false, false, 5, 0, 0, 1, 1);
            GoToCenter(BackToHitBoss);
            BackToHitBoss.BackOffset.Y += 20;
            AddChild(BackToHitBoss);

            BackToRestart = new Sprite("BackToRestart", false, false, 5, 0, 0, 1, 1);
            GoToCenter(BackToRestart);
            BackToRestart.BackOffset.Y += 100;
            AddChild(BackToRestart);

            Boss1Portrait_01 = new Sprite("Boss1Portrait_01", false, false, 1000, 0, 0, 1, 1);
            Boss1Portrait_01.BackOffset = CommonItem.PortraitPosition;
            AddChild(Boss1Portrait_01);

            Boss1Portrait_02 = new Sprite("Boss1Portrait_02", false, false, 1000, 0, 0, 1, 1);
            Boss1Portrait_02.BackOffset = CommonItem.PortraitPosition;
            AddChild(Boss1Portrait_02);

            Boss1Portrait_03 = new Sprite("Boss1Portrait_03", false, false, 1000, 0, 0, 1, 1);
            Boss1Portrait_03.BackOffset = CommonItem.PortraitPosition;
            AddChild(Boss1Portrait_03);

            Boss2Portrait_01 = new Sprite("Boss2Portrait_01", false, false, 1000, 0, 0, 1, 1);
            Boss2Portrait_01.BackOffset = CommonItem.PortraitPosition;
            AddChild(Boss2Portrait_01);

            Boss2Portrait_02 = new Sprite("Boss2Portrait_02", false, false, 1000, 0, 0, 1, 1);
            Boss2Portrait_02.BackOffset = CommonItem.PortraitPosition;
            AddChild(Boss2Portrait_02);

            Boss2Portrait_03 = new Sprite("Boss2Portrait_03", false, false, 1000, 0, 0, 1, 1);
            Boss2Portrait_03.BackOffset = CommonItem.PortraitPosition;
            AddChild(Boss2Portrait_03);

            Cursor = new Sprite("Cursor", false, false, 5, 0, 0, 1, 1);
            GoToCenter(Cursor);
            Cursor.BackOffset += new Vector2(-200, 20);
            AddChild(Cursor);

            TalkBackGround = new Sprite("TalkBackGround", false, false, 1000, 0, 0, 1, 1);
            TalkBackGround.BackOffset = new Vector2(400, 520);
            AddChild(TalkBackGround);

            Continue = new Sprite("Continue", false, true, 1001, 0, 0, 16, 1);
            Continue.BackOffset = new Vector2(1130, 660);
            AddChild(Continue);

            TalkBox = new Sprite_TextBox(750, 600);
            TalkBox.Position = new Vector2(420, 600);
            TalkBox.Color = Color.White;
            TalkBox.Visible = false;
            TalkBox.Z = 1001;
            TalkBox.FontSize = 16;
            AddChild(TalkBox);

            MixBossPortrait_01 = new Sprite("MixBossPortrait_01", false, false, 1000, 0, 0, 1, 1);
            MixBossPortrait_01.BackOffset = CommonItem.PortraitPosition;
            AddChild(MixBossPortrait_01);

            MixBossPortrait_03 = new Sprite("MixBossPortrait_03", false, false, 1000, 0, 0, 1, 1);
            MixBossPortrait_03.BackOffset = CommonItem.PortraitPosition;
            AddChild(MixBossPortrait_03);

            HeroTalkPortrait_01 = new Sprite("HeroTalkPortrait_01", false, false, 1000, 0, 0, 1, 1);
            HeroTalkPortrait_01.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_01);


            HeroTalkPortrait_02 = new Sprite("HeroTalkPortrait_02", false, false, 1000, 0, 0, 1, 1);
            HeroTalkPortrait_02.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_02);

            HeroTalkPortrait_03 = new Sprite("HeroTalkPortrait_03", false, false, 1000, 0, 0, 1, 1);
            HeroTalkPortrait_03.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_03);

            npc1Portrait = new Sprite("npc1Portrait", false, true, 1000, 0, 0, 1, 1);
            npc1Portrait.BackOffset = CommonItem.PortraitPosition;
            AddChild(npc1Portrait);

            npc2Portrait = new Sprite("npc2Portrait", false, true, 1000, 0, 0, 1, 1);
            npc2Portrait.BackOffset = CommonItem.PortraitPosition;
            AddChild(npc2Portrait);

            zhaoshibiao = new Sprite("zhaoshibiao", false, false, 2000, 2, 0, 1, 1);
            AddChild(zhaoshibiao);
        }
    }
}