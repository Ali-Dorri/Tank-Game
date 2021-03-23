using UnityEngine;
using Adop.TankGame.TankShooting;

namespace Adop.TankGame.EnemyControlling
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Tank m_Tank;

        private void OnEnable()
        {
            m_Tank.OnGetDamage += CheckDeath;
        }

        private void OnDisable()
        {
            m_Tank.OnGetDamage -= CheckDeath;
        }

        private void Start()
        {
            GameManager.Instance.IncreaseEnemyCount();
        }

        private void CheckDeath(float healthRatio)
        {
            if(healthRatio == 0)
            {
                GameManager.Instance.DecreaseEnemyCount();
            }
        }
    }
}
