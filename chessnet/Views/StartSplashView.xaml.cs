using Chessnet.ViewModels;
using System.Windows;

namespace Chessnet.Views
{
    /// <summary>
    /// Interaction logic for StartSplashView.xaml
    /// </summary>
    public partial class StartSplashView : Window
    {
        
        public StartSplashView()
        {
            InitializeComponent();
            DataContext = new StartSplashViewModel(this);
        }

       
    }
}
