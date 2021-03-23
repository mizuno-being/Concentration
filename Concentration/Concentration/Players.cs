using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Players {

        /// <summary>
        /// ゲームに参加しているプレイヤー
        /// </summary>
        public List<Player> PlayersList { get; set; }

        /// <summary>
        /// 誰の手番か
        /// </summary>
        public int Turn { get; set; }

        /// <summary>
        /// プレイヤー数だけPlayerインスタンスを作成
        /// </summary>
        /// <param name="vPlayerNum"></param>
        public void MakePlayers(int vPlayerNum) {
            PlayersList = new List<Player>();
            for (int i = 1; i <= vPlayerNum; i++) {
                PlayersList.Add(new Player { Id = i, Name = "プレイヤー" + i, OwnCards = 0 });
            }
        }

        /// <summary>
        /// 入力された各プレイヤー名を各Player.Nameにセット
        /// </summary>
        /// <param name="vNames"></param>
        public void SetPlayersName(List<string> vNames) {
            if (vNames.Count > 0)
                for (int i = 0; i < vNames.Count; i++) {
                    PlayersList[i].Name = vNames[i];
                }
        }

        //手番を次に回す NextTurn
        public void NextTurn(int vTurn, int vPlayerNum) {
            //  手番のプレイヤー番号 = プレイヤー数の場合
            //      0を返す　
            //  手番のプレイヤー番号 < プレイヤー数の場合
            //      手番のプレイヤー番号+1を返す

            if (vTurn == vPlayerNum -1) {
                Turn = 0;
            }
            if (vTurn < vPlayerNum -1) {
                Turn = vTurn + 1;
            }
        }

        //勝者判定 JudgeWinner
        public List<Player> JudgeWinner() {
            //ゲーム終了フラグtrue時に判定
            //  同率が3人いる場合
            //      同率が2人いる場合
            //          単独勝利
            //の順に判定
            List<Player> Kari = new List<Player>();
            return Kari;
        }

        //取得枚数加算 Plus
        public void Plus(Player vPlayer) {
            //一致判定がtrueの場合
            //  ターンプレイヤーのOwnCardsを＋2
            vPlayer.OwnCards += 2;
        }
    }
}
