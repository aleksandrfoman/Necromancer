namespace Content.Scripts.Unit
{
    public class UnitActionDeadBody : UnitActionBase
    {
        public override void StartState()
        {
            base.StartState();
            Machine.UnitMovement.EnableCollider(false);
            Machine.UnitMovement.EnableMovement(false);
        }
    }
}
