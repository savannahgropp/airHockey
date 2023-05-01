using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airHockey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //making players and pucks
        Rectangle player1 = new Rectangle(275, 100, 50, 55);
        Rectangle player1top = new Rectangle(280, 100, 40, 5);
        Rectangle player1right = new Rectangle(320, 105, 5, 45);
        Rectangle player1bottom = new Rectangle(280, 150, 40, 5);
        Rectangle player1left = new Rectangle(275, 105, 5, 45);

        Rectangle player2 = new Rectangle(275, 750, 50, 55);
        Rectangle player2left = new Rectangle(275, 755, 5, 45);
        Rectangle player2top = new Rectangle(280, 750, 40, 5);
        Rectangle player2bottom = new Rectangle(280, 800, 40, 5);
        Rectangle player2right = new Rectangle(320, 755, 5, 45);

        Rectangle puck = new Rectangle(287, 437, 25, 25);

        Rectangle player1Net = new Rectangle(200, 0, 200, 10);
        Rectangle player2Net = new Rectangle(200, 890, 200, 10);

        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 12;
        int puckXSpeed = 0;
        int puckYSpeed = 0;

        bool wDown = false;
        bool sDown = false;
        bool dDown = false;
        bool aDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        Pen redPen = new Pen(Color.Red);
        Pen blackPen = new Pen(Color.Black);
        Brush redBrush = new SolidBrush(Color.Red);
        Brush blueBrush = new SolidBrush(Color.Blue);
        Brush blackBrush = new SolidBrush(Color.Black);

        int counter = 0;

        SoundPlayer puckSound = new SoundPlayer(Properties.Resources.puckShotSound__1_);

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (counter == 1)
            {
                //move puck
                puck.Y += puckYSpeed;
                puck.X += puckXSpeed;
            }

            //move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
                player1top.Y -= playerSpeed;
                player1bottom.Y -= playerSpeed;
                player1right.Y -= playerSpeed;
                player1left.Y -= playerSpeed;
            }
            if (sDown == true && player1.Y < 400)
            {
                player1.Y += playerSpeed;
                player1top.Y += playerSpeed;
                player1bottom.Y += playerSpeed;
                player1right.Y += playerSpeed;
                player1left.Y += playerSpeed;
            }
            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
                player1top.X -= playerSpeed;
                player1bottom.X -= playerSpeed;
                player1right.X -= playerSpeed;
                player1left.X -= playerSpeed;
            }
            if (dDown == true && player1.X < 550)
            {
                player1.X += playerSpeed;
                player1top.X += playerSpeed;
                player1bottom.X += playerSpeed;
                player1right.X += playerSpeed;
                player1left.X += playerSpeed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 450)
            {
                player2.Y -= playerSpeed;
                player2top.Y -= playerSpeed;
                player2bottom.Y -= playerSpeed;
                player2right.Y -= playerSpeed;
                player2left.Y -= playerSpeed;
            }
            if (downArrowDown == true && player2.Y < 850)
            {
                player2.Y += playerSpeed;
                player2top.Y += playerSpeed;
                player2bottom.Y += playerSpeed;
                player2right.Y += playerSpeed;
                player2left.Y += playerSpeed;
            }
            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
                player2top.X -= playerSpeed;
                player2bottom.X -= playerSpeed;
                player2right.X -= playerSpeed;
                player2left.X -= playerSpeed;

            }
            if (rightArrowDown == true && player2.X < 550)
            {
                player2.X += playerSpeed;
                player2top.X += playerSpeed;
                player2bottom.X += playerSpeed;
                player2right.X += playerSpeed;
                player2left.X += playerSpeed;
            }

            //change direction of puck if it hits a boundary
            if (puck.Y > this.Height - puck.Height)
            {
                puck.Y--;
                puckYSpeed *= -1;

                friction();

                puckSound.Play();
            }
            if (puck.Y < 1)
            {
                puck.Y++;
                puckYSpeed *= -1;

                friction();

                puckSound.Play();
            }
            if (puck.X > 570)
            {
                puck.X--;
                puckXSpeed *= -1;

                friction();

                puckSound.Play();
            }
            if (puck.X < 0)
            {
                puck.X++;
                puckXSpeed *= -1;

                friction();

                puckSound.Play();
            }

            //check if player 1 intersects with the puck
            //if the puck is moving downwards, change direction upwards
            //if the puck is moving upwards, change direction downwards
            //left to right
            //up to down
            if (player1bottom.IntersectsWith(puck)) //puck moving up (hits bottom)
            {
                counter = 1;
                puck.Y += 10;
                player1.Y -= 5;
                player1top.Y -= 5;
                player1bottom.Y -= 5;
                player1right.Y -= 5;
                player1left.Y -= 5;

                puckYSpeed = 9;
                friction();

                puckSound.Play();
            }
            if (player1top.IntersectsWith(puck)) //puck moving down (hits top)
            {
                counter = 1;
                puck.Y -= 10;
                player1.Y += 5;
                player1top.Y += 5;
                player1bottom.Y += 5;
                player1right.Y += 5;
                player1left.Y += 5;

                puckYSpeed = -9;
                friction();

                puckSound.Play();
            }
            if (player1right.IntersectsWith(puck)) //puck moving left (hits right side)
            {
                counter = 1;
                puck.X += 10;
                player1.X -= 5;
                player1top.X -= 5;
                player1bottom.X -= 5;
                player1right.X -= 5;
                player1left.X -= 5;

                puckXSpeed = 9;
                friction();

                puckSound.Play();
            }
            if (player1left.IntersectsWith(puck)) //puck moving right (hits left side)
            {
                counter = 1;
                puck.X -= 10;
                player1.X += 5;
                player1top.X += 5;
                player1bottom.X += 5;
                player1right.X += 5;
                player1left.X += 5;

                puckXSpeed = -9;
                friction();

                puckSound.Play();
            }

            //check if player 2 intersects with the puck
            //***
            //down to up
            //up to down
            //left to right
            //right to leftsa
            if (player2bottom.IntersectsWith(puck)) //puck moving up (hits bottom)
            {
                counter = 1;
                puck.Y += 10;
                player2.Y -= 5;
                player2top.Y -= 5;
                player2bottom.Y -= 5;
                player2right.Y -= 5;
                player2left.Y -= 5;

                puckYSpeed = 9;
                friction();

                puckSound.Play();
            }
            if (player2top.IntersectsWith(puck)) //puck moving down (hits top)
            {
                counter = 1;
                puck.Y -= 10;
                player2.Y += 5;
                player2top.Y += 5;
                player2bottom.Y += 5;
                player2right.Y += 5;
                player2left.Y += 5;

                puckYSpeed = -9;
                friction();

                puckSound.Play();
            }
            if (player2left.IntersectsWith(puck)) //puck moving right (hits left side)
            {
                counter = 1;
                puck.X += 10;
                player2.X -= 5;
                player2top.X -= 5;
                player2bottom.X -= 5;
                player2right.X -= 5;
                player2left.X -= 5;

                puckXSpeed = -9;
                friction();

                puckSound.Play();
            }
            if (player2right.IntersectsWith(puck)) //puck moving left (hits right side)
            {
                counter = 1;
                puck.X -= 10;
                player2.X += 5;
                player2top.X += 5;
                player2bottom.X += 5;
                player2right.X += 5;
                player2left.X += 5;

                puckXSpeed = 9;
                friction();

                puckSound.Play();
            }

            //check if puck hit player 1 net and add score to player 2
            if (player1Net.IntersectsWith(puck))
            {
                resetField();
                player2Score++;
                p2Score.Text = $"{player2Score}";
                puck.Y -= 20;
            }
            //check if puck hit player 2 net and add score to player 1
            if (player2Net.IntersectsWith(puck))
            {
                resetField();
                player1Score++;
                p1Score.Text = $"{player1Score}";
                puck.Y += 20;
            }
            //check score and stop the game if a player hits 3 wins
            if (player1Score == 3)
            {
                resetField();
                winLabel.Text = "Player 1 Wins!!";
            }
            if (player2Score == 3)
            {
                resetField();
                winLabel.Text = "Player 2 Wins!!";
            }

            Refresh();
        }

        public void resetField()
        {
            counter = 0;
            puck.X = 287;
            puck.Y = 437;

            player1.X = 275;
            player1.Y = 100;
            player1top.X = 280;
            player1top.Y = 100;
            player1right.X = 320;
            player1right.Y = 105;
            player1bottom.X = 280;
            player1bottom.Y = 150;
            player1left.X = 275;
            player1left.Y = 105;

            player2.X = 275;
            player2.Y = 750;
            player2top.X = 280;
            player2top.Y = 750;
            player2right.X = 320;
            player2right.Y = 755;
            player2bottom.X = 280;
            player2bottom.Y = 800;
            player2left.X = 275;
            player2left.Y = 755;
        }

        public void friction()
        {
            puckXSpeed--;
            puckYSpeed--;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //ice layout
            e.Graphics.FillRectangle(redBrush, 0, 440, 600, 20);
            e.Graphics.FillRectangle(blueBrush, 0, 200, 600, 20);
            e.Graphics.FillRectangle(blueBrush, 0, 680, 600, 20);
            e.Graphics.DrawEllipse(redPen, 150, 300, 300, 300);
            e.Graphics.DrawLine(blackPen, 600, 0, 600, 900); //note the puck cant go past this line (x=600)

            //nets
            e.Graphics.FillRectangle(blackBrush, player1Net);
            e.Graphics.FillRectangle(blackBrush, player2Net);

            //puck and players
            e.Graphics.FillRectangle(redBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(blackBrush, puck);

            //line for alignment (vertical)
            //e.Graphics.DrawLine(blackPen, 300, 0, 300, 900);

            //player 1 lines
            e.Graphics.FillRectangle(redBrush, player1top);//
            e.Graphics.FillRectangle(redBrush, player1right);
            e.Graphics.FillRectangle(redBrush, player1bottom);//
            e.Graphics.FillRectangle(redBrush, player1left);

            //player 2 lines
            e.Graphics.FillRectangle(blueBrush, player2top);
            e.Graphics.FillRectangle(blueBrush, player2right);
            e.Graphics.FillRectangle(blueBrush, player2bottom);
            e.Graphics.FillRectangle(blueBrush, player2left);
        }
    }
}
