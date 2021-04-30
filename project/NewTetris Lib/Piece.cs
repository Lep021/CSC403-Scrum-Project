using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// The class holds a single cube that can be used to compose a Tetris shape
  /// </summary>
  public class Piece {
    public const int SIZE = 30;

    private Position pos;
    private PictureBox img;

    /// <summary>
    /// typical explicit constructor
    /// </summary>
    /// <param name="pos">This gives the position of the piece</param>
    public Piece(Position pos) {
      this.pos = pos;
      img = new PictureBox();
      img.BackgroundImage = Game.imgPiece;
      img.BackgroundImageLayout = ImageLayout.Stretch;
      img.Size = new System.Drawing.Size(SIZE, SIZE);
      Game.field.Controls.Add(img);
      UpdateImgPos();
    }
    
    public void SetPos(Position pos) {
      this.pos = pos;
      UpdateImgPos();
    }

    private void UpdateImgPos() {
      img.Left = pos.x;
      img.Top = pos.y;
      img.Refresh();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool CanMoveDown() {
      Position posMoveTo = pos;
      posMoveTo.y += SIZE;
      return !IsCollision(posMoveTo);
    }

    public bool CanMoveLeft() {
      Position posMoveTo = pos;
      posMoveTo.x -= SIZE;
      return !IsCollision(posMoveTo);
    }

    public bool CanMoveRight() {
      Position posMoveTo = pos;
      posMoveTo.x += SIZE;
      return !IsCollision(posMoveTo);
    }

    public void DissolveIntoField() {
      int r = pos.y / SIZE;
      int c = pos.x / SIZE;
      PlayingField.GetInstance().field[r, c] = 1;
    }

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

    public bool MoveLeft() {
      Position posMoveTo = pos;
      posMoveTo.x -= SIZE;
      if (!IsCollision(posMoveTo)) {
        this.pos = posMoveTo;
        UpdateImgPos();
        return true;
      }
      else {
        return false;
      }
    }

    public bool MoveRight() {
      Position posMoveTo = pos;
      posMoveTo.x += SIZE;
      if (!IsCollision(posMoveTo)) {
        this.pos = posMoveTo;
        UpdateImgPos();
        return true;
      }
      else {
        return false;
      }
    }

    public bool IsCollision() {
      return IsCollision(this.pos);
    }
    public bool IsCollision(Position pos) {
      int r = pos.y / SIZE;
      int c = pos.x / SIZE;
      return !PlayingField.GetInstance().IsEmpty(r, c);
    }
  }
}
