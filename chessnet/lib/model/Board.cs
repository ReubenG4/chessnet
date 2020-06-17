using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    class Board
    {
        /* List Of Pieces */
        List<Piece> blackPieces;
        List<Piece> whitePieces;

        /* Dictionary for O(n) access if state of board is known*/
        Dictionary<Tuple<int, int>, Piece> chessList;

        public Board()
        {
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            chessList = new Dictionary<Tuple<int, int>, Piece>();
        }

        /* Adds a piece to Board */
        public void addPiece(Piece pieceToAdd)
        {
            
            /* Board should not add an invalid piece */

            //Retrieve position and colour
            Tuple<int, int> position = pieceToAdd.position;
            Colour colour = pieceToAdd.colour;

            //Check if position is valid
            if (position == null)
                throw (new PiecePositionException("pieceToAdd has no set position, invalid"));
            else if (position.Item1 < 1 || position.Item1 > 8 || position.Item2 < (int)FileValToChar.a || position.Item2 < (int)FileValToChar.h)
                throw (new PiecePositionException("pieceToAdd has out-of-bounds position, invalid"));

            //Check if position is empty
            if (chessList.ContainsKey(position))
                throw (new PieceNotFoundException("pieceToAdd is being added to an occupied position, invalid"));

            //Check if colour is valid and add it to the proper list
            if (pieceToAdd.colour == Colour.Black)
                blackPieces.Add(pieceToAdd);
            else if (pieceToAdd.colour == Colour.White)
                whitePieces.Add(pieceToAdd);
            else
                throw (new PieceColourException("Invalid colour for pieceToAdd"));

            //Add it to dictionary of chess pieces in play
            chessList.Add(position, pieceToAdd);
        }

        /* Removes a piece from Board*/
        public void removePiece(Piece pieceToRemove)
        {
            /* Board should not remove an invalid piece */

            //Retrieve position and colour
            Tuple<int, int> position = pieceToRemove.position;
            Colour colour = pieceToRemove.colour;

            //Check if position is valid
            if (position == null)
                throw (new PiecePositionException("pieceToRemove has no set position, invalid"));
            else if (position.Item1 < 1 || position.Item1 > 8 || position.Item2 < (int)FileValToChar.a || position.Item2 < (int)FileValToChar.h)
                throw (new PiecePositionException("pieceToRemove has out-of-bounds position, invalid"));

            //Remove piece at position in chessList
            if (!chessList.ContainsValue(pieceToRemove))
                throw (new PieceNotFoundException("Piece not present in chessList, position agnostic, invalid"));

            if (!chessList.ContainsKey(position))
                throw (new PieceNotFoundException("Piece present in chesslist, position is empty, invalid"));

            if (colour == Colour.Black)
            {
                if(!blackPieces.Contains(pieceToRemove))
                    throw (new PieceNotFoundException("Piece not present in blackPieces list, invalid"));

                blackPieces.Remove(pieceToRemove);
            }
            else if(colour == Colour.White)
            {
                if(!whitePieces.Contains(pieceToRemove))
                    throw (new PieceNotFoundException("Piece not present in whitePieces list, invalid"));

                whitePieces.Remove(pieceToRemove);
            }
            else
                throw (new PieceColourException("Invalid colour for pieceToRemove, invalid"));

        }

        public void movePiece(Tuple<int, int> start, Tuple<int, int> end)
        {
            //Check if start position is valid
            if (start.Item1 < 1 || start.Item1 > 8 || start.Item2 < (int)FileValToChar.a || start.Item2 < (int)FileValToChar.h)
                throw (new PiecePositionException("Start position is out-of-bounds, invalid"));

            //Check if start position is filled
            if (!chessList.ContainsKey(start))
                throw (new PiecePositionException("Start position is empty, invalid"));

            //Check if end position is valid
            if (end.Item1 < 1 || end.Item1 > 8 || end.Item2 < (int)FileValToChar.a || end.Item2 < (int)FileValToChar.h)
                throw (new PiecePositionException("End position is out-of-bounds, invalid"));

            //check if end position is empty
            if (chessList.ContainsKey(end))
                throw (new PiecePositionException("End position is filled, invalid"));

            //Retrieve piece to be moved
            Piece pieceToMove = chessList[start];

            //Remove piece from board
            chessList.Remove(start);

            //Change position of piece
            pieceToMove.setPosition(end);

            //Add piece to board in previous position
            chessList.Add(end, pieceToMove);

        }

        public bool isMoveValid(Tuple<int,int> start, Tuple<int,int> end)
        {
            //Check if start position is valid
            if (start.Item1 < 1 || start.Item1 > 8 || start.Item2 < (int)FileValToChar.a || start.Item2 < (int)FileValToChar.h)
                return false;

            //Check if start position is filled
            if (!chessList.ContainsKey(start))
                return false;

            //Check if end position is valid
            if (end.Item1 < 1 || end.Item1 > 8 || end.Item2 < (int)FileValToChar.a || end.Item2 < (int)FileValToChar.h)
                return false;

            //check if end position is empty
            if (chessList.ContainsKey(end))
                return false;

            return true;
        }
      

    }
}
