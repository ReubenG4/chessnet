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

        public PawnPiece(int idVal, Colour colourVal, int fileVal, int rowVal)
        {
            id = idVal;

            icon = "placeholder";

            colour = colourVal;

            position = Tuple.Create(fileVal, rowVal);

            hasMoved = false;

        }

        public void setPosition(int fileValue, int rowValue)
        {
            position = Tuple.Create(fileValue, rowValue);
            hasMoved = true;
        }
        public void setPosition(Tuple<int, int> newPosValue)
        {
            position = newPosValue;
        }


    }
}


