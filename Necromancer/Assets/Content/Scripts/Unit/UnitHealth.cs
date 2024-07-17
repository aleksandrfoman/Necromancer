using System;
using UnityEngine;

namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitHealth 
    {
        public event Action OnDead;
        
        [SerializeField] private float maxHealth;
        [SerializeField] private MeshFlash meshFlash;
        private float health;
        
        public void Init()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            meshFlash.Blink();
            if (health <= 0f)
            {
                OnDead?.Invoke();
            }
        }

        public void Reset()
        {
            health = maxHealth;
        }
    }
}
