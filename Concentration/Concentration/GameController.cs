using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class GameController {

        public Game FGame;
        public Trump FTrump;
        public Players FPlayers;
        public Form1 FForm1;

        public GameController(Form1 fForm1) {
            FForm1 = fForm1;
            FGame = new Game();
            FTrump = new Trump();
            FPlayers = new Players();
            MakeDeck();
            ShuffleDeck();
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


        public const int FSuit = 4;
        public const int FRank = 13;
        //(model)52枚のカードの束が生成される
        public void MakeDeck() {
            FTrump.MakeDeck(FSuit, FRank);
        }
        //(model)シャッフルメソッド
        public void ShuffleDeck() {
            FTrump.Shuffle();
        }
        //(model)カードの配置位置が記憶される(?)


        //(view) カードが配置される(?)

        //≪LOOP≫
        //(input)カードがクリックされる
        //ボタンのTagから配列の位置を取得する

        //カードの位置から指定したカードの情報を得る

        //(model)カードをめくるメソッド
        public void OpenCard(int vCardTag) {
            FTrump.FDeck[vCardTag].IsObverse = FGame.OpenCard(FTrump.FDeck[vCardTag].IsObverse);

        }

        //(view) クリックしたカードが表側表示になる

        //(input)カードがクリックされる
        //(model)カードをめくるメソッド
        //(view) クリックしたカードが表側表示になる
        //(model)一致判定メソッド
        public bool CheckMatchCards() {
            FGame.CheckMatchFlag = FGame.CheckMatchCards(FTrump.FDeck[0/**/], FTrump.FDeck[1/**/]);
            return FGame.CheckMatchFlag;
        }

        //(model)数字が同じ場合:取得枚数加算メソッド
        public void PlusCard() {
            FPlayers.Plus(FPlayers.FPlayers[FPlayers.Turn - 1].OwnCards);
            FGame.CheckMatchFlag = false;
        }

        //(view) 数字が同じ場合:ターンプレイヤーの獲得枚数+2
        public int ViewPlusCard() {
            return FPlayers.FPlayers[FPlayers.Turn - 1].OwnCards;
        }

        //(model)数字が同じ場合:終了判定メソッド
        public bool GetEndFlg() {
            FGame.GameEndFlag = this.FGame.JudgeGameEnd(FTrump.FDeck);
            return FGame.GameEndFlag;
        }
        //(model)数字が違った場合:少し待ってからカードを裏返すメソッド*2
        public void CloseCard() {
            FTrump.FDeck[0/**/].IsObverse = FGame.CloseCard(FTrump.FDeck[0/**/].IsObverse);
        }


        //(view) 数字が違った場合:裏側に戻す
        public string ViewCloseCard() {
            FForm1.FCardButtons[0/**/].Text = "裏";
            return FForm1.FCardButtons[0/**/].Text;
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
