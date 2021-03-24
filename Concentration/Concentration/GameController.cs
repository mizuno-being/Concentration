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

        public Game Game;
        public Trump Trump;
        public Players Players;
        private GameForm FGameForm;
        public List<Player> WinPlayers;
        public int PlayerNum;
        public List<string> FPlayerNames;

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
            Game = new Game();
            Trump = new Trump();
            Players = new Players();
            Trump.ClickCard = new List<int>();
            WinPlayers = new List<Player>();
            PlayerNum = new int();
            PlayerNum = 4;
            Players.Turn = 0;
            Trump.MakeDeck(C_Suit, C_Rank);
            ShuffleDeck();
            Players.MakePlayers(PlayerNum);
            FPlayerNames = new List<string>(PlayerNum);
            Players.SetPlayersName(FPlayerNames);
        }

        /// <summary>
        /// デッキをシャッフル
        /// </summary>
        public void ShuffleDeck() => Trump.Shuffle();

        /// <summary>
        /// カードをめくる
        /// </summary>
        public void OpenCard(int vCardTag) {

            Trump.ClickCardCount(vCardTag);
            Trump.Deck[vCardTag].IsObverse = true;
            FGameForm.RefreshCards(Trump.Deck);
            if (Trump.ClickCard.Count == 2) {
                bool wCheckMatch = Game.IsMatchCards(Trump.Deck[Trump.ClickCard[0]], Trump.Deck[Trump.ClickCard[1]]);
                if (wCheckMatch) {
                    Players.PlusCardNum(Players.PlayersList[Players.Turn]);
                    FGameForm.RefreshMatchCardsNum(Players.PlayersList[Players.Turn].OwnCards, Players.Turn);
                    Game.JudgeGameEnd(Trump.Deck);
                    if (Game.IsGameEnd) {
                        Players.JudgeWinner();
                    }
                } else {
                    Game.CloseCard(Trump.Deck[Trump.ClickCard[0]], Trump.Deck[Trump.ClickCard[1]]);
                    Thread.Sleep(600);
                    Players.NextTurn(Players.Turn, PlayerNum);
                    FGameForm.RefreshTurnPlayer(Players.Turn);
                }
                Trump.ClickCard.Clear();
            }
            FGameForm.RefreshCards(Trump.Deck);
        }
        //reset
    }
}
