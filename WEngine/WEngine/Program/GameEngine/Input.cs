using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WEngine
{
    public enum MouseKeys
    {
        Left,
        Middle,
        Right
    }

    public static class Input
    {
        static Dictionary<Keys, char> keyToChar = new Dictionary<Keys,char>();
        static Dictionary<Keys, char> keyToCharWithShift = new Dictionary<Keys, char>();

        static Dictionary<Keys, bool> pressListLastFrame = new Dictionary<Keys,bool>();
        static Dictionary<Keys, bool> pressList = new Dictionary<Keys,bool>();

        public static Vector2 MousePosition;
        public static int MouseWheelValue;
        static Dictionary<MouseKeys, bool> mousePressListLastFrame = new Dictionary<MouseKeys, bool>();
        static Dictionary<MouseKeys, bool> mousePressList = new Dictionary<MouseKeys, bool>();

        public static bool Active = true;

        public static char CurrentInputChar;



        public static void Initialize()
        {
            foreach (Keys i in Enum.GetValues(typeof(Keys)))
            {
                pressList.Add(i, false);
                pressListLastFrame.Add(i, false);
            }
            foreach (MouseKeys i in Enum.GetValues(typeof(MouseKeys)))
            {
                mousePressList.Add(i, false);
                mousePressListLastFrame.Add(i, false);
            }


            #region key to char without shift
            keyToChar.Add(Keys.Q, 'q');
            keyToChar.Add(Keys.W, 'w');
            keyToChar.Add(Keys.E, 'e');
            keyToChar.Add(Keys.R, 'r');
            keyToChar.Add(Keys.T, 't');
            keyToChar.Add(Keys.Y, 'y');
            keyToChar.Add(Keys.U, 'u');
            keyToChar.Add(Keys.I, 'i');
            keyToChar.Add(Keys.O, 'o');
            keyToChar.Add(Keys.P, 'p');
            keyToChar.Add(Keys.A, 'a');
            keyToChar.Add(Keys.S, 's');
            keyToChar.Add(Keys.D, 'd');
            keyToChar.Add(Keys.F, 'f');
            keyToChar.Add(Keys.G, 'g');
            keyToChar.Add(Keys.H, 'h');
            keyToChar.Add(Keys.J, 'j');
            keyToChar.Add(Keys.K, 'k');
            keyToChar.Add(Keys.L, 'l');
            keyToChar.Add(Keys.Z, 'z');
            keyToChar.Add(Keys.X, 'x');
            keyToChar.Add(Keys.C, 'c');
            keyToChar.Add(Keys.V, 'v');
            keyToChar.Add(Keys.B, 'b');
            keyToChar.Add(Keys.N, 'n');
            keyToChar.Add(Keys.M, 'm');

            keyToChar.Add(Keys.D1, '1');
            keyToChar.Add(Keys.D2, '2');
            keyToChar.Add(Keys.D3, '3');
            keyToChar.Add(Keys.D4, '4');
            keyToChar.Add(Keys.D5, '5');
            keyToChar.Add(Keys.D6, '6');
            keyToChar.Add(Keys.D7, '7');
            keyToChar.Add(Keys.D8, '8');
            keyToChar.Add(Keys.D9, '9');
            keyToChar.Add(Keys.D0, '0');

            keyToChar.Add(Keys.NumPad1, '1');
            keyToChar.Add(Keys.NumPad2, '2');
            keyToChar.Add(Keys.NumPad3, '3');
            keyToChar.Add(Keys.NumPad4, '4');
            keyToChar.Add(Keys.NumPad5, '5');
            keyToChar.Add(Keys.NumPad6, '6');
            keyToChar.Add(Keys.NumPad7, '7');
            keyToChar.Add(Keys.NumPad8, '8');
            keyToChar.Add(Keys.NumPad9, '9');
            keyToChar.Add(Keys.NumPad0, '0');

            keyToChar.Add(Keys.Back, (char)8);
            keyToChar.Add(Keys.Enter, '\n');

            #endregion

            #region key to char with shift
            keyToCharWithShift.Add(Keys.Q, 'Q');
            keyToCharWithShift.Add(Keys.W, 'W');
            keyToCharWithShift.Add(Keys.E, 'E');
            keyToCharWithShift.Add(Keys.R, 'R');
            keyToCharWithShift.Add(Keys.T, 'T');
            keyToCharWithShift.Add(Keys.Y, 'Y');
            keyToCharWithShift.Add(Keys.U, 'U');
            keyToCharWithShift.Add(Keys.I, 'I');
            keyToCharWithShift.Add(Keys.O, 'O');
            keyToCharWithShift.Add(Keys.P, 'P');
            keyToCharWithShift.Add(Keys.A, 'A');
            keyToCharWithShift.Add(Keys.S, 'S');
            keyToCharWithShift.Add(Keys.D, 'D');
            keyToCharWithShift.Add(Keys.F, 'F');
            keyToCharWithShift.Add(Keys.G, 'G');
            keyToCharWithShift.Add(Keys.H, 'H');
            keyToCharWithShift.Add(Keys.J, 'J');
            keyToCharWithShift.Add(Keys.K, 'K');
            keyToCharWithShift.Add(Keys.L, 'L');
            keyToCharWithShift.Add(Keys.Z, 'Z');
            keyToCharWithShift.Add(Keys.X, 'X');
            keyToCharWithShift.Add(Keys.C, 'C');
            keyToCharWithShift.Add(Keys.V, 'V');
            keyToCharWithShift.Add(Keys.B, 'B');
            keyToCharWithShift.Add(Keys.N, 'N');
            keyToCharWithShift.Add(Keys.M, 'M');

            keyToCharWithShift.Add(Keys.NumPad1, '1');
            keyToCharWithShift.Add(Keys.NumPad2, '2');
            keyToCharWithShift.Add(Keys.NumPad3, '3');
            keyToCharWithShift.Add(Keys.NumPad4, '4');
            keyToCharWithShift.Add(Keys.NumPad5, '5');
            keyToCharWithShift.Add(Keys.NumPad6, '6');
            keyToCharWithShift.Add(Keys.NumPad7, '7');
            keyToCharWithShift.Add(Keys.NumPad8, '8');
            keyToCharWithShift.Add(Keys.NumPad9, '9');
            keyToCharWithShift.Add(Keys.NumPad0, '0');
                     
            keyToCharWithShift.Add(Keys.D1, '!');
            keyToCharWithShift.Add(Keys.D2, '@');
            keyToCharWithShift.Add(Keys.D3, '#');
            keyToCharWithShift.Add(Keys.D4, '$');
            keyToCharWithShift.Add(Keys.D5, '%');
            keyToCharWithShift.Add(Keys.D6, '^');
            keyToCharWithShift.Add(Keys.D7, '&');
            keyToCharWithShift.Add(Keys.D8, '*');
            keyToCharWithShift.Add(Keys.D9, '(');
            keyToCharWithShift.Add(Keys.D0, ')');

            keyToCharWithShift.Add(Keys.Back, (char)8);
            keyToCharWithShift.Add(Keys.Enter, '\n');

            #endregion
        }

        public static void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            CurrentInputChar = '\0';
            foreach (Keys i in Enum.GetValues(typeof(Keys)))
            {
                pressListLastFrame[i] = pressList[i];
                pressList[i] = keyState.IsKeyDown(i);
                if (Trigger(i) && CurrentInputChar == '\0')
                {
                    if (keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift))
                    {
                        if(keyToCharWithShift.ContainsKey(i))
                            CurrentInputChar = keyToCharWithShift[i];
                    }
                    else
                    {
                        if (keyToChar.ContainsKey(i))
                            CurrentInputChar = keyToChar[i];
                    }
                }
            }

            MouseState mouseState = Mouse.GetState();
            mousePressListLastFrame[MouseKeys.Left] = mousePressList[MouseKeys.Left];
            mousePressListLastFrame[MouseKeys.Middle] = mousePressList[MouseKeys.Middle];
            mousePressListLastFrame[MouseKeys.Right] = mousePressList[MouseKeys.Right];
            if(mouseState.LeftButton == ButtonState.Pressed) mousePressList[MouseKeys.Left] = true;
            else mousePressList[MouseKeys.Left] = false;
            if (mouseState.MiddleButton == ButtonState.Pressed) mousePressList[MouseKeys.Middle] = true;
            else mousePressList[MouseKeys.Middle] = false;
            if (mouseState.RightButton == ButtonState.Pressed) mousePressList[MouseKeys.Right] = true;
            else mousePressList[MouseKeys.Right] = false;

            MousePosition = new Vector2(mouseState.X, mouseState.Y);
            MouseWheelValue = mouseState.ScrollWheelValue;


        }

        public static void ClearKeyStatus(Keys key)
        {
            pressList[key] = false;
            pressListLastFrame[key] = false;
        }

        public static bool Press(Keys key)
        {
            if (!Active) return false;
            if (pressList[key]) return true;
            
            if (key == Keys.Q || key == Keys.A)
            {

                if (CommonItem.gamePadState.Buttons.X == ButtonState.Pressed && CommonItem.gamePadState.Buttons.X == ButtonState.Released)
                {
                    return true;
                }

            }
            if (key == Keys.W || key == Keys.S)
            {
                if (CommonItem.gamePadState.Buttons.Y == ButtonState.Pressed && CommonItem.gamePadState.Buttons.Y == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Up)
            {
                if (CommonItem.gamePadState.DPad.Up == ButtonState.Pressed && CommonItem.gamePadState.DPad.Up == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Down)
            {
                if (CommonItem.gamePadState.DPad.Down == ButtonState.Pressed && CommonItem.gamePadState.DPad.Down == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Left)
            {
                if (CommonItem.gamePadState.DPad.Left == ButtonState.Pressed && CommonItem.gamePadState.DPad.Left == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Right)
            {
                if (CommonItem.gamePadState.DPad.Right == ButtonState.Pressed && CommonItem.gamePadState.DPad.Right == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Space)
            {
                if (CommonItem.gamePadState.Buttons.Start == ButtonState.Pressed && CommonItem.gamePadState.Buttons.Start == ButtonState.Released)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Trigger(Keys key)
        {
            if (!Active) return false;
            if (pressList[key] && !pressListLastFrame[key]) return true;
            if (key == Keys.Q||key==Keys.A)
            {
               
                    if (CommonItem.gamePadState.Buttons.X == ButtonState.Pressed && CommonItem.gamePadState.Buttons.X== ButtonState.Released)
                    {
                        return true;
                    }
                
            }
            if (key == Keys.W||key==Keys.S)
            {
                if (CommonItem.gamePadState.Buttons.Y== ButtonState.Pressed && CommonItem.gamePadState.Buttons.Y == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Up)
            {
                if (CommonItem.gamePadState.DPad.Up == ButtonState.Pressed && CommonItem.gamePadState.DPad.Up == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Down)
            {
                if (CommonItem.gamePadState.DPad.Down == ButtonState.Pressed && CommonItem.gamePadState.DPad.Down == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Left)
            {
                if (CommonItem.gamePadState.DPad.Left == ButtonState.Pressed && CommonItem.gamePadState.DPad.Left == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key == Keys.Right)
            {
                if (CommonItem.gamePadState.DPad.Right == ButtonState.Pressed && CommonItem.gamePadState.DPad.Right == ButtonState.Released)
                {
                    return true;
                }
            }
            if (key ==Keys.Space)
            {
                if (CommonItem.gamePadState.Buttons.Start == ButtonState.Pressed && CommonItem.gamePadState.Buttons.Start == ButtonState.Released)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool PadTrigger(string sr)
        {
            if (sr == "Up")
            {
                if (CommonItem.gamePadState.DPad.Up == ButtonState.Pressed && CommonItem.gamePadState.DPad.Up == ButtonState.Released)
                {
                    return true;
                }
            }
            if (sr == "Down")
            {
                if (CommonItem.gamePadState.DPad.Down== ButtonState.Pressed && CommonItem.gamePadState.DPad.Down == ButtonState.Released)
                {
                    return true;
                }
            }
            if (sr == "Left")
            {
                if (CommonItem.gamePadState.DPad.Left == ButtonState.Pressed && CommonItem.gamePadState.DPad.Left == ButtonState.Released)
                {
                    return true;
                }
            }
            if (sr == "Right")

            {
                if (CommonItem.gamePadState.DPad.Right == ButtonState.Pressed && CommonItem.gamePadState.DPad.Right == ButtonState.Released)
                {
                    return true;
                }
            }
            if (sr == "A")

            {
                if (CommonItem.gamePadState.Buttons.A == ButtonState.Pressed && CommonItem.gamePadState.Buttons.A == ButtonState.Released)
                {
                    return true;
                }
            }
            if (sr == "B")
            {
                if (CommonItem.gamePadState.Buttons.B == ButtonState.Pressed && CommonItem.gamePadState.Buttons.B == ButtonState.Released)
                {
                    return true;
                }
            }
            if (sr == "Start")
            {
                if (CommonItem.gamePadState.Buttons.Start == ButtonState.Pressed && CommonItem.gamePadState.Buttons.Start == ButtonState.Released)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool PadPress(string sr)
        {
            if (sr == "Up")
            {
                if (CommonItem.gamePadState.DPad.Up == ButtonState.Pressed)
                {
                    return true;
                }
            }
            if (sr == "Down")
            {
                if (CommonItem.gamePadState.DPad.Down == ButtonState.Pressed )
                {
                    return true;
                }
            }
            if (sr == "Left")
            {
                if (CommonItem.gamePadState.DPad.Left == ButtonState.Pressed)
                {
                    return true;
                }
            }
            if (sr == "Right")
            {
                if (CommonItem.gamePadState.DPad.Right == ButtonState.Pressed)
                {
                    return true;
                }
            }
            return false;
        }
        public static int GetPressFlag(Keys key)
        {
            return Convert.ToInt32(Press(key));
        }

        public static int GetTriggerFlag(Keys key)
        {
            if (Trigger(key)) return 1;
            return Convert.ToInt32(Trigger(key));
        }
    }
}
