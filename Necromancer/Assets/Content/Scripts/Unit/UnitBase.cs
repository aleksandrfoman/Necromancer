using System;
using Content.Scripts.PlayerScripts;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitBase : MonoBehaviour
    {
        public UnitMovement Movement => unitMovement;
        public UnitAnimator UnitAnimator => unitAnimator;
        public Player Player => player;
        
        
        
        [SerializeField] private UnitMovement unitMovement;
        [SerializeField] private UnitAnimator unitAnimator;
        [SerializeField] private UnitStateMachine unitStateMachine; 
        private Player player;
        
        public void Init(Player player)
        {
            this.player = player;
            unitStateMachine.Init(this);
        }
    }

    public enum EUnityType
    {
        Player,
        Enemy,
        DeadBody
    }
}
