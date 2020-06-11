using System;
using System.Collections.Generic;

namespace chessnet.lib.model
{
    public interface Piece
    {
        int id { get; set; }
        string icon { get; set; }

        List<Move> moveset { get; set; }
    }
}