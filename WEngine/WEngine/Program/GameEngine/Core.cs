using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WEngine
{
    public class Core
    {
        GraphicsDeviceManager graphicsDeviceManager;
        ContentManager content;


        public Core(GraphicsDeviceManager gdm, ContentManager c)
        {

            content = c;

            graphicsDeviceManager = gdm;
            graphicsDeviceManager.PreferredBackBufferWidth = Prefs.WindowSizeW;
            graphicsDeviceManager.PreferredBackBufferHeight = Prefs.WindowSizeH;

        }

        public void Initialize(Game game, Type startScene)
        {
            Input.Initialize();
            CommonItem.Initialize(game, graphicsDeviceManager, content);
            
            Cache.Initialize(content);
            Graphics.Initialize();
            GotoScene(startScene);
        }

        public void Update()
        {
            Audio.Update();
            Input.Update();
            if (Input.Press(Keys.F11))
            {
                ToggleFullScreen();
            }
            CommonItem.Scene.Update();
        }

        public void Draw()
        {
            Graphics.Draw();
            
        }

        public void GotoScene(Type sceneType)
        {
            if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
            CommonItem.Scene = Activator.CreateInstance(sceneType) as Scene_Base;
        }

        void ToggleFullScreen()
        {
            Microsoft.Xna.Framework.Graphics.PresentationParameters presentation = CommonItem.GraphicsDevice.PresentationParameters;
            if(presentation.IsFullScreen)
            {    
                CommonItem.GraphicsDeviceManager.PreferredBackBufferWidth = Prefs.WindowSizeW;
                CommonItem.GraphicsDeviceManager.PreferredBackBufferHeight = Prefs.WindowSizeH;
                CommonItem.Game.Window.AllowUserResizing = false;
            }
            else
            {
                GraphicsAdapter adapter = CommonItem.GraphicsDeviceManager.GraphicsDevice.Adapter;
                CommonItem.GraphicsDeviceManager.PreferredBackBufferWidth = adapter.CurrentDisplayMode.Width;
                CommonItem.GraphicsDeviceManager.PreferredBackBufferHeight = adapter.CurrentDisplayMode.Height;
            }
            CommonItem.GraphicsDeviceManager.ToggleFullScreen();
        }

        void timerTick(object sender, EventArgs e)
        {
            //CommonItem.GameForm.Text = "SoulDebris     " + "Update: " + fpsCounterUpdate / 5 + ", Draw: " + fpsCounterDraw / 5;
            //fpsCounterDraw = fpsCounterUpdate = 0;
        }
    }
}
