using Content.Scripts.StateMachine;

namespace Content.Scripts.Unit
{
    public class UnitStateMachine : StateMachine<UnitBase,EUnitState>
    {
        public override void StateSwitch()
        {
            if(CurrentStateType == EUnitState.Spawn)
            {
                StartAction(EUnitState.Move);
            }
        }
    }
}
