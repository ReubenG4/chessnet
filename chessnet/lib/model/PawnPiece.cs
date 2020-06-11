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

        public PawnPiece(int nameVal, colour colourVal)
        {
            id = nameVal;

            icon = "placeholder";

            colour = colourVal;

            hasMoved = false;
          
        }

    }
}


