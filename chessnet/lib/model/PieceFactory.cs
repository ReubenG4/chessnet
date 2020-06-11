using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    class PieceFactory
    {
       
        public BishopPiece CreateBishop(int nameVal)
        {
            return new BishopPiece(nameVal);
        }

        public KingPiece CreateKing(int nameVal)
        {
            return new KingPiece(nameVal);
        }

        public KnightPiece CreateKnight(int nameVal)
        {
            return new KnightPiece(nameVal);
        }

        public PawnPiece CreatePawn(int nameVal)
        {
            return new PawnPiece(nameVal);
        }

        public QueenPiece CreateQueen(int nameVal)
        {
            return new QueenPiece(nameVal);
        }

        public RookPiece CreateRook(int nameVal)
        {
            return new RookPiece(nameVal);
        }
    }
}
