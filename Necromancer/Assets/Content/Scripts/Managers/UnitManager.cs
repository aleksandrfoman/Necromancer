using System.Collections.Generic;
using Content.Scripts.Unit;
using Content.Scripts.Utils;
using UnityEngine;
namespace Content.Scripts.Managers
{
    public class UnitManager :  SingletonBehaviour<UnitManager>
    {
        [SerializeField] private List<UnitBase> deadBodyList = new List<UnitBase>();
        [SerializeField] private List<UnitBase> enemiesList = new List<UnitBase>();
        
        public void Init()
        {
            SetSingleton(this);
        }


        public UnitBase FindNearEnemy(Vector3 pos, float findRadius)
        {
            if (enemiesList.Count < 0)
            {
                return null;
            }
            
            float tempDist = findRadius;
            UnitBase enemyBase = null;

            if (enemiesList.Count > 0)
            {
                for (int i = 0; i < enemiesList.Count; i++)
                {
                    UnitBase curEnemyBase = enemiesList[i];
                    if (curEnemyBase != null)
                    {
                        float dist = Vector3.Distance(transform.position, curEnemyBase.transform.position);
                        if (dist < tempDist)
                        {
                            tempDist = dist;
                            enemyBase = curEnemyBase;
                        }
                    }
                }
            }
            return enemyBase;
        }

        
        public UnitBase FindNearDeadBody(Vector3 pos, float findRadius)
        {
            if (deadBodyList.Count < 0)
            {
                return null;
            }
            
            float tempDist = findRadius;
            UnitBase enemyBase = null;

            if (deadBodyList.Count > 0)
            {
                for (int i = 0; i < deadBodyList.Count; i++)
                {
                    UnitBase curEnemyBase = deadBodyList[i];
                    if (curEnemyBase != null)
                    {
                        float dist = Vector3.Distance(transform.position, curEnemyBase.transform.position);
                        if (dist < tempDist)
                        {
                            tempDist = dist;
                            enemyBase = curEnemyBase;
                        }
                    }
                }
            }
            return enemyBase;
        }
        public void AddEnemy(UnitBase enemyBase)
        {
            enemiesList.Add(enemyBase);
        }

        public void RemoveEnemy(UnitBase enemyBase)
        {
            enemiesList.Remove(enemyBase);
        }
        
        public void AddDeadBody(UnitBase enemyBase)
        {
            enemiesList.Add(enemyBase);
        }

        public void RemoveDeadBody(UnitBase enemyBase)
        {
            enemiesList.Remove(enemyBase);
        }
    }
}
