using System.Windows;
using Chessnet.Views;

namespace Chessnet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void Application_Startup(object sender, StartupEventArgs e)
		{
		
			//Instantiate windows
			StartSplashView startSplash = new StartSplashView();
			startSplash.Show();

			
		}
	}
}
