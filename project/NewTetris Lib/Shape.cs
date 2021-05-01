namespace NewTetris_Lib {
  /// <summary>
  /// Used to store a Tetris shape
  /// </summary>
  public class Shape {
    /// <summary>
    /// Array of individual pieces (squares) that
    /// composes this shape. Is always 4 pieces.
    /// </summary>
    private Piece[] pieces;

    /// <summary>
    /// Array of orientations for this shape
    /// </summary>
    private Orientation[] orientations;

    /// <summary>
    /// Current orientation
    /// </summary>
    private int orientationIndex;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="orientations">Array of orientations to use</param>
    public Shape(Orientation[] orientations) {
      this.orientationIndex = 0;
      this.orientations = orientations;
      pieces = new Piece[4];
      int numPositions = orientations[orientationIndex].positions.Count;
      for (int i = 0; i < 4; i++) {
        pieces[i] = new Piece(orientations[orientationIndex].positions[i % numPositions]);
      }
    }

    /// <summary>
    /// Updates the position of each piece based on the current orientation
    /// </summary>
    private void UpdatePiecePos() {
      int numPositions = orientations[orientationIndex].positions.Count;
      for (int i = 0; i < pieces.Length; i++) {
        pieces[i].SetPos(orientations[orientationIndex].positions[i % numPositions]);
      }
    }

    /// <summary>
    /// Rotates the shape clockwise
    /// </summary>
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

    /// <summary>
    /// Rotates the shape counter clockwise
    /// </summary>
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

    /// <summary>
    /// Moves all orientations down to allow them to keep up with the shape
    /// </summary>
    public void MoveOrientationsDown() {
      for (int oi = 0; oi < orientations.Length; oi++) {
        for (int o = 0; o < orientations[oi].positions.Count; o++) {
          orientations[oi].positions[o] = new Position(
            orientations[oi].positions[o].x,
            orientations[oi].positions[o].y + Piece.SIZE);
        }
      }
    }

    /// <summary>
    /// Moves all orientations to the right to allow them to keep up with the shape
    /// </summary>
    public void MoveOrientationsRight() {
      for (int oi = 0; oi < orientations.Length; oi++) {
        for (int o = 0; o < orientations[oi].positions.Count; o++) {
          orientations[oi].positions[o] = new Position(
            orientations[oi].positions[o].x + Piece.SIZE,
            orientations[oi].positions[o].y);
        }
      }
    }

    /// <summary>
    /// Moves all orientations to the left to allow them to keep up with the shape
    /// </summary>
    public void MoveOrientationsLeft() {
      for (int oi = 0; oi < orientations.Length; oi++) {
        for (int o = 0; o < orientations[oi].positions.Count; o++) {
          orientations[oi].positions[o] = new Position(
            orientations[oi].positions[o].x - Piece.SIZE,
            orientations[oi].positions[o].y);
        }
      }
    }

    /// <summary>
    /// Tries to move the shape down as long as all pieces can move down
    /// </summary>
    /// <returns>True if shape was able to move down, False otherwise</returns>
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

    /// <summary>
    /// Tries to move the shape left as long as all pieces can move left
    /// </summary>
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

    /// <summary>
    /// Tries to move the shape right as long as all pieces can move right
    /// </summary>
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

    /// <summary>
    /// Dissolves each piece into playing field, setting each
    /// position to 1 in the field
    /// </summary>
    public void DissolveIntoField() {
      foreach (Piece piece in pieces) {
        piece.DissolveIntoField();
      }
    }
  }
}
