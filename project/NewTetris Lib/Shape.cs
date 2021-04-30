namespace NewTetris_Lib {
  public class Shape {
    private ShapeType type;
    private int row;
    private int col;
    private Piece[] pieces;
    private Orientation[] orientations;
    private int orientationIndex;

    public Shape(Orientation[] orientations) {
      this.orientationIndex = 0;
      this.orientations = orientations;
      pieces = new Piece[4];
      int numPositions = orientations[orientationIndex].positions.Count;
      for (int i = 0; i < 4; i++) {
        pieces[i] = new Piece(orientations[orientationIndex].positions[i % numPositions]);
      }
    }

    private void UpdatePiecePos() {
      int numPositions = orientations[orientationIndex].positions.Count;
      for (int i = 0; i < pieces.Length; i++) {
        pieces[i].SetPos(orientations[orientationIndex].positions[i % numPositions]);
      }
    }

    public void RotateCW() {
      orientationIndex++;
      if (orientationIndex >= orientations.Length) {
        orientationIndex = 0;
      }
      UpdatePiecePos();
      bool rotationValid = true;
      foreach (Piece piece in pieces) {
        rotationValid &= !piece.IsCollision();
      }
      if (!rotationValid) {
        RotateCCW();
      }
    }

    public void RotateCCW() {
      orientationIndex--;
      if (orientationIndex < 0) {
        orientationIndex = orientations.Length - 1;
      }
      UpdatePiecePos();
      bool rotationValid = true;
      foreach (Piece piece in pieces) {
        rotationValid &= !piece.IsCollision();
      }
      if (!rotationValid) {
        RotateCW();
      }
    }

    public void MoveOrientationsDown() {
      for (int oi = 0; oi < orientations.Length; oi++) {
        for (int o = 0; o < orientations[oi].positions.Count; o++) {
          orientations[oi].positions[o] = new Position(
            orientations[oi].positions[o].x,
            orientations[oi].positions[o].y - Piece.SIZE);
        }
      }
    }

    public void MoveOrientationsRight() {
      for (int oi = 0; oi < orientations.Length; oi++) {
        for (int o = 0; o < orientations[oi].positions.Count; o++) {
          orientations[oi].positions[o] = new Position(
            orientations[oi].positions[o].x + Piece.SIZE,
            orientations[oi].positions[o].y);
        }
      }
    }

    public void MoveOrientationsLeft() {
      for (int oi = 0; oi < orientations.Length; oi++) {
        for (int o = 0; o < orientations[oi].positions.Count; o++) {
          orientations[oi].positions[o] = new Position(
            orientations[oi].positions[o].x - Piece.SIZE,
            orientations[oi].positions[o].y);
        }
      }
    }

    public bool TryMoveDown() {
      bool canMoveDown = true;
      foreach (Piece piece in pieces) {
        canMoveDown &= piece.CanMoveDown();
      }
      if (canMoveDown) {
        foreach (Piece piece in pieces) {
          piece.MoveDown();
        }
        MoveOrientationsDown();
      }
      return canMoveDown;
    }

    public void TryMoveLeft() {
      bool canMoveLeft = true;
      foreach (Piece piece in pieces) {
        canMoveLeft &= piece.CanMoveLeft();
      }
      if (canMoveLeft) {
        foreach (Piece piece in pieces) {
          piece.MoveLeft();
        }
        MoveOrientationsLeft();
      }
    }

    public void TryMoveRight() {
      bool canMoveRight = true;
      foreach (Piece piece in pieces) {
        canMoveRight &= piece.CanMoveRight();
      }
      if (canMoveRight) {
        foreach (Piece piece in pieces) {
          piece.MoveRight();
        }
        MoveOrientationsRight();
      }
    }

    public void DissolveIntoField() {
      foreach (Piece piece in pieces) {
        piece.DissolveIntoField();
      }
    }
  }
}
