using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Game {

        //カードをめくる OpenCard
        //クリックされたカードのObverseをtrueにする


        //一致判定 CheckMatchCards
        //同じ数字だった場合
        //  ターンプレイヤーのOwnCardsを＋2
        //  ターンを続行
        //  ゲーム終了判定を行う
        //違う数字だった場合、
        //  少し待ってからCardのObverseをfalseに
        //  手番を次に回す


        //手番を次に回す NextTurn
        //手番のプレイヤー番号 = プレイヤー数の場合
        //  1を返す
        //手番のプレイヤー番号 < プレイヤー数の場合
        //  手番のプレイヤー番号+1を返す


        //ゲーム終了判定 GameEndJudge
        //同じ数字だった場合に判定
        //  全てのCardのObverseがtrue
        //もしくは
        //  全てのプレイヤーのOwnCardsの合計が52
        //      の場合、勝者判定を行う


        //勝者判定 WinnerJudge
        //ゲーム終了時に判定
        //  同率が3人いる場合
        //      同率が2人いる場合
        //          単独勝利
        //の順に判定
    }
}
