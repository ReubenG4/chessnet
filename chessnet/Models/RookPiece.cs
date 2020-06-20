using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    public class RookPiece : Piece
    {
        public string icon { get; set; }
        public Colour colour { get; set; }
        public int file { get; set; }
        public int row { get; set; }
        public string position { get; set; }

        public RookPiece(Colour colourVal, File fileVal, int rowVal)
        {

            icon = "placeholder";

            colour = colourVal;

            file = (int)fileVal;

            row = rowVal;

            setPosition(fileVal, rowVal);

        }
        public void setPosition(File fileValue, int rowValue)
        {
            file = (int)fileValue;
            row = rowValue;

            position = $"{(int)fileValue}{rowValue}";
        }
    }
}


