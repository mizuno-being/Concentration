using System.Collections.Generic;
using System.Threading;

namespace Concentration {
    public class Game {

        /// <summary>
        /// ゲーム終了フラグ
        /// </summary>
        public bool GameEnd { get; set; }

        /// <summary>
        /// カードをめくる
        /// </summary>
        /// <param name="vObverse"></param>
        /// <returns></returns>
        public bool OpenCard(bool vObverse) => true;
            
        /// <summary>
        /// 一致判定
        /// </summary>
        /// <param name="vFirstCard"></param>
        /// <param name="vSecondCard"></param>
        /// <returns></returns>
        public bool CheckMatchCards(Card vFirstCard, Card vSecondCard) {
            if (vFirstCard.Rank == vSecondCard.Rank) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// カードを裏返す
        /// </summary>
        /// <param name="vCard"></param>
        /// <returns></returns>
        public bool CloseCard(Card vCard) {
            Thread.Sleep(300);
            return vCard.IsObverse = false;
        }

        /// <summary>
        /// ゲーム終了判定
        /// </summary>
        /// <param name="vDeck"></param>
        public void JudgeGameEnd(List<Card> vDeck) {
            if ((vDeck.Exists(x=>x.IsObverse==false)) == false) {
                this.GameEnd = true;
            } else {
                this.GameEnd = false;
            }
            
        }
    }
}
