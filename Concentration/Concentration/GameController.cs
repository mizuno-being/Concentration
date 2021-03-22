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
        private Players FPlayers;
        private Form1 FForm1;

        public GameController(Form1 fForm1) {
            FForm1 = fForm1;
            FGame = new Game();
            FTrump = new Trump();
            FPlayers = new Players();
            FTrump.ClickCard = new List<int>();
            MakeDeck();
            //ShuffleDeck();
            TakePlayerNum();
        }

        //(input)ゲームスタート
        public void GameStart() {
            FPlayers.Turn = 1;
        }
        //(input)プレイヤー数を受け取る

        public int FPlayerNum;
        public void TakePlayerNum() {
            FPlayerNum = 2;
        }
        //(input)プレイヤー名を受け取る
        public List<string> FPlayerNames;
        //(model)プレイヤー数だけPlayerインスタンスを作成
        public void MakePlayers() {
            FPlayers.MakePlayers(FPlayerNum);
        }

        //(model)プレイヤー名を各Player.Nameにセット
        public void SetPlayersName() {
            FPlayers.SetPlayersName(FPlayerNames);
        }

        //(view) プレイヤー数を渡す
        public void PlayerNum() {
            FForm1.GetPlayterNum(FPlayerNum);
        }
        //(view) それぞれのプレイヤー名を渡す

        //(view) 現在のターンプレイヤー名を渡す


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

        //≪LOOP≫
        //(input)カードがクリックされる
        //ボタンのTagから配列の位置を取得する

        //カードの位置から指定したカードの情報を得る
        //private int FClickNum = 0;
        //private List<int> FClickCard;
        //(model)カードをめくるメソッド
        public void OpenCard(int vCardTag) {

            FTrump.ClickCardCount(vCardTag);
            FTrump.Deck[vCardTag].IsObverse = FGame.OpenCard(FTrump.Deck[vCardTag].IsObverse);

        }


        //(model)一致判定メソッド
        public void CheckMatchCards(/*int vFirstCard, int vSecondCard*/) {

            if (FTrump.ClickCard.Count == 2) {
                if (FTrump.ClickCard[0] == FTrump.ClickCard[1]) {
                    CloseCard(FTrump.ClickCard[0], FTrump.ClickCard[1]);
                    FTrump.ClickCard.Clear();
                    return;
                }
                bool wCheckMatch = FGame.CheckMatchCards(FTrump.Deck[FTrump.ClickCard[0]], FTrump.Deck[FTrump.ClickCard[1]]);
                if (wCheckMatch == true) {
                    FForm1.FCardButtons[FTrump.ClickCard[0]].Enabled = false;
                    FForm1.FCardButtons[FTrump.ClickCard[1]].Enabled = false;
                } else {

                    CloseCard(FTrump.ClickCard[0], FTrump.ClickCard[1]);
                }
                FTrump.ClickCard.Clear();

            }
            //return FGame.CheckMatchCards(FTrump.Deck[vFirstCard], FTrump.Deck[vSecondCard]);
        }

        //(model)数字が同じ場合:取得枚数加算メソッド
        public void PlusCard() {
            FPlayers.Plus(FPlayers.PlayersList[FPlayers.Turn - 1].OwnCards);
            FGame.CheckMatch = false;
        }

        //(view) 数字が同じ場合:ターンプレイヤーの獲得枚数+2
        public int ViewPlusCard() {
            return FPlayers.PlayersList[FPlayers.Turn - 1].OwnCards;
        }

        //(model)数字が同じ場合:終了判定メソッド
        public bool GetEndFlg() {
            FGame.GameEnd = this.FGame.JudgeGameEnd(FTrump.Deck);
            return FGame.GameEnd;
        }
        //(model)数字が違った場合:少し待ってからカードを裏返すメソッド*2
        public void CloseCard(int vFirstOpenCard, int vSecondOpenCard) {

            FTrump.Deck[vFirstOpenCard].IsObverse = FGame.CloseCard(FTrump.Deck[vFirstOpenCard]);
            FTrump.Deck[vSecondOpenCard].IsObverse = FGame.CloseCard(FTrump.Deck[vSecondOpenCard]);
        }


        //(model)数字が違った場合:手番を次に回すメソッド
        public int NextTurn() {
            this.FPlayers.Turn = this.FPlayers.NextTurn(FPlayers.Turn, FPlayerNum);
            return FPlayers.Turn;
        }

        //(view) 数字が違った場合:次の手番のプレイヤーを表示する
        public string NextTeban() {
            return "プレイヤー1";
        }

        //≪LOOP≫

        //(model)ゲームが終了した場合:勝者判定メソッド
        private List<Player> FWinPlayers;



        public List<Player> GameWinners() {
            this.FWinPlayers = FPlayers.JudgeWinner();
            return FWinPlayers;
        }

        //(view) ゲームが終了した場合:勝者をポップアップ表示する
        //(view) ゲームが終了した場合:最も多い獲得枚数を表示する

        //reset
    }
}
