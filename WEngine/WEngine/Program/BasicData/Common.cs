using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace WEngine
{
    public static class CommonItem
    {
        public static Game Game;
        public static Boolean isPalyed = false;
        public  static Vector2 PortraitPosition = new Vector2(100, 400);
        public static GraphicsDeviceManager GraphicsDeviceManager;
        public static GraphicsDevice GraphicsDevice;
        public static SpriteBatch BasicBatch;
        public static ContentManager Content;

        public static Effect SpriteEffect;
        public static Effect ScreenEffect;
        public static Effect ParticleEffect;
        public static Effect TestEffect;

        public static Scene_Base Scene;

        //public static ButtonState gamePadButtonState_Up;
        //public static ButtonState preGamePadButtonState_Up;
        //public static ButtonState gamePadButtonState_Down;
        //public static ButtonState preGamePadButtonState_Down;
        //public static ButtonState gamePadButtonState_left;
        //public static ButtonState preGamePadButtonState_Left;
        //public static ButtonState gamePadButtonState_Right;
        //public static ButtonState preGamePadButtonState_Right;
        //public static ButtonState gamePadButtonState_A;
        //public static ButtonState preGamePadButtonState_A;
        //public static ButtonState gamePadButtonState_B;
        //public static ButtonState preGamePadButtonState_B;
        //public static ButtonState gamePadButtonState_Start;
        //public static ButtonState preGamePadButtonState_Start;
        public static GamePadState gamePadState;
        public static GamePadState preGamePadState;

       
        public static Form GameForm;

        public static void Initialize(Game game, GraphicsDeviceManager gdm, ContentManager content)
        {
            Game = game;
            GameForm = Form.FromHandle(game.Window.Handle) as Form;
            GraphicsDeviceManager = gdm;
            GraphicsDevice = gdm.GraphicsDevice;
            BasicBatch = new SpriteBatch(GraphicsDevice);
            Content = content;
            SpriteEffect = content.Load<Effect>(@"GameContent/Effects/SpriteEffect");


            SamplerState ss = new SamplerState();
            ss.AddressU = TextureAddressMode.Clamp;
            ss.AddressV = TextureAddressMode.Clamp;
            ss.AddressW = TextureAddressMode.Clamp;
            GraphicsDevice.SamplerStates[0] = ss;

           
        }
    }
}