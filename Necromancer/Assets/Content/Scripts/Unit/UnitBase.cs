using System;
using Content.Scripts.Managers;
using Content.Scripts.PlayerScripts;
using DG.Tweening;
using UnityEngine;
namespace Content.Scripts.Unit
{
    public class UnitBase : MonoBehaviour
    {
        public UnitMovement UnitMovement => unitUnitMovement;
        public UnitAnimator UnitAnimator => unitAnimator;
        public Player Player => player;
        public UnitFind UnitFind => unitFind;
        public UnitAttack UnitAttack => unitAttack;
        public UnitHealth UnitHealth => unitHealth;
        public EUnitType UnitType => unitType;
        
        public bool IsDead => isDead;

        [SerializeField] private UnitMovement unitUnitMovement;
        [SerializeField] private UnitFind unitFind;
        [SerializeField] private UnitAnimator unitAnimator;
        [SerializeField] private UnitAttack unitAttack;
        [SerializeField] private UnitHealth unitHealth;
        [SerializeField] private UnitSkin unitSkin;
        [SerializeField] private UnitStateMachine unitStateMachine;
        [SerializeField] private EUnitType unitType;
        
        private bool isDead;
        private Player player;

        private void Start()
        {
            Init(GlobalManager.Instance.Player);
        }

        private void Init(Player player)
        {
            this.player = player;
            unitHealth.Init();
            unitFind.Init(this);
            unitAnimator.Init();
            unitAttack.Init(unitAnimator,transform);
            unitStateMachine.Init(this);
            unitHealth.OnDead += Dead;
            unitSkin.UpdateSkin(unitType);
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
        

        private void OnDestroy()
        {
            unitAnimator.Destroy();
            unitHealth.OnDead -= Dead;
        }

        public void CaptureUnit()
        {
            unitType = EUnitType.PlayerUnit;
            UnitManager.Instance.RemoveDeadBody(this);
            UnitManager.Instance.AddPlayerUnit(this);
            unitStateMachine.StartAction(EUnitState.Spawn);
            unitSkin.UpdateSkin(unitType);
        }

        public void Dead()
        {
            isDead = true;
            unitStateMachine.StartAction(EUnitState.DeadBody);
            unitAnimator.PlayDead();
            if (unitType == EUnitType.Enemy)
            {
                DeadBodyUnit();
            }
            if (unitType == EUnitType.PlayerUnit)
            {
                UnitManager.Instance.RemovePlayerUnit(this);
                player.PlayerArmy.RemoveArmyUnit();
                player.PlayerArmy.UpdateArmyInfo();
                DestroyUnit();
            }
        }

        private void DeadBodyUnit()
        {
            UnitManager.Instance.RemoveEnemy(this);
            
            DOVirtual.DelayedCall(0.5f, (() =>
            {
                isDead = false;
                unitSkin.UpdateSkin(unitType);
                unitType = EUnitType.DeadBody;
                unitFind.Reset();
                unitHealth.Reset();
                UnitManager.Instance.AddDeadBody(this);
            }));
        }

        private void DestroyUnit()
        {
            DOVirtual.DelayedCall(1f, (() =>
            {
                Vector3 vectorDown = transform.position + (Vector3.down * 1f);
                transform.DOMove(vectorDown,2f).OnComplete((() =>
                {
                    Destroy(gameObject);
                }));
            }));
        }
        
        private void OnDrawGizmos()
        {
            unitAttack.DrawGizmos();
        }
    }

    public enum EUnitType
    {
        PlayerUnit,
        Enemy,
        DeadBody
    }
}
