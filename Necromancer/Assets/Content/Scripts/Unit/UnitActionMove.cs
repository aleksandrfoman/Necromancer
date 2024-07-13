using Content.Scripts.PlayerScripts;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitActionMove : UnitActionBase
    {
        [SerializeField]
        private Transform target;
        
        public override void ProcessState()
        {
            Machine.Movement.SetTarget(target.position);
       
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
