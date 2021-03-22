using UnityEngine;

namespace ADOp.TankGame.TankShooting
{
    public class TankShooter : MonoBehaviour
    {
        [SerializeField] private Bullet m_BulletPrefab;
        [SerializeField] private Transform m_TurretDirection;
        [SerializeField] private Transform m_ShootPosition;
        [Tooltip("Number of fires per second")]
        [SerializeField] private float m_FireRate = 2;
        private float m_FireTime;

        public void Shoot()
        {
            float fireDelay = 1 / m_FireRate;
            if(Time.time - m_FireTime > fireDelay)
            {
                m_FireTime = Time.time;
                Quaternion rotation = Quaternion.LookRotation(m_TurretDirection.forward, Vector3.up);
                Bullet bullet = Instantiate(m_BulletPrefab, m_ShootPosition.position, rotation);
                bullet.Shoot(m_TurretDirection.forward);
            }
        }
    }
}
