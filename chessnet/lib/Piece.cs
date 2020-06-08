using System;
using System.Collections.Generic;

public interface Piece
{
    string name { get; set; }
    string icon { get; set; }

    List<Move> moveset { get; set;}
}