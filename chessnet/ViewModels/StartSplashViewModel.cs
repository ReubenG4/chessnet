using System.Windows;
using Chessnet.ViewModels.Commands;

namespace Chessnet.ViewModels
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
