namespace NewTetris_Lib {
  /// <summary>
  /// Stores a 2D position composed of an
  /// X and Y coordinate
  /// </summary>
  public struct Position {
    /// <summary>
    /// X coordinate
    /// </summary>
    public int x;

    /// <summary>
    /// Y coordinate
    /// </summary>
    public int y;

    /// <summary>
    /// Explicit constructor
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public Position(int x, int y) {
      this.x = x;
      this.y = y;
    }
  }
}
