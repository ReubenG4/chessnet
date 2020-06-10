using System;
using System.Collections.Generic;

namespace chessnet.lib
{
    public interface Piece
    {
        string name { get; set; }
        string icon { get; set; }

        List<Move> moveset { get; set; }
    }
}