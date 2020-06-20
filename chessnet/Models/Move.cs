using System;
using System.Collections.Generic;

namespace Chessnet.Models
{
    public enum Direction
    {
        North = 0,
        NorthEast = 1,
        East = 2,
        SouthEast = 3,
        South = 4,
        SouthWest = 5,
        West = 6,
        NorthWest = 7
    }

    /* Object that represents a Move for a Piece */
    public class Move
    {
        
        //Determines if piece can jump over other pieces
        Boolean canJump;

        //Determines if length of pice is variable
        Boolean isVariable;

        //List of tuples representing steps to take for a single move
        List<Tuple<Direction, int>> steps;

        //Number of steps in the move
        int noOfSteps;

        //Constructor for initialising an Move object with no defined steps
        public Move(Boolean jumpVal, Boolean variableVal, int noOfStepsVal)
        {
            canJump = jumpVal;
            isVariable = variableVal;
            noOfSteps = noOfStepsVal;

            steps = new List<Tuple<Direction, int>>();

        }

        //Add a step to the Move
        public bool AddStep(Direction dirVal, int magVal)
        {
            if (steps.Count < noOfSteps)
            {
                steps.Add(new Tuple<Direction, int>(dirVal, magVal));
                return true;
            }

            return false;
        }
    }
}