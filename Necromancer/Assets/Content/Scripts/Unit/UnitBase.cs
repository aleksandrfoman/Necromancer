using System;
using Content.Scripts.Managers;
using Content.Scripts.PlayerScripts;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitBase : MonoBehaviour
    {
        public UnitMovement Movement => unitMovement;
        public UnitAnimator UnitAnimator => unitAnimator;
        public Player Player => player;
        public EUnitType UnitType => unitType;
        
        [SerializeField] private UnitMovement unitMovement;
        [SerializeField] private UnitAnimator unitAnimator;
        [SerializeField] private UnitStateMachine unitStateMachine;
        [SerializeField] private EUnitType unitType;
        private Player player;

        private void Start()
        {
            Init(GlobalManager.Instance.Player);
            switch (unitType)
            {
                case EUnitType.Enemy:
                    UnitManager.Instance.AddEnemy(this);
                    unitStateMachine.StartAction(EUnitState.Idle);
                    break;
                case EUnitType.DeadBody: 
                    unitStateMachine.StartAction(EUnitState.DeadBody);
                    break;
                case EUnitType.PlayerUnit: break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void Init(Player player)
        {
            this.player = player;
            unitStateMachine.Init(this);
        }
    }

    public enum EUnitType
    {
        PlayerUnit,
        Enemy,
        DeadBody
    }
}
