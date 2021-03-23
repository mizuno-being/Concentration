using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concentration {
    public class GameController {

        public Game FGame;
        public Trump FTrump;
        public Players FPlayers;
        private Form1 FForm1;

        public GameController(Form1 fForm1) {
            FForm1 = fForm1;
            FGame = new Game();
            FTrump = new Trump();
            FPlayers = new Players();
            FTrump.ClickCard = new List<int>();
            FPlayers.Turn = 0;
            MakeDeck();
            //ShuffleDeck();
            TakePlayerNum();
            MakePlayers();
            SetPlayersName();
        }

        //(input)ゲームスタート
        public void GameStart() {
            FPlayers.Turn = 0;
        }
        //(input)プレイヤー数を受け取る

        public int FPlayerNum;
        public void TakePlayerNum() {
            FPlayerNum = new int();
            FPlayerNum = 2;
        }
        //(input)プレイヤー名を受け取る

        //(model)プレイヤー数だけPlayerインスタンスを作成
        public void MakePlayers() {
            FPlayers.MakePlayers(FPlayerNum);
        }
        public List<string> FPlayerNames;
        //(model)プレイヤー名を各Player.Nameにセット
        public void SetPlayersName() {
            FPlayerNames = new List<string>(FPlayerNum);
            FPlayers.SetPlayersName(FPlayerNames);
        }

        /// <summary>
        /// スートの数
        /// </summary>
        public const int C_Suit = 2;

        /// <summary>
        /// 数字の上限
        /// </summary>
        public const int C_Rank = 9;

        /// <summary>
        /// 52枚のカードの束を作成
        /// </summary>
        public void MakeDeck() => FTrump.MakeDeck(C_Suit, C_Rank);

        /// <summary>
        /// デッキをシャッフル
        /// </summary>
        public void ShuffleDeck() => FTrump.Shuffle();

        /// <summary>
        /// カードをめくる
        /// </summary>
        /// <param name="vCardTag"></param>
        public void OpenCard(int vCardTag) {

            FTrump.ClickCardCount(vCardTag);
            FTrump.Deck[vCardTag].IsObverse = FGame.OpenCard(FTrump.Deck[vCardTag].IsObverse);
            FForm1.RefreshCards(FTrump.Deck);
            if (FTrump.ClickCard.Count == 2) {
                if (FTrump.ClickCard[0] == FTrump.ClickCard[1]) {
                    FTrump.ClickCard.RemoveAt(1);
                    return;
                }
                bool wCheckMatch = CheckMatchCards(FTrump.ClickCard[0], FTrump.ClickCard[1]);
                if (wCheckMatch == true) {
                    FForm1.EnableCardButton(FTrump.ClickCard[0]);
                    FForm1.EnableCardButton(FTrump.ClickCard[1]);
                    PlusCard();
                    FForm1.RefreshMatchCardsNum(FPlayers.PlayersList[FPlayers.Turn].OwnCards, FPlayers.Turn);
                    GetGameEnd();
                    if (FGame.GameEnd == true) {
                        GetGameWinners();
                    }
                } else {
                    CloseCard(FTrump.ClickCard[0], FTrump.ClickCard[1]);
                    NextTurn();
                    FForm1.RefreshTurnPlayer(FPlayers.Turn);
                }
                FTrump.ClickCard.Clear();
            }
            FForm1.RefreshCards(FTrump.Deck);
        }

        /// <summary>
        /// 一致判定
        /// </summary>
        /// <param name="vFirstCard"></param>
        /// <param name="vSecondCard"></param>
        /// <returns></returns>
        public bool CheckMatchCards(int vFirstCard, int vSecondCard) => FGame.CheckMatchCards(FTrump.Deck[vFirstCard], FTrump.Deck[vSecondCard]);

        /// <summary>
        /// 取得枚数加算
        /// </summary>
        public void PlusCard() => FPlayers.Plus(FPlayers.PlayersList[FPlayers.Turn]);

        /// <summary>
        /// 終了判定
        /// </summary>
        public void GetGameEnd() => FGame.JudgeGameEnd(FTrump.Deck);

        /// <summary>
        /// カードを裏返す
        /// </summary>
        /// <param name="vFirstOpenCard"></param>
        /// <param name="vSecondOpenCard"></param>
        public void CloseCard(int vFirstOpenCard, int vSecondOpenCard) {

            FTrump.Deck[vFirstOpenCard].IsObverse = FGame.CloseCard(FTrump.Deck[vFirstOpenCard]);
            FTrump.Deck[vSecondOpenCard].IsObverse = FGame.CloseCard(FTrump.Deck[vSecondOpenCard]);
        }

        /// <summary>
        /// 手番を次に回す
        /// </summary>
        public void NextTurn() => FPlayers.NextTurn(FPlayers.Turn, FPlayerNum);

        /// <summary>
        /// 勝者判定
        /// </summary>
        public List<Player> FWinPlayers;
        public void GetGameWinners() {
            FWinPlayers = new List<Player>();
            this.FWinPlayers = FPlayers.JudgeWinner();
        }

        //reset
    }
}
