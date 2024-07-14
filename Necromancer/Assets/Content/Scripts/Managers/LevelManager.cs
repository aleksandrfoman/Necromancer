using Content.Scripts.Utils;

namespace Content.Scripts.Managers
{
    public class LevelManager : SingletonBehaviour<LevelManager>
    { 
        public void Init()
        {
            SetSingleton(this);
        }
    }
}
