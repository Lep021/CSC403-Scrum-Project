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
        int score = 0;
        int scounter = 0;
        int spd = 500;
        ///Need to make pausing the game better if possible.
        int pause = 999999999;

        public FrmMain()
        {
            InitializeComponent();
            Game.imgPiece = Resources.block_piece;
            game = new Game();
            Game.field = lblPlayingField;

            System.Windows.Forms.MessageBox.Show("Thank You For Trying out our Game. :) \nUse the right, left, and down arrow key to move the piece. \n" +
            "Press Z to rotate the piece counter clockwise. \nPress X to rotate the piece clockwise. \nPress V to reshow this message \nPress Enter to pause the game. \nPress ESC to exit the game." +
            "\nPress Ok to start Playing.");

            game.NextShape();

            //PlayingField.GetInstance().CheckClearAllRows();

            lblLevel.Location = new System.Drawing.Point(48, 140);
            lblLevel.Text = "Level: " + lv;
            label2.Text = "Score: " + score;
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
                    game.NextShape();

                    ///Stop game once block go over game field boundary.
                    for (int i = 0; i < 15; i++) { 
                       if (PlayingField.GetInstance().IsEmpty(0, i) == false)
                        {
                            tmrCurrentPieceFall.Interval = pause;
                            System.Windows.Forms.MessageBox.Show("A piece has hit the top, ending the game. \nThank you for playing. \nFinal Score: " + score + "\nFinal level: " + lv);
                            System.Windows.Forms.Application.ExitThread();
                        } 
                    }

                    ///Added Value
                    ///Level and Score part of the game.
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
                        label2.Text = "Score: " + score;
                        if (scounter >= 3000)
                        {
                            lv = lv + 1;
                            lblLevel.Text = "Level: " + lv.ToString();
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

            /// Testing Message
            else if (e.KeyCode == Keys.V)
            {
                tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("Thank You For Trying out our Game. :) \nUse the right, left, and down arrow key to move the piece. \n" +
                "Press Z to rotate the piece counter clockwise. \nPress X to rotate the piece clockwise. \nPress V to reshow this message \nPress Enter to pause the game. \nPress ESC to exit the game." +
                "\nPress Ok to start Playing.");
                tmrCurrentPieceFall.Interval = spd;
            }

            /// Pause Command
            else if (e.KeyCode == Keys.Enter)
            {
                tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("The Game is Pause. Press Ok to Continue.");
                tmrCurrentPieceFall.Interval = spd;
            }

            ///Force Closed Program
            else if (e.KeyCode == Keys.Escape)
            {
                tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("Thank you for playing. \n Final Score: " + score + "\n Final level: " + lv);
                System.Windows.Forms.Application.ExitThread();
            }
        }
    }
}
