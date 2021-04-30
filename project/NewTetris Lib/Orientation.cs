using System.Collections.Generic;

namespace NewTetris_Lib {

  public class Orientation {
    public List<Position> positions;

    public Orientation() {
      positions = new List<Position>();
    }
    public Orientation(List<Position> positions) {
      this.positions = positions;
    }

    public void AddPosition(Position pos) {
      this.positions.Add(pos);
    }
  }
}
