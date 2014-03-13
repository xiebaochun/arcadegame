using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WEngine
{
    

    public class ParticleUnit
    {
        public bool Active;
        public int CurrentLife;

        public Vector2 Position = Vector2.Zero;
        public Vector2 Velocity = Vector2.Zero;
        public Vector2 Accelerate = Vector2.Zero;

        public float Alpha = 1;
        public Vector3 Tone = new Vector3(1, 1, 1);
        public Vector2 Scale = new Vector2(1, 1);
        public float Rotation = 0;

        //==========
        public Color DrawColor = Color.White;

        //==========
        public float Variable_1;
        public float Variable_2;
        public float Variable_3;
    }

    


    public class ParticleGroup : DisplayObjectContainer
    {
        protected Random random = new Random();
        bool additive = true;
        Vector2 texHalfSize;
        Texture2D _texture;
        public Texture2D ParticleTexture
        {
            get
            {
                return _texture;
            }
            set
            {
                _texture = value;
                texHalfSize = new Vector2(_texture.Width / 2, _texture.Height / 2);
            }
        }


        List<ParticleUnit> units = new List<ParticleUnit>();
        List<ForceField> fields = new List<ForceField>();
        int particlePointer = 0;
        float addParticleTimer = 0;
        float addParticleSpeed = 0;
        int addParticleLife = 0;

        public BlendState BlendState = BlendState.AlphaBlend;

        public ParticleGroup(int count, float addSpeed, int particleLife)
            :base(Prefs.GameSizeW, Prefs.GameSizeH)
        {
            particlePointer = 0;
            addParticleSpeed = addSpeed;
            addParticleLife = particleLife;

            for (int i = 0; i < count; i++)
            {
                units.Add(new ParticleUnit());
                units[i].Active = false;
            }
        }

        public override void Update()
        {
            base.Update();
            addParticleTimer += addParticleSpeed;
            while (addParticleTimer >= 1f)
            {
                addParticleTimer--;
                addParticle();
            }
            foreach (ParticleUnit u in units)
            {
                if (!u.Active) continue;
                u.CurrentLife--;
                if (u.CurrentLife <= 0)
                {
                    u.Active = false;
                    continue;
                }
                

                updateParticleProperty(u);

                //=========
                u.DrawColor = new Color(u.Tone);
                u.DrawColor *= u.Alpha;

            }
            
        }

        public override void Draw()
        {
            if (additive)
            {
                CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques["Additive"];
            }
            //CommonItem.BasicBatch.Begin(SpriteSortMode.Texture, BlendState);
            foreach (ParticleUnit i in units)
            {
                if (!i.Active) continue;
                CommonItem.BasicBatch.Draw(ParticleTexture, i.Position, null, i.DrawColor, i.Rotation, texHalfSize, i.Scale, SpriteEffects.None, 1f);
                //BasicBatch.Draw(ParticleTexture, i.Position, i.DrawColor);
                
            }
            //BasicBatch.End();
            if (additive)
            {
                CommonItem.SpriteEffect.CurrentTechnique = CommonItem.SpriteEffect.Techniques["AlphaBlend"];
            }
        }

        public void AddForceField(ForceField ff)
        {
            fields.Add(ff);
        }

        void addParticle()
        {
            newParticlePropertySet(units[particlePointer]);
            particlePointer++;
            if (particlePointer >= units.Count) particlePointer = 0;
        }

        protected virtual void newParticlePropertySet(ParticleUnit unit)
        {
            units[particlePointer].Active = true;
            units[particlePointer].CurrentLife = addParticleLife;
        }

        protected virtual void updateParticleProperty(ParticleUnit unit)
        {
            unit.Accelerate = Vector2.Zero;
            foreach (ForceField ff in fields)
            {
                unit.Accelerate.X += ff.GetForceX(unit.Position);
                unit.Accelerate.Y += ff.GetForctY(unit.Position);
            }
            unit.Velocity += unit.Accelerate;
            unit.Position += unit.Velocity;
        }

        protected int getRandomInt(int min, int max)
        {
            Random rd = new Random(random.Next(38274576));
            rd.NextDouble();
            return rd.Next(max - min + 1) + min;
        }

        protected float getRandomFloat(float min, float max)
        {
            Random rd = new Random(random.Next(23456652));
            rd.NextDouble();
            return (float)(rd.NextDouble() * (max - min) + min);
        }
    }
}
