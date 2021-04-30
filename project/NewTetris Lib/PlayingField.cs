using System;

namespace NewTetris_Lib {
  public class PlayingField {
    private static PlayingField instance = null;

    public int[,] field;
    public event Action OnRowClear;

    private PlayingField() {
      field = new int[22,15];
    }

    public static PlayingField GetInstance() {
      if (instance == null) {
        instance = new PlayingField();
      }
      return instance;
    }

    public bool IsEmpty(int r, int c) {
      if (r < 0 || r >= field.GetLength(0) || c < 0 || c >= field.GetLength(1)) {
        return false;
      }
      return field[r, c] == 0;
    }

    private bool IsRowClear(int row) {
      return true;
    }

    public void CheckClearAllRows() {

    }
  }
}
