using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class RookPiece : Piece
    {
        public string name { get; set; }
        public string icon { get; set; }
        public List<Move> moveset { get; set; }

        public RookPiece()
        {
            name = "Rook";

            icon = "placeholder";

            moveset = new List<Move>();

            var northMove = new Move(false, true, 1);
            northMove.AddStep(Direction.North, 7);
            moveset.Add(northMove);

            var southMove = new Move(false, true, 1);
            southMove.AddStep(Direction.South, 7);
            moveset.Add(southMove);

            var eastMove = new Move(false, true, 1);
            eastMove.AddStep(Direction.East, 7);
            moveset.Add(southMove);

            var westMove = new Move(false, true, 1);
            westMove.AddStep(Direction.West, 7);
            moveset.Add(southMove);

        }

    }
}


