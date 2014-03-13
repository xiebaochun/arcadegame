using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;




namespace WEngine
{
    public class Sprite_TextBox : Sprite_Base
    {
        public string Text = "";
        public Color Color = Color.White;
        public string FontName = "微软雅黑";
        public int FontSize = 16;
        public AlignType Align = AlignType.Left;

        public bool EnableInput = false;
        public Vector2 TextboxSize;

        public Sprite_TextBox(int width, int height)
            : base(width, height)
        {
            DrawSelf = false;
            TextboxSize = new Vector2(width, height);
        }

        public override void Update()
        {
            base.Update();
            if (EnableInput)
            {
                if (Input.CurrentInputChar != '\0')
                {
                    char ch = Input.CurrentInputChar;
                    if (ch == 8)
                    {
                        Text = Text.Substring(0, Text.Length - 1);
                    }
                    else
                    {
                        Text += Input.CurrentInputChar.ToString();
                    }

                }
            }
        }

        public override void Draw()
        {
            if (!Visible) return;
            base.Draw();
            //BasicBatch.Begin();
            Vector2 size;
            string[] texts;
            int h;
            switch (Align)
            {
                case AlignType.Left:
                    TextManager.DrawString(Text, FontName, FontSize, Position, Color, TextboxSize.X);
                    break;
                case AlignType.Middle:
                    texts = TextManager.StringSplitInLine(Text);
                    h = 0;
                    foreach (string s in texts)
                    {
                        size = TextManager.MeasureString(s, FontName, FontSize);
                        TextManager.DrawString(s, FontName, FontSize, Position + new Vector2((TextboxSize.X - size.X) / 2, h), Color, TextboxSize.X);
                        h += TextManager.GetFontHeight(FontName, FontSize);
                    }
                    break;
                case AlignType.Right:
                    texts = TextManager.StringSplitInLine(Text);
                    h = 0;
                    foreach (string s in texts)
                    {
                        size = TextManager.MeasureString(s, FontName, FontSize);
                        TextManager.DrawString(s, FontName, FontSize, Position + new Vector2(TextboxSize.X - size.X, h), Color, TextboxSize.X);
                        h += TextManager.GetFontHeight(FontName, FontSize);
                    }
                    break;
            }
            
            //BasicBatch.End();

        }
    }
}
