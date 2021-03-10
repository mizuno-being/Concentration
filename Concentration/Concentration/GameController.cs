using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class GameController {

        public Game FGame;
        public Trump FTrump;
        public Player FPlayer;



        //(input)プレイヤー数を受け取る
        //(input)プレイヤー名を受け取る
        //(model)プレイヤー数だけPlayerインスタンスを作成
        //(model)プレイヤー名を各Player.Nameにセット
        //(view) プレイヤー数を渡す
        //(view) それぞれのプレイヤー名を渡す

        //(model)52枚のカードの束が生成される
        //(model)シャッフルメソッド
        //(model)配置メソッド
        //(view) カードが配置される

        //≪LOOP≫
        //(input)カードがクリックされる
        //(model)カードをめくるメソッド
        //(view) クリックしたカードが表側表示になる
        //(input)カードがクリックされる
        //(model)カードをめくるメソッド
        //(view) クリックしたカードが表側表示になる
        //(model)一致判定メソッド
        //(view) 数字が同じ場合:ターンプレイヤーの獲得枚数+2
        //(view) 数字が違った場合:少し待ってから裏側に戻す
        //(model)(手番を次に回すメソッド)
        //(view) 次の手番のプレイヤーを表示する
        //(model)(終了判定メソッド)
        //(model)(勝者判定メソッド)
        //(view) 勝者をポップアップ表示する
        //≪LOOP≫


    }
}
