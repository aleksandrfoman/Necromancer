using System;
using UnityEngine;

namespace Content.Scripts
{
    public class AnimationEventsListener : MonoBehaviour
    {
        public event Action OnAttackComplete;
        public event Action OnHitComplete;
        public event Action OnCatchComplete;
        public event Action OnJumpComplete;
        
        public void AttackComplete()
        {
            OnAttackComplete?.Invoke();
        }

        public void HitComplete()
        {
            OnHitComplete?.Invoke();
        }

        public void CatchComplete()
        {
            OnCatchComplete?.Invoke();   
        }
        
        public void JumpComplete()
        {
            OnJumpComplete?.Invoke();   
        }
    }
}
