using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class KingPiece : Piece
    {
        public int id { get; set; }
        public string icon { get; set; }
        public List<Move> moveset { get; set; }

        public KingPiece(int nameVal)
        {
            id = nameVal;

            icon = "placeholder";

            moveset = new List<Move>();

            var northMove = new Move(false, false, 1);
            northMove.AddStep(Direction.North, 1);
            moveset.Add(northMove);

            var southMove = new Move(false, false, 1);
            southMove.AddStep(Direction.South, 1);
            moveset.Add(southMove);

            var eastMove = new Move(false, false, 1);
            eastMove.AddStep(Direction.East, 1);
            moveset.Add(southMove);

            var westMove = new Move(false, false, 1);
            westMove.AddStep(Direction.West, 1);
            moveset.Add(southMove);

            var northEastMove = new Move(false, false, 1);
            northEastMove.AddStep(Direction.NorthEast, 1);
            moveset.Add(northEastMove);

            var northWestMove = new Move(false, false, 1);
            northWestMove.AddStep(Direction.NorthWest, 1);
            moveset.Add(northWestMove);

            var southEastMove = new Move(false, false, 1);
            southEastMove.AddStep(Direction.SouthEast, 1);
            moveset.Add(southEastMove);

            var southWestMove = new Move(false, false, 1);
            southWestMove.AddStep(Direction.SouthWest, 1);
            moveset.Add(southWestMove);

        }

    }
}


