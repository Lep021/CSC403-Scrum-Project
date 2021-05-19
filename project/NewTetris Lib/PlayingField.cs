using System;

namespace NewTetris_Lib {
    /// <summary>
    /// Encodes information about the playing
    /// field of the game. Uses a grid of rows
    /// and cols storing 1 for occupied and 0
    /// for vacant
    /// </summary>
    public class PlayingField
    {
        /// <summary>
        /// Singleton pattern instance
        /// </summary>
        private static PlayingField instance = null;

        /// <summary>
        /// Grid holding 1 for occupied, 0 for vacant
        /// </summary>
        public int[,] field;

        /// <summary>
        /// Observer pattern event for when a row is 
        /// cleared - currently unused
        /// </summary>
        public event Action OnRowClear;

        
        /// <summary>
        /// init temp piece to fill grid.
        /// </summary>
        public Piece tempPiece;

        /// <summary>
        /// Default constructor initializing the field
        /// to 22 rows and 15 columns
        /// </summary>
        private PlayingField()
        {
            field = new int[22, 15];
        }

        /// <summary>
        /// Retrieves the Singleton pattern instance
        /// </summary>
        /// <returns>The Singleton instance</returns>
        public static PlayingField GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayingField();
            }
            return instance;
        }

        /// <summary>
        /// Checks if a location in the field is empty (i.e. vacant)
        /// </summary>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <returns>True if empty, False otherwise</returns>
        public bool IsEmpty(int r, int c)
        {
            if (r < 0 || r >= field.GetLength(0) || c < 0 || c >= field.GetLength(1))
            {
                return false;
            }
            return field[r, c] == 0;
        }

        /// <summary>
        /// Checks each row to see if any of them are filled and
        /// needs to be cleared, then clears those rows - currently
        /// unused and not implemented
        /// </summary>
        public void CheckClearAllRows()
        {
            double multiplier = 0.5;
            double clearscore = 1000;
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (GetInstance().IsEmpty(i, j) == true)
                    {
                        break;
                    }
                    else
                    {
                        if (j == 14)
                        {
                            ClearRow(i);
                            multiplier = multiplier * 2;
                        }
                    }
                }
            }
            clearscore = clearscore * multiplier;
        }
        /// <summary>
        /// Clears the row
        /// </summary>
        /// <param name="r">The row that will be removed</param>
        public void ClearRow(int r)
        {
            //Clears the row
            for (int i = 0; i < 15; i++)
            {
                field[r, i] = 0;
            }
            //Shift rows down
            for (int j = 0; j < 15; j++)
            {
                int i = r;
                while (i>0)
                {
                    field[i, j] = field[i-1, j];
                    i -= 1;
                }
                field[0, j] = 0;
            }
            //Erases blocks
            Game.field.Controls.Clear();
            //Re-generates blocks on grid when pos = 1
            for (int j = 0; j < 15; j++)
            {
                for (int i = 0; i < 22; i++)
                {
                    if(field[i,j] == 1)
                    {
                        Game.next = false;
                        tempPiece = new Piece(new Position(j * Piece.SIZE, i * Piece.SIZE));
                    }
                }
            }
        }
    }
}
