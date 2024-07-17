using System;
using UnityEngine;

namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitSkin
    {
        [SerializeField] private Material materialPlayer;
        [SerializeField] private Material materialEnemy;
        [SerializeField] private Renderer[] renderers;
        private Material curMat;
        public void UpdateSkin(EUnitType unitType)
        {
            if (unitType == EUnitType.Enemy)
            {
                curMat = materialEnemy;
            }
            else
            {
                curMat = materialPlayer;
            }
            
            for (int i = 0; i < renderers.Length; i++)
            {
                var mats = renderers[i].materials;
                for (int j = 0; j < mats.Length; j++)
                {
                    mats[j] = curMat;
                }
                renderers[i].materials = mats;
            }
  
        }
    }
}
