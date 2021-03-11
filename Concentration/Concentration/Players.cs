using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Players {

        private List<Player> FPlayers;

        /// <summary>
        /// 誰の手番か
        /// </summary>
        public int Turn { get; set; }

        /// <summary>
        /// プレイヤー数だけPlayerインスタンスを作成
        /// </summary>
        /// <param name="vPlayerNum"></param>
        public void MakePlayers(int vPlayerNum) {
            for (int i = 1; i <= vPlayerNum; i++) {
                FPlayers.Add(new Player { Id = i, Name = "プレイヤー" + i, OwnCards = 0 });
            }
        }

        /// <summary>
        /// 入力された各プレイヤー名を各Player.Nameにセット
        /// </summary>
        /// <param name="vNames"></param>
        public void SetPlayersName(List<string> vNames) {
            for (int i = 0; i < vNames.Count; i++) {
                FPlayers[i].Name = vNames[i];
            }
        }

        //手番を次に回す NextTurn
        public int NextTurn(int vTurn) {
            //一致判定がfalseの場合
            //  手番のプレイヤー番号 = プレイヤー数の場合
            //      1を返す　
            //  手番のプレイヤー番号 < プレイヤー数の場合
            //      手番のプレイヤー番号+1を返す
        }

        //勝者判定 JudgeWinner
        public List<Player> JudgeWinner(List<Player> vPlayers) {
            //ゲーム終了フラグtrue時に判定
            //  同率が3人いる場合
            //      同率が2人いる場合
            //          単独勝利
            //の順に判定
        }

        //取得枚数加算 Plus
        public int Plus(int vTurnPlayerCardNum) {
            //一致判定がtrueの場合
            //  ターンプレイヤーのOwnCardsを＋2
        }


    }
}
