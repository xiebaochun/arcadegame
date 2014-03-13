using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEngine;
using ArcadeGame.Programs.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Xml;

namespace ArcadeGame.Programs.Scenes
{
    class EndScene:Scene_Base
    {
        public int theBaguaZhengFrmae = 8;//八卦阵动画的帧数
        Sprite BackGround;
        Sprite BackGround1;
        Sprite FarBackGround1;
        Sprite FarBackGround2;
        public Sprite Hero;
        Sprite Continue;
        Sprite TalkBackGround;
        Sprite BaGuaZheng;
        Sprite_TextBox TalkBox;
        Sprite BossKilled;
        Sprite NPC_01;
        Sprite npc1Portrait;
        Sprite npc2Portrait;
        Sprite HeroTalkPortrait_01;
        Sprite HeroTalkPortrait_02;
        Sprite HeroTalkPortrait_03;
        Sprite Cursor;
        Sprite GameEnd;
        Sprite LOGO;
         Boolean isShowSession = false;
        Boolean isGotoFirstSession = false;
            List<char> charList = new List<char>();
        XmlDocument xmlDoc;
        bool isStartAudio = false;
       
        char[] charArray = new char[] { };
        int SessionLength = 0;
        int TalkIcount = 0;
        int StringIndex = 0;
        int ShowSessionTime =10;
        int SessionIndex = 1;
        float TheEndThinksSpeedUp = 1;
        int backGroundSoundIcount = 0;
        Boolean isPlay = false;
        public EndScene():base()
        {
            xmlDoc = new XmlDocument();

            LOGO = new Sprite("LOGO",false, true, 5, 0, 0, 1, 1);
            GoToCenter(LOGO);
            LOGO.Alpha = 1;
            LOGO.SPX = 0.01f;
            AddChild(LOGO);

            Hero = new Sprite("Hero", true, true, 5, 4, 0, 3, 1);
            Hero.Shader = new Sprite_Base("HeroShader");
            Hero.Shader.BackOffset = Hero.BackOffset;
            Hero.Shader.Z = 4;
            Hero.HP = 1000;
            // Hero.BackOffset = new Vector2((Prefs.WindowSizeW - Hero.SourceTexture.Width) / 2, 400);
            Hero.BackOffset = new Vector2(200, 400);
            Hero.Shader.BackOffset = Hero.BackOffset;
            Hero.isStart = false;
            Hero.ShowingRect = Hero.SourceRect(Hero);
            AddChild(Hero);
            AddChild(Hero.Shader);

            TalkBackGround = new Sprite("TalkBackGround", false, false, 6, 0, 0, 1, 1);
            TalkBackGround.BackOffset = new Vector2(400, 520);
            AddChild(TalkBackGround);

            Continue = new Sprite("Continue", false, true, 7, 0, 0, 16, 1);
            Continue.ShowingRect = Continue.SourceRect(Continue);
            Continue.BackOffset = new Vector2(1130, 660);
            AddChild(Continue);

            TalkBox = new Sprite_TextBox(750, 600);
            TalkBox.Position = new Vector2(420, 600);
            TalkBox.Color = Color.White;
            TalkBox.Visible = false;
            TalkBox.Z = 7;
            TalkBox.FontSize = 16;
            AddChild(TalkBox);

            BaGuaZheng = new Sprite("BaGuaZheng", false, false, 4, 0, 0, 2, 6);
            BaGuaZheng.BackOffset = new Vector2(740, 550);
            BaGuaZheng.ShowingRect = BaGuaZheng.SourceRect(BaGuaZheng);
            AddChild(BaGuaZheng);

            BossKilled = new Sprite("BossKilled", true, true, 5, 0, 0, 1, 1);
            BossKilled.BackOffset = new Vector2(450,360);
            AddChild(BossKilled);

            NPC_01 = new Sprite("npc2",true, true, 5, 0.01f, 0, 1, 1);
            NPC_01.BackOffset = new Vector2(890, 410);
            NPC_01.Alpha = 0;
            AddChild(NPC_01);

            npc1Portrait = new Sprite("npc1Portrait", false, true, 6, 0, 0, 1, 1);
            npc1Portrait.BackOffset = CommonItem.PortraitPosition;
            AddChild(npc1Portrait);

            npc2Portrait = new Sprite("npc2Portrait", false, true, 6, 0, 0, 1, 1);
            npc2Portrait.BackOffset = CommonItem.PortraitPosition;
            AddChild(npc2Portrait);

            HeroTalkPortrait_01 = new Sprite("HeroTalkPortrait_01", false, true, 6, 0, 0, 1, 1);
            HeroTalkPortrait_01.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_01);

