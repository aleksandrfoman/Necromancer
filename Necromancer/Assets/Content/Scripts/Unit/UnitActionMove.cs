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
            if (Machine.Movement.CheckDistanceToTarget(0.1f))
            {
                Machine.UnitAnimator.PlayIdle();
            }
            else
            {
                Machine.UnitAnimator.PlayRun();
            }
        }
    }
}
