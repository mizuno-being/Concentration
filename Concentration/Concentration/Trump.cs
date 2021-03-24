using System;
using System.Collections.Generic;

/// <summary>
/// 神経衰弱
/// </summary>
namespace Concentration {

    /// <summary>
    /// トランプを作成する
    /// </summary>
    public class Trump {

        /// <summary>
        /// カードの束
        /// </summary>
        public List<Card> Deck { get; set; }

        /// <summary>
        /// カード52枚でデッキ作成
        /// </summary>
        public void MakeDeck(int vSuit, int vRank) {
            this.Deck = new List<Card>();
            for (int s = 0; s < vSuit; s++) {
                for (int r = 1; r < vRank + 1; r++) {
                    this.Deck.Add(new Card { Suit = s, Rank = r, IsObverse = false });
                }
            }
        }

        /// <summary>
        /// シャッフル
        /// </summary>
        public void Shuffle() {
            Random wRandom = new Random();
            int x = this.Deck.Count;
            while (x > 1) {
                x--;
                int y = wRandom.Next(x + 1);
                Card z = this.Deck[y];
                this.Deck[y] = this.Deck[x];
                this.Deck[x] = z;
            }
        }

        /// <summary>
        /// クリックされたカードの位置の記憶
        /// </summary>
        public List<int> ClickCard { get; set; }

        /// <summary>
        /// クリックされたカードの位置を追加
        /// </summary>
        public void ClickCardCount(int vClickCard) => this.ClickCard.Add(vClickCard);
    }
}




