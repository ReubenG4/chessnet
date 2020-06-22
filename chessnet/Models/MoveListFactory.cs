using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    public static class MoveListFactory
    {
        public static List<Move> CreateBishopMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northEastMove = new Move(false, true, 1);
            northEastMove.AddStep(Direction.NorthEast, 7);
            moveset.Add(northEastMove);

            Move northWestMove = new Move(false, true, 1);
            northWestMove.AddStep(Direction.NorthWest, 7);
            moveset.Add(northWestMove);

            Move southEastMove = new Move(false, true, 1);
            southEastMove.AddStep(Direction.SouthEast, 7);
            moveset.Add(southEastMove);

            Move southWestMove = new Move(false, true, 1);
            southWestMove.AddStep(Direction.SouthWest, 7);
            moveset.Add(southWestMove);

            return moveset;
        }

        public static List<Move> CreateKingMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northMove = new Move(false, false, 1);
            northMove.AddStep(Direction.North, 1);
            moveset.Add(northMove);

            Move southMove = new Move(false, false, 1);
            southMove.AddStep(Direction.South, 1);
            moveset.Add(southMove);

            Move eastMove = new Move(false, false, 1);
            eastMove.AddStep(Direction.East, 1);
            moveset.Add(southMove);

            Move westMove = new Move(false, false, 1);
            westMove.AddStep(Direction.West, 1);
            moveset.Add(southMove);

            Move northEastMove = new Move(false, false, 1);
            northEastMove.AddStep(Direction.NorthEast, 1);
            moveset.Add(northEastMove);

            Move northWestMove = new Move(false, false, 1);
            northWestMove.AddStep(Direction.NorthWest, 1);
            moveset.Add(northWestMove);

            Move southEastMove = new Move(false, false, 1);
            southEastMove.AddStep(Direction.SouthEast, 1);
            moveset.Add(southEastMove);

            Move southWestMove = new Move(false, false, 1);
            southWestMove.AddStep(Direction.SouthWest, 1);
            moveset.Add(southWestMove);

            return moveset;
        }

        public static List<Move> CreateKnightMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northWestMove = new Move(true, false, 2);
            northWestMove.AddStep(Direction.North, 2);
            northWestMove.AddStep(Direction.West, 1);
            moveset.Add(northWestMove);

            Move westNorthMove = new Move(true, false, 2);
            westNorthMove.AddStep(Direction.West, 2);
            westNorthMove.AddStep(Direction.North, 1);
            moveset.Add(westNorthMove);

            Move northEastMove = new Move(true, false, 2);
            northEastMove.AddStep(Direction.North, 2);
            northEastMove.AddStep(Direction.East, 1);
            moveset.Add(northEastMove);

            Move eastNorthMove = new Move(true, false, 2);
            eastNorthMove.AddStep(Direction.East, 2);
            eastNorthMove.AddStep(Direction.North, 1);
            moveset.Add(eastNorthMove);

            Move southWestMove = new Move(true, false, 2);
            southWestMove.AddStep(Direction.South, 2);
            southWestMove.AddStep(Direction.West, 1);
            moveset.Add(southWestMove);

            Move westSouthMove = new Move(true, false, 2);
            westSouthMove.AddStep(Direction.West, 2);
            westSouthMove.AddStep(Direction.South, 1);
            moveset.Add(westSouthMove);

            Move southEastMove = new Move(true, false, 2);
            southEastMove.AddStep(Direction.South, 2);
            southEastMove.AddStep(Direction.East, 1);
            moveset.Add(southEastMove);

            Move eastSouthMove = new Move(true, false, 2);
            eastSouthMove.AddStep(Direction.East, 2);
            eastSouthMove.AddStep(Direction.South, 1);
            moveset.Add(eastSouthMove);

            return moveset;

        }

        public static List<Move> CreateWhitePawnMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northMove = new Move(false, false, 1);
            northMove.AddStep(Direction.North, 1);
            moveset.Add(northMove);

            Move northFirstMove = new Move(false, false, 1);
            northFirstMove.AddStep(Direction.North, 2);
            moveset.Add(northFirstMove);

            return moveset;
        }

        public static List<Move> CreateBlackPawnMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northMove = new Move(false, false, 1);
            northMove.AddStep(Direction.South, 1);
            moveset.Add(northMove);

            Move northFirstMove = new Move(false, false, 1);
            northFirstMove.AddStep(Direction.South, 2);
            moveset.Add(northFirstMove);

            return moveset;
        }

        public static List<Move> CreateQueenMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northMove = new Move(false, true, 1);
            northMove.AddStep(Direction.North, 7);
            moveset.Add(northMove);

            Move southMove = new Move(false, true, 1);
            southMove.AddStep(Direction.South, 7);
            moveset.Add(southMove);

            Move eastMove = new Move(false, true, 1);
            eastMove.AddStep(Direction.East, 7);
            moveset.Add(southMove);

            Move westMove = new Move(false, true, 1);
            westMove.AddStep(Direction.West, 7);
            moveset.Add(southMove);

            Move northEastMove = new Move(false, true, 1);
            northEastMove.AddStep(Direction.NorthEast, 7);
            moveset.Add(northEastMove);

            Move northWestMove = new Move(false, true, 1);
            northWestMove.AddStep(Direction.NorthWest, 7);
            moveset.Add(northWestMove);

            Move southEastMove = new Move(false, true, 1);
            southEastMove.AddStep(Direction.SouthEast, 7);
            moveset.Add(southEastMove);

            Move southWestMove = new Move(false, true, 1);
            southWestMove.AddStep(Direction.SouthWest, 7);
            moveset.Add(southWestMove);

            return moveset;
        }

        public static List<Move> CreateRookMoveList()
        {
            List<Move> moveset = new List<Move>();

            Move northMove = new Move(false, true, 1);
            northMove.AddStep(Direction.North, 7);
            moveset.Add(northMove);

            Move southMove = new Move(false, true, 1);
            southMove.AddStep(Direction.South, 7);
            moveset.Add(southMove);

            Move eastMove = new Move(false, true, 1);
            eastMove.AddStep(Direction.East, 7);
            moveset.Add(southMove);

            Move westMove = new Move(false, true, 1);
            westMove.AddStep(Direction.West, 7);
            moveset.Add(southMove);

            return moveset;
        }


    }
}
