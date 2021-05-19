using NewTetris.Properties;
using NewTetris_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTetris
{
    public partial class FrmMain : Form
    {
        public Game game;
        //Added Varible
        int lv = 1;
        public int score = 0;
        int scounter = 0;
        int spd = 500;
        String rank;
        bool practice;
        ///Need to make pausing the game better if possible.
        int pause = 999999999;

        public FrmMain()
        {
            InitializeComponent();
            Game.imgPiece = Resources.block_piece;
            game = new Game();
            Game.field = lblPlayingField;
            Game.nextShape = grpNextBlock;

            ///Show Message when the game start.
            System.Windows.Forms.MessageBox.Show("Thank You For Trying out our Game. :) \n\nUse the right, left, and down arrow key to move the piece. \n\n" +
            "Press Z to rotate the piece counter clockwise. \n\nPress X to rotate the piece clockwise. \n\nPress V to reshow this message \n\nPress P to enter Pratice Mode. \n\nPress Enter to pause the game. \n\nPress ESC to exit the game." +
            "\n\nPress Ok to start Playing.");

            game.NextShape();

            lblLevel.Location = new System.Drawing.Point(48, 140);
            lblLevel.Text = "Level: " + lv;
            label2.Text = "Score: " + score;
            rank = "Beginner";
            practice = false;
            tmrCurrentPieceFall.Interval = 500;
        }

        private void tmrCurrentPieceFall_Tick(object sender, EventArgs e)
        {
            if (Game.curShape != null)
            {
                if (!Game.curShape.TryMoveDown())
                {
                    Game.curShape.DissolveIntoField();
                    Game.curShape = null;
                    PlayingField.GetInstance().CheckClearAllRows();
                    Game.nextShape.Controls.Clear();
                    game.NextShape();

                    ///Stop game once block go over game field boundary.
                    for (int i = 0; i < 15; i++)
                    {
                        if (PlayingField.GetInstance().IsEmpty(0, i) == false)
                        {
                            tmrCurrentPieceFall.Interval = pause;
                            System.Windows.Forms.MessageBox.Show("A piece has hit the top, ending the game. \nThank you for playing. \nFinal Score: " + score + "\nFinal level: " + lv + "\nRank: " + rank);
                            System.Windows.Forms.Application.ExitThread();
                        }
                    }

                    ///Added Value
                    ///Score and Speed Value
                    if (lv < 5)
                    {
                        score += 100;
                        scounter += 1000;
                        spd = 500;
                    }
                    else if (lv >= 5 && lv < 10)
                    {
                        score += 300;
                        scounter += 600;
                        spd = 400;
                    }
                    else if (lv >= 10 && lv < 15)
                    {
                        score += 500;
                        scounter += 600;
                        spd = 300;
                    }
                    else if (lv >= 15 && lv < 20)
                    {
                        score += 1000;
                        scounter += 500;
                        spd = 200;
                    }
                    else if (lv >= 20)
                    {
                        score += 2000;
                        scounter += 300;
                        spd = 100;
                    }
                    tmrCurrentPieceFall.Interval = spd;

                    ///Rank System
                    if (lv < 5 && practice == false)
                    {
                        rank = "Beginner";
                    }
                    else if (lv >= 5 && lv < 10 && practice == false)
                    {
                        rank = "Intermediate";
                    }
                    else if (lv >= 10 && lv < 15 && practice == false)
                    {
                        rank = "Advance";

                    }
                    else if (lv >= 15 && lv < 20 && practice == false)
                    {
                        rank = "Expert";
                    }
                    else if (lv >= 20 && practice == false)
                    {
                        rank = "Master";
                    }
                    else
                    {
                        rank = "Pratice Mode";
                    }

                    /// Level Up System
                    if (practice == false)
                    {
                        label2.Text = "Score: " + score;
                    }
                    else
                    {
                        label2.Text = "Score: " + score + " (Pratice Mode)";
                    }

                    if (scounter >= 3000)
                    {
                        lv = lv + 1;
                        if (practice == false)
                        {
                            lblLevel.Text = "Level: " + lv;
                        }
                        else
                        {
                            lblLevel.Text = "Level: " + lv + " (Pratice Mode)";
                        }
                        scounter = 0;
                    }
                }
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Game.curShape.TryMoveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                Game.curShape.TryMoveRight();
            }
            else if (e.KeyCode == Keys.Z)
            {
                Game.curShape.RotateCCW();
            }
            else if (e.KeyCode == Keys.X)
            {
                Game.curShape.RotateCW();
            }
            ///Added Value
            /// Add a move down key to move pieces down.
            else if (e.KeyCode == Keys.Down)
            {
                Game.curShape.TryMoveDown();
            }

            /// tutorial Command
            else if (e.KeyCode == Keys.V)
            {
                tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("Thank You For Trying out our Game. :) \n\nUse the right, left, and down arrow key to move the piece. \n\n" +
                "Press Z to rotate the piece counter clockwise. \n\nPress X to rotate the piece clockwise. \n\nPress V to reshow this message \n\nPress P to enter Pratice Mode. \n\nPress Enter to pause the game. \n\nPress ESC to exit the game." +
                "\n\nPress Ok to start Playing.");
                tmrCurrentPieceFall.Interval = spd;
            }

            /// Pause Command
            else if (e.KeyCode == Keys.Enter)
            {
                tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("The Game is Pause. \n\nPress Ok to Continue.");
                tmrCurrentPieceFall.Interval = spd;
            }

            ///Force Closed Program
            else if (e.KeyCode == Keys.Escape)
            {
                tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("Thank you for playing. \n\nFinal Score: " + score + "\n\nFinal level: " + lv + "\n\nRank: " + rank);
                System.Windows.Forms.Application.ExitThread();
            }
            ///Pratice Mode Program
            else if (e.KeyCode == Keys.P)
            {
                lblLevel.Text = "Level: " + lv + " (Pratice Mode)";
                label2.Text = "Score: " + score + " (Pratice Mode)";
                rank = "Pratice Mode";
                if (lv < 5 && practice == true)
                {
                    lv += 5;
                    lblLevel.Text = "Level: " + lv + " (Pratice Mode)";
                    tmrCurrentPieceFall.Interval = 400;
                }
                else if (lv >= 5 && lv < 10 && practice == true)
                {
                    lv += 5;
                    lblLevel.Text = "Level: " + lv + " (Pratice Mode)";
                    tmrCurrentPieceFall.Interval = 300;
                }
                else if (lv >= 10 && lv < 15 && practice == true)
                {
                    lv += 5;
                    lblLevel.Text = "Level: " + lv + " (Pratice Mode)";
                    tmrCurrentPieceFall.Interval = 200;
                }
                else if (lv >= 15 && lv < 20 && practice == true)
                {
                    lv += 5;
                    lblLevel.Text = "Level: " + lv + " (Pratice Mode)";
                    tmrCurrentPieceFall.Interval = 100;
                }

                if(practice == false)
                {
                    tmrCurrentPieceFall.Interval = pause;
                    System.Windows.Forms.MessageBox.Show("You have entered the Pratice Mode for this game. \n\nThere are five speed that the game will switch to, once you reach a certain level." +
                        "\n\nTry to see how well you do at a certain level before trying out the game for real. \n\nPress P to increase the speed of the game.");
                    tmrCurrentPieceFall.Interval = spd;
                }

                practice = true;

            }
        }
    }
}
