using Chessnet.Models;
using Chessnet.ViewModels.StateMachines;
using System.Collections;
using System.Resources;
using System.Windows;
using System.Windows.Input;

namespace Chessnet.ViewModels
{
    public class ChessBoardViewModel : BindableObject
    {
        #region declarations
        /* Declare View and State Machine */
        ChessBoardMachine machine;

        /* Declare board model*/
        public Board board {get; private set;}

        /*Commands*/
        public ICommand whitePieceChosenCommand { get; private set; }
        #endregion declarations

        #region constructors
        /* Constructor */
        public ChessBoardViewModel()
        {
            //Initialise StateMachine
            machine = new ChessBoardMachine(this);

            //Initialise Board model
            board = new Board();

            //Initialise commands for state machine
            whitePieceChosenCommand = machine.CreateCommand(BoardTrigger.WhitePiecePicked);

            //Initialise the game
            gameResetAction();

        }
        #endregion constructors

        /*Actions: Methods directly invoked by state machine*/
        #region Actions

        /*gameResetAction: Resets game*/
        public void gameResetAction()
        {
            //Initialise board model
            board.reset();

            //Render the default board
            renderDefaultBoard();

            //Place state machine in next state
            machine.Fire(BoardTrigger.GameReset);
        }

        /*whiteTurnStartAction: Places game in WhiteTurnStart state */
        public void whiteTurnStartAction()
        {
            /* Iterate through each whitePiece */
            foreach(var pieceToChange in board.whitePieces)
            {
                //Retrieve the appropiate style
                Style validStyle = getValidPieceStyle(pieceToChange);
                (int, int) position = pieceToChange.getPosition();

                //Retrieve the reference to the position's button style
                board.styles[board.toCollectionKey(position)] = validStyle;
                board.commands[board.toCollectionKey(position)] = whitePieceChosenCommand;
            }
        }
        #endregion Actions

        /*Methods not directly invoked by State machine*/
        #region NotActions

        /* Renders every square of the Board model*/
        public void renderDefaultBoard()
        {
            /*Iterate through each chess square*/
            for (int x=1; x<9; x++)
            {
                for(int y=1; y<9; y++)
                {
                    //If square contains a piece
                    if (board.chessList.TryGetValue((x, y), out _))
                    {
                        Piece pieceToRender = board.chessList[(x, y)];
                        Style styleToRender = getDefaultPieceStyle(pieceToRender);
                        board.styles[board.toCollectionKey((x,y))] = styleToRender;
                    }
                    else
                    {
                        board.styles[board.toCollectionKey((x, y))] = getSquareStyle(ButtonStyle.DefaultSquare);
                    }         
                }
            }

        }

        public Style getSquareStyle(ButtonStyle inputVal)
        {
            switch(inputVal)
            {
                case ButtonStyle.DefaultSquare:
                    return Application.Current.Resources["DefaultSquare"] as Style;

                case ButtonStyle.ValidSquare:
                    return Application.Current.Resources["ValidSquare"] as Style;

                case ButtonStyle.InvalidSquare:
                    return Application.Current.Resources["InvalidSquare"] as Style;                                 
            }

            throw new PieceStyleException("SquareStyle not found");
        }


        /* Find default button style for a piece */
        public Style getDefaultPieceStyle(Piece pieceToRender)
        {
            switch(pieceToRender)
            {
                case BishopPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["DefaultWhiteBishop"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["DefaultBlackBishop"] as Style;
                    break;

                case KingPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["DefaultWhiteKing"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["DefaultBlackKing"] as Style;
                    break;

                case KnightPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["DefaultWhiteKnight"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["DefaultBlackKnight"] as Style;
                    break;

                case PawnPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["DefaultWhitePawn"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["DefaultBlackPawn"] as Style;
                    break;

                case QueenPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["DefaultWhiteQueen"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["DefaultBlackQueen"] as Style;
                    break;

                case RookPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["DefaultWhiteRook"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["DefaultBlackRook"] as Style;
                    break;
            }
            throw new PieceStyleException("Default Piece Button Style not found");
        }

        /* Find valid button style for a piece */
        public Style getValidPieceStyle(Piece pieceToRender)
        {
            switch (pieceToRender)
            {
                case BishopPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["ValidWhiteBishop"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["ValidBlackBishop"] as Style;
                    break;

                case KingPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["ValidWhiteKing"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["ValidBlackKing"] as Style;
                    break;

                case KnightPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["ValidWhiteKnight"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["ValidBlackKnight"] as Style;
                    break;

                case PawnPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["ValidWhitePawn"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["ValidBlackPawn"] as Style;
                    break;

                case QueenPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["ValidWhiteQueen"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["ValidBlackQueen"] as Style;
                    break;

                case RookPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["ValidWhiteRook"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["ValidBlackRook"] as Style;
                    break;
            }
            throw new PieceStyleException("ValidPiece Button Style not found");
        }

        /* Find Invalid button style for a piece */
        public Style getInvalidPieceStyle(Piece pieceToRender)
        {
            //Find Default Button Style for the piece
            switch (pieceToRender)
            {
                case BishopPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["InvalidWhiteBishop"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["InvalidBlackBishop"] as Style;
                    break;

                case KingPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["InvalidWhiteKing"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["InvalidBlackKing"] as Style;
                    break;

                case KnightPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["InvalidWhiteKnight"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["InvalidBlackKnight"] as Style;
                    break;

                case PawnPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["InvalidWhitePawn"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["InvalidBlackPawn"] as Style;
                    break;

                case QueenPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["InvalidWhiteQueen"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["InvalidBlackQueen"] as Style;
                    break;

                case RookPiece p:
                    if (pieceToRender.colour == Colour.White)
                        return Application.Current.Resources["InvalidWhiteRook"] as Style;
                    else if (pieceToRender.colour == Colour.Black)
                        return Application.Current.Resources["InvalidBlackRook"] as Style;
                    break;
            }
            throw new PieceStyleException("Invalid Piece Button Style not found");
        }
        #endregion NotActions
    }
}
