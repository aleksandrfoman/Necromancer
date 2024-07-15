using System;
using Content.Scripts.Managers;
using Content.Scripts.PlayerScripts;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitBase : MonoBehaviour
    {
        public UnitMovement UnitMovement => unitUnitMovement;
        public UnitAnimator UnitAnimator => unitAnimator;
        public Player Player => player;
        public UnitFind UnitFind => unitFind;
        public EUnitType UnitType => unitType;


        [SerializeField] private UnitMovement unitUnitMovement;
        [SerializeField] private UnitFind unitFind;
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
                    UnitManager.Instance.AddDeadBody(this);
                    unitStateMachine.StartAction(EUnitState.DeadBody);
                    break;
                case EUnitType.PlayerUnit: break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void Init(Player player)
        {
            this.player = player;
            unitAnimator.Init();
            unitStateMachine.Init(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                unitAnimator.PlaySpawn();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                unitAnimator.PlayRun();
            }
        }

        private void OnDestroy()
        {
            unitAnimator.Destroy();
        }

        public void CaptureUnit()
        {
            unitType = EUnitType.PlayerUnit;
            UnitManager.Instance.RemoveDeadBody(this);
            UnitManager.Instance.AddPlayerUnit(this);
            unitStateMachine.StartAction(EUnitState.Spawn);
        }
    }

    public enum EUnitType
    {
        PlayerUnit,
        Enemy,
        DeadBody
    }
}
