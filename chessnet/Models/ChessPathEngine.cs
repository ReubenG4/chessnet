using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    /*Checks moves and generates a path if they are valid */
    public class ChessPathEngine
    {
        #region declarations
        //Reference to the board
        private ChessBoard board;
        //Holds a list of moves for each piece
        private Dictionary<PieceType, List<Move>> moveListDictionary;

        #endregion declarations
        public ChessPathEngine(ChessBoard boardRef)
        {
            board = boardRef;
            moveListDictionary = new Dictionary<PieceType, List<Move>>();
            
            //Fill up the moveList dictionary
            foreach(PieceType type in Enum.GetValues(typeof(PieceType)))
            {
                moveListDictionary.Add(type, MoveListFactory.CreateMoveList(type));
            }
        }

        public List<Path> GetValidPaths(Piece piece)
        {

            /*Declarations for local variables*/
            #region declarations

            //Get the position of the piece
            (int, int) position = piece.getPosition();

            //Instantiate a movelist
            if (!moveListDictionary.TryGetValue(piece.pieceType, out _)) 
                throw new PieceException("Move list for piece not found");

            List<Move> moveList = moveListDictionary[piece.pieceType];
            List<Path> pathList = new List<Path>();

            //Instantiate a numerator for the moveList
            var moveListEnumerator = moveList.GetEnumerator();

            #endregion declarations

            //Iterate through moves
            while (moveListEnumerator.MoveNext())
            {
                //Declare local to hold move
                Move moveConsidered = moveListEnumerator.Current;

                //Try Move to check validity
                if (TryMove(moveConsidered, position))
                {
                    //If move is valid, get its path and add it to the pathList
                    pathList.Add(GetPath(moveConsidered, position));
                }
            }

            return pathList;
        }

        //Checks a move for a position and determines if it is valid
        public bool TryMove(Move move, (int,int) position)
        {
            return false;
        }

        //Gets a path for a move based on a position
        public Path GetPath(Move move, (int, int) position)
        {
            return null;
        }


    }

    public class Path
    {
        //Positions the path occupies
        List<(int, int)> positionList;

        //If last position of path is a capture or not
        Boolean isCapture;
    }
}
