using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Chessnet.Models
{
    /*Observable collections for buttons to data bind*/

    /*Holds Commands for buttons to invoke*/
    public class ButtonCommandCollection : ObservableCollection<ICommand>
    {
        public ButtonCommandCollection() : base()
        {
            for (int x = 0; x < 64; x++)
            {
                Add(null);
            }
        }
    }

    /*Holds styles for buttons*/
    public class ButtonStyleCollection : ObservableCollection<Style>
    {
        public ButtonStyleCollection() : base()
        {
            for (int x = 0; x < 64; x++)
            {
                Add(Application.Current.Resources["DefaultSquare"] as Style);
            }
        }
    }

    public class ButtonTagCollection : ObservableCollection<int>
    {
        public ButtonTagCollection() : base()
        {
            for (int x = 0; x < 64; x++)
            {
                Add(x);
            }
        }
    }
}
