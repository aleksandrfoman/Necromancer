using System;
using DG.Tweening;
using UnityEngine;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerAnimator
    {
        [SerializeField] private Animator animator;
        
        public void PlayRun(bool value)
        {
            animator.SetBool("IsRun",value);
        }

        public void PlayDead()
        {
            animator.SetBool("IsAim",false);
        }
        
        public void PlayShoot()
        {
            animator.SetTrigger("TriggerShoot");
        }

        private void EnableAimLayer(bool value)
        {
            float weight = value ? 1 : 0;
            DOTween.To(() => animator.GetLayerWeight(1), x => animator.SetLayerWeight(1, x), weight, 0.25f);
        }
        
        public void UpdateDirectional(Vector2 dir)
        {
            PlayRun(dir!=Vector2.zero);
        }
    }
}