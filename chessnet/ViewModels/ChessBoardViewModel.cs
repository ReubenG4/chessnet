﻿using Chessnet.Models;
using Chessnet.ViewModels.StateMachines;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Documents;
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
            var enumerator = board.getWhitePieceEnumerator();

            /* Iterate through each whitePiece */
            while(enumerator.MoveNext())
            {
                //Retrieve the piece's valid style
                Style validStyle = ChessButtonStyle.Valid(enumerator.Current.pieceType);
                //Retrieve the piece's position
                (int, int) position = enumerator.Current.getPosition();

                //Change the piece's style and command
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
            /*Iterate through each chess square, x=file, y=row*/
            for (int x=1; x<9; x++)
            {
                for(int y=1; y<9; y++)
                {
                    //If square contains a piece
                    if (board.tryGetPiece((x, y)))
                    {
                        //Retrieve piece
                        Piece pieceToRender = board.getPiece((x, y));
                        //Find its default style
                        Style styleToRender = ChessButtonStyle.Default(pieceToRender.pieceType);
                        //Render it in default style
                        board.styles[board.toCollectionKey((x,y))] = styleToRender;
                    }
                    else
                    {
                        //Render it as a default square
                        board.styles[board.toCollectionKey((x, y))] = ChessButtonStyle.Default(PieceType.EmptySquare);
                    }         
                }
            }

        }

       
        #endregion NotActions
    }
}
