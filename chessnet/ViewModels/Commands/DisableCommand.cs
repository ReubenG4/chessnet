﻿using System;
using System.Reflection.Metadata;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chessnet.ViewModels.Commands
{
    //Used to disable buttons through property binding
    public class DisableCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public DisableCommand()
        {
           
        }

        public bool CanExecute(object parameter)
        {
           
                return false;
        }

        public void Execute(object parameter)
        {
           
        }
    }
}
