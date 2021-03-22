using UnityEngine;

namespace ADOp.TankGame.TankControlling
{
    public class TurretRotator : MonoBehaviour
    {
        [SerializeField] private float m_RotationSpeed = 100f;
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
            Vector3 forward = new Vector3(m_TargetDirection.x, 0, m_TargetDirection.y);

            if (m_InstantRotate)
            {
                m_Turret.rotation = Quaternion.LookRotation(forward, Vector3.up);
            }
            else
            {
                Quaternion rotation = RotationUtility.Rotate(m_Turret.forward, forward, Vector3.up, m_RotationSpeed * Time.deltaTime);
                m_Turret.rotation *= rotation;
            }
        }

        public void RotateTo(Vector2 direction)
        {
            m_TargetDirection = direction;
        }
    }
}
