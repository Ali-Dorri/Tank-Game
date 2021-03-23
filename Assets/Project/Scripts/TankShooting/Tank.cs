using System;
using UnityEngine;

namespace ADOp.TankGame.TankShooting
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] private int m_Health = 100;
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
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
