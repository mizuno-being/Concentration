
namespace Concentration {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Restart = new System.Windows.Forms.Button();
            this.HowToPlay = new System.Windows.Forms.Button();
            this.Shuffle = new System.Windows.Forms.Button();
            this.TebanText = new System.Windows.Forms.Label();
            this.Teban = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(728, 759);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Restart);
            this.splitContainer1.Panel2.Controls.Add(this.HowToPlay);
            this.splitContainer1.Panel2.Controls.Add(this.Shuffle);
            this.splitContainer1.Panel2.Controls.Add(this.TebanText);
            this.splitContainer1.Panel2.Controls.Add(this.Teban);
            this.splitContainer1.Size = new System.Drawing.Size(984, 761);
            this.splitContainer1.SplitterDistance = 718;
            this.splitContainer1.TabIndex = 2;
            // 
            // Restart
            // 
            this.Restart.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Restart.Location = new System.Drawing.Point(20, 694);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(230, 55);
            this.Restart.TabIndex = 5;
            this.Restart.Text = "リスタート";
            this.Restart.UseVisualStyleBackColor = true;
            // 
            // HowToPlay
            // 
            this.HowToPlay.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HowToPlay.Location = new System.Drawing.Point(20, 615);
            this.HowToPlay.Name = "HowToPlay";
            this.HowToPlay.Size = new System.Drawing.Size(230, 55);
            this.HowToPlay.TabIndex = 4;
            this.HowToPlay.Text = "遊び方";
            this.HowToPlay.UseVisualStyleBackColor = true;
            // 
            // Shuffle
            // 
            this.Shuffle.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Shuffle.Location = new System.Drawing.Point(20, 536);
            this.Shuffle.Name = "Shuffle";
            this.Shuffle.Size = new System.Drawing.Size(230, 55);
            this.Shuffle.TabIndex = 3;
            this.Shuffle.Text = "シャッフル";
            this.Shuffle.UseVisualStyleBackColor = true;
            // 
            // TebanText
            // 
            this.TebanText.AutoSize = true;
            this.TebanText.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TebanText.Location = new System.Drawing.Point(113, 63);
            this.TebanText.Name = "TebanText";
            this.TebanText.Size = new System.Drawing.Size(77, 25);
            this.TebanText.TabIndex = 2;
            this.TebanText.Text = "の番です";
            // 
            // Teban
            // 
            this.Teban.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Teban.Location = new System.Drawing.Point(20, 21);
            this.Teban.Name = "Teban";
            this.Teban.ReadOnly = true;
            this.Teban.Size = new System.Drawing.Size(170, 39);
            this.Teban.TabIndex = 1;
            this.Teban.Text = "プレイヤー1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Concentration-シンケイスイジャク-";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button HowToPlay;
        private System.Windows.Forms.Button Shuffle;
        private System.Windows.Forms.Label TebanText;
        private System.Windows.Forms.TextBox Teban;
    }
}

