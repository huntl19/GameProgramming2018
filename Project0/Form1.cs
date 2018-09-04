using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_Game
{
    public partial class Form1 : Form
    {


        int x = 7;
        int y = 6;
        static int[,] board = new int[7, 6];
        static bool win = false;
        static bool turn = true;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int num = 0;
            bool tie = false;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            for (int i=0; i<7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board [i,j] == 1)
                    {
                        DrawBlue(i, j, e);
                    }
                    else if (board[i, j] == 2)
                    {
                        DrawRed(i, j, e);
                    }
                }
            }
            e.Graphics.DrawImage(Image.FromFile("Connect4Board.png"), 0, 0, w, h);
            //Win(false, e);
            for (int b = 0; b <= 7; b++)
            {
                for (int c = 0 ;c <= 6; c++)
                {
                    try
                    {
                        //Blue
                        if (board[b, c] == 1 && board[b + 1, c] == 1 && board[b + 2, c] == 1 && board[b + 3, c] == 1) Win(true, e);
                        else;//right
                        if (board[b, c] == 1 && board[b - 1, c] == 1 && board[b - 2, c] == 1 && board[b - 3, c] == 1) Win(true, e);
                        else;//left
                        if (board[b, c] == 1 && board[b , c+1] == 1 && board[b , c+2] == 1 && board[b , c+3] == 1) Win(true, e);
                        else;//up
                        if (board[b, c] == 1 && board[b, c - 1] == 1 && board[b, c - 2] == 1 && board[b, c - 3] == 1) Win(true, e);
                        else;//down
                        if (board[b, c] == 1 && board[b +1, c + 1] == 1 && board[b+2, c + 2] == 1 && board[b+3, c + 3] == 1) Win(true, e);
                        else;//up-right
                        if (board[b, c] == 1 && board[b - 1, c + 1] == 1 && board[b - 2, c + 2] == 1 && board[b - 3, c + 3] == 1) Win(true, e);
                        else;//up-left
                        if (board[b, c] == 1 && board[b - 1, c - 1] == 1 && board[b - 2, c - 2] == 1 && board[b - 3, c - 3] == 1) Win(true, e);
                        else;//down-left
                        if (board[b, c] == 1 && board[b + 1, c - 1] == 1 && board[b + 2, c - 2] == 1 && board[b + 3, c - 3] == 1) Win(true, e);
                        else;//down-right
                        //Red
                        if (board[b, c] == 2 && board[b + 1, c] == 2 && board[b + 2, c] == 2 && board[b + 3, c] == 2) Win(false, e);
                        else;//right
                        if (board[b, c] == 2 && board[b - 1, c] == 2 && board[b - 2, c] == 2 && board[b - 3, c] == 2) Win(false, e);
                        else;//left
                        if (board[b, c] == 2 && board[b, c + 1] == 2 && board[b, c + 2] == 2 && board[b, c + 3] == 2) Win(false, e);
                        else;//up
                        if (board[b, c] == 2 && board[b, c - 1] == 2 && board[b, c - 2] == 2 && board[b, c - 3] == 2) Win(false, e);
                        else;//down
                        if (board[b, c] == 2 && board[b + 1, c + 1] == 2 && board[b + 2, c + 2] == 2 && board[b + 3, c + 3] == 2) Win(false, e);
                        else;//up-right
                        if (board[b, c] == 2 && board[b - 1, c + 1] == 2 && board[b - 2, c + 2] == 2 && board[b - 3, c + 3] == 2) Win(false, e);
                        else;//up-left
                        if (board[b, c] == 2 && board[b - 1, c - 1] == 2 && board[b - 2, c - 2] == 2 && board[b - 3, c - 3] == 2) Win(false, e);
                        else;//down-left
                        if (board[b, c] == 2 && board[b + 1, c - 1] == 2 && board[b + 2, c - 2] == 2 && board[b + 3, c - 3] == 2) Win(false, e);
                        else;//down-right

                    }
                    catch (Exception a) { }
                }
            }
            for (int q=0; q<6;q++)
            {
                if (board[q, 5] != 0) num = num + 1;
                else;
                if (num > 5) tie = true;
                else;
            }
            if (num > 5) tie = true;
            else;
            if (tie == true) Tie(e);

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (win == false)
            {
                int w = this.ClientSize.Width;
                int h = this.ClientSize.Height;
                int i = (e.X /(w/7));
                int j = (e.Y /(h/6));
                int l = 0;
                
                if(turn == true && board[i,j] == 0)
                {
                    for (l = 0; l<6;)
                    {
                        if (turn == true && board[i, l] == 0)
                        {
                            j = l;
                            board[i, j] = 1;
                            l = 7;

                        }
                        else l = l + 1;
                    }
                    turn = false;
                }
                else if (turn == false && board[i, j] == 0)
                {
                    for (l = 0; l < 6;)
                    {
                        if (turn == false && board[i, l] == 0)
                        {
                            j = l;
                            board[i, j] = 2;
                            l = 7;
                        }
                        else l = l + 1;
                    }
                    turn = true;
                }
                
                this.Refresh();

            }
        }
        private void Win(bool turn,PaintEventArgs e)
        {
            win = true;
            String winner;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            if(turn==true)
            {
                winner = "Blue";
            }
            else
            {
                winner = "Red";
            }
            String wintext = winner + " player has won!";
            SizeF textSize = e.Graphics.MeasureString(wintext, new Font("Times New Roman", 72));
            if (turn == true)
            {
                e.Graphics.DrawString(wintext, new Font("Times New Roman", 50),Brushes.RoyalBlue, w/2 - (textSize.Width / 3), h / 3 - (textSize.Height / 3));

            }
            else
            {
                e.Graphics.DrawString(wintext, new Font("Times New Roman", 50), Brushes.Maroon, w/2 - (textSize.Width / 3), h / 3 - (textSize.Height / 3));

            }
        }
        private void Tie(PaintEventArgs e)
        {
            win = true;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            String tietext = ("The game is a tie!");
            SizeF textSize = e.Graphics.MeasureString(tietext, new Font("Times New Roman", 72));
            e.Graphics.DrawString(tietext, new Font("Times New Roman", 50), Brushes.Orange, w / 2 - (textSize.Width / 3), h / 3 - (textSize.Height / 3));
        }
        private void DrawRed(int i, int j, PaintEventArgs e)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            e.Graphics.FillRectangle(Brushes.Red, i*(w/7), j*(h/6), i + (w/7)-5,(h/6));
        }
        private void DrawBlue(int i, int j, PaintEventArgs e)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            e.Graphics.FillRectangle(Brushes.Blue, i * (w / 7), j * (h / 6), i + (w / 7)-5,(h / 6));
        }
    }

}
