using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    class PieceFactory
    {
       
        public BishopPiece CreateBishop(int idVal, Colour colourVal, int row, int file)
        {
            return new BishopPiece(idVal, colourVal, row, file);
        }

        public KingPiece CreateKing(int idVal, Colour colourVal, int row, int file)
        {
            return new KingPiece(idVal, colourVal, row, file);
        }

        public KnightPiece CreateKnight(int idVal, Colour colourVal, int row, int file)
        {
            return new KnightPiece(idVal, colourVal, row, file);
        }

        public PawnPiece CreatePawn(int idVal, Colour colourVal, int row, int file)
        {
            return new PawnPiece(idVal, colourVal, row, file);
        }

        public QueenPiece CreateQueen(int idVal, Colour colourVal, int row, int file)
        {
            return new QueenPiece(idVal, colourVal, row, file);
        }

        public RookPiece CreateRook(int idVal, Colour colourVal, int row, int file)
        {
            return new RookPiece(idVal, colourVal, row, file);
        }
    }
}
