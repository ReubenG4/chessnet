using chessnet;
using Chessnet.Models;
using Chessnet.ViewModels.Commands.StateMachines;
using Chessnet.ViewModels.StateMachines;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chessnet.ViewModels
{

    public class ChessBoardViewModel 
    {
        #region declarations
        /* Declare View and State Machine */
        ChessBoardMachine machine;
        ChessBoardView _view;

        /* Declare board model*/
        Board board;

        /* Declare dictionary to lookup button reference for a position */
        private Dictionary<(int,int), Button> buttonDictionary;

        /*Commands*/
        public ICommand whitePieceChosenCommand { get; private set; }

        /* Constructor */
        public ChessBoardViewModel(ChessBoardView view)
        {
            //Initialise view
            _view = view;

            //Initialise StateMachine
            machine = new ChessBoardMachine(this);

            //Initialise Board model
            board = new Board();

            //Initialise Button Dictionary
            initButtonDictionary();

            //Initialise commands for state machine
            whitePieceChosenCommand = machine.CreateCommand(BoardTrigger.WhitePiecePicked);


            //Initialise the game
            gameResetAction();

        }
        #endregion declarations

        /*Actions: Methods directly invoked by state machine*/
        #region Actions

        /*gameResetAction: Resets game*/
        public void gameResetAction()
        {
            //Initialise board model
            board.reset();

            //Render the board
            renderBoard();

            //Place FSM in next state
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

                //Locate the button
                Button buttonToChange = buttonDictionary[pieceToChange.getPosition()];

                //Change its style
                buttonToChange.Style = validStyle;

                //Change its command
                buttonToChange.Command = whitePieceChosenCommand;
            }
        }
        #endregion Actions

        /*Methods not directly invoked by State machine*/

        #region NotActions
        /* Renders every square of the Board model*/
        public void renderBoard()
        {
            /*Iterate through each button*/
            foreach(var square in buttonDictionary){

                //Retrieve each button and its position
                (int,int) position = square.Key;
                Button buttonToChange = square.Value;
                
                //If position is occupied 
                if(board.chessList.TryGetValue(position, out _))
                {
                    //Retrieve piece
                    Piece pieceToRender = board.chessList[position];

                    //Change its associated button to the default style
                    buttonToChange.Style = getDefaultPieceStyle(pieceToRender);
                }
                else
                {
                    //Else, render it as an empty default square
                    buttonToChange.Style = Application.Current.Resources["DefaultSquare"] as Style;
                }
            }
        }

        public Style getDefaultPieceStyle(Piece pieceToRender)
        {
           //Find Default Button Style for the piece
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

        public Style getValidPieceStyle(Piece pieceToRender)
        {
            //Find Default Button Style for the piece
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

        #region Others
        public void initButtonDictionary()
        {
            buttonDictionary = new Dictionary<(int,int), Button>();

            buttonDictionary.Add((1, 1), _view.A1);
            buttonDictionary.Add((2, 1), _view.B1);
            buttonDictionary.Add((3, 1), _view.C1);
            buttonDictionary.Add((4, 1), _view.D1);
            buttonDictionary.Add((5, 1), _view.E1);
            buttonDictionary.Add((6, 1), _view.F1);
            buttonDictionary.Add((7, 1), _view.G1);
            buttonDictionary.Add((8, 1), _view.H1);

            buttonDictionary.Add((1, 2), _view.A2);
            buttonDictionary.Add((2, 2), _view.B2);
            buttonDictionary.Add((3, 2), _view.C2);
            buttonDictionary.Add((4, 2), _view.D2);
            buttonDictionary.Add((5, 2), _view.E2);
            buttonDictionary.Add((6, 2), _view.F2);
            buttonDictionary.Add((7, 2), _view.G2);
            buttonDictionary.Add((8, 2), _view.H2);

            buttonDictionary.Add((1, 3), _view.A3);
            buttonDictionary.Add((2, 3), _view.B3);
            buttonDictionary.Add((3, 3), _view.C3);
            buttonDictionary.Add((4, 3), _view.D3);
            buttonDictionary.Add((5, 3), _view.E3);
            buttonDictionary.Add((6, 3), _view.F3);
            buttonDictionary.Add((7, 3), _view.G3);
            buttonDictionary.Add((8, 3), _view.H3);

            buttonDictionary.Add((1, 4), _view.A4);
            buttonDictionary.Add((2, 4), _view.B4);
            buttonDictionary.Add((3, 4), _view.C4);
            buttonDictionary.Add((4, 4), _view.D4);
            buttonDictionary.Add((5, 4), _view.E4);
            buttonDictionary.Add((6, 4), _view.F4);
            buttonDictionary.Add((7, 4), _view.G4);
            buttonDictionary.Add((8, 4), _view.H4);

            buttonDictionary.Add((1, 5), _view.A5);
            buttonDictionary.Add((2, 5), _view.B5);
            buttonDictionary.Add((3, 5), _view.C5);
            buttonDictionary.Add((4, 5), _view.D5);
            buttonDictionary.Add((5, 5), _view.E5);
            buttonDictionary.Add((6, 5), _view.F5);
            buttonDictionary.Add((7, 5), _view.G5);
            buttonDictionary.Add((8, 5), _view.H4);

            buttonDictionary.Add((1, 6), _view.A6);
            buttonDictionary.Add((2, 6), _view.B6);
            buttonDictionary.Add((3, 6), _view.C6);
            buttonDictionary.Add((4, 6), _view.D6);
            buttonDictionary.Add((5, 6), _view.E6);
            buttonDictionary.Add((6, 6), _view.F6);
            buttonDictionary.Add((7, 6), _view.G6);
            buttonDictionary.Add((8, 6), _view.H6);

            buttonDictionary.Add((1, 7), _view.A7);
            buttonDictionary.Add((2, 7), _view.B7);
            buttonDictionary.Add((3, 7), _view.C7);
            buttonDictionary.Add((4, 7), _view.D7);
            buttonDictionary.Add((5, 7), _view.E7);
            buttonDictionary.Add((6, 7), _view.F7);
            buttonDictionary.Add((7, 7), _view.G7);
            buttonDictionary.Add((8, 7), _view.H7);

            buttonDictionary.Add((1, 8), _view.A8);
            buttonDictionary.Add((2, 8), _view.B8);
            buttonDictionary.Add((3, 8), _view.C8);
            buttonDictionary.Add((4, 8), _view.D8);
            buttonDictionary.Add((5, 8), _view.E8);
            buttonDictionary.Add((6, 8), _view.F8);
            buttonDictionary.Add((7, 8), _view.G8);
            buttonDictionary.Add((8, 8), _view.H8);
        }

        #endregion Others
    }
}
