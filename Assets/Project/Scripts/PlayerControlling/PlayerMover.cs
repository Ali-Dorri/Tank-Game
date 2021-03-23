using UnityEngine;
using Adop.TankGame.TankControlling;

namespace Adop.TankGame.PlayerControlling
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private TankMover m_TankMover;

        private void Update()
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 turretDirection = m_TankMover.TurretDirection.forward;
            Vector3 forward = turretDirection * verticalInput;
            Vector3 horizontal = GetHorizontalDirection(turretDirection, horizontalInput);
            Vector3 move3D = forward + horizontal;
            Vector2 moveTopDown = new Vector2(move3D.x, move3D.z);
            m_TankMover.Move(moveTopDown);
        }

        private Vector3 GetHorizontalDirection(Vector3 direction, float horizontalInput)
        {
            Quaternion rotation = Quaternion.AngleAxis(90, Vector3.up);
            Vector3 horizontalDirection = rotation * direction;
            return horizontalDirection * horizontalInput;
        }
    }
}
