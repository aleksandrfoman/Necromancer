using System;
using DG.Tweening;
using UnityEngine;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitAnimator 
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationEventsListener animationEventsListener;

        public void Init()
        {
            animationEventsListener.OnSpawnComplete += SpawnComplete;
            animationEventsListener.OnAttackComplete += AttackComplete;
        }
        
        public void Destroy()
        {
            animationEventsListener.OnSpawnComplete -= SpawnComplete;
            animationEventsListener.OnAttackComplete -= AttackComplete;
        }
        
        public void PlayIdle()
        {
            animator.SetBool("IsRun",false);
            ResetLayes();
            EnableLayerDeadBody(false);
        }
        public void PlayRun()
        {
            animator.SetBool("IsRun",true);
            ResetLayes();
            EnableLayerDeadBody(false);
        }
        
        public bool IsAttackComplete => isAttackComplete;
        private bool isAttackComplete;
        public void PlayAttack()
        {
            isAttackComplete = false;
            ResetLayes();
            EnableLayerDeadBody(false);
            animator.SetTrigger("AttackTrigger");
        }
        
        private void AttackComplete()
        {
            isAttackComplete = true;
        }

        public void PlayDead()
        {
            animator.SetTrigger("DeadTrigger");
            ResetLayes();
            EnableLayerDeadBody(true);
        }
        #region Layers

        public void ResetLayes()
        {
            isAttackLayer = false;
            isDeadBodyLayer = false;
        }
        
        private bool isAttackLayer;
        private void EnableLayerAttack(bool value)
        {
            if(isAttackLayer) return;
            
            isAttackLayer = true;
            float weight = value ? 1 : 0;
            DOTween.To(() => animator.GetLayerWeight(1),
                x => animator.SetLayerWeight(1, x), weight, 0.15f);
        }
        
        private bool isDeadBodyLayer;
        private void EnableLayerDeadBody(bool value)
        {
            if(isDeadBodyLayer) return;
            
            isDeadBodyLayer = true;
            float weight = value ? 1 : 0;
            DOTween.To(() => animator.GetLayerWeight(2),
                x => animator.SetLayerWeight(2, x), weight, 0.15f);
        }
        
        #endregion

        
        #region Spawn
        
        public bool IsSpawnComplete => isSpawnComplete;
        private bool isSpawnComplete;
        
        public void PlaySpawn()
        {
            isSpawnComplete = false;
            ResetLayes();
            EnableLayerDeadBody(true);
            animator.SetTrigger("SpawnTrigger");
        }

        public void SpawnComplete()
        {
            isSpawnComplete = true;
        }

    
        #endregion
    }
}
