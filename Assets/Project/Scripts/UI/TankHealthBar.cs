using UnityEngine;
using UnityEngine.UI;
using ADOp.TankGame.TankShooting;

namespace ADOp.TankGame.UI
{
    public class TankHealthBar : MonoBehaviour
    {
        [SerializeField] private Tank m_Tank;
        [SerializeField] private Slider m_HealthBar;
        [SerializeField] private Image m_HealthFill;
        [SerializeField] private Color m_FullHealthColor = Color.green;
        [SerializeField] private Color m_LowHealthColor = Color.red;
        [SerializeField] private float m_MinColorHealthRatio = 0.3f;

        private void OnEnable()
        {
            m_Tank.OnGetDamage += UpdateHealthBar;
        }

        private void OnDisable()
        {
            m_Tank.OnGetDamage -= UpdateHealthBar;
        }

        private void UpdateHealthBar(float healthRatio)
        {
            m_HealthBar.value = healthRatio;

            float colorRatio = healthRatio - m_MinColorHealthRatio;
            if(colorRatio < 0)
            {
                colorRatio = 0;
            }
            m_HealthFill.color = Color.Lerp(m_LowHealthColor, m_FullHealthColor, colorRatio);
        }
    }
}
