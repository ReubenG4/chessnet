using System;
using System.Collections.Generic;

public class knightPiece : Piece
{

    public string name { get; set; }
    public string icon { get; set; }
    
    public List<Move> moveset { get; set; }

    public knightPiece()
    {
        name = "Knight";

        icon = "placeholder";

        moveset = new List<Move>();

        var northWestMove = new Move(true,false,2);
        northWestMove.addStep((int)Direction.North, 2);
        northWestMove.addStep((int)Direction.West, 1);
        moveset.Add(northWestMove);

        var westNorthMove = new Move(true, false, 2);
        westNorthMove.addStep((int)Direction.West, 2);
        westNorthMove.addStep((int)Direction.North, 1);
        moveset.Add(westNorthMove);

        var northEastMove = new Move(true, false, 2);
        northEastMove.addStep((int)Direction.North, 2);
        northEastMove.addStep((int)Direction.East, 1);
        moveset.Add(northEastMove);

        var eastNorthMove = new Move(true, false, 2);
        eastNorthMove.addStep((int)Direction.East, 2);
        eastNorthMove.addStep((int)Direction.North, 1);
        moveset.Add(eastNorthMove);

        var southWestMove = new Move(true, false, 2);
        southWestMove.addStep((int)Direction.South, 2);
        southWestMove.addStep((int)Direction.West, 1);
        moveset.Add(southWestMove);

        var westSouthMove = new Move(true, false, 2);
        westSouthMove.addStep((int)Direction.West, 2);
        westSouthMove.addStep((int)Direction.South, 1);
        moveset.Add(westSouthMove);

        var southEastMove = new Move(true, false, 2);
        southEastMove.addStep((int)Direction.South, 2);
        southEastMove.addStep((int)Direction.East, 1);
        moveset.Add(southEastMove);

        var eastSouthMove = new Move(true, false, 2);
        eastSouthMove.addStep((int)Direction.East, 2);
        eastSouthMove.addStep((int)Direction.South, 1);
        moveset.Add(eastSouthMove);

    }
}