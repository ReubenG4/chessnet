using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace chessnet.lib.model
{
    public class KnightPiece : Piece
    {

        public int id { get; set; }
        public string icon { get; set; }

        public List<Move> moveset { get; set; }

        public KnightPiece(int nameVal)
        {
            id = nameVal;

            icon = "placeholder";

            moveset = new List<Move>();

            var northWestMove = new Move(true, false, 2);
            northWestMove.AddStep(Direction.North, 2);
            northWestMove.AddStep(Direction.West, 1);
            moveset.Add(northWestMove);

            var westNorthMove = new Move(true, false, 2);
            westNorthMove.AddStep(Direction.West, 2);
            westNorthMove.AddStep(Direction.North, 1);
            moveset.Add(westNorthMove);

            var northEastMove = new Move(true, false, 2);
            northEastMove.AddStep(Direction.North, 2);
            northEastMove.AddStep(Direction.East, 1);
            moveset.Add(northEastMove);

            var eastNorthMove = new Move(true, false, 2);
            eastNorthMove.AddStep(Direction.East, 2);
            eastNorthMove.AddStep(Direction.North, 1);
            moveset.Add(eastNorthMove);

            var southWestMove = new Move(true, false, 2);
            southWestMove.AddStep(Direction.South, 2);
            southWestMove.AddStep(Direction.West, 1);
            moveset.Add(southWestMove);

            var westSouthMove = new Move(true, false, 2);
            westSouthMove.AddStep(Direction.West, 2);
            westSouthMove.AddStep(Direction.South, 1);
            moveset.Add(westSouthMove);

            var southEastMove = new Move(true, false, 2);
            southEastMove.AddStep(Direction.South, 2);
            southEastMove.AddStep(Direction.East, 1);
            moveset.Add(southEastMove);

            var eastSouthMove = new Move(true, false, 2);
            eastSouthMove.AddStep(Direction.East, 2);
            eastSouthMove.AddStep(Direction.South, 1);
            moveset.Add(eastSouthMove);

        }
    }

}