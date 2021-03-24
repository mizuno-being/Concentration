using System.Collections.Generic;

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

        /// <summary>
        /// スタート時呼び出し
        /// </summary>
        /// <param name="fForm"></param>
        public GameController(GameForm fForm) {
            FGameForm = fForm;
            Game = new Game();
            Trump = new Trump();
            Players = new Players();
            Trump.ClickCard = new List<int>();
            PlayerNum = new int();
            Players.Turn = 0;
            MakeDeck();
            ShuffleDeck();
            TakePlayerNum();
            MakePlayers();
            SetPlayersName();
        }

        /// <summary>
        /// ゲームスタート
        /// </summary>
        private void GameStart() {
            Players.Turn = 0;
        }

        public int PlayerNum;

        /// <summary>
        /// プレイヤー数の決定
        /// </summary>
        private void TakePlayerNum() => PlayerNum = 4;

        /// <summary>
        /// プレイヤー数だけPlayerインスタンスを作成
        /// </summary>
        private void MakePlayers() => Players.MakePlayers(PlayerNum);

        public List<string> FPlayerNames;

        /// <summary>
        /// プレイヤー名を各Player.Nameにセット
        /// </summary>
        private void SetPlayersName() {
            FPlayerNames = new List<string>(PlayerNum);
            Players.SetPlayersName(FPlayerNames);
        }

        /// <summary>
        /// スートの数
        /// </summary>
        public const int C_Suit = 4;

        /// <summary>
        /// 数字の上限
        /// </summary>
        public const int C_Rank = 13;

        /// <summary>
        /// 52枚のカードの束を作成
        /// </summary>
        private void MakeDeck() => Trump.MakeDeck(C_Suit, C_Rank);

        /// <summary>
        /// デッキをシャッフル
        /// </summary>
        public void ShuffleDeck() => Trump.Shuffle();

        /// <summary>
        /// カードをめくる
        /// </summary>
        /// <param name="vCardTag"></param>
        public void OpenCard(int vCardTag) {

            Trump.ClickCardCount(vCardTag);
            Trump.Deck[vCardTag].IsObverse = Game.IsOpenCard(Trump.Deck[vCardTag].IsObverse);
            FGameForm.RefreshCards(Trump.Deck);
            if (Trump.ClickCard.Count == 2) {
                bool wCheckMatch = IsMatchCards(Trump.ClickCard[0], Trump.ClickCard[1]);
                if (wCheckMatch) {
                    PlusCard();
                    FGameForm.RefreshMatchCardsNum(Players.PlayersList[Players.Turn].OwnCards, Players.Turn);
                    GameEnd();
                    if (Game.IsGameEnd) {
                        GameWinners();
                    }
                } else {
                    CloseCard(Trump.ClickCard[0], Trump.ClickCard[1]);
                    NextTurn();
                    FGameForm.RefreshTurnPlayer(Players.Turn);
                }
                Trump.ClickCard.Clear();
            }
            FGameForm.RefreshCards(Trump.Deck);
        }

        /// <summary>
        /// 一致判定
        /// </summary>
        /// <param name="vFirstCard"></param>
        /// <param name="vSecondCard"></param>
        /// <returns></returns>
        private bool IsMatchCards(int vFirstCard, int vSecondCard) => Game.IsMatchCards(Trump.Deck[vFirstCard], Trump.Deck[vSecondCard]);

        /// <summary>
        /// 取得枚数加算
        /// </summary>
        private void PlusCard() => Players.PlusCardNum(Players.PlayersList[Players.Turn]);

        /// <summary>
        /// 終了判定
        /// </summary>
        private void GameEnd() => Game.JudgeGameEnd(Trump.Deck);

        /// <summary>
        /// カードを裏返す
        /// </summary>
        /// <param name="vFirstOpenCard"></param>
        /// <param name="vSecondOpenCard"></param>
        private void CloseCard(int vFirstOpenCard, int vSecondOpenCard) {
            Trump.Deck[vFirstOpenCard].IsObverse = Game.IsCloseCard(Trump.Deck[vFirstOpenCard]);
            Trump.Deck[vSecondOpenCard].IsObverse = Game.IsCloseCard(Trump.Deck[vSecondOpenCard]);
        }

        /// <summary>
        /// 手番を次に回す
        /// </summary>
        private void NextTurn() => Players.NextTurn(Players.Turn, PlayerNum);

        public List<Player> WinPlayers;

        /// <summary>
        /// 勝者判定
        /// </summary>
        private void GameWinners() {
            WinPlayers = new List<Player>();
            this.WinPlayers = Players.JudgeWinner();
        }

        //reset
    }
}
