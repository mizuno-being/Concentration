﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// 神経衰弱
/// </summary>
namespace Concentration {

    /// <summary>
    /// 神経衰弱を行う画面
    /// </summary>
    public partial class GameForm : Form {

        private GameController FGameController;

        /// <summary>
        /// トランプカードを表示するボタン
        /// </summary>
        private Button[] FCardButtons;

        /// <summary>
        /// プレイヤー名を表示するラベル
        /// </summary>
        private Label[] FPlayerNameLabels;

        /// <summary>
        /// 取得枚数を表示するテキストボックス
        /// </summary>
        private TextBox[] FCardNumTextBoxes;

        /// <summary>
        /// 単位(枚)を表示するラベル
        /// </summary>
        private Label[] FUnitLabels;

        /// <summary>
        /// ゲーム終了時の勝利メッセージ
        /// </summary>
        public string WinMessage { get; set; }

        private int FPlayerNum;

        private int FTrumpCardNum = GameController.C_Suit * GameController.C_Rank;

        /// <summary>
        /// トランプを再描画
        /// </summary>
        public void RefreshCards(List<Card> vCards) {
            for (int i = 0; i < vCards.Count; i++) {
                if (vCards[i].IsObverse) {
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
                    this.FCardButtons[i].Enabled = false;
                } else {
                    this.FCardButtons[i].Text = "";
                    this.FCardButtons[i].Enabled = true;
                }
            }
            this.flowLayoutPanel1.Refresh();
        }

        /// <summary>
        /// ターンプレイヤーを再描画
        /// </summary>
        public void RefreshTurnPlayer(int vTurn) {
            this.Teban.Text = FGameController.Players.PlayersList[vTurn].Name;
            this.Teban.Refresh();
        }

        /// <summary>
        /// 取得枚数を再描画
        /// </summary>
        public void RefreshMatchCardsNum(int vMatchCardCount, int vTurnPlayerNum) {
            this.FCardNumTextBoxes[vTurnPlayerNum].Text = $"{vMatchCardCount}";
            this.FCardNumTextBoxes[vTurnPlayerNum].Refresh();
        }

        /// <summary>
        /// GameForm
        /// </summary>
        public GameForm() {
            InitializeComponent();
            FGameController = new GameController(this);
        }

        /// <summary>
        /// カードのボタンをクリック
        /// </summary>
        private void Button_Click(object sender, EventArgs e) {
            int wChoiceCardNum = (int)((Button)sender).Tag;
            FGameController.OpenCard(wChoiceCardNum);
            if (FGameController.Game.IsGameEnd) {
                MessageBox.Show(this.WinMessage);
            }
        }

        /// <summary>
        /// シャッフルボタンクリック
        /// </summary>
        private void Shuffle_Button_Click(object sender, EventArgs e) {
            FGameController.ShuffleDeck();
            RefreshCards(FGameController.Trump.Deck);
            this.Shuffle.Enabled = false;
        }

        private void GameForm_Load(object sender, EventArgs e) {

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
                this.FCardButtons[i].TextAlign = ContentAlignment.TopRight;
                this.FCardButtons[i].UseVisualStyleBackColor = false;
                this.FCardButtons[i].Click += Button_Click;

                this.flowLayoutPanel1.Controls.Add(this.FCardButtons[i]);
            }

            if (this.FPlayerNameLabels != null && this.FCardNumTextBoxes != null && this.FUnitLabels != null) {
                return;
            }

            FPlayerNum = FGameController.PlayerNum;

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
                this.FPlayerNameLabels[i].Location = new Point(20, 135 + 90 * i);
                this.FPlayerNameLabels[i].Name = "Player" + (i + 1);
                this.FPlayerNameLabels[i].Size = new Size(101, 30);
                this.FPlayerNameLabels[i].TabIndex = 0;
                this.FPlayerNameLabels[i].Text = $"{FGameController.Players.PlayersList[i].Name}";

                // 
                // 取得カード数
                // 
                this.FCardNumTextBoxes[i].Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.FCardNumTextBoxes[i].Location = new Point(102, 179 + 90 * i);
                this.FCardNumTextBoxes[i].Name = "CardNum";
                this.FCardNumTextBoxes[i].ReadOnly = true;
                this.FCardNumTextBoxes[i].Size = new Size(37, 33);
                this.FCardNumTextBoxes[i].TabIndex = 2;
                this.FCardNumTextBoxes[i].TabStop = false;
                this.FCardNumTextBoxes[i].Text = "0";

                // 
                // 単位(枚)
                // 
                this.FUnitLabels[i].AutoSize = true;
                this.FUnitLabels[i].Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.FUnitLabels[i].Location = new Point(140, 187 + 90 * i);
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
