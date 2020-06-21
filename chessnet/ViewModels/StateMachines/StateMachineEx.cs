using System.Windows.Input;
using Chessnet.ViewModels.Commands;
using Stateless;


namespace Chessnet.ViewModels.StateMachines
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
