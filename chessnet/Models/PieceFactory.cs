using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    public static class PieceFactory
    {
       
        public static BishopPiece CreateBishop(Colour colourVal,  File file, int row)
        {
            return new BishopPiece(colourVal, file, row);
        }

        public static KingPiece CreateKing(Colour colourVal, File file, int row)
        {
            return new KingPiece(colourVal, file, row);
        }

        public static KnightPiece CreateKnight(Colour colourVal, File file, int row)
        {
            return new KnightPiece(colourVal, file, row);
        }

        public static PawnPiece CreatePawn(Colour colourVal, File file, int row)
        {
            return new PawnPiece(colourVal, file, row);
        }

        public static QueenPiece CreateQueen(Colour colourVal, File file, int row)
        {
            return new QueenPiece(colourVal, file, row);
        }

        public static RookPiece CreateRook(Colour colourVal, File file, int row)
        {
            return new RookPiece(colourVal, file, row);
        }
    }
}
