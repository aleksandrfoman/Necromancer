using System;
using Content.Scripts.PlayerScripts.State;
using UnityEngine;

namespace Content.Scripts.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public PlayerMovement PlayerMovement => playerMovement;
        public PlayerAnimator PlayerAnimator => playerAnimator;
        public PlayerFollow PlayerFollow => playerFollow;
        
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField] private PlayerFind playerFind;
        [SerializeField] private PlayerFollow playerFollow;
        [SerializeField] private PlayerBar playerBar;
        
        [SerializeField] private PlayerStateMachine stateMachine;
        
        public void Init()
        {
            playerFollow.Init(transform);
            stateMachine.Init(this);
        }

        private void OnDestroy()
        {
            playerFollow.Destroy();
        }
    }
}