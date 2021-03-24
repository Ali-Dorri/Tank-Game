using UnityEngine;
using Adop.Demos.Clicking;

namespace Adop.Demos.PhysicsDemos
{
    public class BallShooter : MonoBehaviour
    {
        [SerializeField] private Clicker3DDirection m_Clicker;
        [SerializeField] private Rigidbody m_BallPrefab;
        [SerializeField] private float m_SpawnDistance = 3f;
        [SerializeField] private float m_Force = 10f;

        private void OnEnable()
        {
            m_Clicker.OnClick += ShootBall;
        }

        private void OnDisable()
        {
            m_Clicker.OnClick -= ShootBall;
        }

        private void ShootBall(Vector3 direction)
        {
            Vector3 spawnPosition = Camera.main.transform.position + direction * m_SpawnDistance;
            Rigidbody ball = Instantiate(m_BallPrefab, spawnPosition, Quaternion.identity);
            ball.AddForce(direction * m_Force, ForceMode.Impulse);
        }
    }
}
