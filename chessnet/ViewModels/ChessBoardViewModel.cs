using chessnet;
using Chessnet.Models;
using Chessnet.ViewModels.Commands.StateMachines;
using Chessnet.ViewModels.StateMachines;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Chessnet.ViewModels
{
    public enum SquareState
    {

    }

    public class ChessBoardViewModel 
    {

        /* Declare View and State Machine */
        ChessBoardMachine machine;
        ChessBoardView _view;

        /* Declare board model*/
        Board board;

        /* Declare dictionary to lookup button reference for a position */
        Dictionary<string, Button> directory;
        private Dictionary<string, Button> buttonDirectory;

        /* Constructor */
        public ChessBoardViewModel(ChessBoardView view)
        {
            //Initialise view
            _view = view;

            //Dictionary of actions for machine to access
            Dictionary<string, Action> actions = new Dictionary<string, Action>();
            actions.Add("startup", startup);

            //Initialise Machine
            machine = new ChessBoardMachine(actions);

            board = new Board();

            //Initialise Button Directory
       
            

            startup();

        }

        public void startup()
        {
            board.init();
            initButtonDirectory();
            renderBoard();

        }

        public void renderBoard()
        {
            Dictionary<string, Piece> chessList = board.chessList;
            foreach(var square in chessList){



            }


        }

        public void initButtonDirectory()
        {
            buttonDirectory = new Dictionary<string, Button>();

            buttonDirectory.Add("A1", _view.A1);
            buttonDirectory.Add("B1", _view.B1);
            buttonDirectory.Add("C1", _view.C1);
            buttonDirectory.Add("D1", _view.D1);
            buttonDirectory.Add("E1", _view.E1);
            buttonDirectory.Add("F1", _view.F1);
            buttonDirectory.Add("G1", _view.G1);
            buttonDirectory.Add("H1", _view.H1);

            buttonDirectory.Add("A2", _view.A2);
            buttonDirectory.Add("B2", _view.B2);
            buttonDirectory.Add("C2", _view.C2);
            buttonDirectory.Add("D2", _view.D2);
            buttonDirectory.Add("E2", _view.E2);
            buttonDirectory.Add("F2", _view.F2);
            buttonDirectory.Add("G2", _view.G2);
            buttonDirectory.Add("H2", _view.H2);

            buttonDirectory.Add("A3", _view.A3);
            buttonDirectory.Add("B3", _view.B3);
            buttonDirectory.Add("C3", _view.C3);
            buttonDirectory.Add("D3", _view.D3);
            buttonDirectory.Add("E3", _view.E3);
            buttonDirectory.Add("F3", _view.F3);
            buttonDirectory.Add("G3", _view.G3);
            buttonDirectory.Add("H3", _view.H3);

            buttonDirectory.Add("A4", _view.A4);
            buttonDirectory.Add("B4", _view.B4);
            buttonDirectory.Add("C4", _view.C4);
            buttonDirectory.Add("D4", _view.D4);
            buttonDirectory.Add("E4", _view.E4);
            buttonDirectory.Add("F4", _view.F4);
            buttonDirectory.Add("G4", _view.G4);
            buttonDirectory.Add("H4", _view.H4);

            buttonDirectory.Add("A5", _view.A5);
            buttonDirectory.Add("B5", _view.B5);
            buttonDirectory.Add("C5", _view.C5);
            buttonDirectory.Add("D5", _view.D5);
            buttonDirectory.Add("E5", _view.E5);
            buttonDirectory.Add("F5", _view.F5);
            buttonDirectory.Add("G5", _view.G5);
            buttonDirectory.Add("H5", _view.H5);

            buttonDirectory.Add("A6", _view.A6);
            buttonDirectory.Add("B6", _view.B6);
            buttonDirectory.Add("C6", _view.C6);
            buttonDirectory.Add("D6", _view.D6);
            buttonDirectory.Add("E6", _view.E6);
            buttonDirectory.Add("F6", _view.F6);
            buttonDirectory.Add("G6", _view.G6);
            buttonDirectory.Add("H6", _view.H6);

            buttonDirectory.Add("A7", _view.A7);
            buttonDirectory.Add("B7", _view.B7);
            buttonDirectory.Add("C7", _view.C7);
            buttonDirectory.Add("D7", _view.D7);
            buttonDirectory.Add("E7", _view.E7);
            buttonDirectory.Add("F7", _view.F7);
            buttonDirectory.Add("G7", _view.G7);
            buttonDirectory.Add("H7", _view.H7);

            buttonDirectory.Add("A8", _view.A8);
            buttonDirectory.Add("B8", _view.B8);
            buttonDirectory.Add("C8", _view.C8);
            buttonDirectory.Add("D8", _view.D8);
            buttonDirectory.Add("E8", _view.E8);
            buttonDirectory.Add("F8", _view.F8);
            buttonDirectory.Add("G8", _view.G8);
            buttonDirectory.Add("H8", _view.H8);
        }
    }
}
