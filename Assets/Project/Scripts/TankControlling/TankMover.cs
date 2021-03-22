using UnityEngine;

namespace ADOp.TankGame.TankControlling
{
    public class TankMover : MonoBehaviour
    {
        [SerializeField] private float m_Acceleration = 2f;
        [SerializeField] private float m_MaxSpeed = 3f;
        [SerializeField] private Rigidbody m_Body;
        [SerializeField] private Transform m_TurretDirection;
        private Vector2 m_Direction;

        public Transform TurretDirection => m_TurretDirection;

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(m_Direction.x, 0, m_Direction.y);
            Vector3 newVelocity = m_Body.velocity + (m_Acceleration * direction) * Time.fixedDeltaTime;
            float speed = Mathf.Clamp(newVelocity.magnitude, 0, m_MaxSpeed);
            m_Body.velocity = newVelocity.normalized * speed;
        }

        public void Move(Vector2 topDownDirection)
        {
            m_Direction = topDownDirection.normalized;
        }
    }
}
