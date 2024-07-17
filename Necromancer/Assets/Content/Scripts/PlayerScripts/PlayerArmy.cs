using System;
using Content.Scripts.Managers;
using Content.Scripts.Unit;
using UnityEngine;
namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerArmy
    {
        public int CountArmy => countArmy;
        [SerializeField] private int countArmy;
        private int curArmy;
        private PlayerFind playerFind;
   
        public void Init(PlayerFind playerFind)
        {
            this.playerFind = playerFind;
        }

        public void TryCaptureUnit()
        {
            if (curArmy < CountArmy)
            {
                UnitBase unitBase = playerFind.FindNearDeadBody();
                if (unitBase != null)
                {
                    curArmy++;
                    UpdateArmyInfo();
                    unitBase.CaptureUnit();
                }
            }
        }

        public void RemoveArmyUnit()
        {
            curArmy--;
        }

        public void UpdateArmyInfo()
        {
            UiManager.Instance.ArmyCounter.UpdateInfo(curArmy,countArmy);
        }
    }
}
