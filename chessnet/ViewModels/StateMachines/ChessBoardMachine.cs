using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Chessnet.ViewModels.StateMachines
{
    public enum BoardState
    {
       Startup,

       WhiteTurnStart,
       WhitePieceHeld,
       WhiteTurnEnd,

       BlackTurnStart,
       BlackPieceHeld,
       BlackTurnEnd,

       BlackVictory,
       WhiteVictory
        
    }

    public enum BoardTrigger
    {

        WhitePiecePicked,
        WhitePieceDropped,
        WhitePieceMoved,

        BlackPiecePicked,
        BlackPieceDropped,
        BlackPieceMoved,

        BlackWin,
        BlackNoWin,
        WhiteWin,
        WhiteNoWin,
      
        GameReset
    }

    public class ChessBoardMachine : Stateless.StateMachine<BoardState,BoardTrigger>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ChessBoardMachine(ChessBoardViewModel viewModel) : base(BoardState.Startup)
        {
             

            /* States for white turn */
            this.Configure(BoardState.Startup)
                .OnEntry(viewModel.gameResetAction)
                .Permit(BoardTrigger.GameReset, BoardState.WhiteTurnStart);

            this.Configure(BoardState.WhiteTurnStart)
                .OnEntry(viewModel.whiteTurnStartAction)
                .Permit(BoardTrigger.WhitePiecePicked, BoardState.WhitePieceHeld);

            this.Configure(BoardState.WhitePieceHeld)
                .Permit(BoardTrigger.WhitePieceDropped, BoardState.WhiteTurnStart)
                .Permit(BoardTrigger.WhitePieceMoved, BoardState.WhiteTurnEnd);

            this.Configure(BoardState.WhiteTurnEnd)
                .Permit(BoardTrigger.WhiteWin, BoardState.WhiteVictory)
                .Permit(BoardTrigger.WhiteNoWin, BoardState.BlackTurnStart);

            this.Configure(BoardState.WhiteVictory)
                .Permit(BoardTrigger.GameReset, BoardState.Startup);

            /* States for black turn */
            this.Configure(BoardState.BlackTurnStart)
                .Permit(BoardTrigger.BlackPiecePicked, BoardState.BlackPieceHeld);

            this.Configure(BoardState.BlackPieceHeld)
                .Permit(BoardTrigger.BlackPieceDropped, BoardState.BlackTurnStart)
                .Permit(BoardTrigger.BlackPieceMoved, BoardState.BlackTurnEnd);

            this.Configure(BoardState.BlackTurnEnd)
                .Permit(BoardTrigger.BlackWin, BoardState.BlackVictory)
                .Permit(BoardTrigger.BlackNoWin, BoardState.WhiteTurnStart);

            this.Configure(BoardState.BlackVictory)
               .Permit(BoardTrigger.GameReset, BoardState.Startup);

            OnTransitioned((t) =>
            {
                OnPropertyChanged("State");
                CommandManager.InvalidateRequerySuggested();
            });

            //used to debug commands and UI components
            OnTransitioned
              (
                (t) => Debug.WriteLine
                  (
                    "State Machine transitioned from {0} -> {1} [{2}]",
                    t.Source, t.Destination, t.Trigger
                  )
              );
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       
       

    }
}
