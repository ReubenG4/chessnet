using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using chessnet.ViewModels;
using Chessnet.ViewModels.Commands;

namespace chessnet.ViewModels
{
    public class StartSplashViewModel
    {
        public StartGameCommand StartCommand { get; private set; }

        public StartSplashViewModel(Window startSplash)
        { 
            StartCommand = new StartGameCommand(startSplash);
        }

       
    }

}
