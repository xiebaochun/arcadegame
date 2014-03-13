using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WEngine
{
    public class Sprite_Base : DisplayObjectContainer
    {
        public BlendState BlendType = BlendState.AlphaBlend;
        public TransitionHandler TransitionHandler = new TransitionHandler();


        public Sprite_Base(string file)
            : base()
        {
            DrawSelf = true;
            SourceTexture = Cache.Texture(file);
            //Render = new RenderTarget2D(CommonItem.GraphicsDevice, SourceTexture.Width, SourceTexture.Height);
        }

        public Sprite_Base(int width, int height)
            : base(width, height)
        {
            DrawSelf = true;
        }
        
        public override void Update()
        {
            base.Update();
            foreach (TransitionEntry te in TransitionHandler.Transitions)
            {
                switch (te.Type)
                {
                    case TransitionType.X:
                        this.Position.X = te.CurrentValue;
                        break;
                    case TransitionType.Y:
                        this.Position.Y = te.CurrentValue;
                        break;
                    case TransitionType.Scale:
                        this.Scale = te.CurrentValue;
                        break;
                    case TransitionType.Alpha:
                        //this.EffectParas.Alpha = te.CurrentValue;
                        this.Alpha = te.CurrentValue;
                        break;

                }
            }
        }

        public override void Draw()
        {
            if (BlendType == BlendState.Additive)
            {
                CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques["Additive"];
            }
            else
            {
                CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques["AlphaBlend"];
            }
            base.Draw();
            if (BlendType == BlendState.Additive)
            {
                CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques["AlphaBlend"];
            }
        }
    }
}
