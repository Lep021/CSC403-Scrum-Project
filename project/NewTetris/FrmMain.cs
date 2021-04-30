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

    public FrmMain() {
      InitializeComponent();
      Game.imgPiece = Resources.block_piece;
      game = new Game();
      Game.field = lblPlayingField;
      game.NextShape();
    }

    private void tmrCurrentPieceFall_Tick(object sender, EventArgs e) {
      if (Game.curShape != null) {
        if (!Game.curShape.TryMoveDown()) {
          Game.curShape.DissolveIntoField();
          Game.curShape = null;
          game.NextShape();
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
    }
  }
}
