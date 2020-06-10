using System;
using System.Collections.Generic;

namespace chessnet.lib
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

    public class Move
    {
        

        Boolean canJump;
        Boolean isVariable;
        List<Tuple<Direction, int>> steps;
        int noOfSteps;

        public Move(Boolean jumpVal, Boolean variableVal, int noOfStepsVal)
        {
            canJump = jumpVal;
            isVariable = variableVal;
            noOfSteps = noOfStepsVal;

            steps = new List<Tuple<Direction, int>>();

        }

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