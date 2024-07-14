using UnityEngine;

namespace Content.Scripts.Utils
{
    public class SingletonBehaviour<T> : MonoBehaviour
    {
        private static T _instance;
        public static T Instance => _instance;

        protected void SetSingleton(T obj)
        { 
            _instance = obj;
        }
    }
}
