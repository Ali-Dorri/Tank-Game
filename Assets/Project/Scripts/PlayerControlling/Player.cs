using UnityEngine;
using ADOp.TankGame.TankShooting;

namespace ADOp.TankGame.PlayerControlling
{
    public class Player : MonoBehaviour
    {
        private static Player m_Instance;

        [SerializeField] private Tank m_Tank;
        [SerializeField] private Camera m_Camera;

        public static Player Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = FindObjectOfType<Player>();
                }

                return m_Instance;
            }
        }

        public Camera Camera => m_Camera;

        private void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this;
            }
            else if (m_Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            m_Tank.OnGetDamage += CheckDeath;
        }

        private void OnDisable()
        {
            m_Tank.OnGetDamage -= CheckDeath;
        }

        private void CheckDeath(float healthRatio)
        {
            if(healthRatio <= 0)
            {
                DetachCamera();
            }
        }

        private void DetachCamera()
        {
            m_Camera.transform.SetParent(null, true);
        }
    }
}
