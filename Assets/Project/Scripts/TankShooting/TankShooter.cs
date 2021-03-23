using UnityEngine;
using Adop.TankGame.Utility;

namespace Adop.TankGame.TankShooting
{
    public class TankShooter : MonoBehaviour
    {
        [Tooltip("Number of fires per second")]
        [SerializeField] private float m_FireRate = 2;
        [SerializeField] private Bullet m_BulletPrefab;
        [SerializeField] private Transform m_TurretDirection;
        [SerializeField] private Transform m_ShootPosition;
        [SerializeField] private AutoDestroyParticle m_FireParticlePrefab;
        private float m_FireTime;

        public void Shoot()
        {
            float fireDelay = 1 / m_FireRate;
            if(Time.time - m_FireTime > fireDelay)
            {
                m_FireTime = Time.time;
                Fire();
            }
        }

        private void Fire()
        {
            Quaternion rotation = Quaternion.LookRotation(m_TurretDirection.forward, Vector3.up);
            Bullet bullet = Instantiate(m_BulletPrefab, m_ShootPosition.position, rotation);
            bullet.Shoot(m_TurretDirection.forward);

            AutoDestroyParticle particle = Instantiate(m_FireParticlePrefab, m_ShootPosition.position, Quaternion.identity);
            particle.Play(true);
        }
    }
}
