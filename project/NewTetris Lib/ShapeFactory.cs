namespace NewTetris_Lib {
  /// <summary>
  /// Uses the Factory design pattern to generate shape objects
  /// </summary>
  public class ShapeFactory {
    /// <summary>
    /// Factory method that makes shape objects based on the shape type given
    /// </summary>
    /// <param name="type">Shape type to create the shape from</param>
    /// <returns>Shape object</returns>
    public static Shape MakeShape(ShapeType type) {
      Orientation[] orientations = null;
      switch (type) {
        case ShapeType.LINE:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,0,1,0},
              {0,0,1,0},
              {0,0,1,0},
              {0,0,1,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {1,1,1,1},
              {0,0,0,0},
              {0,0,0,0}}),
          };
          break;
        case ShapeType.SQUARE:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,1,1,0},
              {0,1,1,0},
              {0,0,0,0}})
          };
          break;
        case ShapeType.LBLOCK:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,0,1,0},
              {1,1,1,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,1,0,0},
              {0,1,0,0},
              {0,1,1,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,0,0,0},
              {1,1,1,0},
              {1,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,1,1,0},
              {0,0,1,0},
              {0,0,1,0},
              {0,0,0,0}}),
          };
          break;
        case ShapeType.RBLOCK:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {1,0,0,0},
              {1,1,1,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,1,1,0},
              {0,1,0,0},
              {0,1,0,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,0,0,0},
              {1,1,1,0},
              {0,0,1,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,0,1,0},
              {0,0,1,0},
              {0,1,1,0}}),
          };
          break;
        case ShapeType.ZBLOCK:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {1,1,0,0},
              {0,1,1,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,0,1,0},
              {0,1,1,0},
              {0,1,0,0}}),
          };
          break;
        case ShapeType.TBLOCK:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,1,0,0},
              {1,1,1,0},
              {0,0,0,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,1,0,0},
              {0,1,1,0},
              {0,1,0,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {1,1,1,0},
              {0,1,0,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,1,0,0},
              {1,1,0,0},
              {0,1,0,0},
              {0,0,0,0}}),
          };
          break;
        case ShapeType.REV_ZBLOCK:
          orientations = new Orientation[] {
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,1,1,0},
              {1,1,0,0},
              {0,0,0,0}}),
            MakeOrientation(new int[,] {
              {0,0,0,0},
              {0,1,0,0},
              {0,1,1,0},
              {0,0,1,0}}),
          };
          break;
      }
      Shape shape = new Shape(orientations);
      return shape;
    }

    /// <summary>
    /// Takes a grid of 1s and 0s to create an orientation for a shape
    /// </summary>
    /// <param name="grid">Grid of 1s and 0s</param>
    /// <returns>Orientation object</returns>
    private static Orientation MakeOrientation(int[,] grid) {
      Orientation orientation = new Orientation();
      for (int r = 0; r < grid.GetLength(0); r++) {
        for (int c = 0; c < grid.GetLength(1); c++) {
          if (grid[r, c] == 1) {
            orientation.AddPosition(new Position(c * Piece.SIZE, r * Piece.SIZE));
          }
        }
      }
      return orientation;
    }
  }
}
