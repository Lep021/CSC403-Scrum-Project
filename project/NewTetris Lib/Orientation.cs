using System.Collections.Generic;

namespace NewTetris_Lib {
  /// <summary>
  /// Used to store each of the four orientations of a shape
  /// </summary>
  public class Orientation {
    /// <summary>
    /// Dynamic array (aka List) of 2D positions indicating
    /// the position of each piece in the shape for this orientation
    /// </summary>
    public List<Position> positions;

    /// <summary>
    /// Default constructor initializing the positions to a 
    /// new empty List
    /// </summary>
    public Orientation() {
      positions = new List<Position>();
    }

    /// <summary>
    /// Explicit constructor initializing the positions to
    /// the given positions
    /// </summary>
    /// <param name="positions">List of positions to initialize field to</param>
    public Orientation(List<Position> positions) {
      this.positions = positions;
    }

    /// <summary>
    /// Adds a position to the list of position for this orientation
    /// </summary>
    /// <param name="pos">Position to add</param>
    public void AddPosition(Position pos) {
      this.positions.Add(pos);
    }
  }
}
