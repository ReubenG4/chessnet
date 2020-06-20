using GalaSoft.MvvmLight.Command;
using Stateless;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Chessnet.ViewModels.StateMachines;

namespace Chessnet.ViewModels.Commands.StateMachines
{
    public static class StateMachineEx
    {

        public static ICommand CreateCommand<TState, TTrigger>(this StateMachine<TState, TTrigger> stateMachine, TTrigger trigger)
        {
            return new RelayCommand
              (
                () => stateMachine.Fire(trigger),
                () => stateMachine.CanFire(trigger)
              );
        }
    }

   
}
