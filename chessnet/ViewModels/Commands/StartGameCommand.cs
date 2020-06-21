using Chessnet.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Chessnet.ViewModels.Commands
{
    public class StartGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //Window to be closed when 
        Window _window;
        public StartGameCommand(Window window)
        {
            _window = window;
        }

        public StartGameCommand()
        {
            _window = null;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Instantiate board and show it
            ChessBoardView boardView = new ChessBoardView();
            boardView.Show();

            //Close previous window if present
            if(_window != null)
                _window.Close();
        }
    }
}