            HeroTalkPortrait_02 = new Sprite("HeroTalkPortrait_02", false, true, 6, 0, 0, 1, 1);
            HeroTalkPortrait_02.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_02);

            HeroTalkPortrait_03 = new Sprite("HeroTalkPortrait_03", false, true, 6, 0, 0, 1, 1);
            HeroTalkPortrait_03.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_03);


            Cursor = new Sprite("Cursor", false, false, 8, 0, 0, 1, 1);
            Cursor.Scale = 0.5f;
            Cursor.BackOffset= new Vector2(430, 595);
            AddChild(Cursor);

            BackGround = new Sprite("BackGround1",true, true, 2, -3, 0, 1, 1);
            BackGround.BackOffset = new Vector2(0, -100);
            AddChild(BackGround);

            BackGround1 = new Sprite("BackGround2", true, true, 2, -3, 0, 1, 1);
            BackGround1.BackOffset = new Vector2(BackGround.SourceTexture.Width, -100);
            AddChild(BackGround1);

            FarBackGround1 = new Sprite("farBackGround1", true, true, 1, 0.2f, 0, 1, 1);
            FarBackGround1.BackOffset = new Vector2(0, 0);
            AddChild(FarBackGround1);

            FarBackGround2 = new Sprite("farBackGround2",true, true, 1, 0.2f, 0, 1, 1);
            FarBackGround2.BackOffset = new Vector2(FarBackGround1.SourceTexture.Width, 0);
            AddChild(FarBackGround2);

            GameEnd = new Sprite("GameEnd", false, false, 5, 0.002f, 0, 1, 1);
            AddChild(GameEnd);
         }
        public override void Update()
        {
            if (isPlay == false)
            {
                Audio.BGSStop("10");
                Audio.BGSPlay("13",true);
                isPlay = true;
            }
            //八卦阵显示

            if (BaGuaZheng.Visible == true)
            {
                BaGuaZheng.iCount++;
                if (BaGuaZheng.iCount >= theBaguaZhengFrmae)//8
                {
                    BaGuaZheng.iCount = 0;
                    BaGuaZheng.ObjectAnimation(BaGuaZheng);
                }
            }
            if (NPC_01.Visible == true)
            {
                if (NPC_01.Alpha == 0)
                {
                    BaGuaZheng.Visible = true;
                    Audio.SEPlay("11");
                }
                NPC_01.Alpha += NPC_01.SPX;

                if (NPC_01.Alpha >= 1)
                {
                    NPC_01.SPX = 0;
                    isGotoFirstSession = true;
                }

                if (isGotoFirstSession == true)
                {
                    if (Continue.Visible == true && SessionIndex != 6)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            SessionIndex++;
                            Continue.SPX = 0;
                            Continue.Visible = false;
                            ShowSessionTime = 10;
                        }
                    }
                    if (SessionIndex == 1 && Continue.SPX == 0)
                    {
                        //HeroTalkPortrait_02.Visible = true;
                        TalkBackGround.Visible = true;
                        TalkBox.Visible = true;
                        //TalkBox.Text = "aiusahdasda";
                        npc2Portrait.Visible = true;
                        ShowSession("「呆れた。まさか本当に勝ったとは」", 11, "EndNpcTalk_01");


                    }
                    if (SessionIndex == 2 && Continue.SPX == 0)
                    {
                     
                        HeroTalkPortrait_01.Visible = true;
                        npc2Portrait.Visible = false;
                        ShowSession("「・・・寧ろあたしはあんたのお節介焼きに呆れたけどね」", 11, "EndHeroTalk_01");


                    }
                    if (SessionIndex == 3 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「何のことだ？」", 11, "EndNpcTalk_02");


                    }
                    if (SessionIndex == 4 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「・・・そうか、じゃなんでもない」", 11, "EndHeroTalk_02");


                    }
                    if (SessionIndex == 5 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「うるさい。で？こいつらをどうするつもり？警察に引き渡す？それともここで・・・」", 11, "EndNpcTalk_03");


                    }
                    if (SessionIndex == 5 && Continue.Visible == true)
                    {
                        SessionIndex++;
                        Continue.SPX = 0;
                    }
                    if (SessionIndex == 6 && Continue.SPX == 0)
                    {
                        // ShowSession("「うるさい。で？こいつらをどうするつもり？警察に引き渡す？それともここで・・・」", 11, "EndNpcTalk_03");
                        if (isShowSession == false)
                        {
                            TalkBox.Text = "                         警察に引き渡す\n                          止めを刺す";
                            // TalkBox.BackOffset.X = 420;
                            Cursor.Visible = true;
                        }

                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            Cursor.Visible = false;
                            if (Cursor.BackOffset.Y == 595)
                            {
                                SessionIndex = 7;
                                npc1Portrait.Visible = true;
                                ShowSession("「何のことだ？」", 11, "EndNpcTalk_04");
                            }
                            if (Cursor.BackOffset.Y == 615)
                            {

                                TalkBox.Text = "この選択肢の展開まだ用意されてない";
                                charList.Clear();
                                charArray = TalkBox.Text.ToCharArray();
                                foreach (char c in charArray)
                                {
                                    charList.Add(c);
                                }
                                SessionLength = charArray.Length;
                                //ShowSessionTime = (time * 40) / SessionLength;

                                Continue.SPX = 1;
                                Continue.SPX = 0;
                                isShowSession = true;
                            }
                        }
                        if (Input.Trigger(Keys.Up))
                        {
                            Cursor.BackOffset.Y = 595;

                        }
                        if (Input.Trigger(Keys.Down))
                        {
                            Cursor.BackOffset.Y = 615;
                        }
                    }

                    if (SessionIndex == 8 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「傷害、道交法違反、銃刀法違反、過失致死傷容疑・・・長いお勤めになるね」", 11, "EndNpcTalk_05");


                    }
                    if (SessionIndex == 9 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「もっとも、彼女たちにとってはほんの少しの時間だけど」", 11, "EndNpcTalk_06");


                    }
                    if (SessionIndex == 10 && Continue.SPX == 0)
                    {

                        HeroTalkPortrait_02.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「・・・」", 1, "002");


                    }
                    if (SessionIndex == 11 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「あなたは、これでいいの？」", 11, "EndNpcTalk_07");


                    }
                    if (SessionIndex == 12 && Continue.SPX == 0)
                    {

                        HeroTalkPortrait_01.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「いいわけないけど、ほんのすこし、気が済んだ。これ以上のことやったら、こいつらと同じにになってしまう。彼も、そんなこと、喜ぶはずも無い」", 1, "EndHeroTalk_03");
                    }
                    if (SessionIndex == 13 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「そうか」", 11, "EndNpcTalk_08");


                    }
                    if (SessionIndex == 14 && Continue.SPX == 0)
                    {

                        HeroTalkPortrait_02.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「しかし疲れた。少し、眠らせてくれ・・・」", 1, "EndHeroTalk_04");
                    }
                    if (SessionIndex == 15 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = false;
                        npc1Portrait.Visible = true;
                        ShowSession("「え」", 11, "EndNpcTalk_09");


                    }
                    if (SessionIndex == 16 && Continue.SPX == 0)
                    {

                        HeroTalkPortrait_01.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「・・・むっ・・・」", 1, "EndHeroTalk_05");
                    }
                    if (SessionIndex == 17 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = false;
                        npc2Portrait.Visible = true;
                        ShowSession("「ちょ、ここで寝るな、起きろよ！わたしはもうあなたを運ぶ気はないからな！」", 11, "EndNpcTalk_10");


                    }
                    if (SessionIndex == 18 && Continue.SPX == 0)
                    {

                        HeroTalkPortrait_01.Visible = true;
                        npc2Portrait.Visible = false;
                        ShowSession("「スっ・・・」", 1, "EndHeroTalk_06");
                    }
                    if (SessionIndex == 19 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = false;
                        npc2Portrait.Visible = true;
                        ShowSession("「こ、こいつ、本当寝ってやがる・・・！」", 11, "EndNpcTalk_11");


                    }
                    if (SessionIndex == 20 && Continue.SPX == 0)
                    {


                        npc1Portrait.Visible = true;
                        npc2Portrait.Visible = true;
                        ShowSession("「・・・」", 11, "Null");
                    }
                    if (SessionIndex == 21 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = false;
                        npc2Portrait.Visible = true;
                        ShowSession("「チッ、はぁ～・・・本当に関わるべきじゃなかった・・・」", 11, "EndNpcTalk_12");
                    }

                    if (SessionIndex >= 22 && Continue.SPX == 0)
                    {
                        TalkBackGround.Visible = false;
                        TalkBox.Visible = false;
                        npc2Portrait.Visible = false;
                        npc1Portrait.Visible = false;
                        HeroTalkPortrait_01.Visible = false;
                        HeroTalkPortrait_02.Visible = false;
                        HeroTalkPortrait_03.Visible = false;
                        BackGround.Alpha -= 0.005f;
                        BackGround1.Alpha = BackGround.Alpha;
                        FarBackGround1.Alpha = BackGround.Alpha;
                        FarBackGround2.Alpha = BackGround.Alpha;
                        Hero.Alpha = BackGround.Alpha;
                        BossKilled.Alpha = BackGround.Alpha;
                        NPC_01.Alpha = BackGround.Alpha;
                        Continue.Alpha = BackGround.Alpha;
                        if (BackGround.Alpha <= 0)
                        {
                            Hero.Visible = false;
                            BossKilled.Visible = false;
                            NPC_01.Visible = false;
                            BackGround1.Visible = false;
                            BackGround.Visible = false;
                            FarBackGround1.Visible = false;
                            FarBackGround2.Visible = false;
                            Continue.Visible = false;
                            GameEnd.Visible = true;
                            SessionIndex = 22;
                            TalkBox.Position = new Vector2(450, 730);
                            LOGO.BackOffset.Y = 730;
                            LOGO.Visible = true;
                            //CommonItem.isPalyed = true;

                        }
                    }
                }
            }
            if (GameEnd.Visible == true)
            {
                GameEnd.Alpha -= GameEnd.SPX;
                if (GameEnd.Alpha <= 0.3f)
                {
                    if (isStartAudio == false)
                    {
                        Audio.BGSStop("13");
                        GameEnd.SPX = 0;
                        isStartAudio = true;
                        Audio.BGMPlay("bgm_maoudamashii_piano04",true);
                    }
                    TalkBox.Position.Y -= TheEndThinksSpeedUp;
                    TalkBox.Visible = true;
                    if (LOGO.BackOffset.Y > 150)
                    {
                        TalkBox.Text = "スタッフ（敬称略）\n\n・声出演\n八重垣　杏児：笑兵衛\n蕭　紫琳：杏*樹  \n阿美賢（姉）：坂崎真央\n阿美英（妹）：坂崎真央\n雑魚敵（男）：狸田太一\n雑魚敵（女）：？？？\nシステムボイス：狸田太一\n \n・企画・原案\n夏雪羽\n\n・キャラクターデザイン\nleon\n夏雪羽\n\n・原画・グラフィック\nleon\n瑠璃瑠璃\n夏雪羽\n\n・キャラドット絵\nいのうえしろ\nｍｍｍ街\n有織\ntocoda\n夏雪羽\n\n・背景ドット絵\nｍｍｍ街\n\n・エフェクト\n minag\n\n ・プログラム\nGeink\n夏雪雨\nwindy\n\nSpecial Thanks-\n テストプレイ\nchikuchikugonzalez　様\nhttp://chiku2gonzalez.hatenablog.com/\n\n・背景素材\nヤマンチュゲーム研究所　様 \nhttp://www.ob2.aitai.ne.jp/~owl/material/index.html    \n風のリュート　観月らん　様\nhttp://sky.geocities.jp/lute_wind/     \n\n・エフェクト素材     \nファナテイル　様\nhttp://fanatail.michikusa.jp/    \n\n・BGM・SE素材\nOn-Jin ～音人～　様\nhttp://www.yen-soft.com/ssse/    \n小森平　様\nhttp://taira-komori.jpn.org/daily01.html     \n魔王魂　様  \nhttp://maoudamashii.jokersounds.com/list/se7.html   \n\n音々亭　様\nhttp://soundarbour.sakura.ne.jp/SE_03.html \n\n\n\n\n\n\n";
                    }
                    if (TalkBox.Position.Y <= -1400 || Input.Trigger(Keys.Q) || Input.Trigger(Keys.W) || GameEnd.Alpha <= 0)
                    {
                        TalkBox.Visible = false;
                        GameEnd.SPX = 0.01f;
                        if (GameEnd.Alpha <= 0)
                        {

                            Audio.BGMStop();
                           
                            //判断是否Xml存在
                            if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\isPlayed.xml"))
                            {
                                if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                                CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.StartScene)) as Scene_Base;
                                return;
                            }
                            //if (System.IO.File.Exists("C:\\isPlayed.xml"))
                            //{
                            //    return;
                            //}
                            else
                            {
                                XmlNode xe1 = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
                                xmlDoc.AppendChild(xe1);

                                XmlElement root = xmlDoc.CreateElement("isPlayed");
                                xmlDoc.AppendChild(root);
                                root.InnerText = "true";
                                //xmlDoc.Save("C:\\isPlayed.xml");
                                xmlDoc.Save(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\isPlayed.xml");
                            }

                            if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                            CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.StartScene)) as Scene_Base;
                        }
                    }
                }


                //if ( GameEnd.SPX == 0)
                //{
                //    LOGO.BackOffset.Y -= TheEndThinksSpeedUp;
                //    if (LOGO.BackOffset.Y <= 150)
                //    {
                //        LOGO.Visible = false;
                //        TheEndThinksSpeedUp = 0;
                //        TalkBox.Position.Y = 200;
                //        TalkBox.Position.X = 320;
                //        TalkBox.Text = "                                      注意書き：\n\n\nこの物語は虚構、フィクションであり、実在の人物や団体と一切関係ありません。\n本作品において犯罪となる行為が描写されておりますが、現実にこの様な行為に及んだ場合、法律により厳しく罰せられます。\n\nこのゲームには暴力シーンやグロテスクな表現が含まれています";
                //        LOGO.iCount++;
                //        if (LOGO.iCount >= 300)
                //        {
                //            LOGO.iCount = 0;
                //            if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                //            CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.StartScene)) as Scene_Base;
                //        }
                //    }
                //}
            }

                if (Continue.Visible == true)
                {
                    Continue.iCount++;
                    if (Continue.iCount >= 3)
                    {
                        Continue.iCount = 0;
                        Continue.ObjectAnimation(Continue);
                    }
                }

                //显示台词
                if (isShowSession == true)
                {
                    TalkIcount++;
                    if (TalkIcount >= ShowSessionTime)
                    {
                        TalkIcount = 0;

                        TalkBox.Text = TalkBox.Text + charList[StringIndex];
                        StringIndex++;
                        if (StringIndex >= SessionLength)
                        {
                            isShowSession = false;
                            Continue.Visible = true;
                            StringIndex = 0;
                            if (ShowSessionTime == 1)
                            {
                                Audio.BGMStop();
                            }
                            ShowSessionTime = 10;


                        }
                    }
                    if (TalkIcount >= 2)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            ShowSessionTime = 1;
                        }
                    }

                }
                //if (GameEnd.Visible == false)
                //{
                //    backGroundSoundIcount++;
                //    if (backGroundSoundIcount >= 1800)
                //    {
                //        Audio.SEPlay("13");
                //        backGroundSoundIcount = 0;
                //    }
                //}
                base.Update();
            }
        
        

        //播放会话文本
        private void ShowSession(string sr,int time,string name)
        {
            TalkBox.Text = "";
            charList.Clear();
            charArray = sr.ToCharArray();
            foreach (char c in charArray)
            {
                charList.Add(c);
            }
            SessionLength = charArray.Length;
            //ShowSessionTime = (time * 40) / SessionLength;
            isShowSession = true;
            Continue.SPX = 1;
            if (name != "Null")
            {
                Audio.BGMPlay(name, false);
            }
        }


          
        public override void Draw()
        {
            base.Draw();
        }
        public void GoToCenter(Sprite sprite)
        {
            sprite.BackOffset.X = Prefs.WindowSizeW / 2 - sprite.SourceTexture.Width / (sprite.spriteSizeX * 2);
            sprite.BackOffset.Y = Prefs.WindowSizeH / 2 - sprite.SourceTexture.Height / (sprite.spriteSizeY * 2);
        }
    }
}
