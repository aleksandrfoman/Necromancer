using Content.Scripts.Utils;
using UnityEngine;

namespace Content.Scripts.Pool
{
    public class PoolManager : SingletonBehaviour<PoolManager>
    {
        [SerializeField] private Particle spawnParticleEffect;
        public PoolMono<Particle> PoolSpawnEffect { get; private set; }
        
        public void Init()
        {
            SetSingleton(this);
            PoolSpawnEffect = new PoolMono<Particle>(spawnParticleEffect, 1);
        }
    }
}
