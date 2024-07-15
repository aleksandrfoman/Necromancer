using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitActionIdle : UnitActionBase
    {
        private Vector3 randomTarget;
        private float curCrRotate;
        
        public override void StartState()
        {
            base.StartState();
            Machine.UnitAnimator.PlayIdle();
        }
        
        public override void ProcessState()
        {
            RandomRotate();
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
