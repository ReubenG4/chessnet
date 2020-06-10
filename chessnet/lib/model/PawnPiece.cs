using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class PawnPiece : Piece
    {
        public string name { get; set; }
        public string icon { get; set; }
        public List<Move> moveset { get; set; }

        public PawnPiece()
        {
            name = "Pawn";

            icon = "placeholder";

            moveset = new List<Move>();

            var northMove = new Move(false, false, 1);
            northMove.AddStep(Direction.North, 1);
            moveset.Add(northMove);

            var northFirstMove = new Move(false, false, 1);
            northFirstMove.AddStep(Direction.North, 2);
            moveset.Add(northFirstMove);

          
        }

    }
}


