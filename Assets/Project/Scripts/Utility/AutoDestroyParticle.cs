using System.Collections;
using UnityEngine;

namespace Adop.TankGame.Utility
{
    public class AutoDestroyParticle: MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_Particle;

        public void Play(bool withChildren)
        {
            m_Particle.Play(withChildren);
            StartCoroutine(DestroyOnEnd(withChildren));
        }

        private IEnumerator DestroyOnEnd(bool withChildren)
        {
            yield return new WaitWhile(() => m_Particle.IsAlive(withChildren));
            Destroy(gameObject);
        }
    }
}
