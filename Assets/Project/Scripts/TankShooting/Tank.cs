using System;
using UnityEngine;
using Adop.TankGame.Utility;

namespace Adop.TankGame.TankShooting
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] private int m_Health = 100;
        [SerializeField] private AutoDestroyParticle m_Explosion;
        [SerializeField] private AudioSource m_SoundPlayer;
        [SerializeField] private AudioClip m_DamageSound;
        [SerializeField] private AudioClip m_ExplosionSound;
        private int m_MaxHealth;

        /// <summary>
        /// Raised when tank get damage. Parameters: health ratio
        /// </summary>
        public event Action<float> OnGetDamage;

        private void Awake()
        {
            m_MaxHealth = m_Health;
        }

        public void GetDamage(int damage)
        {
            if (m_Health > 0)
            {
                m_Health -= damage;
                if (m_Health <= 0)
                {
                    m_Health = 0;
                }

                float healthRatio = m_Health / (float)m_MaxHealth;
                OnGetDamage?.Invoke(healthRatio);

                if(m_Health == 0)
                {
                    m_Explosion.transform.SetParent(null, true);
                    m_Explosion.gameObject.SetActive(true);
                    m_Explosion.Play(true);
                    gameObject.SetActive(false);
                    AudioSource.PlayClipAtPoint(m_ExplosionSound, transform.position);
                }
                else
                {
                    m_SoundPlayer.PlayOneShot(m_DamageSound);
                }
            }
        }
    }
}
