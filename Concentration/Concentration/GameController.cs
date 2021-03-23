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
            FPlayerNum = 4;
        }
        //(input)プレイヤー名を受け取る
        public List<string> FPlayerNames;
        //(model)プレイヤー数だけPlayerインスタンスを作成
        public void MakePlayers() {
            FPlayers.MakePlayers(FPlayerNum);
        }

        //(model)プレイヤー名を各Player.Nameにセット
        public void SetPlayersName() {
            FPlayerNames = new List<string>(FPlayerNum);
            FPlayers.SetPlayersName(FPlayerNames);
        }

        //(view) プレイヤー数を渡す
        public void PlayerNum() {
            FForm1.GetPlayterNum(FPlayerNum);
        }

        public const int C_Suit = 4;
        public const int C_Rank = 13;
        //(model)52枚のカードの束が生成される
        public void MakeDeck() {
            FTrump.MakeDeck(C_Suit, C_Rank);
        }
        //(model)シャッフルメソッド
        public void ShuffleDeck() {
            FTrump.Shuffle();
        }

        //(model)カードをめくるメソッド
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
                //viewに移す
                if (wCheckMatch == true) {
                    FForm1.FCardButtons[FTrump.ClickCard[0]].Enabled = false;
                    FForm1.FCardButtons[FTrump.ClickCard[1]].Enabled = false;
                    PlusCard();
                    FForm1.RefreshMatchCardsNum(FPlayers.PlayersList[FPlayers.Turn].OwnCards, FPlayers.Turn);
                    GetGameEnd();
                } else {
                    CloseCard(FTrump.ClickCard[0], FTrump.ClickCard[1]);
                    NextTurn();
                    FForm1.RefreshTurnPlayer(FPlayers.Turn);
                }
                FTrump.ClickCard.Clear();
            }
            FForm1.RefreshCards(FTrump.Deck);
        }


        //(model)一致判定メソッド
        public bool CheckMatchCards(int vFirstCard, int vSecondCard) {
            return FGame.CheckMatchCards(FTrump.Deck[vFirstCard], FTrump.Deck[vSecondCard]);
        }

        //(model)数字が同じ場合:取得枚数加算メソッド
        public void PlusCard() {
            FPlayers.Plus(FPlayers.PlayersList[FPlayers.Turn]);
        }

        //(model)数字が同じ場合:終了判定メソッド
        public void GetGameEnd() {
            FGame.JudgeGameEnd(FTrump.Deck);
        }
        //(model)数字が違った場合:少し待ってからカードを裏返すメソッド
        public void CloseCard(int vFirstOpenCard, int vSecondOpenCard) {

            FTrump.Deck[vFirstOpenCard].IsObverse = FGame.CloseCard(FTrump.Deck[vFirstOpenCard]);
            FTrump.Deck[vSecondOpenCard].IsObverse = FGame.CloseCard(FTrump.Deck[vSecondOpenCard]);
        }

        //(model)数字が違った場合:手番を次に回すメソッド
        public void NextTurn() {
            FPlayers.NextTurn(FPlayers.Turn, FPlayerNum);
        }

        //(model)ゲームが終了した場合:勝者判定メソッド
        private List<Player> FWinPlayers;
        public List<Player> GameWinners() {
            FWinPlayers = new List<Player>();
            this.FWinPlayers = FPlayers.JudgeWinner();
            return FWinPlayers;
        }

        //reset
    }
}
