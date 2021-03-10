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

        //同じ数字だった場合
        //  ターンプレイヤーのOwnCardsを＋2
        //  ターンを続行
        //  ゲーム終了判定を行う
        //違う数字だった場合、
        //  少し待ってからCardのObverseをfalseに
        //  手番を次に回す


        //手番を次に回す NextTurn
        public int NextTurn(int vTurn) { }
        //手番のプレイヤー番号 = プレイヤー数の場合
        //  1を返す　
        //手番のプレイヤー番号 < プレイヤー数の場合
        //  手番のプレイヤー番号+1を返す


        //ゲーム終了判定 JudgeGameEnd

        //同じ数字だった場合に判定
        //  全てのCardのObverseがtrue
        //もしくは
        //  全てのプレイヤーのOwnCardsの合計が52
        //      の場合、ゲーム終了フラグをtrueにする


        //勝者判定 JudgeWinner

        //ゲーム終了フラグtrue時に判定
        //  同率が3人いる場合
        //      同率が2人いる場合
        //          単独勝利
        //の順に判定
    }
}
