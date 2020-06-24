using Chessnet.Models;
using Chessnet.ViewModels.Commands;
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
        public ChessBoard board {get; private set;}

        /*Commands*/
        public RelayCommand whitePieceChosenCommand { get; private set; }
        public RelayCommand whitePieceDroppedCommand { get; private set; }

        //Used to disable a button from use, never able to execute
        public DisabledCommand disabledCommand { get; private set; }

        /*Button Commands and Styles: Used to bind buttons to*/
        public ButtonCommandCollection commands { get; private set; }
        public ButtonStyleCollection styles { get; private set; }

        #endregion declarations

        #region constructors
        /* Constructor */
        public ChessBoardViewModel()
        {
            //Initialise StateMachine
            machine = new ChessBoardMachine(this);

            //Initialise Board model
            board = new ChessBoard();

            //Initialise button binding collections
            commands = new ButtonCommandCollection();
            styles = new ButtonStyleCollection();

            //Initialise commands
            disabledCommand = new DisabledCommand();
            whitePieceChosenCommand = machine.CreateCommand(BoardTrigger.WhitePiecePicked);
            whitePieceDroppedCommand = machine.CreateCommand(BoardTrigger.WhitePieceDropped);

            //Initialise the game
            GameResetAction();

        }
        #endregion constructors

        /*Actions: Methods directly invoked by state machine, typically set up to fire onEntry for a state*/
        #region Actions

        /*gameResetAction: Resets game*/
        public void GameResetAction()
        {
            //Initialise board model
            board.Reset();

            //Render the default board
            RenderDefaultBoard();

            //Place state machine in next state
            machine.Fire(BoardTrigger.GameReset);
        }

        /*whiteTurnStartAction: Places game in WhiteTurnStart state */
        public void WhiteTurnStartAction()
        {
            var pieceEnumerator = board.GetWhitePieceEnumerator();

            /* Iterate through each whitePiece */
            while(pieceEnumerator.MoveNext())
            {
                //Retrieve the piece's valid style
                Style validStyle = ChessButtonStyle.Valid(pieceEnumerator.Current.pieceType);
                //Retrieve the piece's position
                (int, int) position = pieceEnumerator.Current.getPosition();

                //Change the piece's style and command
                styles[board.ToCollectionKey(position)] = validStyle;
                commands[board.ToCollectionKey(position)] = whitePieceChosenCommand;
            }       
        }

        /*WhitePieceHeldAction: Places game in WhitePieceHeld state */
        public void WhitePieceHeldAction()
        {
            var pieceEnumerator = board.GetWhitePieceEnumerator();
            int pieceKey = whitePieceChosenCommand.getParamInt();

            //Iterate through each whitePiece 
            while (pieceEnumerator.MoveNext())
            {
                //Retrieve the piece's default style
                Style defaultStyle = ChessButtonStyle.Default(pieceEnumerator.Current.pieceType);
                //Retrieve the piece's position
                (int, int) position = pieceEnumerator.Current.getPosition();

                //Change the piece's style and command (Disable the piece from being selected)
                styles[board.ToCollectionKey(position)] = defaultStyle;
                commands[board.ToCollectionKey(position)] = disabledCommand;
            }

            //Retrieve the piece chosen
            Piece pieceChosen = board.GetPiece(pieceKey);

            //Set it to whitePieceDroppedCommand
            commands[pieceKey] = whitePieceDroppedCommand;

            //Set it to white piece chosen style
            styles[pieceKey] = ChessButtonStyle.Chosen(pieceChosen.pieceType);
         
        }
        #endregion Actions

        /*Methods not directly invoked by State machine*/
        #region NotActions

        /* Renders every square of the Board model*/
        public void RenderDefaultBoard()
        {
            /*Iterate through each chess square, x=file, y=row*/
            for (int x=1; x<9; x++)
            {
                for(int y=1; y<9; y++)
                {
                    //If square contains a piece
                    if (board.TryGetPiece((x, y)))
                    {
                        //Retrieve piece
                        Piece pieceToRender = board.GetPiece((x, y));
                        //Find its default style
                        Style styleToRender = ChessButtonStyle.Default(pieceToRender.pieceType);
                        //Render it in default style
                        styles[board.ToCollectionKey((x,y))] = styleToRender;
                        //Set command to disabledCommand
                        commands[board.ToCollectionKey((x,y))] = disabledCommand;
                    }
                    else
                    {
                        //Render it as a default square
                        styles[board.ToCollectionKey((x, y))] = ChessButtonStyle.Default(PieceType.EmptySquare);
                        //Set command to disabledCommand
                        commands[board.ToCollectionKey((x, y))] = disabledCommand;
                    }         
                }
            }

        }

       
        #endregion NotActions
    }
}
