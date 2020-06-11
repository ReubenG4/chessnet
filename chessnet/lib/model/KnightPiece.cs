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
        public int row { get; set; }
        public int file { get; set; }

        public KnightPiece(int nameVal, colour colourVal, int row, int file)
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