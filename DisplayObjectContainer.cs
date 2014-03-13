using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WEngine
{
    public class DisplayObjectContainer
    {
        public bool Visible = true;
        public bool DrawSelf = false;
        

        public float _z = 1;


        public float Z{
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                if (Parent != null) Parent.sortChilds();
            }
        }
        
        //public SpriteEffectParas EffectParas = new SpriteEffectParas();

        public BlendState BasicBlendState = BlendState.AlphaBlend;
        

        public DisplayObjectContainer Parent = null;
        public List<DisplayObjectContainer> Childs = new List<DisplayObjectContainer>();
        //public RenderTarget2D Render;
        public Texture2D SourceTexture;

        public Vector2 Position = Vector2.Zero;
        float _alpha = 1f;
        public float Alpha
        {
            get
            {
                return _alpha;
            }

            set
            {
                _alpha = value;
                if (_alpha > 1f) _alpha = 1f;
                if (_alpha < 0f) _alpha = 0f;
            }
        }
        public float Rotation = 0f;
        public float Scale = 1f;
        
        public Vector2 ScreenPosition
        {
            get
            {
                if (Parent == null) return Position;
                else return Parent.ScreenPosition + this.Position;
            }
        }
        public float ScreenAlpha
        {
            get
            {
                if (Parent == null) return Alpha;
                else return Parent.ScreenAlpha * this.Alpha;
            }
        }

        public Vector2 BackOffset = Vector2.Zero;


        public CoordPositionMode OriginType = CoordPositionMode.Normal;
        Vector2 _origin;
        public Vector2 Origin
        {
            get
            {
                switch (OriginType)
                {
                    case CoordPositionMode.Normal:
                        return Vector2.Zero;
                    case CoordPositionMode.Center:
                        return new Vector2(SourceTexture.Width, SourceTexture.Height) / 2;
                    case CoordPositionMode.Foot:
                        //return new Vector2(Render.Width / 2, Render.Height);
                        return new Vector2(SourceTexture.Width / 2, SourceTexture.Height);
                    case CoordPositionMode.Other:
                        return _origin;
                        
                }
                return Vector2.Zero;
            }

            set
            {
                OriginType = CoordPositionMode.Other;
                _origin = value;
            }
            
        }

        
        public Rectangle? ShowingRect = null;

        public Vector2 RedShadowPosition;
        public float RedShadowRadius;
        enum RedShadowType
        {
            Invisible,
            Expanding,
            Visible,
            Retracting
        }
        RedShadowType redShadowType = RedShadowType.Invisible;

        //CAUTION=====
        public DisplayObjectContainer()
        {
            //这种方法需要手动初始化其他参数
            //Render/SourceTexture
        }
        //CAUTION=====

        public DisplayObjectContainer(int w, int h)
        {
            //Render = new RenderTarget2D(CommonItem.GraphicsDevice, w, h);
        }

        public DisplayObjectContainer(Texture2D texture)
        {
            //Render = new RenderTarget2D(CommonItem.GraphicsDevice, texture.Width, texture.Height);
            SourceTexture = texture;
        }

        public virtual void Dispose()
        {
            foreach (DisplayObjectContainer doc in Childs)
            {
                doc.Dispose();
            }
            Childs.RemoveRange(0, Childs.Count);

            Visible = false;
            SourceTexture = null;
        }

        public virtual void Update()
        {
            if (redShadowType == RedShadowType.Expanding)
            {
                RedShadowRadius += 32;
                if (RedShadowRadius * 2 > 2500)
                    redShadowType = RedShadowType.Visible;
            }
            else if (redShadowType == RedShadowType.Retracting)
            {
                RedShadowRadius -= 32;
                if (RedShadowRadius <= 0)
                    redShadowType = RedShadowType.Invisible;
            }
            foreach (DisplayObjectContainer doc in Childs)
            {
                doc.Update();
            }
           
        }


        public virtual void Draw()
        {
            if (!Visible) return;
            if (DrawSelf && SourceTexture == null) throw new Exception("没有纹理却要求绘制自身。");

           
            //CommonItem.GraphicsDevice.SetRenderTarget(null);
            //CommonItem.GraphicsDevice.SetRenderTarget(Render);
            //CommonItem.GraphicsDevice.Clear(Color.Transparent);

            //EffectParas.SetParas();
          
            
            if (DrawSelf)
            {
                Vector2 pos = Vector2.Zero;
                Color finalColor = Color.White;
                finalColor.A = (byte)(255 * Alpha);

                pos += BackOffset;
                CommonItem.SpriteEffect.Parameters["ImageSize"].SetValue(new Vector2(SourceTexture.Width, SourceTexture.Height));
                if (redShadowType != RedShadowType.Invisible)
                {
                    CommonItem.SpriteEffect.Parameters["EnableRedShadow"].SetValue(true);
                    CommonItem.SpriteEffect.Parameters["RedShadowPosition"].SetValue(RedShadowPosition);
                    CommonItem.SpriteEffect.Parameters["RedShadowRadius"].SetValue(RedShadowRadius);
                }
                else
                {
                    CommonItem.SpriteEffect.Parameters["EnableRedShadow"].SetValue(false);
                }
                //CommonItem.BasicBatch.Begin(SpriteSortMode.Immediate, BasicBlendState, null, null, null, CommonItem.SpriteEffect);
                CommonItem.BasicBatch.Draw(SourceTexture, this.ScreenPosition + pos, ShowingRect, finalColor, 
                    Rotation, Origin, Scale, SpriteEffects.None, 1f);
                //CommonItem.BasicBatch.End();
            }

            foreach (DisplayObjectContainer doc in Childs)
            {
                if (doc.Visible)
                {
                    //int tx = (int)doc.ScreenPosition.X, ty = (int)doc.ScreenPosition.Y;
                    //CommonItem.BasicBatch.Begin(SpriteSortMode.Immediate, doc.BasicBlendState, null, null, null, CommonItem.SpriteEffect);
                    //CommonItem.BasicBatch.Draw(doc.Render,
                    //    new Vector2(tx, ty),
                    //    doc.ShowingRect, Color.White, doc.Rotation, doc.Origin, 1f, SpriteEffects.None, 0);
                    //CommonItem.BasicBatch.End();

                    doc.Draw();

                }

                
            }
            
        }

        public virtual void AddChild(DisplayObjectContainer child)
        {
            child.Parent = this;
            Childs.Add(child);
            sortChilds();
        }

        public void StartRedShadow(Vector2 position)
        {
            redShadowType = RedShadowType.Expanding;
            RedShadowPosition = position;
            RedShadowRadius = 0;
            
        }

        public void EndRedShadow()
        {
            redShadowType = RedShadowType.Retracting;
        }

        void commonInitialize()
        {
        }

        void sortChilds()
        {
            Childs.Sort(sortFunc);
        }

        int sortFunc(DisplayObjectContainer a, DisplayObjectContainer b)
        {
            if (a.Z > b.Z) return 1;
            else if (a.Z < b.Z) return -1;
            else return 0;
        }

        int max(int a, int b) { return a > b ? a : b; }
        int min(int a, int b) { return a < b ? a : b; }

    }
}
