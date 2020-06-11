using System;
using System.Collections.Generic;

namespace chessnet.lib.model
{
    public enum Colour
    {
        Black = 0,
        White = 1
    }

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
        int id { get; set; }
        string icon { get; set; }
        Colour colour { get; set; }
        Tuple<int, int> position { get; set; }
        public void setPosition(int rowValue, int fileValue);
    }
}