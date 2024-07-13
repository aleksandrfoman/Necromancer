using Content.Scripts.StateMachine;

namespace Content.Scripts.PlayerScripts.State
{
    public class PlayerStateMachine : StateMachine<PlayerScripts.Player,EPlayerState>
    {
        public override void StateSwitch()
        {
            base.StateSwitch();
            
            if (CurrentStateType == EPlayerState.Move)
            {
                return;
            }
            StartAction(EPlayerState.Move);
        }
    }
}
