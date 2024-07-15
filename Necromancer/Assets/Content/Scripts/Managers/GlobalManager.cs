using Content.Scripts.PlayerScripts;
using Content.Scripts.Pool;
using Content.Scripts.Utils;
using UnityEngine;
namespace Content.Scripts.Managers
{
    public class GlobalManager : SingletonBehaviour<GlobalManager>
    {
        public Player Player => player;
        [SerializeField] private PoolManager poolManager;
        [SerializeField] private Player player;
        [SerializeField] private UnitManager unitManager;
        [SerializeField] private UiManager uiManager;
        [SerializeField] private LevelManager levelManager;
        private void Awake()
        {
            SetSingleton(this);
            Application.targetFrameRate = 60;
            
            poolManager.Init();
            player.Init();
            levelManager.Init();
            unitManager.Init();
            uiManager.Init(player);
        }
    }
}
