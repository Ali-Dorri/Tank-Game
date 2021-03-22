using UnityEngine;

namespace ADOp.TankGame.TankControlling
{
    public class TurretRotator : MonoBehaviour
    {
        [SerializeField] private float m_RotateSpeed = 100f;
        [SerializeField] private bool m_InstantRotate = false;
        [SerializeField] private Transform m_Turret;
        private Vector2 m_TargetDirection;

        public Transform Turret => m_Turret;

        private void Start()
        {
            m_TargetDirection = m_Turret.forward;
        }

        private void Update()
        {
            if (!m_InstantRotate)
            {
                Vector3 targetDirection = new Vector3(m_TargetDirection.x, 0, m_TargetDirection.y);
                float targetRotationAngle = Vector3.SignedAngle(m_Turret.forward, targetDirection, Vector3.up);
                float maxRotation = m_RotateSpeed * Time.deltaTime;
                float rotationSize = Mathf.Min(maxRotation, Mathf.Abs(targetRotationAngle));
                float rotationAngle = Mathf.Sign(targetRotationAngle) * rotationSize;
                Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);
                m_Turret.forward = rotation * m_Turret.forward;
            }
        }

        public void RotateTo(Vector2 direction)
        {
            m_TargetDirection = direction;

            if (m_InstantRotate)
            {
                Vector3 forward = new Vector3(direction.x, 0, direction.y);
                m_Turret.rotation = Quaternion.LookRotation(forward, Vector3.up);
            }
        }
    }
}
