using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Game {

        //手番を次に回す
        //手番のプレイヤー番号 = プレイヤー数の場合
        //  1を返す
        //手番のプレイヤー番号 < プレイヤー数の場合
        //  手番のプレイヤー番号+1を返す


        //めくったカードの一致判定
        //同じ数字だった場合
        //  CardのObverseをtrueに
        //  ターンプレイヤーのOwnCardsを＋2
        //違う数字だった場合、
        //  少し待ってから裏側に戻る
        //  次のプレイヤーの手番に移る


        //ゲーム終了判定
        //同じ数字だった場合に判定
        //  全てのCardのObverseがtrue
        //もしくは
        //  全てのプレイヤーのOwnCardsの合計が52


        //勝者判定
        //ゲーム終了時に判定
        //  同率が3人いる場合
        //      同率が2人いる場合
        //          単独勝利
        //の順に判定
    }
}
