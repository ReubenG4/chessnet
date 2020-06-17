using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{
    class PieceColourException : Exception
    {
        public PieceColourException(string message) : base(message)
        {

        }
    }

    class PiecePositionException : Exception
    {
        public PiecePositionException(string message) : base(message)
        {

        }
    }

    class PieceNotFoundException : Exception
    {
        public PieceNotFoundException(string message) : base(message)
        {

        }
    }
}
