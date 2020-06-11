using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    public class QueenPiece : Piece
    {
        public int id{ get; set; }
        public string icon { get; set; }
        public List<Move> moveset { get; set; }

        public QueenPiece(int nameVal)
        {
            id = nameVal;

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


