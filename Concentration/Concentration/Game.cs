using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Game {


        /// <summary>
        /// ゲーム終了フラグ
        /// </summary>
        public bool GameEndFlag { get; set; }
        
        /// <summary>
        /// 一致判定フラグ
        /// </summary>
        public bool CheckMatchFlag { get; set; }

        //カードをめくる OpenCard
        public bool OpenCard(bool vObverse) {
            //クリックされたカードのObverseをtrueにする
            return true;
        }

        //一致判定 CheckMatchCards
        public bool CheckMatchCards(Card vFirstCard, Card vSecondCard) {
            //同じ数字だった場合trueを返す
            //違う数字だった場合falseを返す
            return false;
        }

        //カードを裏返す
        public bool CloseCard(bool vObverse) {
            //一致判定がfalseの場合
            //  少し待ってからCardのObverseをfalseに
            return false;
        }

        //ゲーム終了判定 JudgeGameEnd
        public bool JudgeGameEnd(List<Card> vDeck) {
            //一致判定がtrueの場合
            //  全てのCardのObverseがtrue
            //      ゲーム終了フラグをtrueにする
            return false;
        }
    }
}
