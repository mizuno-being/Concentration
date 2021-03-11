using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Game {

        //カードをめくる OpenCard
        public bool OpenCard(bool vObverse) {
            //クリックされたカードのObverseをtrueにする
        }

        //一致判定 CheckMatchCards
        public bool CheckMatchCards(Card vFirstCard, Card vSecondCard) {
            //同じ数字だった場合trueを返す
            //違う数字だった場合falseを返す
        }

        //取得枚数加算 Plus
        public int Plus(int vTurnPlayerCardNum) {
            //一致判定がtrueの場合
            //  ターンプレイヤーのOwnCardsを＋2
        }

        //カードを裏返す
        public bool CloseCard(bool vObverse) {
            //一致判定がfalseの場合
            //  少し待ってからCardのObverseをfalseに
        }

        //手番を次に回す NextTurn
        public int NextTurn(int vTurn) {
            //一致判定がfalseの場合
            //  手番のプレイヤー番号 = プレイヤー数の場合
            //      1を返す　
            //  手番のプレイヤー番号 < プレイヤー数の場合
            //      手番のプレイヤー番号+1を返す
        }

        //ゲーム終了判定 JudgeGameEnd
        public bool JudgeGameEnd(List<Card> vDeck) {
            //一致判定がtrueの場合
            //  全てのCardのObverseがtrue
            //      ゲーム終了フラグをtrueにする
        }

        //勝者判定 JudgeWinner
        public List<Player> JudgeWinner(List<Player> vPlayers) {
            //ゲーム終了フラグtrue時に判定
            //  同率が3人いる場合
            //      同率が2人いる場合
            //          単独勝利
            //の順に判定
        }
    }
}
