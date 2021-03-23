using UnityEngine;
using UnityEngine.EventSystems;
using Adop.TankGame.TankShooting;

namespace Adop.TankGame.PlayerControlling
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private TankShooter m_Shooter;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                m_Shooter.Shoot();
            }
        }
    }
}
