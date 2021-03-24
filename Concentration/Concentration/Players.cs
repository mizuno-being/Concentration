using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 神経衰弱
/// </summary>
namespace Concentration {

    /// <summary>
    ///プレイヤーに関する操作を行う
    /// </summary>
    public class Players {

        /// <summary>
        /// ゲームに参加しているプレイヤー
        /// </summary>
        public List<Player> PlayersList { get; set; }

        /// <summary>
        /// プレイヤー数だけPlayerインスタンスを作成
        /// </summary>
        public void MakePlayers(int vPlayerNum) {
            this.PlayersList = new List<Player>();
            for (int i = 1; i <= vPlayerNum; i++) {
                this.PlayersList.Add(new Player { Id = i, Name = "プレイヤー" + i, OwnCards = 0 });
            }
        }

        /// <summary>
        /// 入力された各プレイヤー名を各Player.Nameにセット
        /// </summary>
        public void SetPlayersName(List<string> vNames) {
            if (vNames.Count > 0)
                for (int i = 0; i < vNames.Count; i++) {
                    this.PlayersList[i].Name = vNames[i];
                }
        }

        /// <summary>
        /// 取得枚数加算
        /// </summary>
        public void PlusCardNum(Player vPlayer) => vPlayer.OwnCards += 2;

        /// <summary>
        /// 誰の手番か
        /// </summary>
        public int Turn { get; set; }

        /// <summary>
        /// 手番を次に回す
        /// </summary>
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
        public List<Player> JudgeWinner() {
            List<Player> wWinners = new List<Player>();
            List<Player> wSortedOwnCards = this.PlayersList.OrderByDescending(x => x.OwnCards).ToList();
            if (wSortedOwnCards[0].OwnCards > wSortedOwnCards[1].OwnCards) {
                wWinners.Add(wSortedOwnCards[0]);
                return wWinners;
            }
            if (wSortedOwnCards[0].OwnCards == wSortedOwnCards[1].OwnCards) {
                if (wSortedOwnCards.Count == 2) {
                    wWinners.Add(wSortedOwnCards[0]);
                    wWinners.Add(wSortedOwnCards[1]);
                    return wWinners;
                }
                if (wSortedOwnCards[1].OwnCards > wSortedOwnCards[2].OwnCards) {
                    wWinners.Add(wSortedOwnCards[0]);
                    wWinners.Add(wSortedOwnCards[1]);
                    return wWinners;
                }
            }
            if (wSortedOwnCards[0].OwnCards == wSortedOwnCards[1].OwnCards && wSortedOwnCards[1].OwnCards == wSortedOwnCards[2].OwnCards) {
                wWinners.Add(wSortedOwnCards[0]);
                wWinners.Add(wSortedOwnCards[1]);
                wWinners.Add(wSortedOwnCards[2]);
                return wWinners;
            }
            return wWinners;
        }
    }
}
