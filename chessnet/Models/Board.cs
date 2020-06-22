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
        private Dictionary<(int, int), Piece> chessPieceList;
        #endregion class variables

        #region class properties
        /* Collections for holding the pieces associated commands and styles */
        public ButtonCommandCollection commands { get; private set; }
        public ButtonStyleCollection styles { get; private set; }

        #endregion region class properties

        public Board()
        {
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            chessPieceList = new Dictionary<(int,int) , Piece>();

            commands = new ButtonCommandCollection();

            styles = new ButtonStyleCollection();

        }

        public void Reset()
        {
            blackPieces = new List<Piece>();
            whitePieces = new List<Piece>();

            chessPieceList = new Dictionary<(int,int), Piece>();

            

            /*Create White Pieces */
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.A, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.B, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.C, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.D, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.E, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.F, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.G, 2));
            AddPiece(PieceFactory.CreatePawn(Colour.White, File.H, 2));

            AddPiece(PieceFactory.CreateRook(Colour.White, File.A, 1));
            AddPiece(PieceFactory.CreateKnight(Colour.White, File.B, 1));
            AddPiece(PieceFactory.CreateBishop(Colour.White, File.C, 1));
            AddPiece(PieceFactory.CreateKing(Colour.White, File.D, 1));
            AddPiece(PieceFactory.CreateQueen(Colour.White, File.E, 1));
            AddPiece(PieceFactory.CreateBishop(Colour.White, File.F, 1));
            AddPiece(PieceFactory.CreateKnight(Colour.White, File.G, 1));
            AddPiece(PieceFactory.CreateRook(Colour.White, File.H, 1));

            /*Create Black Pieces */
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.A, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.B, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.C, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.D, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.E, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.F, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.G, 7));
            AddPiece(PieceFactory.CreatePawn(Colour.Black, File.H, 7));

            AddPiece(PieceFactory.CreateRook(Colour.Black, File.A, 8));
            AddPiece(PieceFactory.CreateKnight(Colour.Black, File.B, 8));
            AddPiece(PieceFactory.CreateBishop(Colour.Black, File.C, 8));
            AddPiece(PieceFactory.CreateKing(Colour.Black, File.D, 8));
            AddPiece(PieceFactory.CreateQueen(Colour.Black, File.E, 8));
            AddPiece(PieceFactory.CreateBishop(Colour.Black, File.F, 8));
            AddPiece(PieceFactory.CreateKnight(Colour.Black, File.G, 8));
            AddPiece(PieceFactory.CreateRook(Colour.Black, File.H, 8));

        }


        /* Adds a piece to Board */
        public void AddPiece(Piece pieceToAdd)
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
            if (chessPieceList.ContainsKey(position))
                throw (new PieceNotFoundException("pieceToAdd is being added to an occupied position, invalid"));

            //Check if colour is valid and add it to the proper list
            if (pieceToAdd.colour == Colour.Black)
                blackPieces.Add(pieceToAdd);
            else if (pieceToAdd.colour == Colour.White)
                whitePieces.Add(pieceToAdd);
            else
                throw (new PieceColourException("Invalid colour for pieceToAdd"));

            //Add it to dictionary of chess pieces in play
            chessPieceList.Add(position, pieceToAdd);
        }

        public bool TryGetPiece((int, int) posVal)
        {
            return chessPieceList.TryGetValue(posVal, out _);
        }

        public bool TryGetPiece(int keyVal)
        {
            return chessPieceList.TryGetValue(ToPositionKey(keyVal), out _);
        }

        public Piece GetPiece((int,int)posVal)
        {
            return chessPieceList[posVal];
        }

        public Piece GetPiece(int posVal)
        {
            return chessPieceList[ToPositionKey(posVal)];
        }

        public List<Piece>.Enumerator GetBlackPieceEnumerator()
        {
            return blackPieces.GetEnumerator();
        }

        public List<Piece>.Enumerator GetWhitePieceEnumerator()
        {
            return whitePieces.GetEnumerator();
        }

        //Translates position into a key to access ButtonDataCollections
        public int ToCollectionKey(int fileVal, int rowVal)
        {
            return (rowVal * 8) + fileVal - 9;
        }

        public int ToCollectionKey((int, int) posVal)
        {
            return (posVal.Item2 * 8) + posVal.Item1 - 9;
        }

        public (int,int) ToPositionKey(int keyVal)
        {
            return ((keyVal+1) / 8, (keyVal % 8));
        }
    }
}
