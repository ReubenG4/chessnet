using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class QueenPiece : Piece
    {
        public int id{ get; set; }
        public string icon { get; set; }
        public colour colour { get; set; }
        public int row { get; set; }
        public int file { get; set; }

        public QueenPiece(int nameVal, colour colourVal, int row, int file)
        {
            id = nameVal;

            icon = "placeholder";

            colour = colourVal;

            setPosition(row, file);

        }

        public void setPosition(int rowValue, int fileValue)
        {
            row = rowValue;
            file = fileValue;
        }

    }
}


