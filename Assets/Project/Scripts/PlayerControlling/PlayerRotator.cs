using UnityEngine;
using ADOp.TankGame.TankControlling;

namespace ADOp.TankGame.PlayerControlling
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private TurretRotator m_TurretRotator;
        [Tooltip("Ratio of poiter motion effect on rotation")]
        [SerializeField] private float m_RotateSensitivity = 180f;

        private void Update()
        {
            float pointerMove = Input.GetAxis("Mouse X");
            float rotationAngle = pointerMove * m_RotateSensitivity;
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);
            Vector3 turretDirection = m_TurretRotator.Turret.forward;
            Vector3 targetDirection = rotation * turretDirection;
            Vector2 topDownDirection = new Vector2(targetDirection.x, targetDirection.z);
            m_TurretRotator.RotateTo(topDownDirection);
        }
    }
}
