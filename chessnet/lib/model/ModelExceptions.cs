using System;
using System.Collections.Generic;
using System.Text;

namespace chessnet.lib.model
{

    class PieceException : Exception
    {
        public PieceException(string message)
        {

        }
    }

    class PieceColourException : PieceException
    {
        public PieceColourException(string message) : base(message)
        {

        }
    }

    class PiecePositionException : PieceException
    {
        public PiecePositionException(string message) : base(message)
        {

        }
    }

    class PieceNotFoundException : PieceException
    {
        public PieceNotFoundException(string message) : base(message)
        {

        }
    }
}
