using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class PawnPiece : Piece
    {
        public int id { get; set; }
        public string icon { get; set; }
        public colour colour { get; set; }
        public bool hasMoved { get; set; }
        public int row { get; set; }
        public int file { get; set; }

        public PawnPiece(int nameVal, colour colourVal, int row, int file)
        {
            id = nameVal;

            icon = "placeholder";

            colour = colourVal;

            setPosition(row, file);

            hasMoved = false;

        }

        public void setPosition(int rowValue, int fileValue)
        {
            row = rowValue;
            file = fileValue;
        }

    }
}


