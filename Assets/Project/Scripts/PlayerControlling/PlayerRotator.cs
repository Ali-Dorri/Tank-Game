using UnityEngine;
using ADOp.TankGame.TankControlling;

namespace ADOp.TankGame.PlayerControlling
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private TurretRotator m_TurretRotator;
        [Tooltip("How much degrees rotate when moving pointer about screen's width")]
        [SerializeField] private float m_RotateSensitivity = 180f;
        private float m_PointerX;

        private void Start()
        {
            m_PointerX = Input.mousePosition.x;
        }

        private void Update()
        {
            float pointerMove = Input.mousePosition.x - m_PointerX;
            m_PointerX = Input.mousePosition.x;
            float moveRatio = pointerMove / Screen.width;
            Debug.Log("Move ratio: " + moveRatio);
            float rotationAngle = moveRatio * m_RotateSensitivity;
            Debug.Log("Rotation angle: " + rotationAngle);
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);
            Vector3 turretDirection = m_TurretRotator.Turret.forward;
            Vector3 targetDirection = rotation * turretDirection;
            Vector2 topDownDirection = new Vector2(targetDirection.x, targetDirection.z);
            m_TurretRotator.RotateTo(topDownDirection);
        }
    }
}
