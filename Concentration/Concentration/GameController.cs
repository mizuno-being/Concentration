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
        public const int C_Suit = 4;

        /// <summary>
        /// 数字の上限
        /// </summary>
        public const int C_Rank = 13;

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
            this.Trump.ClickCard = new List<Card>();
            this.Trump.MakeDeck(C_Suit, C_Rank);
            ShuffleDeck();
            this.Players.MakePlayers(this.PlayerNum);
        }

        /// <summary>
        /// デッキをシャッフル
        /// </summary>
        public void ShuffleDeck() => this.Trump.Shuffle();

        /// <summary>
        /// カードをめくる
        /// </summary>
        public void OpenCard(int vCardTag) {
            this.Trump.ClickCard.Add(this.Trump.Deck[vCardTag]);
            this.Game.OpenCard(this.Trump.Deck[vCardTag]);
            FGameForm.RefreshCards(this.Trump.Deck);
            if (this.Trump.ClickCard.Count == 2) {
                if (this.Game.IsMatchCards(this.Trump.ClickCard[0], this.Trump.ClickCard[1])) {
                    this.Players.PlusCardNum(this.Players.TurnPlayerNum);
                    FGameForm.RefreshMatchCardsNum(this.Players.PlayersList[this.Players.TurnPlayerNum].OwnCardCount, this.Players.TurnPlayerNum);
                    this.Game.SetGameEnd(this.Trump.Deck);
                    if (this.Game.IsGameEnd) {
                        List<Player> wWinnerList = this.Players.Winners;
                        string wWinMessage = "";
                        if (wWinnerList.Count == this.PlayerNum) {
                            wWinMessage = $"引き分け!!";
                        } else {
                            wWinnerList.ForEach(x => wWinMessage += $"{x.Name}\n");
                            wWinMessage += $"の勝ち!!";
                        }
                        FGameForm.WinMessage = wWinMessage;
                    }
                } else {
                    this.Game.CloseCard(this.Trump.ClickCard[0], this.Trump.ClickCard[1]);
                    Thread.Sleep(800);
                    this.Players.NextTurn(this.PlayerNum);
                    FGameForm.RefreshTurnPlayer(this.Players.TurnPlayerNum);
                    FGameForm.RefreshCards(this.Trump.Deck);
                }
                this.Trump.ClickCard.Clear();
            }
        }
    }
}
