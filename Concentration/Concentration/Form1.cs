using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentration {
    public partial class Form1 : Form {

        private GameController FGameController;

        /// <summary>
        /// トランプカードを表示するボタン
        /// </summary>
        public Button[] FCardButtons;
        /// <summary>
        /// プレイヤー名を表示するラベル
        /// </summary>
        private Label[] FPlayerNameLabels;
        /// <summary>
        /// 取得枚数を表示するテキストボックス
        /// </summary>
        public TextBox[] FCardNumTextBoxes;
        /// <summary>
        /// 単位(枚)を表示するラベル
        /// </summary>
        private Label[] FUnitLabels;


        public int FPlayerNum;
        public int FTrumpCardNum = GameController.C_Suit * GameController.C_Rank;

        public void GetPlayterNum(int vPlayerNum) {
            FPlayerNum = vPlayerNum;
        }

        public void Reflesh(List<Card> vCards) {
            for (int i = 0; i < vCards.Count; i++) {
                if (vCards[i].IsObverse == true) {
                    string wSuit = "♥";
                    if (vCards[i].Suit == 0) {
                        wSuit = "♠";
                    }
                    if (vCards[i].Suit == 1) {
                        wSuit = "♦";
                    }
                    if (vCards[i].Suit == 2) {
                        wSuit = "♣";
                    }
                    this.FCardButtons[i].Text = $"{wSuit}{vCards[i].Rank}";
                } else {
                    this.FCardButtons[i].Text = "";
                }
            }
        }


        public Form1() {
            InitializeComponent();
            FGameController = new GameController(this);
        }

        private void Form1_Click(object sender, EventArgs e) {

        }

        public void Button_Click(object sender, EventArgs e) {
            int wChoiceCardNum = (int)((Button)sender).Tag;
            FGameController.OpenCard(wChoiceCardNum);
            Reflesh(FGameController.FTrump.Deck);
            FGameController.CheckMatchCards();
            Reflesh(FGameController.FTrump.Deck);
        }

        private void Form1_Load(object sender, EventArgs e) {

            ///トランプを52枚表示
            if (this.FCardButtons != null) {
                return;
            }

            this.FCardButtons = new Button[FTrumpCardNum];

            for (int i = 0; i < this.FCardButtons.Length; i++) {
                this.FCardButtons[i] = new Button();

                this.FCardButtons[i].BackColor = SystemColors.ButtonShadow;
                this.FCardButtons[i].Font = new Font("Yu Gothic UI", 25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.FCardButtons[i].Location = new Point(77, 3);
                this.FCardButtons[i].Name = "Card" + i;
                this.FCardButtons[i].Tag = i;
                this.FCardButtons[i].Size = new Size(68, 100);
                this.FCardButtons[i].TabIndex = 0;
                this.FCardButtons[i].Text = "";
                //this.FCardButtons[i].Text = char.ConvertFromUtf32(127136);
                this.FCardButtons[i].TextAlign = ContentAlignment.TopRight;
                this.FCardButtons[i].UseVisualStyleBackColor = false;
                this.FCardButtons[i].Click += Button_Click;

                this.flowLayoutPanel1.Controls.Add(this.FCardButtons[i]);
            }

            if (this.FPlayerNameLabels != null && this.FCardNumTextBoxes != null && this.FUnitLabels != null) {
                return;
            }

            GetPlayterNum(FGameController.FPlayerNum);

            this.FPlayerNameLabels = new Label[FPlayerNum];
            this.FCardNumTextBoxes = new TextBox[FPlayerNum];
            this.FUnitLabels = new Label[FPlayerNum];

            for (int i = 0; i < FPlayerNum; i++) {
                this.FPlayerNameLabels[i] = new Label();
                this.FCardNumTextBoxes[i] = new TextBox();
                this.FUnitLabels[i] = new Label();

                // 
                // プレイヤー名
                // 
                this.FPlayerNameLabels[i].AutoSize = true;
                this.FPlayerNameLabels[i].Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.FPlayerNameLabels[i].Location = new Point(20, 135 + 100 * i);
                this.FPlayerNameLabels[i].Name = "Player" + (i + 1);
                this.FPlayerNameLabels[i].Size = new Size(101, 30);
                this.FPlayerNameLabels[i].TabIndex = 0;
                this.FPlayerNameLabels[i].Text = "プレイヤー" + (i + 1);

                // 
                // 取得カード数
                // 
                this.FCardNumTextBoxes[i].Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.FCardNumTextBoxes[i].Location = new Point(102, 179 + 100 * i);
                this.FCardNumTextBoxes[i].Name = "CardNum";
                this.FCardNumTextBoxes[i].ReadOnly = true;
                this.FCardNumTextBoxes[i].Size = new Size(37, 33);
                this.FCardNumTextBoxes[i].TabIndex = 2;
                this.FCardNumTextBoxes[i].Text = "0";

                // 
                // 単位(枚)
                // 
                this.FUnitLabels[i].AutoSize = true;
                this.FUnitLabels[i].Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.FUnitLabels[i].Location = new Point(140, 187 + 100 * i);
                this.FUnitLabels[i].Name = "Unit";
                this.FUnitLabels[i].Size = new Size(31, 25);
                this.FUnitLabels[i].TabIndex = 1;
                this.FUnitLabels[i].Text = "枚";

                this.splitContainer1.Panel2.Controls.Add(this.FPlayerNameLabels[i]);
                this.splitContainer1.Panel2.Controls.Add(this.FCardNumTextBoxes[i]);
                this.splitContainer1.Panel2.Controls.Add(this.FUnitLabels[i]);

            }
        }
    }
}
