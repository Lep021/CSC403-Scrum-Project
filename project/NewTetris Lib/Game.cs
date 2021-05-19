using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// Oracle game class controling the entire game
  /// </summary>
  public class Game {
    /// <summary>
    /// Current level the player is on - currently unused
    /// </summary>
    private int level;

    /// <summary>
    /// Flag to see if player is currently playing the level
    /// and therefore level code should be running - currently unused
    /// </summary>
    private bool isPlaying;

    /// <summary>
    /// Current player score - currently unused
    /// </summary>
    private int score;

    /// <summary>
    /// Boolean used to determine which display to draw piece
    /// </summary>
    public static bool next;

    public int nextShapen;

    /// <summary>
    /// Random object used to randomly select next shape
    /// to appear in level
    /// </summary>
    private Random random;

    /// <summary>
    /// Current shape dropping onto the playing field
    /// </summary>
    public static Shape curShape;

    /// <summary>
    /// Next shape to drop
    /// </summary>
    public static Shape NShape;

    /// <summary>
    /// Link to widget displaying the next shape
    /// </summary>
    public static Control nextShape;

    /// <summary>
    /// Link to widget displaying the playing field. 
    /// Used to place pieces and shapes inside of it.
    /// </summary>
    public static Control field;

    /// <summary>
    /// Holds the image for a piece that is used to 
    /// compose a shape. This is used so the New Tetris Library
    /// can retrieve the image for a shape.
    /// </summary>
    public static Image imgPiece;

    /// <summary>
    /// Default constructor initializing random field and setting
    /// curShape to null
    /// </summary>
    public Game() {
      random = new Random();
      curShape = null;
    }

    /// <summary>
    /// Generates the next shape to be put into the playing field
    /// </summary>
    public void NextShape() {
        if (NShape == null)
        {
            next = false;
            int shapeNum1 = random.Next(7);
            ShapeType shapeType1 = (ShapeType)shapeNum1;
            curShape = ShapeFactory.MakeShape(shapeType1);
        }
        else
        {
            next = false;
            ShapeType shapeType1 = (ShapeType)nextShapen;
            curShape = ShapeFactory.MakeShape(shapeType1);
        }

        NShape = null;
        next = true;
        nextShapen = random.Next(7);
        ShapeType shapeType = (ShapeType)nextShapen;
        NShape = ShapeFactory.MakeShape(shapeType);

    }
  }
}
