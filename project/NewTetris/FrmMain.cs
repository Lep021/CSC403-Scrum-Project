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

namespace NewTetris {
  public partial class FrmMain : Form {
    public Game game;
        int lv = 1;
        int score = 0;
        int scounter = 0;
        int spd = 200;
        int pause = 999999999;

    public FrmMain() {
      InitializeComponent();
      Game.imgPiece = Resources.block_piece;
      game = new Game();
      Game.field = lblPlayingField;
            System.Windows.Forms.MessageBox.Show("Thank You For Trying out our Game. :) \n Use the right, left, and down arrow key to move the piece. \n " +
                "Press Z to rotate the piece counter clockwise. \n Press X to rotate the piece clockwise. \n *Developer Tool For Testing* \n " +
                "Press C to advance level \n Press V to increase your score \n Press B to speed up. \n Press N to reshow this message \n Press M to exit the game. \n Press Ok to start Playing.");
            game.NextShape();

            this.lblLevel.Text = "Level: " + lv;
            this.label2.Text = "Score: " + score;
            this.tmrCurrentPieceFall.Interval = spd;

        }

    private void tmrCurrentPieceFall_Tick(object sender, EventArgs e) {
        if (Game.curShape != null) {
        if (!Game.curShape.TryMoveDown()) {
          Game.curShape.DissolveIntoField();
          Game.curShape = null;
          game.NextShape();
                    ///Added Value
                    score += 100;
                    scounter += 100;
                    this.label2.Text = "Score: " + score;

                    if(scounter == 300)
                    {
                        lv = lv + 1;
                        this.lblLevel.Text = "Level: " + lv.ToString();
                        scounter = 0;
                        if(lv == 3)
                        {
                            spd = spd - 150;
                            this.tmrCurrentPieceFall.Interval = spd;
                        }
                    }
          }
      }
    }

    private void FrmMain_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Left) {
        Game.curShape.TryMoveLeft();
      }
      else if (e.KeyCode == Keys.Right) {
        Game.curShape.TryMoveRight();
      }
      else if (e.KeyCode == Keys.Z) {
        Game.curShape.RotateCCW();
      }
      else if (e.KeyCode == Keys.X) {
        Game.curShape.RotateCW();
      }
            ///Added Value
            /// Add a move down key to move pieces down.
            else if (e.KeyCode == Keys.Down)
            {
                Game.curShape.TryMoveDown();
            }
            /// Testing Level Up
            else if (e.KeyCode == Keys.C)
            {
                lv = lv+1;
                this.lblLevel.Text = "Level: " + lv.ToString();
            }
            /// Testing Score Up
            else if (e.KeyCode == Keys.V)
            {
                score = score + 50;
                this.label2.Text = "Score: " + score;
            }
            /// Testing Speed Up
            else if (e.KeyCode == Keys.B)
            {
                spd = spd - 50;
                this.tmrCurrentPieceFall.Interval = spd;
            }
            /// Testing Message
            else if (e.KeyCode == Keys.N)
            {
                this.tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("Thank You For Trying out our Game. :) \n Use the right, left, and down arrow key to move the piece. \n " +
    "Press Z to rotate the piece counter clockwise. \n Press X to rotate the piece clockwise. \n *Developer Tool For Testing* \n " +
    "Press C to advance level \n Press V to increase your score \n Press B to speed up. \n Press N to reshow this message \n Press M to exit the game. \n Press Ok to start Playing.");
                this.tmrCurrentPieceFall.Interval = spd;
            }
            /// Testing Speed Up
            else if (e.KeyCode == Keys.M)
            {
                this.tmrCurrentPieceFall.Interval = pause;
                System.Windows.Forms.MessageBox.Show("Thank you for playing. \n Final Score: " + score + "\n Highest level: " + lv);
                System.Windows.Forms.Application.ExitThread();
            }
        }
  }
}
