namespace NewTetris_Lib {
  /// <summary>
  /// This holds the different types of shapes.
  /// Used in Shape class to hold the type of shape.
  /// </summary>
  public enum ShapeType {
    /// <summary>
    /// Makes the following shape<br />
    ///    X<br />
    ///    X<br />
    ///    X<br />
    ///    X
    /// </summary>
    LINE,

    /// <summary>
    /// Makes the following shape<br />
    ///    XX<br />
    ///    XX
    /// </summary>
    SQUARE,

    /// <summary>
    /// Makes the following shape<br />
    ///    X<br />
    ///    X<br />
    ///    XX
    /// </summary>
    LBLOCK,

    /// <summary>
    /// Makes the following shape<br />
    ///    X<br />
    ///    X<br />
    ///   XX<br />
    /// </summary>
    RBLOCK,

    /// <summary>
    /// Makes the following shape<br />
    ///    XX<br />
    ///     XX<br />
    /// </summary>
    ZBLOCK,

    /// <summary>
    /// Makes the following shape<br />
    ///     X<br />
    ///    XXX
    /// </summary>
    TBLOCK,

    /// <summary>
    /// Makes the following shape<br />
    ///    XX<br />
    ///   XX<br />
    /// </summary>
    REV_ZBLOCK,
  }
}
