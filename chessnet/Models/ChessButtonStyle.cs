using System.Collections.Generic;
using System.Windows;

namespace Chessnet.Models
{
    public enum PieceType
    {
        EmptySquare,
        
        WhiteBishop,
        WhiteKing,
        WhiteKnight,
        WhitePawn,
        WhiteQueen,
        WhiteRook,

        BlackBishop,
        BlackKing,
        BlackKnight,
        BlackPawn,
        BlackQueen,
        BlackRook
    }

    public static class ChessButtonStyle
    {
        private static readonly Dictionary<PieceType, string> defaultDictionary = new Dictionary<PieceType, string>()
        {
            {PieceType.EmptySquare,"DefaultSquare" },

            {PieceType.BlackBishop, "DefaultBlackBishop"},
            {PieceType.BlackKing, "DefaultBlackKing" },
            {PieceType.BlackKnight, "DefaultBlackKnight" },
            {PieceType.BlackPawn, "DefaultBlackPawn" },
            {PieceType.BlackQueen, "DefaultBlackQueen"},
            {PieceType.BlackRook, "DefaultBlackRook" },

            {PieceType.WhiteBishop, "DefaultWhiteBishop"},
            {PieceType.WhiteKing, "DefaultWhiteKing" },
            {PieceType.WhiteKnight, "DefaultWhiteKnight" },
            {PieceType.WhitePawn, "DefaultWhitePawn" },
            {PieceType.WhiteQueen, "DefaultWhiteQueen"},
            {PieceType.WhiteRook, "DefaultWhiteRook" },
        };

        private static readonly Dictionary<PieceType, string> validDictionary = new Dictionary<PieceType, string>()
        {
            {PieceType.EmptySquare,"ValidSquare" },

            {PieceType.BlackBishop, "ValidBlackBishop"},
            {PieceType.BlackKing, "ValidBlackKing" },
            {PieceType.BlackKnight, "ValidBlackKnight" },
            {PieceType.BlackPawn, "ValidBlackPawn" },
            {PieceType.BlackQueen, "ValidBlackQueen"},
            {PieceType.BlackRook, "ValidBlackRook" },

            {PieceType.WhiteBishop, "ValidWhiteBishop"},
            {PieceType.WhiteKing, "ValidWhiteKing" },
            {PieceType.WhiteKnight, "ValidWhiteKnight" },
            {PieceType.WhitePawn, "ValidWhitePawn" },
            {PieceType.WhiteQueen, "ValidWhiteQueen"},
            {PieceType.WhiteRook, "ValidWhiteRook" },
        };

        private static readonly Dictionary<PieceType, string> invalidDictionary = new Dictionary<PieceType, string>()
        {
            {PieceType.EmptySquare,"InvalidSquare" },

            {PieceType.BlackBishop, "InvalidBlackBishop"},
            {PieceType.BlackKing, "InvalidBlackKing" },
            {PieceType.BlackKnight, "InvalidBlackKnight" },
            {PieceType.BlackPawn, "InvalidBlackPawn" },
            {PieceType.BlackQueen, "InvalidBlackQueen"},
            {PieceType.BlackRook, "InvalidBlackRook" },

            {PieceType.WhiteBishop, "InvalidWhiteBishop"},
            {PieceType.WhiteKing, "InvalidWhiteKing" },
            {PieceType.WhiteKnight, "InvalidWhiteKnight" },
            {PieceType.WhitePawn, "InvalidWhitePawn" },
            {PieceType.WhiteQueen, "InvalidWhiteQueen"},
            {PieceType.WhiteRook, "InvalidWhiteRook" },
        };

        private static readonly Dictionary<PieceType, string> chosenDictionary = new Dictionary<PieceType, string>()
        {
            {PieceType.EmptySquare,"ChosenSquare" },

            {PieceType.BlackBishop, "ChosenBlackBishop"},
            {PieceType.BlackKing, "ChosenBlackKing" },
            {PieceType.BlackKnight, "ChosenBlackKnight" },
            {PieceType.BlackPawn, "ChosenBlackPawn" },
            {PieceType.BlackQueen, "ChosenBlackQueen"},
            {PieceType.BlackRook, "ChosenBlackRook" },

            {PieceType.WhiteBishop, "ChosenWhiteBishop"},
            {PieceType.WhiteKing, "ChosenWhiteKing" },
            {PieceType.WhiteKnight, "ChosenWhiteKnight" },
            {PieceType.WhitePawn, "ChosenWhitePawn" },
            {PieceType.WhiteQueen, "ChosenWhiteQueen"},
            {PieceType.WhiteRook, "ChosenWhiteRook" },
        };

        /* Find default button style for a piece */
        public static Style Default(PieceType typeVal)
        {
            if (defaultDictionary.TryGetValue(typeVal, out _))
                return Application.Current.Resources[defaultDictionary[typeVal]] as Style;

            throw new PieceStyleException("Default Style not found");
        }

        /* Find valid button style for a piece */
        public static Style Valid(PieceType typeVal)
        {
            if (defaultDictionary.TryGetValue(typeVal, out _))
                return Application.Current.Resources[validDictionary[typeVal]] as Style;

            throw new PieceStyleException("Valid Style not found");
        }

        /* Find Invalid button style for a piece */
        public static Style Invalid(PieceType typeVal)
        {
            if (defaultDictionary.TryGetValue(typeVal, out _))
                return Application.Current.Resources[invalidDictionary[typeVal]] as Style;

            throw new PieceStyleException("Invalid Style not found");
        }

        /* Find Chosen button style for a piece */
        public static Style Chosen(PieceType typeVal)
        {
            if (defaultDictionary.TryGetValue(typeVal, out _))
                return Application.Current.Resources[chosenDictionary[typeVal]] as Style;

            throw new PieceStyleException("Chosen Style not found");
        }
    }
}
