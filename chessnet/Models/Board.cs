using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    public class Board
    {
        #region class variables
        //List Of Pieces
        private List<Piece> blackPieces;
        private List<Piece> whitePieces;

        //Dictionary for O(n) access if state of board is known
        private Dictionary<(int, int), Piece> chessList;
        #endregion class variables

        #region class properties
        /* Collections for holding the pieces associated commands and styles */
        public ButtonCommandCollection commands { get; private set; }
        public ButtonStyleCollection styles { get; private set; }
        public ButtonTagCollection tags { get; private set; }

        #endregion region class properties

        public Board()
        {
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            chessList = new Dictionary<(int,int) , Piece>();

            commands = new ButtonCommandCollection();

            styles = new ButtonStyleCollection();

            tags = new ButtonTagCollection();
        }

        public void reset()
        {
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            chessList = new Dictionary<(int,int), Piece>();

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

            /*Create Black Pieces */
            addPiece(piecefactory.CreatePawn(Colour.Black, File.A, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.B, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.C, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.D, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.E, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.F, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.G, 7));
            addPiece(piecefactory.CreatePawn(Colour.Black, File.H, 7));

            addPiece(piecefactory.CreateRook(Colour.Black, File.A, 8));
            addPiece(piecefactory.CreateKnight(Colour.Black, File.B, 8));
            addPiece(piecefactory.CreateBishop(Colour.Black, File.C, 8));
            addPiece(piecefactory.CreateKing(Colour.Black, File.D, 8));
            addPiece(piecefactory.CreateQueen(Colour.Black, File.E, 8));
            addPiece(piecefactory.CreateBishop(Colour.Black, File.F, 8));
            addPiece(piecefactory.CreateKnight(Colour.Black, File.G, 8));
            addPiece(piecefactory.CreateRook(Colour.Black, File.H, 8));

        }


        /* Adds a piece to Board */
        public void addPiece(Piece pieceToAdd)
        {
            
            /* Board should not add an invalid piece */

            //Retrieve position and colour
            File file = (File)pieceToAdd.file;
            int row = pieceToAdd.row;
            (int,int) position = pieceToAdd.getPosition();
            Colour colour = pieceToAdd.colour;

            //Check if position is valid
            if (row < 1 || row > 8 || file < File.A || file > File.H)
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

        public bool tryGetPiece((int, int) inputVal)
        {
            return chessList.TryGetValue(inputVal, out _);
        }

        public Piece getPiece((int,int)inputVal)
        {
            return chessList[inputVal];
        }

        public List<Piece>.Enumerator getBlackPieceEnumerator()
        {
            return blackPieces.GetEnumerator();
        }

        public List<Piece>.Enumerator getWhitePieceEnumerator()
        {
            return whitePieces.GetEnumerator();
        }

        //Returns Key to access corresponding element in ButtonStyleCollection, ButtonCommandCollection
        public int toCollectionKey(int fileVal, int rowVal)
        {
            return (rowVal * 8) + fileVal - 9;
        }

        public int toCollectionKey((int, int) posVal)
        {
            return (posVal.Item2 * 8) + posVal.Item1 - 9;
        }


    }
}
