using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using WEngine;
using Microsoft.Xna.Framework.Input;
using ArcadeGame.Programs.Sprites;

namespace ArcadeGame.Programs.Scenes
{
   partial class Scene_Main
    {
        int SessionLength = 0;
        int TalkIcount = 0;
        int StringIndex = 0;
        int ShowSessionTime = 0;
        int SessionIndex = 1;
        Sprite_TextBox TalkBox;
        Sprite Continue;
        Sprite TalkBackGround;
        Sprite MixBossPortrait_01;
        Boolean isShowSession = false;
        List<char> charList = new List<char>();      
        char[] charArray = new char[] { };
      
       
        Boolean isGotoTimeStop2HeroTalk = false;
        Boolean isGotoTimeStop3NpcTalk = false;
        Boolean isGotoTimeStop3HillDownTalk = false;
        Boolean isGotoTimeStop3RedDisappear = false;

        Boolean isGotoTimeStop2HeroTalked = false;
        Boolean isGotoTimeStop3NpcTalked = false;
        Boolean isGotoTimeStop3HillDownTalked = false;
        Boolean isGotoTimeStop3RedDisappeared = false;

        Boolean isGotoHP90Talk = false;
        Boolean isGotoHP90Talked = false;
        Boolean isGotoHP75Talk = false;
        Boolean isGotoHP75Talked = false;
        Boolean isGotoHP60Talk = false;
        Boolean isGotoHP60Talked = false;
        Boolean isGotoHP50Talk=false;
        Boolean isGotoHP50Talked = false;
        Boolean isGotoHP25Talk = false;
        Boolean isGotoHP25Talked = false;
        Boolean isGotoHP0Talk = false;
        Boolean isGotoHP0Talked = false;
       private void PortraitUpdate()
       {


           //if (TalkBackGround.Visible == true)
           //{
           //    isBossNiubility = true;
           //    isHeroNiuBility = true;
           //}
           if (Boss.HP <= 900&&isGotoHP90Talked==false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoHP90Talk = true;
               isGotoHP90Talked = true;
               Continue.Visible =false;
           }
           if (Boss.HP <= 750 && isGotoHP75Talked == false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoHP75Talk = true;
               isGotoHP75Talked = true;
               Continue.Visible = false;
           }
           if (Boss.HP <= 600 && isGotoHP60Talked == false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoHP60Talk = true;
               isGotoHP60Talked = true;
               Continue.Visible = false;
           }
           if (Boss.HP <= 500 && isGotoHP50Talked == false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoHP50Talk = true;
               isGotoHP50Talked = true;
               Continue.Visible = false;
           }
           if (Boss.HP <= 250 && isGotoHP25Talked == false)
           {
               isGotoHP50Talk = false;
               isGotoHP60Talk = false;
               isGotoHP75Talk = false;
               isGotoHP90Talk = false;
               isGotoHP50Talked = true;
               isGotoHP60Talked = true;
               isGotoHP75Talked = true;
               isGotoHP90Talked = true;
               isGotoTimeStop3NpcTalk = false;
               SessionIndex++;
               Continue.SPX = 0;
               isGotoHP25Talk = true;
               isGotoHP25Talked = true;
               Continue.Visible = false;
           }
           if (Boss.HP <=0 && isGotoHP0Talked == false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoHP0Talk = true;
               isGotoHP0Talked = true;
               Continue.Visible = false;
           }
           if (isGotoTimeStop2HeroTalk == true&&isGotoTimeStop2HeroTalked==false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoTimeStop2HeroTalked = true;
               isGotoTimeStop2HeroTalk = false;
               Continue.Visible = false;
           }
           //山掉下来的前一刻（Npc说话）
           //if (isGotoTimeStop3HillDownTalk == true&&isGotoTimeStop3HillDownTalked==false)
           //{
           //    SessionIndex++;
           //    Continue.SPX = 0;
           //    isGotoTimeStop3HillDownTalk = false;
           //    isGotoTimeStop3HillDownTalked = true;
           //    Continue.Visible = false;
           //}
           ////时间停止3红色消失时
           //if (isGotoTimeStop3RedDisappear == true &&isGotoTimeStop3RedDisappeared==false)
           //{
           //    SessionIndex++;
           //    Continue.SPX = 0;
           //    isGotoTimeStop3RedDisappear =false;
           //    isGotoTimeStop3RedDisappeared=
           //        true;
           //    Continue.Visible = false;
           //}
           if (isGotoTimeStop3NpcTalk == true && isGotoTimeStop3NpcTalked== false)
           {
               SessionIndex++;
               Continue.SPX = 0;
               isGotoTimeStop3NpcTalk = false;
               isGotoTimeStop3NpcTalked = true;
               Continue.Visible = false;
           }
           //if (isGotoTimeStop2HeroTalked ==false&&isGotoTimeStop2HeroTalked == true)
           //{
           //    isGotoTimeStop2HeroTalked = true;
           //    isGotoTimeStop2HeroTalk = false;
           //    SessionIndex++;
           //    Continue.SPX = 0;
           //    isGotoHP0Talk = true;
           //    isGotoHP0Talked = true;
           //    Continue.Visible = false;
           //}
           


          
           #region Boss出场前演出
           if(loopCount >= maxloopCount)
           {
               if (Continue.SPX == 1&&Continue.Visible==true)
               {
                   Continue.HP++;
                   if (Continue.HP >= 60)
                   {
                       Continue.HP = 0;
                       if (SessionIndex <= 3)
                       {                        
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       if (isGotoHP90Talk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       if (isGotoHP75Talk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       if (isGotoHP60Talk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       if (isGotoHP50Talk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       if (isGotoHP25Talk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       if (isGotoHP0Talk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                       //主角说话
                       if (isGotoTimeStop3NpcTalk == true)
                       {
                           SessionIndex++;
                           Continue.SPX = 0;
                           Continue.Visible = false;
                       }
                     
                                      
                   }
                  
               }
               if (SessionIndex == 1 && Continue.SPX == 0)
               {
                   //Hero.isStart = false;
                   Audio.BGMPause();
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                    Boss1Portrait_02.Visible = true;
                    ShowSession("「きゃははは、思いのほか早く再会できたねェ！かわいい子猫ちゃん！」", 10, "imo_01");

               }
               if (SessionIndex == 2 && Continue.SPX == 0)
               {
                      
                   Boss2Portrait_01.Visible = true;
                   Boss1Portrait_02.Visible = false;
                   ShowSession("「そんなもので追ってくるなんて・・・どうするつもり？」", 7, "ane_01");

               }
               //if (SessionIndex == 2 && Continue.Visible == true)
               //{
               //    Boss.Visible = true;
               //}
               if (SessionIndex == 3 && Continue.SPX == 0)
               {
                   Boss.Visible = true;
                   Boss2Portrait_01.Visible =false;
                   Boss1Portrait_02.Visible = true;
                   ShowSession("「姉ちゃん、また子猫ちゃん掴まえたら、いっぱいいっぱい可愛がってあげようよ！」", 8, "imo_03");

               }
               if (SessionIndex == 4 && Continue.SPX == 0)
               {

                   Boss2Portrait_01.Visible = true;
                   Boss1Portrait_02.Visible = false;
                   ShowSession("「そうね、折角『普通の』女の子にしてあげたことですし、一杯遊びましょう」", 12, "ane_03");

               }
               if (SessionIndex == 4 &&Continue.Visible==true)
               {
                   Boss2Portrait_01.Visible = false;
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   Audio.BGMPlay("two", true);
               }
               //Boss第一段  HP 90%
               if (SessionIndex == 5 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                   //Boss2Portrait_01.Visible = true;
                  // Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   Boss1Portrait_03.Visible =true;
                   ShowSession("「こいつ、調子に乗って！」", 3, "imo_04");

               }
               if (SessionIndex == 6 && Continue.SPX == 0)
               {
                   isGotoHP90Talk = false;
                   Boss2Portrait_03.Visible = true;
                   Boss1Portrait_03.Visible =false;
                   ShowSession("「・・・ッ！本気にわたしたちに勝つつもり？」", 4, "ane_04");
               }
               if (SessionIndex == 6 && Continue.Visible == true)
               {
                   Boss2Portrait_03.Visible = false;
                   Boss2Portrait_01.Visible = false;
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   Audio.BGMResume();
               }
               //进入时间停止1 HP75%
               if (SessionIndex == 7 && Continue.SPX == 0)
               {
                   //Boss2Portrait_01.Visible = true;
                  // Continue.Visible = true;
                   Audio.BGMPause();
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   Boss1Portrait_03.Visible = true;
                   ShowSession("「ぃーたぃ！もう許さない！今度こそ絶望と欲望の淵に叩き込んであげる！」", 10, "imo_05");

               }
               if (SessionIndex == 8 && Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;
                  
                   Boss1Portrait_03.Visible = false;
                   Boss2Portrait_01.Visible = true;
                   ShowSession("「まて、壊したら元も子もないわ。いけない子猫は、ゆっくり躾けて上げる。」", 11, "ane_05");
               }
               if (SessionIndex == 9 && Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;

                   Boss1Portrait_01.Visible =true;
                   Boss2Portrait_01.Visible =false;
                   ShowSession("「・・・そうね、わかったよ、姉ちゃん。手足だけじゃ足りないみたい、今回はその牙と爪ももぎ取ってあがる。」", 10, "imo_06");

               }
               if (SessionIndex == 10 && Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;

                   Boss1Portrait_02.Visible = true;
                   Boss1Portrait_01.Visible = false;
                   ShowSession("「姉ちゃん、そろそろ「あれ」をやろっか？！」", 5, "imo_07");

               }
               if (SessionIndex == 11 && Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;

                   Boss1Portrait_02.Visible = false;
                   Boss2Portrait_02.Visible = true;
                   ShowSession("「ええ、いいわ。格の違いを思い知らせてあげましょう。」", 4, "ane_07");

               }
               if (SessionIndex == 12 && Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;

                   Boss1Portrait_01.Visible = true;
                   Boss2Portrait_02.Visible = false;
                   ShowSession("「相対速度測定（そうたいそくどそくてい）！」", 2, "imo_08");

               }
               if (SessionIndex == 13&& Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;

                   Boss1Portrait_01.Visible = false;
                   Boss2Portrait_01.Visible = true;
                   ShowSession("「座標恒等変換（ざひょうこうとうへんかん）！」", 5, "ane_08");

               }
               if (SessionIndex == 14 && Continue.SPX == 0)
               {

                   //Boss2Portrait_01.Visible = true;
                   isGotoHP75Talk = false;
                   MixBossPortrait_01.Visible =true;
                   Boss2Portrait_01.Visible = false; ;
                   ShowSession("「時はこの「場」に留まった！」", 3, "mix_01");

               }
               if (SessionIndex == 14 && Continue.Visible ==true)
               {
                   Audio.BGMResume();
                   isTimeStop = true;
                   MixBossPortrait_01.Visible = false;
                
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
               }
               //进入时间停止1画面回到主角（主角说话）
               if (SessionIndex == 15 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                   isGotoTimeStop2HeroTalk = false;
                   //Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   HeroTalkPortrait_03.Visible = true;
                   ShowSession("「・・・！」", 2, "HeroTalk_01");

               }
               if(SessionIndex==15&&Continue.Visible==true)
               {
                  
                   Audio.BGMResume();
                   isTimeStop = false;
                     Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   HeroTalkPortrait_03.Visible = false;
               }
               //进入时间停止2前一刻（boss说）60%
               if (SessionIndex == 16 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                  // Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   Boss1Portrait_01.Visible = true;
                   ShowSession("「相対速度測定（そうたいそくどそくてい）！」", 5, "imo_08");

               }
               if (SessionIndex == 17 && Continue.SPX == 0)
               {

                   Boss2Portrait_01.Visible = true;
                   Boss1Portrait_01.Visible = false;
                   ShowSession("「座標恒等変換（ざひょうこうとうへんかん）！」", 5, "ane_08");

               }
               if (SessionIndex == 18 && Continue.SPX == 0)
               {
                   isGotoHP60Talk = false;
                   Boss2Portrait_01.Visible = false;
                   MixBossPortrait_01.Visible = true;
                   ShowSession("「時はこの「場」に留まった！」", 4, "mix_01");

               }
               if (SessionIndex == 18 && Continue.Visible == true)
               {
                   Audio.BGMResume();
                   isTimeStop2 = true;
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   MixBossPortrait_01.Visible = false;
               }
               //进入时间停止3前一刻（boss说） Hp50%
               if (SessionIndex == 19 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                   //Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   Boss1Portrait_01.Visible = true;
                   ShowSession("「相対速度測定（そうたいそくどそくてい）！」", 5, "imo_08");

               }
               if (SessionIndex == 20 && Continue.SPX == 0)
               {

                   Boss2Portrait_01.Visible = true;
                   Boss1Portrait_01.Visible = false;
                   ShowSession("「座標恒等変換（ざひょうこうとうへんかん）！」", 5, "ane_08");

               }
               if (SessionIndex == 21 && Continue.SPX == 0)
               {

                   isGotoHP50Talk = false;
                   Boss2Portrait_01.Visible = false;
                   MixBossPortrait_01.Visible = true;
                   ShowSession("「時はこの「場」に留まった！」", 4, "mix_01");

               }
               if (SessionIndex == 21 && Continue.Visible==true)
               {
                   Audio.BGMResume();
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   MixBossPortrait_01.Visible = false;
                   //进入时间停止3
                   isTimeStop = true;
                   isTimeStop3 = true;
                   isGotoTimeStop3NpcTalk = true;

               }
              //山下来前一刻
               if (SessionIndex == 22 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                   isGotoTimeStop3NpcTalk = true;
                  // Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   npc1Portrait.Visible = true;
                   ShowSession("「さすが、数万年の繁栄を誇った、地上最初の霊長類と言われる超人種族『ソルムンデ』の末裔。時間停止くらいはお手のものだな。でも・・・」", 20, "NpcTalk_01");
               }
               if (SessionIndex == 23 && Continue.SPX == 0)
               {
                   ShowSession("「怪我人相手にそんなものを持ち出しなんて、フェアじゃないわ」", 8, "NpcTalk_02"); 
               }
               if (SessionIndex == 24 && Continue.SPX == 0)
               {
                   ShowSession("「完壁な術というのは、それだけ脆い。静止質量を消したというのなら、そうだな、ここは・・・」", 12, "NpcTalk_03");
               }
               if (SessionIndex == 25 && Continue.SPX == 0)
               {
                   

                   ShowSession("「お二人にびったりの長白山（ちょうはくさん）でも贈ろう。あのサルですら背負うのは精々三つの山までだけど、『ソルムンデ』はどれくらい耐えられるのかな？」", 25, "NpcTalk_04");
               }
               //if (SessionIndex == 25 && Continue.Visible == true)
               //{
               //    Audio.BGMResume();
               //  //  Continue.Visible = false;
               //    TalkBackGround.Visible = false;
               //    TalkBox.Visible = false;
               //    npc1Portrait.Visible = false;
               //    //山开始下来
               //    isStartHillDown = true;


               //}
               //山下来后
               if (SessionIndex == 26 && Continue.SPX == 0)
               {
                   //Audio.BGMPause();
                  // isGotoTimeStop3HillDownTalk = false;
                   isStartHillDown = true;
                   Continue.Visible =true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   npc1Portrait.Visible = true;
                   ShowSession("「これでよし。超人といえと物理法則を守ることだ」", 10, "NpcTalk_05");
                  
               }
               //if (SessionIndex == 26 && Continue.Visible == true)
               //{
               //    Audio.BGMResume();
               //    Continue.Visible = false;
               //    TalkBackGround.Visible = false;
               //    TalkBox.Visible = false;
               //    npc1Portrait.Visible = false;
               //}
               //红消失后
               if (SessionIndex == 27 && Continue.SPX == 0)
               {
                   //Audio.BGMPause();
                   //Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   Boss1Portrait_03.Visible = true;
                   npc1Portrait.Visible = false;
                   ShowSession("「・・・ッ！姉ちゃん！スピードが落ちて行くよ！」", 5, "imo_09");
               }
               if (SessionIndex == 28 && Continue.SPX == 0)
               {                 
                   Boss2Portrait_03.Visible = true;
                   Boss1Portrait_03.Visible = false;
                   ShowSession("「何者？わたしたちの時空変換を干渉できるなんで・・・」", 5, "ane_08");
               }
               if (SessionIndex == 29 && Continue.SPX == 0)
               {
                   Boss2Portrait_03.Visible = true;
                   Boss1Portrait_03.Visible = false;
                   ShowSession("「まさか、これは移山法？！」", 4, "ane_09");
               }
               if (SessionIndex == 30 && Continue.SPX == 0)
               {

                   //isGotoTimeStop3HillDownTalk = false;
                   isGotoTimeStop3RedDisappear = false;
                   Boss2Portrait_03.Visible = false;
                   Boss1Portrait_03.Visible = true;
                   ShowSession("「馬鹿な！何処の仙人か知らないけどそんなチンケな術でわたしたちを止めるわけが・・・ぎゃぁ！」", 8, "imo_10");
               }
               if (SessionIndex == 30 && Continue.Visible == true)
               {
                   isGotoTimeStop3HillDownTalk = false;
                   Audio.BGMResume();
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   Boss1Portrait_03.Visible = false;
               }
              //当Boss扣血到第四段时 25%
               if (SessionIndex == 31 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                   //Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   Boss1Portrait_03.Visible = true;
                   ShowSession("「ぐっ！姉ちゃん！アレをもう一度できない？」", 5, "imo_11");
               }
               if (SessionIndex == 32 && Continue.SPX == 0)
               {

                   Boss2Portrait_03.Visible = true;
                   Boss1Portrait_03.Visible = false;
                   ShowSession("「やってるわ、やってるけど・・・だめ、体が重い、速度が上がらない！」", 5, "ane_10");
               }
               if (SessionIndex == 33 && Continue.SPX == 0)
               {

                   Boss2Portrait_03.Visible = false;
                   Boss1Portrait_03.Visible = true;
                   ShowSession("「チッ！質量がどんどん増えている・・・一体誰だよ！子猫ちゃんの手助けしたのは！姿を現しなさいよ！」", 5, "imo_12");
               }
               if (SessionIndex == 34 && Continue.SPX == 0)
               {
                   isGotoHP25Talk = false;
                   Boss2Portrait_03.Visible = true;
                   Boss1Portrait_03.Visible = false;
                   ShowSession("「このままでは・・・」", 5, "ane_11");
               }
               if (SessionIndex == 34&& Continue.Visible == true)
               {
                   Audio.BGMResume();
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   Boss2Portrait_03.Visible = false;
               }
               //Boss的HP扣完后
               if (SessionIndex == 35 && Continue.SPX == 0)
               {
                   Audio.BGMPause();
                   isGotoHP0Talk = false;
                   //Continue.Visible = true;
                   TalkBackGround.Visible = true;
                   TalkBox.Visible = true;
                   MixBossPortrait_03.Visible = true;
                   ShowSession("「う、うきゃぁぁぁ」", 5, "mix_02");
               }
               if (SessionIndex == 35 && Continue.Visible == true)
               {
                   Audio.BGMResume();
                   Continue.Visible = false;
                   TalkBackGround.Visible = false;
                   TalkBox.Visible = false;
                   MixBossPortrait_03.Visible = false;
               }

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
           #endregion
           #region 显示对话与播放声音
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
                       
                       
                    }
                }
            }
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
            ShowSessionTime = (time * 40) / SessionLength;
            isShowSession = true;
            Continue.SPX = 1;
            Audio.SEPlay(name);
           // Audio.BGMPlay(name, false);
        }
           #endregion

     }
 }

