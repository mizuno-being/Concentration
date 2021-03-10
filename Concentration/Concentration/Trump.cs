using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Trump {

        /// <summary>
        /// カード52枚でデッキ作成
        /// </summary>
        /// <returns></returns>
        public List<Card> MakeDeck() {

            List<Card> wDeck = new List<Card>();

            for (int s = 0; s < 4; s++) {
                for (int r = 1; r < 14; r++) {
                    wDeck.Add( new Card { Suit = s, Rank = r, IsObverse = false });
                }
            }
            return wDeck;
        }


        /// <summary>
        /// シャッフル
        /// </summary>
        /// <param name="vDeck"></param>
        /// <returns></returns>
        public List<Card> Shuffle(List<Card> vDeck) {

            Random wRandom = new Random();

            int x = vDeck.Count;

            while (x > 1) {
                x--;
                int y = wRandom.Next(x + 1);
                Card z = vDeck[y];
                vDeck[y] = vDeck[x];
                vDeck[x] = z;
            }

            //List<Card> wShuffleDeck = Deck.OrderBy(x => Guid.NewGuid()).ToList();
            return vDeck;
        }

        /// <summary>
        /// 配置
        /// </summary>

    }
}




