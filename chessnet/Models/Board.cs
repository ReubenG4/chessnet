using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    class Board
    {
        /* List Of Pieces */
        List<Piece> blackPieces { get; set; }
        List<Piece> whitePieces { get; set; }

        /* Dictionary for O(n) access if state of board is known*/
        public Dictionary<string, Piece> chessList { get; private set; }

        public Board()
        {
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            chessList = new Dictionary<string, Piece>();
        }

        public void init()
        {
            PieceFactory piecefactory = new PieceFactory();

            /*Create White Pieces */
            addPiece(piecefactory.CreatePawn(Colour.White, File.A, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.B, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.C, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.D, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.E, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.F, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.G, 2));
            addPiece(piecefactory.CreatePawn(Colour.White, File.H, 2));

            addPiece(piecefactory.CreateRook(Colour.White, File.A, 1));
            addPiece(piecefactory.CreateKnight(Colour.White, File.B, 1));
            addPiece(piecefactory.CreateBishop(Colour.White, File.C, 1));
            addPiece(piecefactory.CreateKing(Colour.White, File.D, 1));
            addPiece(piecefactory.CreateQueen(Colour.White, File.E, 1));
            addPiece(piecefactory.CreateBishop(Colour.White, File.F, 1));
            addPiece(piecefactory.CreateKnight(Colour.White, File.G, 1));
            addPiece(piecefactory.CreateRook(Colour.White, File.H, 1));

        }



        /* Adds a piece to Board */
        public void addPiece(Piece pieceToAdd)
        {
            
            /* Board should not add an invalid piece */

            //Retrieve position and colour
            File file = (File)pieceToAdd.file;
            int row = pieceToAdd.row;
            string position = pieceToAdd.position;
            Colour colour = pieceToAdd.colour;

            //Check if position is valid
            if (position == null)
                throw (new PiecePositionException("pieceToAdd has no set position, invalid"));
            else if (row < 1 || row > 8 || file < File.A || file > File.H)
                throw (new PiecePositionException("pieceToAdd has out-of-bounds position, invalid"));

            //Check if position is empty
            if (chessList.ContainsKey(pieceToAdd.position))
                throw (new PieceNotFoundException("pieceToAdd is being added to an occupied position, invalid"));

            //Check if colour is valid and add it to the proper list
            if (pieceToAdd.colour == Colour.Black)
                blackPieces.Add(pieceToAdd);
            else if (pieceToAdd.colour == Colour.White)
                whitePieces.Add(pieceToAdd);
            else
                throw (new PieceColourException("Invalid colour for pieceToAdd"));

            //Add it to dictionary of chess pieces in play
            chessList.Add(pieceToAdd.position, pieceToAdd);
        }

      

        
      

    }
}
