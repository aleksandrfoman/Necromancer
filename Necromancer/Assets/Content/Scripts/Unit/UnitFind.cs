using System;
using Content.Scripts.Managers;
using UnityEngine;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitFind
    {
        public UnitBase EnemyUnit => enemyUnit;
        public bool IsMaxTarget => maxTarget;
        [SerializeField] private int maxTargetCount;
        [SerializeField] private float findRadius;
        private bool maxTarget;
        private int curTargets;
        private UnitBase enemyUnit;
        private UnitBase unitBase;

        public void Init(UnitBase unitBase)
        {
            this.unitBase = unitBase;
        }
        
        private UnitBase FindNearEnemy()
        {
            if (unitBase.UnitType == EUnitType.PlayerUnit)
            {
                return UnitManager.Instance.FindNearEnemy(unitBase.transform.position, findRadius);
            }
            if(unitBase.UnitType == EUnitType.Enemy)
            {
                return UnitManager.Instance.FindNearPlayerUnit(unitBase.transform.position, findRadius);
            }
            return null;
        }

        public void Reset()
        {
            enemyUnit = null;
        }
        public bool HasFoundEnemy()
        {
            UnitBase unit = FindNearEnemy();
            
            if (unit)
            {
                enemyUnit = unit;
                return true;
            }
            return false;
        }
    }
}
