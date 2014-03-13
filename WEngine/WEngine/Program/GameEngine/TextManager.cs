using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WEngine
{
    public enum AlignType
    {
        Left,
        Middle,
        Right
    }
}

namespace WEngine
{
    public static class TextManager
    {
        static int CHAR_COUNT_ROW = 16;
        static int CHAR_COUNT_TOTAL = CHAR_COUNT_ROW * CHAR_COUNT_ROW;

        /// <summary>
        /// 这货是存储某一个字体一个字在纹理上占的空间
        /// </summary>
        static Dictionary<string, Vector2> fontCharSize = new Dictionary<string,Vector2>();
        /// <summary>
        /// 这货是存储每一个字的宽度（0、1号位不要在意）
        /// </summary>
        static Dictionary<string, byte[]> fontSizeDic = new Dictionary<string,byte[]>();
        /// <summary>
        /// 这货表示某个字符在图片上排第几个
        /// </summary>
        static Dictionary<char, int> charImageIndexDic = new Dictionary<char,int>();
        static bool indexInitFlag = false;

        public static string[] StringSplitInLine(string text)
        {
            return text.Split(new char[] {'\n', '\r' });
        }

        public static Vector2 MeasureString(string text, string fontname, int fontsize)
        {
            CheckFont(fontname, fontsize);
            string fontindex = getFontIndex(fontname, fontsize);
            string[] lines = StringSplitInLine(text);
            int maxWidth = 0;
            int maxHeight = 0;
            foreach (string line in lines)
            {
                int tempWidth = 0;
                foreach (char ch in line.ToCharArray())
                {
                    tempWidth += fontSizeDic[fontindex][(int)ch];
                }
                if (tempWidth > maxWidth) maxWidth = tempWidth;
                maxHeight += GetFontHeight(fontname, fontsize);
            }
            return new Vector2(maxWidth, maxHeight);
        }

        public static void DrawString(string text, string fontname, int fontsize, Vector2 position, Color color, float width)
        {
            CheckFont(fontname, fontsize);
            string fontindex = getFontIndex(fontname, fontsize);

            char[] characters = text.ToCharArray();
            Vector2 cursor = Vector2.Zero;
            int charWidthInImage = (int)fontCharSize[fontindex].X,
                charWidthUsing,
                charHeight = (int)fontCharSize[fontindex].Y;

            
            foreach (char ch in characters)
            {
                if (ch == '\r' || ch == '\n')
                {
                    cursor.X = 0;
                    cursor.Y += charHeight;
                    continue;
                }
                int charImageIndex = 0;

                if (charImageIndexDic.ContainsKey(ch))
                {
                    charImageIndex = charImageIndexDic[ch];
                }
                else
                {
                    throw new Exception("缺少文字纹理：" + ch + "，代码为" + (int)ch + "。");
                }
                
                charWidthUsing = fontSizeDic[fontindex][(int)ch];

                int imageIndex = charImageIndex / CHAR_COUNT_TOTAL;
                int indexInImage = charImageIndex % CHAR_COUNT_TOTAL;
                int indexX = (indexInImage % CHAR_COUNT_ROW);
                int indexY = indexInImage / CHAR_COUNT_ROW;

                if (cursor.X + charWidthUsing> width)
                {
                    cursor.X = 0;
                    cursor.Y += charHeight;
                }

                CommonItem.BasicBatch.Draw(
                    Cache.FontTexture(fontindex, imageIndex),
                    cursor + position,
                    new Rectangle(indexX * charWidthInImage, indexY * charHeight, charWidthInImage, charHeight),
                    color
                    );
                cursor.X += charWidthUsing;
                
            }
            
        }

        public static int GetFontHeight(string fontname, int fontsize)
        {
            string fontindex = getFontIndex(fontname, fontsize);
            return (int)fontCharSize[fontindex].Y;
        }

        static void prepareFont(string fontname, int fontsize)
        {
            string fontindex = getFontIndex(fontname, fontsize);

            FileStream fs = new FileStream(@"Content/GameContent/Fonts/" + fontindex + @"/info.dat", FileMode.Open);
            byte[] data = new byte[0xFFFF];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, data.Length);
            fs.Close();

            fs = new FileStream(@"Content/GameContent/Fonts/" + fontindex + @"/char.dat", FileMode.Open);
            byte[] cdata = new byte[fs.Length];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(cdata, 0, cdata.Length);
            fs.Close();
            string cstring = System.Text.Encoding.UTF8.GetString(cdata);

            fontSizeDic.Add(fontindex, data);
            fontCharSize.Add(fontindex, new Vector2(data[0], data[1]));

            if (indexInitFlag) return;
            int index = 0;
            foreach (char c in cstring.ToCharArray())
            {
                charImageIndexDic.Add(c, index);
                index++;
            }
            indexInitFlag = true;
        }

        static string getFontIndex(string fontname, int fontsize)
        {
            return fontname + "_" + fontsize;
        }

        static void CheckFont(string fontname, int fontsize)
        {
            string fontindex = getFontIndex(fontname, fontsize);
            if (!fontSizeDic.ContainsKey(fontindex)) prepareFont(fontname, fontsize);
        }
    }
}
