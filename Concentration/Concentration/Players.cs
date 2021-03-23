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
            this.PlayersList = new List<Player>();
            for (int i = 1; i <= vPlayerNum; i++) {
                this.PlayersList.Add(new Player { Id = i, Name = "プレイヤー" + i, OwnCards = 0 });
            }
        }

        /// <summary>
        /// 入力された各プレイヤー名を各Player.Nameにセット
        /// </summary>
        /// <param name="vNames"></param>
        public void SetPlayersName(List<string> vNames) {
            if (vNames.Count > 0)
                for (int i = 0; i < vNames.Count; i++) {
                    this.PlayersList[i].Name = vNames[i];
                }
        }

        /// <summary>
        /// 手番を次に回す
        /// </summary>
        /// <param name="vTurn"></param>
        /// <param name="vPlayerNum"></param>
        public void NextTurn(int vTurn, int vPlayerNum) {
            if (vTurn == vPlayerNum - 1) {
                this.Turn = 0;
            }
            if (vTurn < vPlayerNum - 1) {
                this.Turn = vTurn + 1;
            }
        }

        /// <summary>
        /// 勝者判定
        /// </summary>
        /// <returns></returns>
        public List<Player> JudgeWinner() {
            List<Player> wWinners = new List<Player>();
            //単独勝利
            List<Player> wSortedPlayersList = this.PlayersList.OrderByDescending(x => x.OwnCards).ToList();
            if (wSortedPlayersList[0].OwnCards > wSortedPlayersList[1].OwnCards) {
                wWinners.Add(wSortedPlayersList[0]);
                return wWinners;
            }
            //      同率が2人いる場合
            if (wSortedPlayersList[0].OwnCards == wSortedPlayersList[1].OwnCards) {
                //プレイヤー数が2人の場合
                if (wSortedPlayersList.Count == 2) {
                    wWinners.Add(wSortedPlayersList[0]);
                    wWinners.Add(wSortedPlayersList[1]);
                    return wWinners;
                } 
                if (wSortedPlayersList[1].OwnCards > wSortedPlayersList[2].OwnCards) {
                    wWinners.Add(wSortedPlayersList[0]);
                    wWinners.Add(wSortedPlayersList[1]);
                    return wWinners;
                }
                
            }
            //          同率が3人いる場合
            if (wSortedPlayersList[0].OwnCards == wSortedPlayersList[1].OwnCards && wSortedPlayersList[1].OwnCards == wSortedPlayersList[2].OwnCards) {
                wWinners.Add(wSortedPlayersList[0]);
                wWinners.Add(wSortedPlayersList[1]);
                wWinners.Add(wSortedPlayersList[2]);
                return wWinners;
            }
            //の順に判定
            return wWinners;
        }

        /// <summary>
        /// 取得枚数加算
        /// </summary>
        /// <param name="vPlayer"></param>
        public void Plus(Player vPlayer) => vPlayer.OwnCards += 2;
    }
}
