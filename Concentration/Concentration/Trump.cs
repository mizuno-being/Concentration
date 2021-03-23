using System;
using System.Collections.Generic;

namespace Concentration {
    public class Trump {

        /// <summary>
        /// カードの束
        /// </summary>
        public List<Card> Deck { get; set; }

        /// <summary>
        /// カード52枚でデッキ作成
        /// </summary>
        /// <returns></returns>
        public void MakeDeck(int vSuit, int vRank) {
            this.Deck = new List<Card>();
            for (int s = 0; s < vSuit; s++) {
                for (int r = 1; r < vRank+1; r++) {
                    this.Deck.Add( new Card { Suit = s, Rank = r, IsObverse = false });
                }
            }
        }

        /// <summary>
        /// シャッフル
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        public List<int> ClickCard { get; set; }

        /// <summary>
        /// クリックされたカードの追加
        /// </summary>
        /// <param name="vClickCard"></param>
        public void ClickCardCount(int vClickCard) => this.ClickCard.Add(vClickCard);
    }
}




