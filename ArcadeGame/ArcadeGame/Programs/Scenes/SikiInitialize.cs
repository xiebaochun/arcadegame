using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArcadeGame.Programs.Sprites;
using Microsoft.Xna.Framework;
using WEngine;

namespace ArcadeGame.Programs.Scenes
{
    partial class  Scene_Main
    {
       private  void  SikiInitialize()
       {
           Siki = new Sprite("Siki", false, true, 5, 0, 0, 1, 1);
           //if (Prefs.Theme == 1)
           //{
               SikiAttack = new Sprite("SikiAttack1", false, false, 5, 0, 0, 2, 1);
               SikiAttack2 = new Sprite("SikiAttack2", false, false, 5, 0, 0, 2, 1);
           //}
           //else
           //{
           //    SikiAttack = new Sprite("SikiAttack1_T2", false, false, 5, 0, 0, 2, 1);
           //    SikiAttack2 = new Sprite("SikiAttack2_T2", false, false, 5, 0, 0, 2, 1);
           //}
          
           HeroAttackSkill1 = new Sprite("HeroAttackSkill_001", false, false, 5, 0, 0, 3, 2);
           HeroAttackSkill2 = new Sprite("HeroAttackSkill_002", false, false, 5, 0, 0, 3, 2);
           SikiAttackSkillEffect1 = new Sprite("SikiAttackSkillEffect1", false, true, (int)(HeroHighRunning.Z+1), 0, 0, 1, 6);
           SikiAttackSkillEffect2 = new Sprite("SikiAttackSkillEffect2", false, false, (int)(HeroHighRunning.Z + 1), 0, 0, 1, 4);
           SikiAttackSkillEffect1.SPX = 20;
           SikiAttackSkillEffect1.Alpha = 0.5f;
           SikiAttackSkillEffect2.Alpha = 0.5f;
           SikiAttackSkillEffect1.BackOffset.X = Hero.BackOffset.X + 220;
           SikiAttackSkillEffect1.BackOffset.Y = Hero.BackOffset.Y + 20;
           SikiAttackSkillEffect2.BackOffset = Hero.BackOffset;
           SikiAttackSkillEffect1.ShowingRect = SikiAttackSkillEffect1.SourceRect(SikiAttackSkillEffect1);
           SikiAttackSkillEffect2.ShowingRect = SikiAttackSkillEffect2.SourceRect(SikiAttackSkillEffect2);
           AddChild(SikiAttackSkillEffect1);
           AddChild(SikiAttackSkillEffect2);
         
           Siki.BackOffset.X = Hero.BackOffset.X - 40;
           Siki.BackOffset.Y = Hero.BackOffset.Y;
           Siki.Z = Hero.Z - 1;
           SikiAttack.BackOffset = Siki.BackOffset;
           SikiAttack.sourceRect = SikiAttack.SourceRect(SikiAttack);
           HeroAttackSkill1.BackOffset.X = Siki.BackOffset.X - 24;
           HeroAttackSkill2.BackOffset.X = Siki.BackOffset.X - 30;
           HeroAttackSkill1.BackOffset.Y = Siki.BackOffset.Y + 40;
           HeroAttackSkill2.BackOffset.Y = Siki.BackOffset.Y - 200;
           Siki.ShowingRect = Siki.SourceRect(Siki);
           SikiAttack.ShowingRect = Siki.SourceRect(SikiAttack);
           HeroAttackSkill1.ShowingRect = HeroAttackSkill1.SourceRect(HeroAttackSkill1);
           HeroAttackSkill2.ShowingRect = HeroAttackSkill2.SourceRect(HeroAttackSkill2);

           AddChild(Siki);
           AddChild(SikiAttack);
           AddChild(SikiAttack2);
           AddChild(HeroAttackSkill1);
           AddChild(HeroAttackSkill2);

           HeroDefense = new Sprite("HeroDefense", false, false, 5, 0, 0, 1, 3);
          // HeroDefense.BackOffset = Siki.BackOffset;
           HeroDefense.ShowingRect = HeroDefense.SourceRect(HeroDefense);
           AddChild(HeroDefense);

           xinyue = new Sprite("xinyue", false, true, 5, 30, 0, 2, 2);
           xinyue.Alpha = 0.7f;
           xinyue.ShowingRect = xinyue.SourceRect(xinyue);
           AddChild(xinyue);

           Fire = new Sprite("fire", false, true, 5, 30, 0, 3, 2);
           Fire.Alpha = 0.8f;
           Fire.ShowingRect = Fire.SourceRect(Fire);
           AddChild(Fire);

           Fire_fire = new Sprite("fire_fire", false, false, 5, 0, 0, 10, 7);
           Fire_fire.Alpha = 0.8f;
           Fire_fire.ShowingRect = Fire_fire.SourceRect(Fire_fire);
           AddChild(Fire_fire);

           generateElectric = new Sprite("generateElectric", false, false, 5, 5, 0, 3, 2);
           generateElectric.Alpha = 0.8f;
           generateElectric.ShowingRect = generateElectric.SourceRect(generateElectric);
           AddChild(generateElectric);

           Electric = new Sprite("Electric", false, true, 5, 10, 0, 3, 2);
           Electric.Alpha = 0.8f;
           Electric.ShowingRect = Electric.SourceRect(Electric);
           AddChild(Electric);

           reduceElectric = new Sprite("reduceElectric", false, false, 5, 5, 0, 2, 2);
           reduceElectric.Alpha = 0.8f;
           reduceElectric.ShowingRect = reduceElectric.SourceRect(reduceElectric);
           AddChild(reduceElectric);

           Electric_fire = new Sprite("Electric_fire", false, false, 5, 0, 0, 6, 5);
           Electric_fire.Alpha = 0.8f;
           Electric_fire.ShowingRect = Electric_fire.SourceRect(Electric_fire);
           AddChild(Electric_fire);

           lianxuzhan = new Sprite("lianxuzhan", false, true, 6, 0, 0, 3, 2);
           lianxuzhan.ShowingRect = lianxuzhan.SourceRect(lianxuzhan);
           AddChild(lianxuzhan);

           generateAnger = new Sprite("generateAnger", false, false, 5, 0, 0, 3, 1);
           generateAnger.ShowingRect = generateAnger.SourceRect(generateAnger);
           generateAnger.Alpha = 0.5f;
           AddChild(generateAnger);

           AngerLoop = new Sprite("AngerLoop", false, true, 5, 0, 0, 3, 2);
           AngerLoop.ShowingRect = AngerLoop.SourceRect(AngerLoop);
           AngerLoop.Alpha = 0.5f;
           AddChild(AngerLoop);

           reduceAnger = new Sprite("reduceAnger", false, false, 5, 0, 0, 3, 1);
           reduceAnger.ShowingRect = reduceAnger.SourceRect(reduceAnger);
           reduceAnger.Alpha = 0.5f;
           reduceAnger.BackOffset = new Vector2(Hero.BackOffset.X - 38, Hero.BackOffset.Y - 218);
           AddChild(reduceAnger);
       }
    }
}
