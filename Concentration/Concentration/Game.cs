using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 神経衰弱
/// </summary>
namespace Concentration {

    /// <summary>
    /// ゲームルールに関わる操作を行う
    /// </summary>
    public class Game {

        /// <summary>
        /// ゲーム終了フラグ
        /// </summary>
        public bool IsGameEnd { get; private set; }

        /// <summary>
        /// 一致判定
        /// </summary>
        public bool IsMatchCards(Card vFirstCard, Card vSecondCard) => vFirstCard.Rank == vSecondCard.Rank;

        /// <summary>
        /// カードをめくる
        /// </summary>
        public void OpenCard(Card vCard) => vCard.IsObverse = true;

        /// <summary>
        /// カードを裏返す
        /// </summary>
        public void CloseCard(Card vFirstCard, Card vSecondCard) {
            vFirstCard.IsObverse = false;
            vSecondCard.IsObverse = false;
        }

        /// <summary>
        /// ゲーム終了判定
        /// </summary>
        public void SetGameEnd(List<Card> vDeck) {
            if (vDeck.All(x=>x.IsObverse)) {
                this.IsGameEnd = true;
            } else {
                this.IsGameEnd = false;
            }
        }
    }
}
