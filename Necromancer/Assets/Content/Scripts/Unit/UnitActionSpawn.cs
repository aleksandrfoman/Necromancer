using UnityEngine;

namespace Content.Scripts.Unit
{
    public class UnitActionSpawn : UnitActionBase
    {
        public override void StartState()
        {
            base.StartState();
            Particle particle = Pool.PoolManager.Instance.PoolSpawnEffect.GetFreeElement();
            particle.transform.position = Machine.transform.position-Vector3.down;
            particle.transform.localScale = Vector3.one * 2f;
            particle.Activate();
            Machine.UnitAnimator.PlaySpawn();
        }

        public override void ProcessState()
        {
            if (Machine.UnitAnimator.IsSpawnComplete)
            {
                EndState();
            }
        }
    }
}
