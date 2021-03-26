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
        public List<Player> PlayersList { get; private set; }

        /// <summary>
        /// 勝者判定
        /// </summary>
        public List<Player> Winners => this.PlayersList.GroupBy(x => x.OwnCardCount).OrderByDescending(x => x.Key).First().ToList();

        /// <summary>
        /// 誰の手番か
        /// </summary>
        public int TurnPlayerNum { get; set; }

        /// <summary>
        /// プレイヤー数だけPlayerインスタンスを作成
        /// </summary>
        public void MakePlayers(int vPlayerNum) {
            this.PlayersList = new List<Player>();
            for (int i = 1; i <= vPlayerNum; i++) {
                this.PlayersList.Add(new Player { Id = i, Name = "プレイヤー" + i, OwnCardCount = 0 });
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
        public void PlusCardNum(int vTurnPlayerNum) => this.PlayersList[vTurnPlayerNum].OwnCardCount += 2;

        /// <summary>
        /// 手番を次に回す
        /// </summary>
        public void NextTurn(int vPlayerNum) {
            if (this.TurnPlayerNum == vPlayerNum - 1) {
                this.TurnPlayerNum = 0;
            } else if (this.TurnPlayerNum < vPlayerNum - 1) {
                this.TurnPlayerNum++;
            }
        }
    }
}
