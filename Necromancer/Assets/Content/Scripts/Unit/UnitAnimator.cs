using System;
using UnityEngine;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitAnimator 
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationEventsListener animationEventsListener;

        private void Awake()
        {
            animationEventsListener.OnJumpComplete += JumpComplete;
        }
        
        private void Disable()
        {
            animationEventsListener.OnJumpComplete -= JumpComplete;
        }
        
        public void PlayIdle()
        {
            animator.SetBool("IsRun",false);
        }
        public void PlayRun()
        {
            animator.SetBool("IsRun",true);
        }

        #region Jump
        
        public bool IsJumpComplete => isJumpComplete;
        private bool isJumpComplete;
        
        public void PlayJump()
        {
            isJumpComplete = false;
            animator.SetTrigger("JumpTrigger");
        }

        public void JumpComplete()
        {
            isJumpComplete = true;
        }

        #endregion
    }
}
