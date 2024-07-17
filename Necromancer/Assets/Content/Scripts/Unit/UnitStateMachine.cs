using Content.Scripts.StateMachine;

namespace Content.Scripts.Unit
{
    public class UnitStateMachine : StateMachine<UnitBase,EUnitState>
    {
        public override void StateSwitch()
        {
            if (Machine.UnitType == EUnitType.PlayerUnit)
            {
                if (CurrentStateType == EUnitState.Move)
                {
                    StartAction(EUnitState.ChaseAttack);
                }
                else
                {
                    StartAction(EUnitState.Move);
                }
            }
            if (Machine.UnitType == EUnitType.Enemy)
            {
                if (CurrentStateType == EUnitState.Idle)
                {
                    StartAction(EUnitState.ChaseAttack);
                }
                else
                {
                    StartAction(EUnitState.Idle);
                }
            }
        }
    }
}
