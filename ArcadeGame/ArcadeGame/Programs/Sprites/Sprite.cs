using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace ArcadeGame.Programs.Sprites
{
  public  class Sprite:Sprite_Base
    {
      public Sprite_Base Shader;
      public Sprite_Base CollisionRectView;
       public float HP;
       public float SPY;
       public float SPX;
       public bool isSpeedChange=true;
       public int CurrentPositionX;
       public int CurrentPositionY;
       public bool isPool;
       public int spriteZ;
       public int spriteSizeX;
       public int spriteSizeY;
       public float iCount;
       public bool isMove;
      public bool isStart;
      public int prePositionY;
      public DateTime dateTime;
      public Rectangle CollisionRect;
       public Rectangle sourceRect;
       public Sprite(string file,bool isAlive,bool isBool,int spriteZ,float SPX,float SPY,int spriteSizeX,int spriteSizeY):base(file)
       {

           this.Visible = isAlive;
           this.isPool = isBool;
           this.Z = spriteZ;
           this.SPX = SPX;
           this.SPY = SPY;
           this.spriteSizeX = spriteSizeX;
           this.spriteSizeY = spriteSizeY;
           this.iCount = 0;
           this.CurrentPositionX = 0;
           this.CurrentPositionY = 0;
           this.sourceRect = this.SourceRect(this);
           this.isStart=false;
           this.HP = 0;
           this.dateTime = DateTime.Now;
          // this.Shader.Visible = false;
           this.CollisionRectView = new Sprite_Base("CollisionRectView");
           this.CollisionRectView.Visible = false;
           
           AddChild(this.CollisionRectView);
       }
       public  Sprite(string files,bool IsAlive):base(files)
       {
           this.Visible = IsAlive;
       }
       public Rectangle SourceRect(Sprite sprite)
       {
           Rectangle SourceRect;
           SourceRect = new Rectangle(sprite.CurrentPositionX * sprite.SourceTexture.Width / sprite.spriteSizeX,
                                    sprite.CurrentPositionY * sprite.SourceTexture.Height / sprite.spriteSizeY,
                                    sprite.SourceTexture.Width / sprite.spriteSizeX,
                                    sprite.SourceTexture.Height / sprite.spriteSizeY);
           return SourceRect;
       }
       public void ObjectAnimation(Sprite sprite)
       {
           if (sprite.Visible == true)
           {
               
               sprite.CurrentPositionX++; 
               
               if (sprite.CurrentPositionX >= sprite.spriteSizeX)
               {
                   sprite.CurrentPositionX = 0;
                   sprite.CurrentPositionY++;
               }
               if (sprite.CurrentPositionY >= sprite.spriteSizeY)
               {
                   sprite.CurrentPositionY = 0;
                   if (sprite.isPool == false)
                   {
                       sprite.Visible = false;
                   }
               }
               sprite.ShowingRect = SourceRect(sprite);
             
           }
       }
       public Boolean gotoCenterSlowly()
       {
           if (this.BackOffset.X < Prefs.WindowSizeW / 2 - this.SourceTexture.Width / (this.spriteSizeX * 2) + 3 && this.BackOffset.X > Prefs.WindowSizeW / 2 - this.SourceTexture.Width / (this.spriteSizeX * 2) - 3)
           {
               this.SPX = 0f;
               return true;
           }
           if (this.BackOffset.X >= Prefs.WindowSizeW / 2 - this.SourceTexture.Width / (this.spriteSizeX * 2)+3)
           {
               this.SPX = 3f;
           }
           if (this.BackOffset.X <= Prefs.WindowSizeW / 2 - this.SourceTexture.Width / (this.spriteSizeX * 2)-3)
           {
               this.SPX = -3f;
           }
           return false;
       }


     
      
          
      
       public override void Update()
       {
           this.CollisionRectView.ShowingRect = new Rectangle(0, 0, this.CollisionRect.Width, this.CollisionRect.Height);
           this.CollisionRectView.BackOffset = new Vector2(this.CollisionRect.X, this.CollisionRect.Y);

           this.CollisionRectView.Z = this.Z+10;
           base.Update();
       }
       public override void Draw()
       {
           base.Draw();
       }
    }
}
