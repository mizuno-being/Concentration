using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Trump {

        public List<Card> FDeck;

        /// <summary>
        /// カード52枚でデッキ作成
        /// </summary>
        /// <returns></returns>
        public void MakeDeck(int vSuit, int vRank) {
            FDeck = new List<Card>();
            for (int s = 0; s < vSuit; s++) {
                for (int r = 1; r < vRank+1; r++) {
                    FDeck.Add( new Card { Suit = s, Rank = r, IsObverse = false });
                }
            }
        }

        /// <summary>
        /// シャッフル
        /// </summary>
        /// <returns></returns>
        public void Shuffle() {

            Random wRandom = new Random();

            int x = FDeck.Count;

            while (x > 1) {
                x--;
                int y = wRandom.Next(x + 1);
                Card z = FDeck[y];
                FDeck[y] = FDeck[x];
                FDeck[x] = z;
            }

            //List<Card> wShuffleDeck = Deck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// 配置
        /// </summary>

    }
}




