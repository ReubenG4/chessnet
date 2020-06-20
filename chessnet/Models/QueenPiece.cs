using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    public class QueenPiece : Piece
    {
        public string icon { get; set; }
        public Colour colour { get; set; }
        public int file { get; set; }
        public int row { get; set; }
 

        public QueenPiece(Colour colourVal, File fileVal, int rowVal)
        {

            icon = "placeholder";

            colour = colourVal;

            setPosition(fileVal, rowVal);

        }

        public void setPosition(int fileValue, int rowValue)
        {
            file = fileValue;
            row = rowValue;
        }

        public void setPosition(File fileValue, int rowValue)
        {
            file = (int)fileValue;
            row = rowValue;
        }

        public void setPosition(Tuple<int, int> posVal)
        {
            file = posVal.Item1;
            row = posVal.Item2;
        }

        public (int, int) getPosition()
        {
            return (file, row);
        }

    }
}


