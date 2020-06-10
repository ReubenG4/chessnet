using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib
{
    public class BishopPiece : Piece
    {
        public string name { get; set; }
        public string icon { get; set; }
        public List<Move> moveset { get; set; }

        public BishopPiece()
        {
            name = "Bishop";

            icon = "placeholder";

            moveset = new List<Move>();

            var northEastMove = new Move(false, true, 1);
            northEastMove.AddStep(Direction.NorthEast, 7);
            moveset.Add(northEastMove);

            var northWestMove = new Move(false, true, 1);
            northWestMove.AddStep(Direction.NorthWest, 7);
            moveset.Add(northWestMove);

            var southEastMove = new Move(false, true, 1);
            southEastMove.AddStep(Direction.SouthEast, 7);
            moveset.Add(southEastMove);

            var southWestMove = new Move(false, true, 1);
            southWestMove.AddStep(Direction.SouthWest, 7);
            moveset.Add(southWestMove);

        }

    }
}


