using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace chessnet.lib.model
{
    public class KnightPiece : Piece
    {

        public int id { get; set; }
        public string icon { get; set; }

        public colour colour { get; set; }

        public KnightPiece(int nameVal, colour colourVal)
        {
            id = nameVal;

            icon = "placeholder";

            colour = colourVal;
        }
    }

}