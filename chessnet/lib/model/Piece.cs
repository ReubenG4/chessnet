using System;
using System.Collections.Generic;

namespace chessnet.lib.model
{
    public enum Colour
    {
        Black = 0,
        White = 1
    }

    //Enumerated type to convert value of file position to a representative character
    public enum FileValToChar
    {
        a = 1,
        b = 2,
        c = 3,
        d = 4,
        e = 5,
        f = 6,
        g = 7,
        h = 9
    }

    public interface Piece
    {   
        //id number for a piece
        int id { get; set; }
        //Placeholder variable to describe icon
        string icon { get; set; }
        //Colour of the piece
        Colour colour { get; set; }
        //Current position of piece
        Tuple<int, int> position { get; set; }
        //Set current position of piece
        public void setPosition(int fileValue, int rowValue);
        public void setPosition(Tuple<int, int> posValue);
    }
}