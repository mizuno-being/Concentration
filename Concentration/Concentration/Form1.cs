using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentration {
    public partial class Form1 : Form {

        private Button[] CardButtons;
        private Label[] PlayerNames;
        private TextBox[] CardNums;
        private Label[] Unit;

        int wPlayerNum = 4;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

            ///トランプを52枚表示
            if (this.CardButtons != null) {
                return;
            }

            this.CardButtons = new Button[52];

            for (int i = 0; i < this.CardButtons.Length; i++) {
                this.CardButtons[i] = new Button();

                this.CardButtons[i].BackColor = SystemColors.ButtonShadow;
                this.CardButtons[i].Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.CardButtons[i].Location = new Point(77, 3);
                this.CardButtons[i].Name = "Card" + i;
                this.CardButtons[i].Size = new Size(68, 100);
                this.CardButtons[i].TabIndex = 0;
                this.CardButtons[i].Text = "裏";
                this.CardButtons[i].UseVisualStyleBackColor = false;

                this.flowLayoutPanel1.Controls.Add(this.CardButtons[i]);
            }

            if (this.PlayerNames != null && this.CardNums != null && this.Unit != null) {
                return;
            }

            this.PlayerNames = new Label[wPlayerNum];
            this.CardNums = new TextBox[wPlayerNum];
            this.Unit = new Label[wPlayerNum];

            for (int i = 0; i < wPlayerNum; i++) {
                this.PlayerNames[i] = new Label();
                this.CardNums[i] = new TextBox();
                this.Unit[i] = new Label();


                // 
                // プレイヤー名
                // 
                this.PlayerNames[i].AutoSize = true;
                this.PlayerNames[i].Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                this.PlayerNames[i].Location = new System.Drawing.Point(20, 135 + i * 100);
                this.PlayerNames[i].Name = "Player" + (i + 1);
                this.PlayerNames[i].Size = new System.Drawing.Size(101, 30);
                this.PlayerNames[i].TabIndex = 0;
                this.PlayerNames[i].Text = "プレイヤー" + (i + 1);

                // 
                // 取得カード数
                // 
                this.CardNums[i].Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.CardNums[i].Location = new System.Drawing.Point(102, 179 + i * 100);
                this.CardNums[i].Name = "CardNum";
                this.CardNums[i].ReadOnly = true;
                this.CardNums[i].Size = new System.Drawing.Size(37, 33);
                this.CardNums[i].TabIndex = 2;
                this.CardNums[i].Text = "0";

                // 
                // 単位(枚)
                // 
                this.Unit[i].AutoSize = true;
                this.Unit[i].Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.Unit[i].Location = new System.Drawing.Point(140, 187 + i * 100);
                this.Unit[i].Name = "CardUnit";
                this.Unit[i].Size = new System.Drawing.Size(31, 25);
                this.Unit[i].TabIndex = 1;
                this.Unit[i].Text = "枚";


                this.splitContainer1.Panel2.Controls.Add(this.PlayerNames[i]);
                this.splitContainer1.Panel2.Controls.Add(this.CardNums[i]);
                this.splitContainer1.Panel2.Controls.Add(this.Unit[i]);

            }
        }
    }
}
