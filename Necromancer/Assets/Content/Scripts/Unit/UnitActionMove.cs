using Content.Scripts.PlayerScripts;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitActionMove : UnitActionBase
    {
        public override void StartState()
        {
            base.StartState();
            Machine.UnitMovement.EnableCollider(true);
            Machine.UnitMovement.EnableMovement(true);
        }

        public override void ProcessState()
        {
            Machine.UnitMovement.SetTarget(Machine.Player.transform.position);
            Machine.UnitMovement.Gravity();
            Machine.UnitMovement.Rotate(Machine.Player.PlayerMovement.Forward);
            Machine.UnitMovement.Move();
            if (Machine.UnitMovement.IsMove)
            {
                Machine.UnitAnimator.PlayRun();
            }
            else
            {
                Machine.UnitAnimator.PlayIdle();
            }
        }
    }
}
