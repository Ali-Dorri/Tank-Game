using UnityEngine;
using ADOp.TankGame.TankControlling;
using ADOp.TankGame.TankShooting;
using ADOp.TankGame.PlayerControlling;

namespace ADOp.TankGame.EnemyControlling
{
    public class EnemyShooter : MonoBehaviour
    {
        private const float DirectionAngleTreshold = 0.1f;

        [SerializeField] private TurretRotator m_TurretRotator;
        [SerializeField] private TankShooter m_TankShooter;
        [SerializeField] private float m_MinDelay = 1f;
        [SerializeField] private float m_MaxDelay = 5f;
        private float m_FireTime;
        private float m_Delay;
        private bool m_IsWaiting;

        private void Start()
        {
            StartWaiting();
        }

        private void Update()
        {
            if (m_IsWaiting)
            {
                if (Time.time - m_FireTime > m_Delay)
                {
                    m_IsWaiting = false;
                }
            }
            else
            {
                RotateToPlayer();
            }
        }

        private void StartWaiting()
        {
            m_IsWaiting = true;
            m_FireTime = Time.time;
            m_Delay = Random.Range(m_MinDelay, m_MaxDelay);
        }

        private void RotateToPlayer()
        {
            Vector3 toPlayerDirection = Player.Instance.transform.position - transform.position;
            float toPlayerAngle = Vector3.Angle(toPlayerDirection, m_TurretRotator.Turret.forward);
            if(toPlayerAngle > DirectionAngleTreshold)
            {
                Vector2 topDownDirection = new Vector2(toPlayerDirection.x, toPlayerDirection.z);
                m_TurretRotator.RotateTo(topDownDirection);
            }
            else
            {
                m_TankShooter.Shoot();
                StartWaiting();
            }
        }
    }
}
