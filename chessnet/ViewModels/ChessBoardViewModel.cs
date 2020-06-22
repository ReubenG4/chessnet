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
        public Board board {get; private set;}

        /*Commands*/
        public RelayCommand whitePieceChosenCommand { get; private set; }

        //Used to disable a button from use, unable to fire
        public DisableCommand disableCommand { get; private set; }

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
            disableCommand = new DisableCommand();

            whitePieceChosenCommand = machine.CreateCommand(BoardTrigger.WhitePiecePicked);

            //Initialise the game
            GameResetAction();

        }
        #endregion constructors

        /*Actions: Methods directly invoked by state machine*/
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
            var enumerator = board.GetWhitePieceEnumerator();

            /* Iterate through each whitePiece */
            while(enumerator.MoveNext())
            {
                //Retrieve the piece's valid style
                Style validStyle = ChessButtonStyle.Valid(enumerator.Current.pieceType);
                //Retrieve the piece's position
                (int, int) position = enumerator.Current.getPosition();

                //Change the piece's style and command
                board.styles[board.ToCollectionKey(position)] = validStyle;
                board.commands[board.ToCollectionKey(position)] = whitePieceChosenCommand;
            }       
        }

        public void WhitePieceHeldAction()
        {
            var enumerator = board.GetWhitePieceEnumerator();

            /* Iterate through each whitePiece */
            while (enumerator.MoveNext())
            {
                //Retrieve the piece's default style
                Style defaultStyle = ChessButtonStyle.Default(enumerator.Current.pieceType);
                //Retrieve the piece's position
                (int, int) position = enumerator.Current.getPosition();

                //Change the piece's style and command
                board.styles[board.ToCollectionKey(position)] = defaultStyle;
                board.commands[board.ToCollectionKey(position)] = disableCommand;
            }
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
                        board.styles[board.ToCollectionKey((x,y))] = styleToRender;
                        //Set command to disabledCommand
                        board.commands[board.ToCollectionKey((x,y))] = disableCommand;
                    }
                    else
                    {
                        //Render it as a default square
                        board.styles[board.ToCollectionKey((x, y))] = ChessButtonStyle.Default(PieceType.EmptySquare);
                        board.commands[board.ToCollectionKey((x, y))] = disableCommand;
                    }         
                }
            }

        }

       
        #endregion NotActions
    }
}
