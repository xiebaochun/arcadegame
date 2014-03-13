using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEngine;
using System.IO;
using ArcadeGame.Programs.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ArcadeGame.Programs.Scenes
{
    class StartScene : Scene_Base
    {
        #region 声明成员变量
        Sprite LOGO;
        Sprite T01;
        Sprite GameName_01;
        Sprite Start;
        Sprite T02;
        Sprite BackGround;
        Sprite BackGround1;
        Sprite FarBackGround1;
        Sprite FarBackGround2;
        public Sprite Hero;
        Sprite HeroTalkPortrait_01;
        Sprite HeroTalkPortrait_02;
        Sprite HeroTalkPortrait_03;
        Sprite Continue;
        Sprite TalkBackGround;
        Sprite BaGuaZheng;
        Sprite NPC_01;
        Sprite npc1Portrait;
        Sprite npc2Portrait;
        Sprite generateSiki;
        Sprite Siki_b;
        Sprite generateAnger;
        Sprite reduceAnger;
        Sprite AngerLoop;
        Sprite Choose;
        Sprite Cursor;
        Sprite YongYuCursor;
        Sprite back;
        //Sprite yongYuBackGround;
        List<Sprite> yongYuBackGround=new List<Sprite>();
        Sprite_TextBox TalkBox;
        Sprite_TextBox YongYuBox1;
        Sprite_TextBox YongYuBox2;
        Boolean isGotoSecendTalk = false;
        Boolean isBackGroundMove = false;
        Boolean isShowSession = false;
        Boolean isYongYu=false;
        Boolean isStartAudio = false;
        bool isPlay = false;
        List<char> charList = new List<char>();
       
        char[] charArray = new char[] { };
        int SessionLength = 0;
        int TalkIcount = 0;
        int StringIndex = 0;
        int ShowSessionTime =10;
        int SessionIndex = 1;
        int YongYuIndex = 1;
        int huanjingSoundIcount=0;
        int HeroSoundsIcount = 0;
        bool isgotoNext = false;
        bool isgotoHH = false;
        #endregion
        #region 构造函数（初始化成员变量）
        public StartScene():base()
        {
            back = new Sprite("back", false, true, 1000, 0, 0, 1, 1);
            back.Alpha = 0;
            AddChild(back);

            LOGO = new Sprite("LOGO", true, true, 5, 0, 0, 1, 1);
            GoToCenter(LOGO);
            LOGO.Alpha = 0;
            LOGO.SPX = 0.01f;
            AddChild(LOGO);

            T01 = new Sprite("T01", false, true, 5, 0, 0, 1, 1);
            GoToCenter(T01);
            T01.Alpha = 0;
            T01.SPX = 0.01f;
            AddChild(T01);

            GameName_01 = new Sprite("GameName_01", false, true, 6, 0, 0, 1, 1);
            GoToCenter(GameName_01);
            GameName_01.SPY = 2f;
            GameName_01.Alpha = 0;
            GameName_01.SPX = 0.01f;
            AddChild(GameName_01);

            Start = new Sprite("Start_01", false, true, 6, 0, 10, 1, 1);
            GoToCenter(Start);
            Start.BackOffset.Y = Prefs.WindowSizeH - Start.SourceTexture.Height - 20;
            Start.SPX = 0.01f;
            Start.HP = 1;
            Start.SPY = 4;
            AddChild(Start);

            T02 = new Sprite("T02", false, true, 5, 0, 0, 1, 1);
            T02.Alpha = 0;
            T02.SPX = 0.01f;
            AddChild(T02);

            //背景初始化
            BackGround = new Sprite("BackGround1",false, true, 2,-2f,0, 1, 1);
            BackGround.BackOffset = new Vector2(0, -100);
            AddChild(BackGround);

            BackGround1 = new Sprite("BackGround2",false , true, 2, -3,0, 1, 1);
            BackGround1.BackOffset = new Vector2(BackGround.SourceTexture.Width, -100);
            AddChild(BackGround1);

            FarBackGround1 = new Sprite("farBackGround1",false , true, 1, -0.01f, 0, 1, 1);
            FarBackGround1.BackOffset = new Vector2(0, 0);
            AddChild(FarBackGround1);

            FarBackGround2 = new Sprite("farBackGround2",false , true, 1, 0.2f, 0, 1, 1);
            FarBackGround2.BackOffset = new Vector2(FarBackGround1.SourceTexture.Width, 0);
            AddChild(FarBackGround2);

            Hero = new Sprite("Hero",true , true, 5, 2.5f, 0, 3, 1);  
Hero.Visible=false;         
            Hero.Shader = new Sprite_Base("HeroShader");
            Hero.Shader.BackOffset = Hero.BackOffset;
            Hero.Shader.Z = 4;
            Hero.HP = 1000;
           // Hero.BackOffset = new Vector2((Prefs.WindowSizeW - Hero.SourceTexture.Width) / 2, 400);
            Hero.BackOffset = new Vector2(-800, 400);
            Hero.Shader.BackOffset = Hero.BackOffset;
            Hero.isStart = false;
            Hero.ShowingRect = Hero.SourceRect(Hero);
            AddChild(Hero);
            AddChild(Hero.Shader);

            HeroTalkPortrait_01 = new Sprite("HeroTalkPortrait_01", false, true, 6, 0, 0, 1, 1);
            HeroTalkPortrait_01.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_01);

            HeroTalkPortrait_02= new Sprite("HeroTalkPortrait_02", false, true, 6, 0, 0, 1, 1);
            HeroTalkPortrait_02.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_02);

            HeroTalkPortrait_03 = new Sprite("HeroTalkPortrait_03", false, true, 6, 0, 0, 1, 1);
            HeroTalkPortrait_03.BackOffset = CommonItem.PortraitPosition;
            AddChild(HeroTalkPortrait_03);

            npc1Portrait = new Sprite("npc1Portrait", false, true, 6, 0, 0, 1, 1);
            npc1Portrait.BackOffset = CommonItem.PortraitPosition;
            AddChild(npc1Portrait);

            npc2Portrait = new Sprite("npc2Portrait", false, true, 6, 0, 0, 1, 1);
            npc2Portrait.BackOffset = CommonItem.PortraitPosition;
            AddChild(npc2Portrait);

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
            TalkBox.Alpha = 0;
            TalkBox.FontSize = 16;
            AddChild(TalkBox);
            Cache.BGM("Talk_01");

            BaGuaZheng = new Sprite("BaGuaZheng", false, false, 4, 0, 0, 2, 6);
            BaGuaZheng.BackOffset = new Vector2(740, 550);
            BaGuaZheng.ShowingRect = BaGuaZheng.SourceRect(BaGuaZheng);
            AddChild(BaGuaZheng);

            NPC_01 = new Sprite("npc2", false, true, 5, 0.01f, 0, 1, 1);
            NPC_01.BackOffset = new Vector2(890, 410);
            NPC_01.Alpha = 0;
            AddChild(NPC_01);

            generateSiki = new Sprite("generateSiki", false,false, 4, 0.01f, 0, 3, 1);
            generateSiki.ShowingRect = generateSiki.SourceRect(generateSiki);
            generateSiki.Alpha = 0;
            AddChild(generateSiki);

            Siki_b = new Sprite("Siki_b", false, true, 4, 0, 0, 1, 1);
            Siki_b.Alpha = 0.5f;
            AddChild(Siki_b);

            generateAnger = new Sprite("generateAnger", false, false, 5, 0, 0, 3, 1);
            generateAnger.ShowingRect = generateAnger.SourceRect(generateAnger);
            generateAnger.Alpha = 0.5f;
            AddChild(generateAnger);

            AngerLoop = new Sprite("AngerLoop", false, true, 5, 0, 0, 3, 2);
            AngerLoop.ShowingRect = AngerLoop.SourceRect(AngerLoop);
            AngerLoop.Alpha = 0.5f;
            AddChild(AngerLoop);

            reduceAnger = new Sprite("reduceAnger", false, false, 5, 0, 0, 3, 1);
            reduceAnger.ShowingRect = reduceAnger.SourceRect(reduceAnger);
            reduceAnger.Alpha = 0.5f;
            reduceAnger.BackOffset = new Vector2(Hero.BackOffset.X - 38, Hero.BackOffset.Y - 218);
            AddChild(reduceAnger);

            Choose = new Sprite("Choose", false, false, 9, 0, 0, 1, 1);
            GoToCenter(Choose);
            AddChild(Choose);

            Cursor = new Sprite("Cursor", false, false, 10, 0, 0, 1, 1);
            //Cursor.Scale = 0.5f;
            Cursor.BackOffset = new Vector2(300, 200);
            AddChild(Cursor);

            YongYuBox1 = new Sprite_TextBox(350, 700);
            YongYuBox1.Visible = false;
            YongYuBox1.Text = "・新羽羽岐神社\n・八重垣　杏児\n・八重垣の一族\n・杏児の彼氏\n・神／悪魔\n・多機能車椅子「スワリちゃん」\n・アグディスティス\n・久利加羅\n・蕭　紫琳（サイ・ズーリン）\n・アミヒョン（阿美賢）、アミヨン（阿美英）\n・オトバイ『瞻星』\n・光線銃『キャリコちゃん』\n・魔人姉妹の部下たち\n・八重垣流剣術　顕世のつるぎ\n・八重垣流剣術　常夜のつるぎ\n・八重垣流　魔降霊身\n・八重垣流　土車運転術\n・禁じ手『神性解放』\n・一般相対性理論\n・移山法\n・付録";
            YongYuBox1.Z = 300;
            YongYuBox1.Position = new Vector2(50, 20);
            AddChild(YongYuBox1);

            YongYuBox2 = new Sprite_TextBox(1000, 700);
            YongYuBox2.Z = 300;
            YongYuBox2.Position = new Vector2(500, 20);
            AddChild(YongYuBox2);

            YongYuCursor = new Sprite("YongYuCursor", false, false, 20, 0, 0, 1, 1);
            YongYuCursor.BackOffset = new Vector2(5, 22);
           YongYuCursor.Scale = 0.3f;
            AddChild(YongYuCursor);

            for (int i = 1; i <= 13; i++)
            {
                Sprite sp = new Sprite(i.ToString(), false, true, 2, 0, 0, 1, 1);
                sp.BackOffset = new Vector2(500, 300);
                AddChild(sp);
                yongYuBackGround.Add(sp);
            }
        }
        #endregion
        public override void Update()
        {
            //主角轮椅声音
            if (Hero.Visible == true && Hero.BackOffset.X > -30 && Hero.SPX != 0 || BackGround.SPX != 0 && Hero.Visible == true && Hero.BackOffset.X > -30)
            {
                HeroSoundsIcount++;
                if (HeroSoundsIcount >= 10)
                {
                    HeroSoundsIcount = 0;
                    Audio.SEPlay("00");
                }
            }
            if (FarBackGround2.Visible == true)
            {
                if (isPlay == false)
                {
                    Audio.BGSPlay("13", true);
                    isPlay = true;
                }
                //huanjingSoundIcount++;
                //if (huanjingSoundIcount >= 1800)
                //{
                //    huanjingSoundIcount = 0;
                //    Audio.SEPlay("13");
                //}
            }
            
            if (CommonItem.isPalyed == false)
            {
                if (LOGO.Visible == true)
                {
                    LOGO.Alpha += LOGO.SPX;
                    if (LOGO.Alpha >= 1)
                    {
                        LOGO.SPX = 0;
                        LOGO.iCount++;
                    }
                    if (LOGO.iCount >= 300)
                    {
                        LOGO.iCount = 0;
                        LOGO.SPX = -0.01f;

                    }

                    if (LOGO.Alpha <= 0)
                    {
                        LOGO.Visible = false;
                        TalkBox.Position = new Vector2(320, 200);
                        LOGO.SPX = 0.01f;
                        TalkBox.Text = "                                                       注意書き：\n\n\nこの物語は虚構、フィクションであり、実在の人物や団体と一切関係ありません。\n\n本作品において犯罪となる行為が描写されておりますが、現実にこの様な行為に及んだ場合、法律により厳しく罰せられます。\n\nこのゲームには暴力シーンやグロテスクな表現が含まれています";
                        TalkBox.Visible = true;

                        
                    }
                    
                    if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                    {
                        LOGO.Visible = false;
                        TalkBox.Position = new Vector2(320, 200);
                        
                        TalkBox.Text = "                                                       注意書き：\n\n\nこの物語は虚構、フィクションであり、実在の人物や団体と一切関係ありません。\n\n本作品において犯罪となる行為が描写されておりますが、現実にこの様な行為に及んだ場合、法律により厳しく罰せられます。\n\nこのゲームには暴力シーンやグロテスクな表現が含まれています";
                        TalkBox.Visible = true;
                        LOGO.SPX = 0.01f;
                        LOGO.iCount = 0;
                    }

                }
                 if (TalkBox.Visible == true&&BackGround.Visible==false)
                 {
                     TalkBox.Alpha += LOGO.SPX;
                     if (TalkBox.Alpha >= 1)
                     {
                         LOGO.SPX = 0;
                         LOGO.iCount++;
                        
                     } 
                     if (LOGO.iCount >= 250)
                         {
                             LOGO.iCount = 0;
                             LOGO.SPX = -0.01f;      
                         }
                     if (TalkBox.Alpha <= 0)
                     {
                         LOGO.SPX =0.01f;
                         TalkBox.Visible = false;
                         T01.Visible = true;
                         TalkBox.Position = new Vector2(420, 600);
                         
                     }         
                }
            }       
            if (CommonItem.isPalyed == true)
            {
                CommonItem.isPalyed = false;
                T01.Visible = true;
                LOGO.Visible = false;
            }

            if (T01.Visible == true)
            {
               
                T01.Alpha += T01.SPX;
                if (T01.Alpha >= 1)
                {
                    T01.SPX = 0;
                    T01.iCount++;
                    GameName_01.Visible = true;
                    GameName_01.Alpha += GameName_01.SPX;
                    if (GameName_01.Alpha >= 0.5f)
                    {
                        GameName_01.SPX = 0;
                        GameName_01.BackOffset.Y -= GameName_01.SPY;
                        if (GameName_01.BackOffset.Y <= 0)
                        {
                            GameName_01.SPY = 0;
                            Start.Visible = true;
                        }
                    }

                }
            }
            if (Start.Visible == true)
            {
                 if (Input.Trigger(Keys.Space))
                {
                    GameName_01.Visible=false;
                      T01.Visible = false;
                     T02.Visible = false;
                    Start.Visible = false;
                    isBackGroundMove = true;
                    BackGround.Visible = true;
                    BackGround1.Visible = true;
                    FarBackGround1.Visible = true;
                    FarBackGround2.Visible = true;
                    Audio.BGMStop();

                }
                if (isStartAudio == false)
                {
                    isStartAudio = true;
                    Audio.BGMPlay("bgm_maoudamashii_piano07", true);
                }
                Start.iCount++;
                if (Start.iCount >= Start.SPY)
                {
                    Start.Alpha =Start.HP;
                }
                if (Start.iCount >= 2*Start.SPY)
                {
                    Start.Alpha = 0;
                    Start.iCount = 0;
                }
                if (Input.Trigger(Keys.Q) && Choose.Visible == false && GameName_01.Alpha >= 0.5f || Input.Trigger(Keys.W) && Choose.Visible == false && GameName_01.Alpha >= 0.5f)
                {
                    Audio.SEPlay("14");
                    Start.SPY = 0;
                  
                }
                //进行选择
               
                if (Start.SPY == 1)
                {
                    Start.HP -= Start.SPX;
                   GameName_01.SPX=-0.01f;
                    if (Start.HP <= 0)
                    {
                        T01.SPX = -0.01f;

                    }
                      T02.Visible = true;

                      Choose.Visible = false;
                      Cursor.Visible = false;
                      
                }
                
                if (T01.Alpha <= 0)
                {
                    T01.SPX = 0;
                    T01.Visible = false;
                    Start.Visible = false;
                }
            }
            if (Start.SPY == 0)
            {
                //if (File.Exists("C:\\isPlayed.xml"))
                //{

                //}
                //判断我的文档里是否存在isplayed.xml文件
                if (System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\isPlayed.xml"))
                {
                    Start.SPY = 2;
                }
                else
                {
                    Start.SPY = 1;
                }
                if (Start.SPY == 2)
                {
                    Choose.Visible = true;
                    Cursor.Visible = true;
                    Start.Visible = false;
                    Start.SPY = 3;
                }
            }
            //如果成功玩过一次后，则需要进行选择
            if (Choose.Visible == true&&isYongYu==false)
            {
                if (Input.Trigger(Keys.Up))
                {
                    Audio.SEPlay("15");
                    Cursor.BackOffset.Y -= 130;
                    if(Cursor.BackOffset.Y<200)
                         {
                            Cursor.BackOffset.Y=460;
                          }
                }
                if (Input.Trigger(Keys.Down))
                {
                    Audio.SEPlay("15");
                    Cursor.BackOffset.Y += 130;
                    if(Cursor.BackOffset.Y>460)
                         {
                            Cursor.BackOffset.Y=200;
                          }
                 }
                //Cursor.BackOffset.Y = MathHelper.Clamp(Cursor.BackOffset.Y, 200, 460);
                if (Input.Trigger(Keys.A) && GameName_01.Alpha >= 0.5f || Input.Trigger(Keys.S) && GameName_01.Alpha >= 0.5f)
                {
                    Audio.SEPlay("14");
                    if (Cursor.BackOffset.Y == 200) Start.SPY = 1;
                    if (Cursor.BackOffset.Y == 330)
                    {
                        //换装
                        Prefs.Theme = 2;
                        Start.SPY = 1;
                    }
                    if (Cursor.BackOffset.Y == 460)
                    {
                        //用语
                        isYongYu = true;
                    }
                }
            }
            if (T02.Visible == true)
            {
                T02.Alpha += T02.SPX;
                if (T02.Alpha >= 1)
                {                  
                    T02.SPX = -0.002f;
                }
                if (T02.Alpha <=0)
                {
                    T02.Visible = false;
                    Start.Visible = false;
                    isBackGroundMove = true;
                    BackGround.Visible = true;
                    BackGround1.Visible = true;
                    FarBackGround1.Visible = true;
                    FarBackGround2.Visible = true;
                    Audio.BGMStop();
                }
            }
            try
            {
                if(Hero.Visible==true)
{
 if (Input.Trigger(Keys.Space))
                    {
                        isgotoNext = true;

                    }
                    if (isgotoNext == true)
                    {
                        back.Visible = true;
                        back.Alpha += 0.01f;
                        if (back.Alpha >= 1)
                        {
                            Audio.BGSStop("13");
                            Audio.BGMStop();
                            //Hero.Visible = false;
                            //BackGround1.Visible = false;
                            //BackGround.Visible = false;
                            //FarBackGround1.Visible = false;
                            //FarBackGround2.Visible = false;
                            if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                            CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.Scene_Main)) as Scene_Base;
                        }
                    }
}
                if (isBackGroundMove == true)
                {
                   
                    backGroundUpdate();

                    Hero.BackOffset.X += Hero.SPX;
 if (Hero.BackOffset.X >= -200)
                    {
Hero.Visible=true;

}
                    if (Hero.BackOffset.X >= (Prefs.WindowSizeW - Hero.SourceTexture.Width) / 2)
                    {

                        //按空格直接跳过开始场景
                    if (Input.Trigger(Keys.Space))
                    {
                        isgotoNext = true;

                    }
                    if (isgotoNext == true)
                    {
                        back.Visible = true;
                        back.Alpha += 0.01f;
                        if (back.Alpha >= 1)
                        {
                            Audio.BGSStop("13");
                            Audio.BGMStop();
                            //Hero.Visible = false;
                            //BackGround1.Visible = false;
                            //BackGround.Visible = false;
                            //FarBackGround1.Visible = false;
                            //FarBackGround2.Visible = false;
                            if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                            CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.Scene_Main)) as Scene_Base;
                        }
                    }
                        //isBackGroundMove =false;
                        BackGround.SPX = 1f;
                        Hero.SPX = 0;
                        Hero.BackOffset.X = (Prefs.WindowSizeW - Hero.SourceTexture.Width) / 2 + 1;
                        Hero.SPY++;
                        if (Hero.SPY >= 1000)
                        {
                            Hero.SPY = 0;
                            isBackGroundMove = false;
                            BackGround.SPX = 0;
                            TalkBackGround.Visible = true;
                            TalkBox.Visible = true;
                            HeroTalkPortrait_02.Visible = true;

                            ShowSession("「・・・」", 1, "002");
                           // Continue.Visible = true;
                           

                            
                        }

                    }
                    Hero.Shader.BackOffset = Hero.BackOffset;
                    if (Hero.Visible == true)
                    {
                        Hero.iCount++;
                        if (Hero.iCount >= 10)
                        {
                            Hero.iCount = 0;
                            Hero.ObjectAnimation(Hero);
                        }

                    }
                }
                if (Continue.Visible==true&&isGotoSecendTalk==false&&TalkBackGround.Visible == true&&isgotoHH==false)
                {
                    isgotoHH = true;
                    HeroTalkPortrait_02.Visible = false;
                    HeroTalkPortrait_01.Visible = true;
                    isGotoSecendTalk = true;
                    //TalkBox.Text = "「・・・!」";
                    //Audio.BGMPlay("Talk_01", false);
                    Continue.Visible = false;
                    ShowSession("「・・・!」", 2, "Talk_01");
                   
                }
               
            }
            catch
            {
                return;
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
          

            if (isGotoSecendTalk == true&&Continue.Visible==true)
            {
                
                    Audio.SEPlay("14");
                    HeroTalkPortrait_01.Visible =false;
                    TalkBackGround.Visible = false;
                    TalkBox.Visible = false;
                    //TalkBox.Text = "继续？";
                    Continue.Visible = false;
                    BaGuaZheng.BackOffset = new Vector2(740, 550);
                    BaGuaZheng.Visible = true;
                    NPC_01.Visible = true;
                    isGotoSecendTalk = false;
                    Audio.SEPlay("11");
                    Continue.SPX = 0;
            }
            if (BaGuaZheng.Visible == true)
            {
                BaGuaZheng.iCount++;
                if (BaGuaZheng.iCount >= 8)
                {
                    BaGuaZheng.iCount = 0;
                    BaGuaZheng.ObjectAnimation(BaGuaZheng);
                }
            }
            //用语
            if (isYongYu== true)
            {
                //T02.Visible = false;
                Choose.Visible = false;
                T01.Visible = false;
                Start.Visible = false;
                Cursor.Visible = false;
                GameName_01.Visible = false;
                YongYuBox1.Visible = true;
                YongYuBox2.Visible = true;
                YongYuCursor.Visible = true;
                if (YongYuCursor.BackOffset.Y == 22)
                {
                    yongYuBackGround[11].Visible = true;
                    YongYuBox2.Text = "・分類：名\n日本の東北地方とある町にある小さな神社。\n古神道に近い独自な信仰を持ち、\nシャーマニズムの面が強く、様々な超自然的存在を利用、または排除し、現代に入る以前\nまで人類の生存圏を確保してきた。\nちなみに神社の祭神はアラハバキではない。\n\n主人公はその神社の宮司。";
                }
                else
                {
                    yongYuBackGround[11].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43)
                {
                    yongYuBackGround[3].Visible = true;
                    YongYuBox2.Text = "・分類：キャラ\nこのゲームの主人公。18才。\nまだ高校生ではあるが、「常闇の扉」を開く八重垣流剣術の腕に加えて、「魔降霊身」とい\nう神々の分霊を召喚・使役する技を持つ。\nデビルサマナーとしての類希なる才能を見込まれ若干１８歳で特例により新羽羽岐真宮\nの宮司を務めている。\n\nかつてその身体にある秘密が隠されていた。";
                }
                else
                {
                    yongYuBackGround[3].Visible =false;
                }
                if (YongYuCursor.BackOffset.Y == 43+21)
                {
                    YongYuBox2.Text = "・分類：名\n八重垣の一族はとある特別な遺伝子を持つ一族。\n一族みんな美形揃いだが身体にある共通の秘密のため、他の人間と交わることできず、\n二千年以上前から直系血族で子を作り繁殖してきた。\nそのため、系譜は常に蜘蛛の網のように複雑に絡み合ったような混沌状態。初めて見た人\nは気を失うほど凄まじいものである。\n主人公もまだ、父（血縁上は母でもある）と姉（血縁上父でもある）の間で生まれた、世\n間にとっては忌み子。\nちなみに、その体の特質ゆえ交神の儀でどちらの神とも子を成すことできるが、生まれた\n半神の子供が強大な力持つ変わりに短命の上性別もないゆえ一代限り。";
                }
                if (YongYuCursor.BackOffset.Y == 43 + 42)
                {
                    yongYuBackGround[12].Visible = true;
                    YongYuBox2.Text = "・分類：名\n普通の少年。童顔で内気だが、心優しく、いざという時の行動力もある。\n進学の時杏児と同じクラスで知り合い、事あるごとにいい雰囲気になるも、\nその後「彼女の秘密」と知り、ショックを受け悩んだ頃もあった。、\n部活の先輩に相談して助言を貰い、ありのままの彼女を受け入れると決意し、\nその後自然な流れで恋人同士になった。\n\nしかしその時相談した先輩が口を漏らして、杏児の体の秘密が知れわたり、自分も杏児も”\n魔人姉妹”に狙われる羽目になる。\n人質として囚われた時激しく抵抗したことが原因で姉妹の部下に暴行を受け落命した。";
                }
                else
                {
                    yongYuBackGround[12].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21*3)
                {
                    YongYuBox2.Text = "・分類：名\nこの作品の神／悪魔とは、現霊長（＝人類）の意志の外にある、アストラル体を持つ善き\n／悪しき超存在、\nあるいは現霊長がそれを理解／対抗するために模して作った超存在、その両方のことを指\nしている。必ずしも「知的」生命とは限れない。\n生命体として両者は基本似たようなもの、区別が困難だが、後者は前者に比べ、\n例えば創世神には創世神の、戦神は戦神の、淫魔には淫魔の役割がであるのように、\n「システムの一部に組められ、役割と本分以外のことを実行する自由意志がない」\nという欠点持つ同時に\n「稼動期間存在するが、寿命はない」という長所が存在する。\nゆえに前者には原生神／自然魔、後者には悠久神／永劫魔と呼ばわれている。\n理由は不明だが、作品の舞台となる現代では多くの原生神／自然魔は地上から姿が消え、\nどこかへ旅立っている。\n対し悠久神／永劫魔はいまだそのまま稼動しているものが多い。\n";
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21*4)
                {
                    YongYuBox2.Text = "・分類：武器\n使用者から発する微弱の電気信号を受信し、その意志に反応して自由に動ける、動力付し\nた車椅子。\n理論上最大500km/hという法外の速度維持したまま何時間も走れるが、使用者の生命安否\nは保障されてないというなぜ開発したのか分からない代物。\n世界中でも50台しかないため値段はかなり高い。\n";
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 5)
                {
                    yongYuBackGround[0].Visible = true;
                    YongYuBox2.Text = "・分類：キャラ\nかつて地球に存在していた「神」と呼ばわれた超存在の一柱。原生神\n自然魔に分類され\nる。\n召喚されたのはその分霊、そのため明確意思というものはない。\n本来の姿はは別のようだが、今回召喚する触媒（車椅子）の関係で今の姿を取っている。\nまだ本来の戦闘スタイルは剣ではない。\n\nアグディスティスとはフリギア地方起源とされる大地の母神で、その源流は旧石器時代の\n大地母神まで遡る。\nその神性はその後ギリシャに伝え、人によってそっちの名前の方が有名。\nそれは「キュベレー」である。\n";
                }
                else
                {
                    yongYuBackGround[0].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 6)
                {
                    yongYuBackGround[8].Visible = true;
                    YongYuBox2.Text = "・分類：武器\n剣身108cm、全長132cm、重さ約70キロ。\n伝説の金属「日火緋色金」と天を補修した時使われてない「補天石」が、剣身と剣柄にな\nったという、属性は氷と雷。\n杏児の家代々伝わる名剣といわれが、剣そのものも、その銘の由来も、謎に包まれている。\n召喚された神に持たせることで、それと一体化している間は半幽体（アストラル体）にな\nるため、敵を一方的に攻撃可能だが、手放すと元の実体に戻る。";
                }
                else
                {
                    yongYuBackGround[8].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 7)
                {
                    yongYuBackGround[10].Visible = true;
                    YongYuBox2.Text = "・分類：キャラ\n新羽羽岐真宮の近所に住んでる留学生。18才。\nインドで生まれ、オーストラリアで育ち、現在は日本に留学中。\nというのは表の経歴だが、「道教に近いがそれとどこか違う、シンプルな不思議な術」を\n使いのなせる辺り、色々謎が多い。\n趣味なのか、暇なときはゴーストスイーパーをやっている。\n父は城持っているイギリスの世襲貴族、母は中国香港の大物映画スター。\n両親は彼女の裏の顔ことを一切知らず、普通に留学していると思っている。\n杏児とは、近所に住んでるため、何度も顔あわせただけの縁で、同じ学校でもなければ友\n達でもない。おまけにお互いの名前すら知らない。\n英語のフルネームは「ズーリン・サイ・リリー」（Zilin Xiao Lillie）";
                }
                else
                {
                    yongYuBackGround[10].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 8)
                {
                    yongYuBackGround[1].Visible = true;
                    YongYuBox2.Text = "・分類：キャラ\n二つ名は「棒にあたる秒針運び屋」「魔人姉妹」「超人種族の忘れ形見」\n妹は無邪気で小悪魔。\n姉は冷静にして残忍。\n「時間を止めるような」超能力を持つ、双子の魔人姉妹。\n半島出身で年齢不明ではあるが、18才くらいと思われる。\n実は数万年の繁栄を誇る、地上最初の霊長類である超人種族「ソルムンデ」の末裔。\n「主人公のような体質の人は邪悪な生き物」と考えており、主人公のような体質の人を見\nつけ次第一方的に因縁を付け、懲らしめるために行動する。\nしかしその蛮行の裏に、彼女たちなりに悲しい過去があるらしい。\n座右の銘は「男は奴隷、女は愛人、○○○○は敵」";
                }
                else
                {
                    yongYuBackGround[1].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 9)
                {
                    yongYuBackGround[2].Visible = true;
                    YongYuBox2.Text = "・分類『武器』\n魔人姉妹の姉、アミヒョンが操縦するバイク。シリンダーから螺子の一本まで妹のアミヨ\nンの手製。\n最高出力312kW（420ps）/6000rpm、最大トルク183Nm(18.6kgfm)/3600rpm、圧縮比25：1。\n動力は二人の息吹、新陳代謝の残りカス、生体エネルギーであるため、二人が生きている\n限り走り続けれる。\n欠点はまだ慣性に縛られていること。\nちなみに二人は毎朝これで通校する。";
                }
                else
                {
                    yongYuBackGround[2].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 10)
                {
                    yongYuBackGround[7].Visible = true;
                    YongYuBox2.Text = "・分類『武器』\n魔人姉妹の妹、アミヨンが使用するカービン。バレルから螺子の一本まで姉のアミヒョン\nの手製。\n有効射程約は600メートル、連射速度毎分180発、最大口径（可変））時11.2ミリ。\n弾薬は二人の息吹、新陳代謝の残りカス、生体エネルギーであるため、二人が生きている\n限り撃ち続けれる。\n欠点は反動が凄いこと。\nちなみに二人休日これを使って近所の森でハンティング。";
                }
                else
                {
                    yongYuBackGround[7].Visible =false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 11)
                {
                    yongYuBackGround[9].Visible = true;
                    YongYuBox2.Text = "・分類：名\n魔人姉妹の魅了され、自らで姉妹の配下に志願した街の不良たちやヤンキー。\n筋肉ムチムチで絶倫の男ともは雑用係り兼スカベンジャー、\n計算高く顔もそれなりに美人（配下面接の時魔人姉妹自らで厳選した）の少女たちは愛人\n兼秘書。\n一人一人は大した戦闘力ではないが、数は多い。\n男ともは日ごろ雑用で溜まったストレスに捌き口として、欲望のまま主人公に凶行を振る\nったが、\n少女だちは今回の人誅の必要性に対して疑問を持ったものもいるらしい。";
                }
                else
                {
                    yongYuBackGround[9].Visible = false;
                }

                if (YongYuCursor.BackOffset.Y == 43 + 21 * 12)
                {
                    yongYuBackGround[6].Visible = true;
                    YongYuBox2.Text = "・分類：技\nこの世のもの斬る剣術。\n八重垣一族が剣を手にした以来千年間、実体を持つ様々の人外を徹底的に研究し、\n例えば腕多い敵にはどう攻めるか、飛べる敵にはどう追いつくか、無限復活できる敵にど\nう仕留めるか、など\nその経験の元に編み出し、人外を屠る技の集大成。\nだがその由来のため、同じ腕経つ人間の剣術使いにだけは苦手。";
                }
                else
                {
                    yongYuBackGround[6].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 13)
                {
                    yongYuBackGround[5].Visible = true;
                    YongYuBox2.Text = "・分類：技\nこの世ではないものを斬る剣術。\n術を使わず、技だけでアストラル体を切り裂く魔技。\nもし、召喚された神々は意図せずにして召喚者の支配から離れた場合、\n被害を出る前にこの技で暴走した神々のを力ずくでもあるべき場所へ送り返すのが召喚\n者の義務。\nそのため、これを会得したものがこそ、八重垣流剣術を極めたものといえる。\n";
                }
                else
                {
                    yongYuBackGround[5].Visible = false;
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 14)
                {
                    yongYuBackGround[4].Visible = true;
                    YongYuBox2.Text = "・分類：術\n八重垣流持つ秘伝の奥義。本来なら複雑な召喚儀式が必要な古代の神魔召喚・制御を、触\n媒一つで手軽くできる凄まじい術。\n但し呼ばされた神魔は触媒によって姿が異なり、触媒が性質に合わないと本来の強さ発揮\nできないの場合もある。\n今回の召喚者は、神の肉体を召喚し自分の手足の代わりに剣術を使う、という異例な使い\n方。\n\nちなみに本来ならグルヴェイグ・オシリス・アラハバキなどこそ、\n杏児の使役慣れている神々であって、同時召喚もできるだが、剣士として再起不能になっ\nた今の杏児ではそれらを完全制御できなくなっている。";
                }
                else
                {

                    yongYuBackGround[4].Visible = false;
                }

                if (YongYuCursor.BackOffset.Y == 43 + 21 * 15)
                {
                    YongYuBox2.Text = "・分類：技\n剣士として再起不能になった主人公が編み出した車椅子操縦術。\n・八重垣流　夜見の禊\n\n・分類：術\n魔降霊身おける最高の秘儀と言われる、秘伝の奥義。";
                }
                if (YongYuCursor.BackOffset.Y == 43 + 21 * 16)
                {
                    YongYuBox2.Text = "・分類：術\n『解放』とは『枷を外す』こと。\n召喚された神が、『触媒の殻』を脱ぎ捨て、本来の姿・神格・意志を取り戻す。一個の自\n己判断力を持つ『神性』として、己が「そうでありたい」限り、\n召喚者の生命力を絞りつくすまで現界にあり続ける。\nこの状態の神に対して、召喚者の強制力はもはや消滅しているため、事実上完全な使役は\nできなくなり、自分から神を送還することもできなくなる。\n召喚者の命令に遵うかはその神の自己判断に委ねられるため、悪神だけでなく、\n例え良き神性でも時に人間の立場・思考と折り合いがないので、極めて危険な状態である\nこと間違いない。\nゆえに、基本道連れ用の禁じ手。";
                }
                 if (YongYuCursor.BackOffset.Y == 43 + 21 * 17)
                {
                    YongYuBox2.Text = "・分類：科学仮説\n各自ぐぐるべし";
                }
                 if (YongYuCursor.BackOffset.Y == 43 + 21 * 18)
                {
                    YongYuBox2.Text = "・分類：術\nその名の通り、山を動かす、道教の術。\n相手の背中にその召喚された山を移すことによって、物理・霊格双方面重圧かけるという\n使い方。\n紫琳はこの術で魔人姉妹の超能力を一時的に封じた。";
                }
                 if (YongYuCursor.BackOffset.Y == 43 + 21 * 19)
                {
                   
                    if (Input.Trigger(Keys.Left))
                    {
                        Audio.SEPlay("15");
                        YongYuIndex++;
                    }
                    if (Input.Trigger(Keys.Right))
                    {
                        Audio.SEPlay("15");
                        YongYuIndex--;
                    }
                    if (YongYuIndex == 1)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『八重垣　杏児』のプロフィール\n\n種族：人間\n年齢：18\n出身地：日本東北地方\n身長：167cm\nスリーサイズ： Ｂ84Ｗ51Ｈ83\nプライドサイズ：Ｎ7.8cmＥ13.1cm（ＧＣ前）、Ｎ3.2cm（ＧＣ後）\n戦闘スタイル：八重垣流剣術・土車運転術・魔降霊身\n武器：多機能車椅子、剣、牙、含み針、唾\n趣味： ガンプラつくり、彼氏とのクロスカウンター（ＧＣ前）\n好みタイプ：偏見持たず、心も優しいの同年代の男の子\n苦手なもの：なぜか自分の好意を持つ女の子\n嫌なもの：乱暴な男、噂、家族\n主な使用言語：東日本方言、八丈方言、上代日本語、標準日本語、アイヌ語、高校英語　";
                    }
                    if (YongYuIndex == 2)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『蕭　紫琳（サイ・ズーリン）』ののプロフィール\n\n種族：仙人？\n年齢：18\n出身地：インド\n身長：164cm\nスリーサイズ： Ｂ77Ｗ47Ｈ80\n戦闘スタイル：仙術？\n武器：不明\n趣味：ゴーストスイーパー？ \n好みタイプ：ルックス平均以上かつ、勇気ある同年代の男の子\n苦手なもの：勝手に人に祭り上げられること\n嫌なもの：面倒くさいこと、毎回毎回面倒事に首を突っ込む自分の癖\n主な使用言語：オーストラリア英語、サンスクリット、広東語、古代漢語、現代日本語　 ";
                    }
                    if (YongYuIndex == 3)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『アミヒョン（阿美賢）』、『アミヨン（阿美英）』のプロフィール\n\n種族：超人種族「ソルムンデ」\n年齢：18？\n出身地：不明\n身長：165cm\nスリーサイズ： Ｂ79Ｗ48Ｈ82\n戦闘スタイル：超能力\n武器：ビーム銃、バイク\n趣味：部下の面接\n好みタイプ：とにかく可愛い女の子\n苦手なもの：現霊長のルール\n嫌なもの：杏児のような体を持つ人\n主な使用言語：上古霊長統一言語、コリョマル、高句麗語、古代朝鮮語、古代漢語、高校\n英語、現代日本語　";
                    }
                    if (YongYuIndex == 4)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『杏児の彼氏』のプロフィール\n\n種族：人間\n年齢：18\n出身地：日本関東地方\n身長：164cm\nプライドサイズ：Ｎ7.4cmＥ12.6cm\n戦闘スタイル：なし\n武器：なし\n趣味：野球、ヌードグラビア撮影、杏児と二人きりの夜\n好みタイプ：活発な女の子\n苦手なもの：乱暴な人、杏児とのクロスカウンター\n嫌なもの：父\n主な使用言語：標準日本語　";
                    }
                    if (YongYuIndex == 5)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『部下（男）』のプロフィール\n\n種族：人間\n年齢：18～27\n出身地：日本各地\n身長：172cm～180cm\nプライドサイズ：Ｎ8.4cm～9.7cmＥ13.7cm～16.8cm\n戦闘スタイル：力任せ\n武器：斧、鎖、鋏\n趣味：いい食事をし、いい女を抱く\n好みタイプ：いい女\n苦手なもの：手出すこと禁じられた女同僚\n嫌なもの：禁欲\n主な使用言語：日本語各地方言　";
                    }
                    if (YongYuIndex == 6)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『部下（女）』のプロフィール\n\n種族：人間\n年齢：16～24\n出身地：日本各地\n身長：155cm～162cm\nスリーサイズ： Ｂ75-83Ｗ46～49Ｈ77～82\n戦闘スタイル：恐れ知らず\n武器：斧、鎖、鋏\n趣味：買い物\n好みタイプ：かっこいい王子様\n苦手なもの：乱暴な男同僚\n嫌なもの：虫\n主な使用言語：日本語各地方言　";
                    }
                    if (YongYuIndex == 7)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『アグディスティス（触媒車椅子）』のプロフィール\n\n種族：原生神分霊\n殻材質：アストラルステンレススチール\n融合経過：約47秒\n全高：156cm\n属性：水\n戦闘スタイル：八重垣流剣術\n武器：剣\n趣味：なし\n好みタイプ：なし\n苦手なもの：なし\n嫌なもの：なし\n主な使用言語：なし　";
                    }
                    if (YongYuIndex == 8)
                    {
                        YongYuBox2.Text = "・各キャラ詳細設定\n\n『アグディスティス（神性解放）』のプロフィール\n\n種族：原生神\n神暦：約2400？\n出身地：フリュギア？\n身長：174cm\nスリーサイズ： Ｂ92Ｗ50Ｈ86\nプライドサイズ：Ｎ13.2cmＥ22.4cm\n戦闘スタイル：ハイリビドー\n武器：ザクロ、ブドウ、ワイン、城壁冠、太鼓、鏡、壷、松、蔦\n趣味：祭り、酒\n好みタイプ：美少年\n苦手なもの：破壊神バッコス\n嫌なもの：浮気\n主な使用言語：上古霊長統一言語、アッカド語、シュメール語、古代ヘブライ語、トラキ\nア語、フリュギア語、古代ギリシャ語、古ラテン語　";
                    }
                    if (YongYuIndex == 9) YongYuIndex = 1;
                    if (YongYuIndex == 0) YongYuIndex = 8;


                }
              

                //YongYuBox2.Text = YongYuCursor.BackOffset.Y.ToString();
                if (Input.Trigger(Keys.Up))
                {
                   Audio.SEPlay("15");
                    YongYuCursor.BackOffset.Y -= 21;
                    if(YongYuCursor.BackOffset.Y<22)
                       {
                         YongYuCursor.BackOffset.Y=442;
                        }
                }
                if (Input.Trigger(Keys.Down))
                {
                    Audio.SEPlay("15");
                    YongYuCursor.BackOffset.Y += 21;
                    if(YongYuCursor.BackOffset.Y>442)
                       {
                        YongYuCursor.BackOffset.Y=22;
                       }
                }
                YongYuCursor.BackOffset.Y = MathHelper.Clamp(YongYuCursor.BackOffset.Y,22,442);
                if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                {
                    foreach (var ss in yongYuBackGround)
                    {
                        ss.Visible = false;
                    }
                    isYongYu = false;
                    Audio.SEPlay("14");
                    //T02.Visible = true;
                    Start.Visible = true;
                    Cursor.Visible = true;
                    GameName_01.Visible = true;
                    Choose.Visible = true;
                    T01.Visible = true;

                    YongYuBox1.Visible = false;
                    YongYuBox2.Visible = false;
                    YongYuCursor.Visible = false;

                }
            }
            if (NPC_01.Visible == true)
            {
                NPC_01.Alpha += NPC_01.SPX;
                if (NPC_01.Alpha >= 1)
                {

                    if (SessionIndex == 6 && Continue.Visible == true)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            Audio.BGMStop();
                            Audio.SEPlay("14");
                            Audio.SEPlay("04");
                            Continue.Visible = false;
                            SessionIndex++;
                            generateAnger.BackOffset = new Vector2(Hero.BackOffset.X - 38, Hero.BackOffset.Y - 218);

                            generateAnger.Visible = true;
                            Siki_b.BackOffset = Hero.BackOffset + new Vector2(-40, 0);
                            generateSiki.BackOffset = Siki_b.BackOffset + new Vector2(3, -55);

                            generateSiki.Visible = true;

                            //关闭对话框
                            HeroTalkPortrait_01.Visible = false;
                            TalkBackGround.Visible = false;
                            TalkBox.Visible = false;
                            npc1Portrait.Visible = false;
                            TalkBox.Visible = false;
                        }
                    }
                    if (Continue.Visible == true)
                    {
                        if (Input.Trigger(Keys.Q) || Input.Trigger(Keys.W))
                        {
                            Audio.SEPlay("14");
                            SessionIndex++;
                            Continue.SPX = 0;
                            Continue.Visible = false;
                            ShowSessionTime = 10;
                        }
                    }
                    if (SessionIndex == 1&&Continue.SPX==0)
                    {
                        NPC_01.SPX = 0;
                        TalkBackGround.Visible = true;
                        TalkBox.Visible = true;
                        npc1Portrait.Visible = true; 
                        ShowSession("「そんな体で何処へ行く気なの？」", 4,"001");
                        
                    }
                    if (SessionIndex == 2 && Continue.SPX==0)
                    {
                        TalkBackGround.Visible = true;
                        TalkBox.Visible = true;
                        HeroTalkPortrait_02.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「・・・」", 1,"002");
                    }
                    if (SessionIndex == 3 && Continue.SPX==0)
                    {
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_02.Visible = false;
                        ShowSession("「あんな状態で路頭に倒れていたあなたを病院へ引渡したのはわたしだ。それくらい教えろ」", 10,"003");

                    }
                    if (SessionIndex == 4 && Continue.SPX==0)
                    {
                        HeroTalkPortrait_01.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「・・・助けてくれたことは感謝している。しかし、あいつらに恨みがある」", 10,"004");
                    }
                    if (SessionIndex == 5 && Continue.SPX==0)
                    {
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_01.Visible = false;
                        ShowSession("「あなたはもう、剣士として終ったんだ」", 5,"005");

                    }
                    if (SessionIndex == 6 && Continue.SPX==0)
                    {
                        HeroTalkPortrait_01.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「剣を握れなくとも、まだ『魔降術』がある」", 5,"006");
                    }
                   
                    if (SessionIndex == 7 && Continue.SPX == 0)
                    {
                        
                        TalkBackGround.Visible =true;
                        TalkBox.Visible = true;
                        
                        TalkBox.Visible =true;
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_01.Visible = false;
                        ShowSession("「うん・・・？これはまた、珍しい技を・・・プリュギアを起源とする死と再生の神、アグディスティスの分霊（わけみたま）か。召喚した神霊(しんれい)を自分に憑依させる技だな。なるほどそんな状態でも自力で来れたわけだ」", 50, "007");

                    }
                    if (SessionIndex == 8 && Continue.SPX == 0)
                    {
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_01.Visible = false;
                        ShowSession("「宮司（みやづかさ）が異境の神を使役するのは奇っ怪（きっかい ）だが、ある意味今のあなたにぴったりか」",15, "008");

                    }
                    if (SessionIndex == 9 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_02.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「・・・」", 1, "002");
                    }
                    if (SessionIndex == 10 && Continue.SPX == 0)
                    {
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_02.Visible = false;
                        ShowSession("「そうまでして復讐したいのか？あんなことされて、憤る気持ちは分かるが・・・」", 10, "009");

                    }
                    if (SessionIndex == 11 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「あたしの体のことではない」", 5, "010");
                    }
                    if (SessionIndex == 12 && Continue.SPX == 0)
                    {
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_01.Visible = false;
                        ShowSession("「うん？」", 1, "011");

                    }
                    if (SessionIndex == 13 && Continue.SPX == 0)
                    {
                        HeroTalkPortrait_01.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「あたしの・・・大事の人が・・・殺された。あいつらが直接手を下したわけではないが、しかし・・・」", 12, "012");
                    }
                    if (SessionIndex == 14 && Continue.SPX == 0)
                    {
                        npc1Portrait.Visible = true;
                        HeroTalkPortrait_01.Visible = false;
                        ShowSession("「・・・男のためか、チッ」", 5, "013");

                    }
                    if (SessionIndex == 15 && Continue.SPX == 0)
                    {
                        npc2Portrait.Visible = true;
                        npc1Portrait.Visible = false;
                        ShowSession("「本当バカね・・・折角助けて上げたのに。もう知らない、勝手に逝け」", 15, "014");

                    }
                    if (SessionIndex == 15 && Continue.Visible == true || SessionIndex > 15 && Continue.SPX==0)
                    {
                        Audio.SEPlay("11");
                        Continue.Visible = false;
                        BaGuaZheng.Visible = true;
                        HeroTalkPortrait_01.Visible = false;
                        TalkBackGround.Visible = false;
                        TalkBox.Visible = false;
                        npc1Portrait.Visible = false;
                        TalkBox.Visible = false;
                        npc2Portrait.Visible = false;
                    }

                    if (BaGuaZheng.CurrentPositionX == 1 && BaGuaZheng.CurrentPositionY == 2)
                    {
                    NPC_01.SPX = -0.01f;
                    Continue.SPX = 0;
                     }

                }

               

                 if (NPC_01.Alpha <= 0)
                    {
                        
                        //NPC_01.Visible = false;
                       // if (Continue.Visible == false&&Continue.SPX==0)
                       // {
                        if (Input.Trigger(Keys.Q) && NPC_01.SPX != 0 || Input.Trigger(Keys.W) && NPC_01.SPX != 0)
                        {
                            Audio.SEPlay("14");
                            TalkBackGround.Visible = true;
                            TalkBox.Visible = true;
                            NPC_01.SPX = 0;
                            TalkBox.Visible = true;
                            HeroTalkPortrait_01.Visible = true;
                            ShowSession("「違う・・・これは、あくまで自己満足だ」", 8, "015");
                        }
                        if (Continue.Visible == true)
                        {
                            Continue.Alpha = 0;
                            HeroTalkPortrait_01.Visible = false;
                            TalkBackGround.Visible = false;
                            TalkBox.Visible = false;
                            npc1Portrait.Visible = false;
                            TalkBox.Visible = false;
                            npc2Portrait.Visible = false;
                            Siki_b.BackOffset = Hero.BackOffset + new Vector2(-40, 0);
                            Hero.BackOffset.X +=Hero.SPX;
                            Hero.Shader.BackOffset = Hero.BackOffset;
                            Siki_b.Alpha -= 0.01f;
                            if (Siki_b.Alpha <= 0)
                            {
                                Siki_b.Visible = false;
                            }
                            if (Hero.Visible == true)
                            {
                                Hero.SPX = 2f;
                                Hero.iCount++;
                                if (Hero.iCount >= 6)
                                {
                                    Hero.iCount = 0;
                                    Hero.ObjectAnimation(Hero);
                                }

                            }
                            if (Hero.BackOffset.X >= 1350)
                            {
                                Hero.SPX = 0;
                                BackGround.Alpha -= 0.01f;
                                BackGround1.Alpha = BackGround.Alpha;
                                FarBackGround1.Alpha = BackGround.Alpha;
                                FarBackGround2.Alpha = BackGround.Alpha;
                                if (BackGround.Alpha <= 0)
                                {
                                    Audio.BGSStop("13");
                                    Hero.Visible = false;
                                    BackGround1.Visible = false;
                                    BackGround.Visible = false;
                                    FarBackGround1.Visible = false;
                                    FarBackGround2.Visible = false;
                                    if (CommonItem.Scene != null) CommonItem.Scene.Dispose();
                                    CommonItem.Scene = Activator.CreateInstance(typeof(Programs.Scenes.Scene_Main)) as Scene_Base;
                                }
                            }
                        }
                        
                  
                    }
                
            }
            //if (Input.Trigger(Keys.A))
            //{
            //    SessionIndex = 5;
                
            //}
            //if (Input.Trigger(Keys.S))
            //{
            //    SessionIndex = 14;
            //}
            #region 产生Siki
            if (generateSiki.Visible==true)
            { 
                generateSiki.Alpha += generateSiki.SPX;

                if (generateSiki.Alpha >= 0.5)
                {
                    generateSiki.SPX = 0;

                    generateSiki.iCount++;
                    if (generateSiki.iCount >= 5)
                    {
                        generateSiki.iCount = 0;
                        generateSiki.ObjectAnimation(generateSiki);

                    }
                    if (generateSiki.Visible == false)
                    {
                        generateSiki.Alpha = 0;
                        
                        Continue.SPX = 0;
                        Siki_b.Visible = true;

                    }
                }
            }
            #endregion
            #region 产生怒气
            if (generateAnger.Visible == true)
            {
                generateAnger.iCount++;
                if (generateAnger.iCount >= 5)
                {
                    generateAnger.ObjectAnimation(generateAnger);
                    generateAnger.iCount = 0;
                }
                if (generateAnger.Visible == false)
                {
                    AngerLoop.Visible = true;
                }
            }
            if (AngerLoop.Visible == true)
            {
                AngerLoop.BackOffset = generateAnger.BackOffset;
                AngerLoop.iCount++;
                if(AngerLoop.iCount>=5)
                {
                    AngerLoop.SPX++;
                    AngerLoop.iCount = 0;
                    AngerLoop.ObjectAnimation(AngerLoop);
                }
                if (AngerLoop.SPX >= 3)
                {
                    AngerLoop.Visible = false;
                    reduceAnger.Visible = true;
                }
            }
            if (reduceAnger.Visible == true)
            {
                reduceAnger.BackOffset = generateAnger.BackOffset;
                reduceAnger.iCount++;
                if (reduceAnger.iCount >= 5)
                {
                    reduceAnger.iCount = 0;
                    reduceAnger.ObjectAnimation(reduceAnger);
                }
            }
         #endregion
            //显示台词
            if (isShowSession == true)
            {
                TalkIcount++;
                if (TalkIcount >=ShowSessionTime)
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
                            //Audio.BGMStop();
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
        }
        //用语
       

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
            Audio.BGMStop();
            Audio.BGMPlay(name, false);
        }
        //背景更新
        private void backGroundUpdate()
        {

            //backGroundSoundIcount++;
            //if (backGroundSoundIcount >= 1800)
            //{
            //    backGroundSoundIcount = 0;
            //    Audio.SEPlay("13");
            //}
            BackGround.BackOffset.X -= BackGround.SPX;
            BackGround1.BackOffset.X -= BackGround.SPX;

            if (BackGround.SPX > 0)
            {
                if (BackGround.BackOffset.X <= -BackGround.SourceTexture.Width)
                {

                    BackGround.BackOffset.X = BackGround1.BackOffset.X + BackGround1.SourceTexture.Width;
                }

                if (BackGround1.BackOffset.X <= -BackGround1.SourceTexture.Width)
                {
                    BackGround1.BackOffset.X = BackGround.BackOffset.X + BackGround.SourceTexture.Width;
                }
            }
            if (BackGround.SPX < 0)
            {
                try
                {
                    if (BackGround.BackOffset.X >= BackGround.SourceTexture.Width)
                    {

                        BackGround.BackOffset.X = BackGround1.BackOffset.X - BackGround1.SourceTexture.Width;
                    }

                    if (BackGround1.BackOffset.X >= BackGround.SourceTexture.Width)
                    {
                        BackGround1.BackOffset.X = BackGround.BackOffset.X - BackGround.SourceTexture.Width;
                    }
                }
                catch
                {
                    return;
                }

            }
            FarBackGround1.BackOffset.X -= FarBackGround1.SPX;
            FarBackGround2.BackOffset.X -= FarBackGround1.SPX;

            if (FarBackGround1.BackOffset.X >= FarBackGround1.SourceTexture.Width)
            {
                FarBackGround1.BackOffset.X =FarBackGround2.BackOffset.X- FarBackGround1.SourceTexture.Width;
            }

            if (FarBackGround2.BackOffset.X >= FarBackGround2.SourceTexture.Width)
            {
                FarBackGround2.BackOffset.X = FarBackGround1.BackOffset.X-FarBackGround2.SourceTexture.Width;
            }

           

        }
        public void GoToCenter(Sprite sprite)
        {
            sprite.BackOffset.X = Prefs.WindowSizeW / 2 - sprite.SourceTexture.Width / (sprite.spriteSizeX * 2);
            sprite.BackOffset.Y = Prefs.WindowSizeH / 2 - sprite.SourceTexture.Height / (sprite.spriteSizeY * 2);
        }
        public override void Draw()
        {
            base.Draw();
        }
        public int backGroundSoundIcount = 0;
    }
}
