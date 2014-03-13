using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

namespace WEngine
{
    public static class Prefs
    {
        //套装选择
        public static int Theme = 1;
        public static int GameSizeW = 1280;
        public static int GameSizeH = 720;
        public static Vector2 GameSize = new Vector2(GameSizeW, GameSizeH);
        public static Vector2 GameSizeHalf = GameSize / 2;
        public static int WindowSizeW = 1280;
        //public static int WindowSizeW =800;

        public static int WindowSizeH = 720;
      

        public static int FrameRate = 60;

        public static void Initialize(
            int gameWidth = 1280,
            int gameHeight = 720,
            int windowWidth = 1280,
            int windowHeight = 720,
            int frameRate = 60
            )
        {
            GameSizeW = gameWidth;
            GameSizeH = gameHeight;
            GameSize = new Vector2(GameSizeW, GameSizeH);
            GameSizeHalf = GameSize / 2;
            WindowSizeW = windowWidth;
            WindowSizeH = windowHeight;
            CommonItem.Game.TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 1000 / frameRate);


        }
    }
}
