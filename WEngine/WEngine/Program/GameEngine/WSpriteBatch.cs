using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WEngine
{
    public class WSpriteBatch
    {
        GraphicsDevice graphicsDevice;
        Matrix worldview;
        VertexPositionTexture[] vertexArray;
        Effect spriteEffect;
        //BasicEffect testEffect;

        Texture2D currentTexture;
        VertexBuffer vertexBuffer;

        public WSpriteBatch()
        {
            graphicsDevice = CommonItem.GraphicsDevice;

            Matrix world = Matrix.CreateWorld(Vector3.Zero, Vector3.Forward, Vector3.Up);
            Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, -1), new Vector3(0, 0, 1), Vector3.Down);
            Matrix projection = Matrix.CreateOrthographic(Prefs.WindowSizeW, Prefs.WindowSizeH, -2, 2);

            worldview = world * view * projection;
            

            List<VertexPositionTexture> vertexs = new List<VertexPositionTexture>();
            vertexs.Add(new VertexPositionTexture(new Vector3(0, 0, 0), new Vector2(0, 0)));
            vertexs.Add(new VertexPositionTexture(new Vector3(100, 100, 0), new Vector2(1, 1)));
            vertexs.Add(new VertexPositionTexture(new Vector3(0, 100, 0), new Vector2(0, 1)));
            vertexs.Add(new VertexPositionTexture(new Vector3(100, 100, 0), new Vector2(1, 1)));
            vertexs.Add(new VertexPositionTexture(new Vector3(0, 0, 0), new Vector2(0, 0)));
            vertexs.Add(new VertexPositionTexture(new Vector3(100, 0, 0), new Vector2(1, 0)));

            vertexArray = vertexs.ToArray();

            vertexBuffer = new VertexBuffer(CommonItem.GraphicsDevice, typeof(VertexPositionTexture), vertexArray.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionTexture>(vertexArray);
            spriteEffect = CommonItem.SpriteEffect;
            
            

            //testEffect = new BasicEffect(CommonItem.GraphicsDevice);
            //testEffect.World = world;
            //testEffect.View = view;
            //testEffect.Projection = projection;
            //testEffect.TextureEnabled = true;
            //testEffect.Texture = Cache.Texture("Rumia");
            
        }

        public void Begin()
        {

        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            //spriteEffect = CommonItem.SpriteEffect;
            //spriteEffect.CurrentTechnique = spriteEffect.Techniques["Normal"];
            //foreach (var i in spriteEffect.CurrentTechnique.Passes)
            //{
            //    i.Apply();
            //}
            //spriteEffect.Parameters["Alpha"].SetValue(1f);

            Matrix translation1 = Matrix.CreateTranslation(
                new Vector3(position.X + Prefs.WindowSizeW, position.Y + Prefs.WindowSizeH, 0));

            


            Matrix basicMatrix = worldview;
            basicMatrix *= translation1;

            spriteEffect.Parameters["WorldView"].SetValue(worldview);

            spriteEffect.Parameters["Tone"].SetValue(new Vector4(0f, 0f, 0f, 0f));
            foreach (var i in spriteEffect.CurrentTechnique.Passes)
            {
                i.Apply();
            }
            if (!texture.Equals(currentTexture))
            {
                spriteEffect.Parameters["SpriteTexture"].SetValue(texture);

                vertexArray[1].Position.X
                     = vertexArray[3].Position.X
                     = vertexArray[5].Position.X
                     = texture.Width;

                vertexArray[1].Position.Y
                     = vertexArray[2].Position.Y
                     = vertexArray[3].Position.Y
                     = texture.Height;
                
                //vertexBuffer = new VertexBuffer(CommonItem.GraphicsDevice, typeof(VertexPositionTexture), vertexArray.Length, BufferUsage.None);
                vertexBuffer.SetData<VertexPositionTexture>(vertexArray, 0, vertexArray.Length);
                
                currentTexture = texture;
            }


            CommonItem.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            for (int i = 0; i < 50; i++ )
                CommonItem.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);

            //graphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vertexArray, 0, 2);

        }

        public void End()
        {

        }
    }
}
