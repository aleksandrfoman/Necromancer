using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitActionChaseAttack : UnitActionBase
    {
        private UnitBase enemyUnit;

        public override void StartState()
        {
            base.StartState();
            Machine.UnitMovement.EnableMovement(true);
            Machine.UnitAttack.ResetAttack();
        }

        public override void ProcessState()
        {
            if (Machine.UnitFind.HasFoundEnemy())
            {
                enemyUnit = Machine.UnitFind.EnemyUnit;
            }
            
            if (enemyUnit != null && !enemyUnit.IsDead)
            {
                Machine.UnitMovement.SetTarget(enemyUnit.transform.position);
                Machine.UnitMovement.Gravity();
                Machine.UnitMovement.RotateToTarget(enemyUnit.transform.position);
                Machine.UnitMovement.Move();

                if (Machine.UnitAttack.Attack(enemyUnit))
                {
                    Machine.UnitMovement.ResetVelocity();
                }
                
                if (Machine.UnitMovement.IsMove(0.25f))
                {
                    Machine.UnitAnimator.PlayRun();
                }
                else
                {
                    Machine.UnitAnimator.PlayIdle();
                }
            }
            else
            {
                EndState();
            }
        }
    }
}
