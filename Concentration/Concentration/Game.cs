using System.Collections.Generic;
using System.Threading;

/// <summary>
/// 神経衰弱
/// </summary>
namespace Concentration {

    /// <summary>
    /// ゲームルールに関わる操作を行う
    /// </summary>
    public class Game {

        /// <summary>
        /// 一致判定
        /// </summary>
        /// <param name="vFirstCard"></param>
        /// <param name="vSecondCard"></param>
        /// <returns></returns>
        public bool IsMatchCards(Card vFirstCard, Card vSecondCard) {
            if (vFirstCard.Rank == vSecondCard.Rank) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// カードをめくる
        /// </summary>
        /// <param name="vObverse"></param>
        /// <returns></returns>
        public bool IsOpenCard(bool vObverse) => true;

        /// <summary>
        /// カードを裏返す
        /// </summary>
        /// <param name="vCard"></param>
        /// <returns></returns>
        public bool IsCloseCard(Card vCard) {
            Thread.Sleep(300);
            return vCard.IsObverse = false;
        }

        /// <summary>
        /// ゲーム終了フラグ
        /// </summary>
        public bool IsGameEnd { get; set; }

        /// <summary>
        /// ゲーム終了判定
        /// </summary>
        /// <param name="vDeck"></param>
        public void JudgeGameEnd(List<Card> vDeck) {
            if (vDeck.Exists(x => x.IsObverse == false) == false) {
                this.IsGameEnd = true;
            } else {
                this.IsGameEnd = false;
            }
        }
    }
}
