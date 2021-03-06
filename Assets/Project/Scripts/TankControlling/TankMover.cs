using UnityEngine;
using Adop.TankGame.Utility;

namespace Adop.TankGame.TankControlling
{
    public class TankMover : MonoBehaviour
    {
        [SerializeField] private Transform m_TurretDirection;

        [Header("Body Motion")]
        [SerializeField] private float m_Acceleration = 2f;
        [SerializeField] private float m_MaxSpeed = 3f;
        [SerializeField] private Rigidbody m_Body;
        private Vector2 m_Direction;

        [Header("Body Rotation")]
        [Tooltip("Speed of rotating body")]
        [SerializeField] private float m_RotationSpeed = 100;
        [Tooltip("Maximum angle between move direction and body direction which tank can start moving.")]
        [SerializeField] private float m_MoveTresholdAngle = 30f;
        [Tooltip("Maximum angle between move direction and body direction which tank stop rotation when reach it.")]
        [SerializeField] private float m_RotationReachAngle = 5f;

        public Transform TurretDirection => m_TurretDirection;

        private void FixedUpdate()
        {
            if (m_Direction != Vector2.zero)
            {
                RotateBody();
                MoveBody();
            }
        }

        public void Move(Vector2 topDownDirection)
        {
            m_Direction = topDownDirection.normalized;
        }

        private void MoveBody()
        {
            Vector3 direction = new Vector3(m_Direction.x, 0, m_Direction.y);
            float moveAngle = Vector3.Angle(direction, m_Body.transform.forward);

            if(moveAngle <= m_MoveTresholdAngle)
            {
                Vector3 newVelocity = m_Body.velocity + (m_Acceleration * direction) * Time.fixedDeltaTime;
                float speed = Mathf.Clamp(newVelocity.magnitude, 0, m_MaxSpeed);
                m_Body.velocity = newVelocity.normalized * speed;
            }
        }

        private void RotateBody()
        {
            Vector3 targetDirection = new Vector3(m_Direction.x, 0, m_Direction.y);
            float maxRotationAngle = Vector3.Angle(m_Body.transform.forward, targetDirection);

            if (maxRotationAngle > m_RotationReachAngle)
            {
                Quaternion rotation = RotationUtility.Rotate(m_Body.transform.forward, targetDirection, Vector3.up
                , m_RotationSpeed * Time.fixedDeltaTime);
                Quaternion newRotation = m_Body.rotation * rotation;
                m_Body.MoveRotation(newRotation);
            }
        }
    }
}
