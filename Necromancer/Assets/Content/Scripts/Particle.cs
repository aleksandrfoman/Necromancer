using UnityEngine;

namespace Content.Scripts
{
    public class Particle : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem[] particleSystems;
    
        public void Activate()
        {
            for (int i = 0; i < particleSystems.Length; i++)
            {
                particleSystems[i].gameObject.SetActive(true);
                particleSystems[i].Clear();
                particleSystems[i].Play();
            }
        }

        public void Deactivate()
        {
            for (int i = 0; i < particleSystems.Length; i++)
            {
                particleSystems[i].Stop(true);
                particleSystems[i].Clear();
                particleSystems[i].gameObject.SetActive(false);
            }
        }
    }
}
