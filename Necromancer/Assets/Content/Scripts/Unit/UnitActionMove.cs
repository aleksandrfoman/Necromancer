using Content.Scripts.PlayerScripts;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitActionMove : UnitActionBase
    {
        public override void ProcessState()
        {
            Machine.Movement.SetTarget(Machine.Player.transform.position);
            Machine.Movement.Gravity();
            Machine.Movement.Rotate(Machine.Player.PlayerMovement.Forward);
            Machine.Movement.Move();
            if (Machine.Movement.IsMove)
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
