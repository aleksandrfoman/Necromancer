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
        }
        
        public void Destroy()
        {
            animationEventsListener.OnSpawnComplete -= SpawnComplete;
        }
        
        public void PlayIdle()
        {
            animator.SetBool("IsRun",false);
            ResetLayes();
            EnableLayerAttack(false);
            EnableLayerDeadBody(false);
        }
        public void PlayRun()
        {
            animator.SetBool("IsRun",true);
            ResetLayes();
            EnableLayerAttack(false);
            EnableLayerDeadBody(false);
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

        
        #region Jump
        
        public bool IsSpawnComplete => isSpawnComplete;
        private bool isSpawnComplete;
        
        public void PlaySpawn()
        {
            isSpawnComplete = false;
            ResetLayes();
            EnableLayerAttack(false);
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
