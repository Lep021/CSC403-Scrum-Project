using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTetris.code {
  public class Piece {
    private PieceType type;
    private int row;
    private int col;
    private PictureBox[] pb;

    public bool CanMoveDown() {
      return true;
    }
  }
}
