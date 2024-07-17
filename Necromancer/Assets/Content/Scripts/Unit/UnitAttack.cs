using System;
using UnityEngine;

namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitAttack
    {
        [SerializeField] private float cdAttack;
        [SerializeField] private float damage;
        [SerializeField] private float distanceAttack;
        
        private float curCdAttack;
        private UnitAnimator unitAnimator;
        private Transform transform;
        private bool isAttack;
        public void Init(UnitAnimator unitAnimator, Transform transform)
        {
            this.unitAnimator = unitAnimator;
            this.transform = transform;
            curCdAttack = cdAttack;
        }


        public bool Attack(UnitBase unitBase)
        {
            if(!unitBase) return false;
            
            if (CheckDistance(unitBase.transform.position))
            {
                if (curCdAttack <= 0f)
                {
                    if(!isAttack)
                    {
                        unitAnimator.PlayAttack();
                    }
                    isAttack = true;
                    if (unitAnimator.IsAttackComplete)
                    {
                        isAttack = false;
                        curCdAttack = cdAttack;
                        unitBase.UnitHealth.TakeDamage(damage);
                    }
                }
                else
                {
                    curCdAttack -= Time.deltaTime;
                }
                return true;
            }
            return false;
        }

        public void ResetAttack()
        {
            curCdAttack = 0f;
        }

        private bool CheckDistance(Vector3 targetPos)
        {
            return Vector3.Distance(transform.position, targetPos)<=distanceAttack;
        }

        public void DrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position,distanceAttack);
            }
        }
    }
}
