using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace WEngine
{
    public enum ForceFieldType
    {
        RectHorizonal,
        RectVertical,
        Round
    }

    public class ForceField
    {
        public float Strength;
        public virtual bool InField(Vector2 particlePos) { return false; }
        public virtual float GetForceX(Vector2 particlePos) { return 0; }
        public virtual float GetForctY(Vector2 particlePos) { return 0; }
    }
    public class RoundForceField : ForceField
    {
        public Vector2 Position;
        float squaredRadius;
        float radius;
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                squaredRadius = value * value;
            }
        }

        public override bool InField(Vector2 particlePos)
        {
            if ((particlePos - Position).LengthSquared() < squaredRadius)
            {
                return true;
            }
            return false;
        }

        public override float  GetForceX(Vector2 particlePos)
        {
            float dlen = (particlePos - Position).Length();
            return Strength / dlen * (Position.X - particlePos.X);
        }

        public override float  GetForctY(Vector2 particlePos)
        {
            float dlen = (particlePos - Position).Length();
            return Strength / dlen * (Position.Y - particlePos.Y);
        }

    }
    /*
    public class GravityLikeForceField : ForceField
    {
        public Vector2 Position;
        float squaredRadius;
        float radius;
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                squaredRadius = value * value;
            }
        }

        public override bool InField(Vector2 particlePos)
        {
            if ((particlePos - Position).LengthSquared() < squaredRadius)
            {
                return true;
            }
            return false;
        }

        public override float GetForceX(Vector2 particlePos)
        {
            Vector2 delta = particlePos - Position;
            float dlensqu = delta.LengthSquared();
            float dlen = delta.Length();
            return Strength / dlensqu / dlen * (Position.X - particlePos.X);
        }

        public override float  GetForctY(Vector2 particlePos)
        {
            Vector2 delta = particlePos - Position;
            float dlensqu = delta.LengthSquared();
            float dlen = delta.Length();
            return Strength / dlensqu / dlen * (Position.Y - particlePos.Y);
        }
    }
    */
    public class HorizonalRectForceField : ForceField
    {
        public Rectangle Range;
        public override bool InField(Vector2 particlePos)
        {
            if (particlePos.X > Range.Left && particlePos.X < Range.Right && particlePos.Y > Range.Left && particlePos.Y < Range.Right)
            {
                return true;
            }
            return false;
        }

        public override float GetForceX(Vector2 particlePos)
        {
            if (!InField(particlePos)) return 0;
            return Strength;
        }

        public override float GetForctY(Vector2 particlePos)
        {
            return 0;
        }
    }
    public class VerticalRectForceField : ForceField
    {
        public Rectangle Range;

        public override bool InField(Vector2 particlePos)
        {
            if (particlePos.X > Range.Left && particlePos.X < Range.Right && particlePos.Y > Range.Left && particlePos.Y < Range.Right)
            {
                return true;
            }
            return false;
        }

        public override float GetForceX(Vector2 particlePos)
        {
            return 0;
        }

        public override float GetForctY(Vector2 particlePos)
        {
            if (!InField(particlePos)) return 0;
            return Strength;
        }
    }
    
}
