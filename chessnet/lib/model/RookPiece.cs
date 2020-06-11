using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class RookPiece : Piece
    {
        public int id { get; set; }
        public string icon { get; set; }
        public colour colour { get; set; }

        public RookPiece(int nameVal, colour colourVal)
        {
            id = nameVal;

            icon = "placeholder";

            colour = colourVal;

        }

    }
}


