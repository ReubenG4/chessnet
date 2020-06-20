using chessnet;
using Chessnet.ViewModels.Commands.StateMachines;
using Chessnet.ViewModels.StateMachines;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace Chessnet.ViewModels
{
    class ChessBoardViewModel 
    {

        ChessBoardMachine machine;
        ChessBoardView _view;


        public ChessBoardViewModel(ChessBoardView view)
        {
            _view = view;
            Dictionary<string, Action> actions = new Dictionary<string, Action>();
            actions.Add("renderWhite", renderBoard);

            machine = new ChessBoardMachine(actions);

        }


        public void renderBoard()
        {
            
        }
    }
}
