using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// The class holds a single cube that can be used to compose a Tetris shape
  /// </summary>
  public class Piece {
    /// <summary>
    /// Size of piece, i.e the width and height in pixels
    /// </summary>
    public const int SIZE = 30;

    /// <summary>
    /// Current position of piece
    /// </summary>
    private Position pos;

    /// <summary>
    /// Control used to hold the image of the piece so GUI can display it
    /// </summary>
    private PictureBox pic;

    /// <summary>
    /// typical explicit constructor
    /// </summary>
    /// <param name="pos">This gives the position of the piece</param>
    public Piece(Position pos) {
      this.pos = pos;
      pic = new PictureBox();
      pic.BackgroundImage = Game.imgPiece;
      pic.BackgroundImageLayout = ImageLayout.Stretch;
      pic.Size = new System.Drawing.Size(SIZE, SIZE);
      Game.field.Controls.Add(pic);
      UpdateImgPos();
    }
    
    /// <summary>
    /// Sets the position of the piece
    /// </summary>
    /// <param name="pos">New position of the piece</param>
    public void SetPos(Position pos) {
      this.pos = pos;
      UpdateImgPos();
    }

    /// <summary>
    /// Allows the Picture Box control to be updated to the
    /// position of the piece, meaning the visual representation
    /// of the piece will now match the coding position of the piece.
    /// </summary>
    private void UpdateImgPos() {
      pic.Left = pos.x;
      pic.Top = pos.y;
      pic.Refresh();
    }

    /// <summary>
    /// Check to see if the piece can move down.
    /// </summary>
    /// <returns>True if moving down will not cause a collision, False otherwise</returns>
    public bool CanMoveDown() {
      Position posMoveTo = pos;
      posMoveTo.y += SIZE;
      return !IsCollision(posMoveTo);
    }

    /// <summary>
    /// Check to see if the piece can move left.
    /// </summary>
    /// <returns>True if moving left will not cause a collision, False otherwise</returns>
    public bool CanMoveLeft() {
      Position posMoveTo = pos;
      posMoveTo.x -= SIZE;
      return !IsCollision(posMoveTo);
    }

    /// <summary>
    /// Check to see if the piece can move right.
    /// </summary>
    /// <returns>True if moving right will not cause a collision, False otherwise</returns>
    public bool CanMoveRight() {
      Position posMoveTo = pos;
      posMoveTo.x += SIZE;
      return !IsCollision(posMoveTo);
    }

    /// <summary>
    /// Puts this piece into the playing field. This takes the current position of the piece
    /// and puts a 1 in the playing field at that location, signify it is now occupied
    /// </summary>
    public void DissolveIntoField() {
      int r = pos.y / SIZE;
      int c = pos.x / SIZE;
      PlayingField.GetInstance().field[r, c] = 1;
    }

    /// <summary>
    /// Moves the piece down, updating the visual representation as well
    /// </summary>
    /// <returns>True if moving down was successful (i.e. no collision occurred), False otherwise</returns>
    public bool MoveDown() {
      Position posMoveTo = pos;
      posMoveTo.y += SIZE;
      if (!IsCollision(posMoveTo)) {
        this.pos = posMoveTo;
        UpdateImgPos();
        return true;
      }
      else {
        return false;
      }
    }

    /// <summary>
    /// Moves the piece left, updating the visual representation as well
    /// </summary>
    public void MoveLeft() {
      Position posMoveTo = pos;
      posMoveTo.x -= SIZE;
      if (!IsCollision(posMoveTo)) {
        this.pos = posMoveTo;
        UpdateImgPos();
      }
    }

    /// <summary>
    /// Moves the piece right, updating the visual representation as well
    /// </summary>
    public void MoveRight() {
      Position posMoveTo = pos;
      posMoveTo.x += SIZE;
      if (!IsCollision(posMoveTo)) {
        this.pos = posMoveTo;
        UpdateImgPos();
      }
    }

    /// <summary>
    /// Checks if this piece's position is already occupied in the playing field
    /// </summary>
    /// <returns>
    /// True if a collision occurred (i.e. playing field already has a 1 in the piece's current position),
    /// False otherwise
    /// </returns>
    public bool IsCollision() {
      return IsCollision(this.pos);
    }

    /// <summary>
    /// Checks a given position to see if it is already occupied in the playing field.
    /// Used to specutively move a piece and see if a collision would occur, without actually
    /// modifying its current position
    /// </summary>
    /// <param name="pos">Position to check</param>
    /// <returns>True if a collision does occur at the given position, False otherwise</returns>
    public bool IsCollision(Position pos) {
      int r = pos.y / SIZE;
      int c = pos.x / SIZE;
      return !PlayingField.GetInstance().IsEmpty(r, c);
    }
  }
}
