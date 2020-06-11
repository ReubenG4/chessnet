using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class BishopPiece : Piece
    {
        public int id { get; set; }
        public string icon { get; set; }
        public Colour colour { get; set; }
        public Tuple<int, int> position { get; set; }

        public BishopPiece(int idVal, Colour colourVal, int rowVal, int fileVal)
        {
            id = idVal;

            icon = "placeholder";

            colour = colourVal;

            setPosition(rowVal, fileVal);

        }

        public void setPosition(int rowValue, int fileValue)
        {
            position = Tuple.Create(rowValue, fileValue);
        }

    }
}


