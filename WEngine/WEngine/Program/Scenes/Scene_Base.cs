using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace WEngine
{
    public class Scene_Base : DisplayObjectContainer
    {

        public Scene_Base():base(Prefs.GameSizeW, Prefs.GameSizeH)
        {
        }

        public override void Update()
        {
            base.Update();
            
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
