using System;
using System.Collections.Generic;

namespace Chessnet.Models
{
    public enum Colour
    {
        Black = 0,
        White = 1
    }

    //Enumerated type to convert value of file position to a representative character
    public enum File
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8
    }

    public interface IPiece
    {   
        //Colour of the piece
        Colour colour { get; set; }
        //Current position of piece
        int file { get; set; }
        int row { get; set; }

        PieceType pieceType { get; set; }

        //Set current position of piece
        public void setPosition(int fileValue, int rowValue);
        public void setPosition(File fileValue, int rowValue);
        public void setPosition(Tuple<int, int> posVal);
        public (int,int) getPosition();
        
    }

    public class Piece : IPiece
    {

        public Colour colour { get; set; }
        public int file { get; set; }
        public int row { get; set; }
        public PieceType pieceType { get; set; }

        public Piece(Colour colourVal, File fileVal, int rowVal)
        {

            colour = colourVal;
          
            setPosition(fileVal, rowVal);

        }

        public void setPosition(int fileValue, int rowValue)
        {
            file = fileValue;
            row = rowValue;
        }

        public void setPosition(File fileValue, int rowValue)
        {
            file = (int)fileValue;
            row = rowValue;
        }

        public void setPosition(Tuple<int, int> posVal)
        {
            file = posVal.Item1;
            row = posVal.Item2;
        }

        public (int, int) getPosition()
        {
            return (file, row);
        }
       
    }

    public class BishopPiece : Piece
    {

        public BishopPiece(Colour colourVal, File fileVal, int rowVal) : base(colourVal, fileVal, rowVal)
        {
            switch (colourVal)
            {
                case Colour.Black:
                    pieceType = PieceType.BlackBishop;
                    break;

                case Colour.White:
                    pieceType = PieceType.WhiteBishop;
                    break;

                default:
                    throw new PieceColourException("Piece cannot be constructed, missing colour");
            }
                

        }


    }

    public class KingPiece : Piece
    {

        public KingPiece(Colour colourVal, File fileVal, int rowVal) : base(colourVal, fileVal, rowVal)
        {
            switch (colourVal)
            {
                case Colour.Black:
                    pieceType = PieceType.BlackKing;
                    break;

                case Colour.White:
                    pieceType = PieceType.WhiteKing;
                    break;

                default:
                    throw new PieceColourException("Piece cannot be constructed, missing colour");
            }

        }
    }

    public class KnightPiece : Piece
    {
        public KnightPiece(Colour colourVal, File fileVal, int rowVal) : base(colourVal, fileVal, rowVal)
        {
            switch (colourVal)
            {
                case Colour.Black:
                    pieceType = PieceType.BlackKnight;
                    break;

                case Colour.White:
                    pieceType = PieceType.WhiteKnight;
                    break;

                default:
                    throw new PieceColourException("Piece cannot be constructed, missing colour");
            }

        }
    }

    public class PawnPiece : Piece
    {
        public PawnPiece(Colour colourVal, File fileVal, int rowVal) : base(colourVal, fileVal, rowVal)
        {
            switch (colourVal)
            {
                case Colour.Black:
                    pieceType = PieceType.BlackPawn;
                    break;

                case Colour.White:
                    pieceType = PieceType.WhitePawn;
                    break;

                default:
                    throw new PieceColourException("Piece cannot be constructed, missing colour");
            }

        }
    }

    public class QueenPiece : Piece
    {
        public QueenPiece(Colour colourVal, File fileVal, int rowVal) : base(colourVal, fileVal, rowVal)
        {

            switch (colourVal)
            {
                case Colour.Black:
                    pieceType = PieceType.BlackQueen;
                    break;

                case Colour.White:
                    pieceType = PieceType.WhiteQueen;
                    break;

                default:
                    throw new PieceColourException("Piece cannot be constructed, missing colour");
            }
        }
    }

    public class RookPiece : Piece
    {
        public RookPiece(Colour colourVal, File fileVal, int rowVal) : base(colourVal, fileVal, rowVal)
        {
            switch (colourVal)
            {
                case Colour.Black:
                    pieceType = PieceType.BlackRook;
                    break;

                case Colour.White:
                    pieceType = PieceType.WhiteRook;
                    break;

                default:
                    throw new PieceColourException("Piece cannot be constructed, missing colour");
            }

        }
    }
}