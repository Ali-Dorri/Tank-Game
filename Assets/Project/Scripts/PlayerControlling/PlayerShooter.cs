using UnityEngine;
using ADOp.TankGame.TankShooting;

namespace ADOp.TankGame.PlayerControlling
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private TankShooter m_Shooter;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_Shooter.Shoot();
            }
        }
    }
}