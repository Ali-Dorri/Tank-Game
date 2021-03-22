using UnityEngine;
using ADOp.TankGame.TankControlling;

namespace ADOp.TankGame.PlayerControlling
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private TurretRotator m_TurretRotator;
        [Tooltip("Ratio of poiter motion effect on rotation")]
        [SerializeField] private float m_RotateSensitivity = 180f;
        Vector3 m_CurrentDirection;

        private void Start()
        {
            m_CurrentDirection = m_TurretRotator.Turret.forward;
        }

        private void Update()
        {
            float pointerMove = Input.GetAxis("Mouse X");
            float rotationAngle = pointerMove * m_RotateSensitivity;
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);
            m_CurrentDirection = rotation * m_CurrentDirection;
            Vector2 topDownDirection = new Vector2(m_CurrentDirection.x, m_CurrentDirection.z);
            m_TurretRotator.RotateTo(topDownDirection);
        }
    }
}
