using Content.Scripts.PlayerScripts;
using Content.Scripts.UI;
using Content.Scripts.Utils;
using UnityEngine;
namespace Content.Scripts.Managers
{
    public class UiManager : SingletonBehaviour<UiManager>
    {
        public ArmyCounter ArmyCounter => armyCounter;
        
        [SerializeField] private ArmyCounter armyCounter;
        public void Init(Player player)
        {
            SetSingleton(this);
            armyCounter.Init(0,player.PlayerArmy.CountArmy);
        }
    }
}
