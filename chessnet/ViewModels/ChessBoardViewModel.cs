using chessnet;
using Chessnet.Models;
using Chessnet.ViewModels.Commands.StateMachines;
using Chessnet.ViewModels.StateMachines;
using System.Collections.Generic;
using System.ComponentModel;
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

        /* Declare board model*/
        Board board;

        /* Declare dictionary to lookup style reference for a button */
        public Dictionary<(int,int), Style> buttonStyleDictionary;

        /*Declare dictionary to lookup Command reference for a button*/
        public Dictionary<(int, int), ICommand> buttonCommandDictionary;

        /*Commands*/
        public ICommand whitePieceChosenCommand { get; private set; }

        /* Constructor */
        public ChessBoardViewModel()
        {
            //Initialise StateMachine
            machine = new ChessBoardMachine(this);

            //Initialise Board model
            board = new Board();

            //Initialise ButtonStyles 
            initButtonStyleDictionary();

            //Initialise Commands
            initButtonCommandDictionary();

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
            //machine.Fire(BoardTrigger.GameReset);
        }

        /*whiteTurnStartAction: Places game in WhiteTurnStart state */
        public void whiteTurnStartAction()
        {
          
            /* Iterate through each whitePiece */
            foreach(var pieceToChange in board.whitePieces)
            {
                //Retrieve the appropiate style
                Style validStyle = getValidPieceStyle(pieceToChange);

                //Retrieve the reference to the position's button style
                Style styleToChange = buttonStyleDictionary[pieceToChange.getPosition()];

                //Change its style
                styleToChange = validStyle;
            }
        }
        #endregion Actions

        /*Methods not directly invoked by State machine*/

        #region NotActions
        /* Renders every square of the Board model*/
        public void renderBoard()
        {
            /*Iterate through each button*/
            foreach(var styleToChange in buttonStyleDictionary){

                //Retrieve each button and its position
                (int,int) styleKey = styleToChange.Key;
                
                
                //If key's corresponding position is occupied 
                if(board.chessList.TryGetValue(styleKey, out _))
                {
                    //Retrieve piece
                    Piece pieceToRender = board.chessList[styleKey];

                    //Change its associated button to the default style
                   
                }
                else
                {
                    //Else, render it as an empty default square
                  
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
        public void initButtonStyleDictionary()
        {
            buttonStyleDictionary = new Dictionary<(int,int), Style>();

            for(int x=1; x<9; x++)
            {
                for (int y = 1; y < 9; y++)
                    buttonStyleDictionary.Add((x, y), Application.Current.Resources["DefaultSquare"] as Style);
            }
        }

        public void initButtonCommandDictionary()
        {
            buttonCommandDictionary = new Dictionary<(int, int), ICommand>();

            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                    buttonCommandDictionary.Add((x, y), null);
            }

        }

        #endregion Others
    }
}
