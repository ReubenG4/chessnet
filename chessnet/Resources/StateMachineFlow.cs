using System;
using System.Collections.Generic;
using System.Text;
using Stateless;
using Stateless.Graph;

namespace chessnet.Resources
{
    class StateMachineFlow
    {
        /*Triggers for next state */
        enum Trigger
        {
            SplashExit,
            BlackWin,
            WhiteWin
        }

        /*States*/
        enum State
        {
            StartSplash,
            GameOn,
            BlackWin,
            WhiteWin
        }

        /* StartSplash is initial state */
        State state = State.StartSplash;

        /*Declare State Machine and Trigger*/
        StateMachine<State, Trigger> machine;
        StateMachine<State, Trigger>.TriggerWithParameters<string> splashExitTrigger;
        StateMachine<State, Trigger>.TriggerWithParameters<string> blackWinTrigger;
        StateMachine<State, Trigger>.TriggerWithParameters<string> whiteWinTrigger;

        public StateMachineFlow()
        {
            machine = new StateMachine<State, Trigger>(State.StartSplash);
            splashExitTrigger = machine.SetTriggerParameters<String>(Trigger.SplashExit);
            blackWinTrigger = machine.SetTriggerParameters<String>(Trigger.BlackWin);
            whiteWinTrigger = machine.SetTriggerParameters<String>(Trigger.WhiteWin);
        }
    }
}
