namespace airHockey
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2label = new System.Windows.Forms.Label();
            this.p1Score = new System.Windows.Forms.Label();
            this.p2Score = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(610, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(178, 84);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Savannah\'s Super Awesome Air Hockey";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // player1Label
            // 
            this.player1Label.BackColor = System.Drawing.Color.Transparent;
            this.player1Label.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(611, 243);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(77, 24);
            this.player1Label.TabIndex = 1;
            this.player1Label.Text = "Player 1";
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2label
            // 
            this.player2label.BackColor = System.Drawing.Color.Transparent;
            this.player2label.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2label.Location = new System.Drawing.Point(694, 243);
            this.player2label.Name = "player2label";
            this.player2label.Size = new System.Drawing.Size(77, 24);
            this.player2label.TabIndex = 2;
            this.player2label.Text = "Player 2";
            this.player2label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1Score
            // 
            this.p1Score.BackColor = System.Drawing.Color.Transparent;
            this.p1Score.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Score.Location = new System.Drawing.Point(611, 267);
            this.p1Score.Name = "p1Score";
            this.p1Score.Size = new System.Drawing.Size(77, 24);
            this.p1Score.TabIndex = 6;
            this.p1Score.Text = "0";
            this.p1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2Score
            // 
            this.p2Score.BackColor = System.Drawing.Color.Transparent;
            this.p2Score.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Score.Location = new System.Drawing.Point(694, 267);
            this.p2Score.Name = "p2Score";
            this.p2Score.Size = new System.Drawing.Size(77, 24);
            this.p2Score.TabIndex = 7;
            this.p2Score.Text = "0";
            this.p2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.Location = new System.Drawing.Point(610, 317);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(178, 84);
            this.winLabel.TabIndex = 8;
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 900);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.p2Score);
            this.Controls.Add(this.p1Score);
            this.Controls.Add(this.player2label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hockey";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2label;
        private System.Windows.Forms.Label p1Score;
        private System.Windows.Forms.Label p2Score;
        private System.Windows.Forms.Label winLabel;
    }
}

