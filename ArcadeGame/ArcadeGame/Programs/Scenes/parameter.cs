using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ArcadeGame.Programs.Scenes
{
   partial  class Scene_Main
    {

        public float HeroUpOrDownSP = 5f;//按上下键时主角上下移动速度
        public float HeroLeftSP = 10f;//按左键时主角向左移动的的速度
        public float HeroRightSP = 5f;//按右键时主角向右移动的速度
        public int theHeroFrame = 5;//主角动画的每帧显示时间

        public int theHeroDefenseFrame = 6;//主角防御状态的动画帧数
        public int theHeroDefenseShootedFrame = 6;//主角防御状态被打中时火花动画的帧数

        public int thebrokenframe = 3;//时间停止3时，窗口破碎每帧显示的时间
        public int theBulletFrame = 5;//子弹动画每帧显示的时间
        public int theBossTakeOutGunFrame = 6;//boss掏枪动作每帧显示的时间
        public int theBossAttackedFrame = 6;//boss被攻击时的动画帧数
        public int theLastExplodeFrame = 3;//最后大爆炸每帧显示的时间
        public float theRedShaerEnlargeSpeed = 0.8f;//红色背景扩大的速度
        public int theBossFrame = 2;//boss的每帧显示的时间
        public int theBossNiubilityTime = 50;//boss无敌时间
        public int[] HeroCollisionRect ={130,220,50,5};//正常情况下，主角的碰撞判断区域，相对于主角左上角
        public int[] BossCollisionRect ={27, 250, 230, 5};//正常情况下，Boss的碰撞判断区域，相对于Boss的左上角
        public int[] BossShoot1CollisionRect = { -300, 240, 500, 10 };//boss射击类型1的子弹碰撞区域，相对于子弹的左上角
        public int[] BossShoot2CollisionRect = { 0, 240, 500, 10 };//
    }
}
