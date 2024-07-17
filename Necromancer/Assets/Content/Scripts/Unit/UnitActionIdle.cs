using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitActionIdle : UnitActionBase
    {
        private Vector3 randomTarget;
        private float curCrRotate;
        private PointMover pointMover;
        
        public override void StartState()
        {
            base.StartState();

            Machine.UnitAnimator.PlayIdle();
            pointMover = Machine.UnitMovement.PointMover;
            Machine.UnitMovement.EnableMovement(pointMover != null);

        }
        
        public override void ProcessState()
        {
            if (pointMover != null)
            {
                Machine.UnitMovement.SetTarget(pointMover.transform.position);
                Machine.UnitMovement.Gravity();
                Machine.UnitMovement.Move(); 
                Machine.UnitMovement.Rotate(pointMover.transform.forward);
        
                if (Machine.UnitMovement.IsMove())
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
                RandomRotate();
            }
            
            if (Machine.UnitFind.HasFoundEnemy())
            {
                EndState();
            }
        }

        private void RandomRotate()
        {
            Machine.UnitMovement.RotateToTarget(randomTarget);
            if (Machine.UnitMovement.IsVisible(randomTarget) && curCrRotate<=0f)
            {
                curCrRotate = Random.Range(1f,3f);
                randomTarget = GetRandomVisiblePoint();
            }
            else
            {
                curCrRotate -= Time.deltaTime;
            }
        }
        
        private Vector3 GetRandomVisiblePoint()
        {
            return new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        }
    }
}
