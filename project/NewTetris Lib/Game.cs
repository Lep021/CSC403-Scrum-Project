using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTetris_Lib {
  public class Game {
    private int level;
    private bool isPlaying;
    private int score;
    private Random random;
    public static Shape curShape;
    public static Control field;
    public static Image imgPiece;

    public Game() {
      random = new Random();
      curShape = null;
    }

    public void NextShape() {
      int shapeNum = random.Next(7);
      ShapeType shapeType = (ShapeType)shapeNum;
      curShape = ShapeFactory.MakeShape(shapeType);
    }
  }
}
