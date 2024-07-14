using System;
using System.Collections.Generic;
using Content.Scripts.Unit;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerFind
    {
        private List<UnitBase> enemiesList;
        
        public UnitBase FindNearEnemy()
        {
            //enemiesList = LevelManager.Instance.EnemiesList;
            UnitBase unitBase = null;

            return unitBase;
        }
    }
}
