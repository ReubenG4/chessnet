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

        public BishopPiece(int idVal, Colour colourVal, int fileVal, int rowVal)
        {
            id = idVal;

            icon = "placeholder";

            colour = colourVal;

            setPosition(fileVal, rowVal);

        }

        public void setPosition(int fileValue, int rowValue)
        {
            position = Tuple.Create(fileValue, rowValue);
        }

        public void setPosition(Tuple<int,int> newPosValue)
        {
            position = newPosValue;
        }

    }
}


