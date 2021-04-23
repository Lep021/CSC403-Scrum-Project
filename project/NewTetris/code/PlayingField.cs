using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTetris.code {
  public class PlayingField {
    private bool[,] field;
    public event Action OnRowClear;

    private bool IsRowClear(int row) {
      return true;
    }

    public void CheckClearAllRows() {

    }
  }
}
