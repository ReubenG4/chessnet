using System;
using System.Collections.Generic;

namespace chessnet.lib.model
{
    public enum colour
    {
        black = 0,
        white = 1
    }

    public interface Piece
    {
        int id { get; set; }
        string icon { get; set; }

        colour colour { get; set; }
    }
}