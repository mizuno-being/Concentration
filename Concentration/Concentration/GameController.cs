using System.Collections.Generic;
using System.Threading;

/// <summary>
/// 神経衰弱
/// </summary>
namespace Concentration {

    /// <summary>
    /// コントローラー
    /// </summary>
    public class GameController {

        /// <summary>
        /// Game
        /// </summary>
        public Game Game { get; private set; }

        /// <summary>
        /// Trump
        /// </summary>
        public Trump Trump { get; private set; }

        /// <summary>
        /// Players
        /// </summary>
        public Players Players { get; private set; }

        /// <summary>
        /// プレイヤーの人数
        /// </summary>
        public int PlayerNum { get; private set; }

        /// <summary>
        /// プレイヤーの名前
        /// </summary>
        public List<string> PlayerNames { get; private set; }

        private GameForm FGameForm;

        /// <summary>
        /// スートの数
        /// </summary>
        public const int C_Suit = 2;

        /// <summary>
        /// 数字の上限
        /// </summary>
        public const int C_Rank = 8;

        /// <summary>
        /// スタート時呼び出し
        /// </summary>
        public GameController(GameForm fForm) {
            FGameForm = fForm;
            this.Game = new Game();
            this.Trump = new Trump();
            this.Players = new Players();
            this.PlayerNum = 4;
            this.Players.TurnPlayerNum = 0;
            this.Trump.ClickCard = new List<int>();
            this.Trump.MakeDeck(C_Suit, C_Rank);
            //ShuffleDeck();
            this.Players.MakePlayers(this.PlayerNum);
            this.PlayerNames = new List<string>(this.PlayerNum);
            this.Players.SetPlayersName(this.PlayerNames);
        }

        /// <summary>
        /// デッキをシャッフル
        /// </summary>
        public void ShuffleDeck() => this.Trump.Shuffle();

        /// <summary>
        /// カードをめくる
        /// </summary>
        public void OpenCard(int vCardTag) {

            this.Trump.ClickCard.Add(vCardTag);
            this.Game.OpenCard(this.Trump.Deck[vCardTag]);
            FGameForm.RefreshCards(this.Trump.Deck);
            if (this.Trump.ClickCard.Count == 2) {
                if (this.Game.IsMatchCards(this.Trump.Deck[this.Trump.ClickCard[0]], this.Trump.Deck[this.Trump.ClickCard[1]])) {
                    this.Players.PlusCardNum(this.Players.TurnPlayerNum);
                    FGameForm.RefreshMatchCardsNum(this.Players.PlayersList[this.Players.TurnPlayerNum].OwnCardCount, this.Players.TurnPlayerNum);
                    this.Game.SetGameEnd(this.Trump.Deck);
                    if (this.Game.IsGameEnd) {
                        
                        string wWinMessage = $"{this.Players.SetWinners[0].Name}の勝ち!!";
                        if (this.Players.SetWinners.Count == 2) {
                            if (this.PlayerNum == 2) {
                                wWinMessage = $"引き分け!!";
                            } else {
                                wWinMessage = $"{this.Players.SetWinners[0].Name}と{this.Players.SetWinners[1].Name}の勝ち!!";
                            }
                        }
                        if (this.Players.SetWinners.Count == 3) {
                            wWinMessage = $"{this.Players.SetWinners[0].Name}と{this.Players.SetWinners[1].Name}と{this.Players.SetWinners[2].Name}の勝ち!!";
                        }
                        FGameForm.WinMessage = wWinMessage;
                    }
                } else {
                    this.Game.CloseCard(this.Trump.Deck[this.Trump.ClickCard[0]], this.Trump.Deck[this.Trump.ClickCard[1]]);
                    Thread.Sleep(600);
                    this.Players.NextTurn(this.PlayerNum);
                    FGameForm.RefreshTurnPlayer(this.Players.TurnPlayerNum);
                }
                this.Trump.ClickCard.Clear();
            }
            FGameForm.RefreshCards(this.Trump.Deck);
        }
        //reset
    }
}
