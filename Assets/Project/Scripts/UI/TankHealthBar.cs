using UnityEngine;
using UnityEngine.UI;
using ADOp.TankGame.TankShooting;
using ADOp.TankGame.PlayerControlling;

namespace ADOp.TankGame.UI
{
    public class TankHealthBar : MonoBehaviour
    {
        [SerializeField] private Tank m_Tank;
        [SerializeField] private Slider m_HealthBar;
        [SerializeField] private Image m_HealthFill;
        [SerializeField] private Color m_FullHealthColor = Color.green;
        [SerializeField] private Color m_MediumHealthColor = Color.yellow;
        [SerializeField] private Color m_LowHealthColor = Color.red;
        [SerializeField] private float m_MediumHealthRatio = 0.6f;
        [SerializeField] private float m_LowHealthRatio = 0.3f;

        private void OnEnable()
        {
            m_Tank.OnGetDamage += UpdateHealthBar;
        }

        private void OnDisable()
        {
            m_Tank.OnGetDamage -= UpdateHealthBar;
        }

        private void Update()
        {
            LookCamera();
        }

        private void LookCamera()
        {
            Vector3 forward = Player.Instance.Camera.transform.position - transform.position;
            forward.y = 0;
            Quaternion rotation = Quaternion.LookRotation(forward, Vector3.up);
            transform.rotation = rotation;
        }

        private void UpdateHealthBar(float healthRatio)
        {
            m_HealthBar.value = healthRatio;

            if(healthRatio <= m_LowHealthRatio)
            {
                m_HealthFill.color = m_LowHealthColor;
            }
            else if(healthRatio <= m_MediumHealthRatio)
            {
                m_HealthFill.color = m_MediumHealthColor;
            }
            else
            {
                m_HealthFill.color = m_FullHealthColor;
            }
        }
    }
}
