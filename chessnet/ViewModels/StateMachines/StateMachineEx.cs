using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stateless;


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
