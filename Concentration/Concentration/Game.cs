using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concentration {
    public class Game {



        /// <summary>
        /// ゲーム終了フラグ
        /// </summary>
        public bool GameEnd { get; set; }

        /// <summary>
        /// 一致判定フラグ
        /// </summary>
        public bool CheckMatch { get; set; }

        //カードをめくる OpenCard
        public bool OpenCard(bool vObverse) => true;
            

        //一致判定 CheckMatchCards
        public bool CheckMatchCards(Card vFirstCard, Card vSecondCard) {
            if (vFirstCard.Rank == vSecondCard.Rank) {
                return true;
            }
            return false;
        }

        //カードを裏返す
        public bool CloseCard(Card vCard) {
            Thread.Sleep(300);
            return vCard.IsObverse = false;
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
