using Chessnet.ViewModels;
using System.Windows;

namespace Chessnet.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChessBoardView : Window
    {      

        public ChessBoardView()
        {
            InitializeComponent();
            DataContext = new ChessBoardViewModel(); 
        }
        
    }
}
