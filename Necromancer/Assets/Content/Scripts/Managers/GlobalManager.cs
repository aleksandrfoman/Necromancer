using Content.Scripts.PlayerScripts;
using Content.Scripts.Utils;
using UnityEngine;
namespace Content.Scripts.Managers
{
    public class GlobalManager : SingletonBehaviour<GlobalManager>
    {
        public Player Player => player;
        [SerializeField] private Player player;
        [SerializeField] private UnitManager unitManager;
        [SerializeField] private LevelManager levelManager;
        private void Awake()
        {
            SetSingleton(this);
            player.Init();
            levelManager.Init();
            unitManager.Init();
        }
    }
}
