using System;
using System.Collections.Generic;
using System.Text;

namespace Chessnet.Models
{
    public class PieceFactory
    {
       
        public BishopPiece CreateBishop(Colour colourVal,  File file, int row)
        {
            return new BishopPiece(colourVal, file, row);
        }

        public KingPiece CreateKing(Colour colourVal, File file, int row)
        {
            return new KingPiece(colourVal, file, row);
        }

        public KnightPiece CreateKnight(Colour colourVal, File file, int row)
        {
            return new KnightPiece(colourVal, file, row);
        }

        public PawnPiece CreatePawn(Colour colourVal, File file, int row)
        {
            return new PawnPiece(colourVal, file, row);
        }

        public QueenPiece CreateQueen(Colour colourVal, File file, int row)
        {
            return new QueenPiece(colourVal, file, row);
        }

        public RookPiece CreateRook(Colour colourVal, File file, int row)
        {
            return new RookPiece(colourVal, file, row);
        }
    }
}
