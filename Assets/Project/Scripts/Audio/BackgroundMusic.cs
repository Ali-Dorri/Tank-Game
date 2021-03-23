using UnityEngine;

namespace Adop.TankGame.Audio
{
    public class BackgroundMusic : MonoBehaviour
    {
        private static BackgroundMusic m_Instance;

        private void Awake()
        {
            if(m_Instance == null)
            {
                m_Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
