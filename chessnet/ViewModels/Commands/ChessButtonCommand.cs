using System;
using System.Reflection.Metadata;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chessnet.ViewModels.Commands
{
    public class ChessButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

       
         
        public ChessButtonCommand()
        {
           
        }

        public bool CanExecute(object parameter)
        {
            if (parameter.GetType() == typeof(Button))
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
           
        }
    }
}

