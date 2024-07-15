using System;
using System.Collections.Generic;
using Content.Scripts.Managers;
using Content.Scripts.Unit;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerFind
    {
        public float FindRadius => findRadius;
        [SerializeField] private float findRadius;
        
        private Transform transform;
        
        public void Init(Transform transform, PlayerBar playerBar)
        {
            this.transform = transform;
            playerBar.ChangeCircleRange(findRadius);
        }
        
        public UnitBase FindNearEnemy()
        {
            return UnitManager.Instance.FindNearEnemy(transform.position, findRadius);
        }
        
        public UnitBase FindNearDeadBody()
        {
            return UnitManager.Instance.FindNearDeadBody(transform.position, findRadius);
        }
    }
}
