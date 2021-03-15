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



        //(input)ゲームスタート
        public void GameStart() {
            FPlayers.Turn = 1;
        }
        //(input)プレイヤー数を受け取る
        public int FPlayerNum = 2;
        //(input)プレイヤー名を受け取る
        public List<string> FPlayerNames;
        //(model)プレイヤー数だけPlayerインスタンスを作成
        public List<Player> FPlayersList;
        public List<Player> MakePlayers() {
            this.FPlayersList = this.FPlayers.MakePlayers(FPlayerNum);
            return FPlayersList;
        }

        //(model)プレイヤー名を各Player.Nameにセット
        public List<Player> SetPlayersName() {
            this.FPlayersList = this.FPlayers.SetPlayersName(FPlayersList, FPlayerNames);
            return FPlayersList;
        }

        //(view) プレイヤー数を渡す
        //(view) それぞれのプレイヤー名を渡す

        //(model)52枚のカードの束が生成される
        private List<Card> FTrumpDeck;
        public List<Card> MakeDeck() {
            this.FTrumpDeck = this.FTrump.MakeDeck();
            return FTrumpDeck;
        }
        //(model)シャッフルメソッド
        public List<Card> ShuffleDeck() {
            this.FTrumpDeck = this.FTrump.Shuffle(FTrumpDeck);
            return FTrumpDeck;
        }
        //(model)カードの配置位置が記憶される
        //(view) カードが配置される

        //≪LOOP≫
        //(input)カードがクリックされる
        //(model)カードをめくるメソッド
        public void OpenCard() {
            this.FTrumpDeck[1].IsObverse = this.FGame.OpenCard(this.FTrumpDeck[1].IsObverse);
        }

        //(view) クリックしたカードが表側表示になる
        //(input)カードがクリックされる
        //(model)カードをめくるメソッド
        //(view) クリックしたカードが表側表示になる
        //(model)一致判定メソッド
        private bool FMatchCards = false;

        //(model)数字が同じ場合:取得枚数加算メソッド
        public void PlusCard() {
            this.FPlayers.Plus(this.FPlayersList[FPlayers.Turn - 1].OwnCards);
        }

        //(view) 数字が同じ場合:ターンプレイヤーの獲得枚数+2
        //(model)数字が同じ場合:終了判定メソッド
        private bool FGameEnd = false;
        public bool GetEndFlg() {
            this.FGameEnd = this.FGame.JudgeGameEnd(FTrumpDeck);
            return FGameEnd;
        }
        //(model)数字が違った場合:少し待ってからカードを裏返すメソッド*2


        //(view) 数字が違った場合:裏側に戻す
        //(model)数字が違った場合:手番を次に回すメソッド
        public int NextTurn() {
            this.FPlayers.Turn = this.FPlayers.NextTurn(FPlayers.Turn, FPlayerNum);
            return FPlayers.Turn;
        }

        //(view) 数字が違った場合:次の手番のプレイヤーを表示する
        //≪LOOP≫

        //(model)ゲームが終了した場合:勝者判定メソッド
        private List<Player> FWinPlayers;
        public List<Player> GameWinners() {
            this.FWinPlayers = this.FPlayers.JudgeWinner(FPlayers);
            return FWinPlayers;
        }

        //(view) ゲームが終了した場合:勝者をポップアップ表示する
        //(view) ゲームが終了した場合:最も多い獲得枚数を表示する

        //reset
    }
}
