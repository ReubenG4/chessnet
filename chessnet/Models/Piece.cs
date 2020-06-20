using System;
using System.Collections.Generic;

namespace Chessnet.Models
{
    public enum Colour
    {
        Black = 0,
        White = 1
    }

    //Enumerated type to convert value of file position to a representative character
    public enum File
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8
    }

    public interface Piece
    {   
        //Placeholder variable to describe icon
        string icon { get; set; }
        //Colour of the piece
        Colour colour { get; set; }
        //Current position of piece
        int file { get; set; }
        int row { get; set; }

        //Set current position of piece
        public void setPosition(int fileValue, int rowValue);
        public void setPosition(File fileValue, int rowValue);
        public void setPosition(Tuple<int, int> posVal);
        public (int, int) getPosition();
        
        
    }
}