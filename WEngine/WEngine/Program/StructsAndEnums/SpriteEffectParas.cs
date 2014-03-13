using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace WEngine
{
    public class SpriteEffectParas
    {
        public string TechniqueName = "Normal";
        public bool EnableAlphaBlend = true;
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

        public bool EnableTone = true;
        public Vector4 Tone = new Vector4(0, 0, 0, 0);

        public void SetParas()
        {
            CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques[TechniqueName];
            if(EnableAlphaBlend) CommonItem.SpriteEffect.Parameters["Alpha"].SetValue(Alpha);
            if(EnableTone) CommonItem.SpriteEffect.Parameters["Tone"].SetValue(Tone);
        }
    }
}
