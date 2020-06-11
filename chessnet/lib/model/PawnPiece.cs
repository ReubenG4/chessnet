using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class PawnPiece : Piece
    {
        public int id { get; set; }
        public string icon { get; set; }
        public Colour colour { get; set; }
        public bool hasMoved { get; set; }
        public Tuple<int, int> position { get; set; }

        public PawnPiece(int idVal, Colour colourVal, int rowVal, int fileVal)
        {
            id = idVal;

            icon = "placeholder";

            colour = colourVal;

            position = Tuple.Create(rowVal, fileVal);

            hasMoved = false;

        }

        public void setPosition(int rowValue, int fileValue)
        {
            position = Tuple.Create(rowValue, fileValue);
            hasMoved = true;
        }


    }
}


