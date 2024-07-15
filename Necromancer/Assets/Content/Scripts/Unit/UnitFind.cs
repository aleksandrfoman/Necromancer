using System;
using Content.Scripts.Managers;
using UnityEngine;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitFind
    {
        [SerializeField] private float findRadius;
        
        private UnitBase enemyUnit;
        private UnitBase unitBase;
        private Transform transform;
        
        public void Init(UnitBase unitBase)
        {
            
        }
        
        public UnitBase FindNearEnemy()
        {
            if (unitBase.UnitType == EUnitType.PlayerUnit)
            {
                return UnitManager.Instance.FindNearEnemy(unitBase.transform.position, findRadius);
            }
            
            if(unitBase.UnitType == EUnitType.Enemy)
            {
                return UnitManager.Instance.FindNearEnemy(unitBase.transform.position, findRadius);
            }
            
            return null;
        }
    }
}
