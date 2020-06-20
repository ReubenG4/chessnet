using GalaSoft.MvvmLight.Command;
using Stateless;
using System;
using System.Collections.Generic;
using System.Text;
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
       
        public ChessBoardMachine(Dictionary<string, Action> actions) : base(BoardState.Startup)
        {

            /* States for white turn */
            this.Configure(BoardState.Startup)
                .OnEntry(actions["GameReset"])
                .Permit(BoardTrigger.GameReset, BoardState.WhiteTurnStart);

            this.Configure(BoardState.WhiteTurnStart)
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

        }

       

    }
}
