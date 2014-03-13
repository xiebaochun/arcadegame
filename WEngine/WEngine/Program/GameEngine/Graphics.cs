using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WEngine
{
    public static class Graphics
    {
        static SpriteBatch basicBatch;

        static bool locked = false;


        public static void Initialize()
        {
            basicBatch = CommonItem.BasicBatch ;


        }

        public static void Update()
        {
        }

        public static void Draw()
        {



            if (!locked)
            {
                CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques["AlphaBlend"];
                basicBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, CommonItem.SpriteEffect);
                CommonItem.Scene.Draw();
                basicBatch.End();
            } 
            //CommonItem.GraphicsDevice.Clear(Color.Transparent);
            //basicBatch.Begin();
            //basicBatch.Draw(scene.Render, new Rectangle(
            //    0, 0, CommonItem.GraphicsDeviceManager.PreferredBackBufferWidth, CommonItem.GraphicsDeviceManager.PreferredBackBufferHeight), Color.White);
            //basicBatch.End();


            
            //batch.Draw(textures[0], Vector2.Zero, Color.White);

        }

        public static void Lock()
        {
            locked = true;
        }

        public static void UnLock()
        {
            locked = false;
        }

        public static void TransitionIn()
        {

        }

        public static void TransitionOut()
        {

        }

        

    }


}
