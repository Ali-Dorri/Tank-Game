using System;
using UnityEngine;

namespace Adop.TankGame
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_Instance;

        private int m_EnemyCount;
        private bool m_HasLost = false;
        private bool m_HasWon = false;

        public event Action OnWin;
        public event Action OnLose;

        public static GameManager Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = FindObjectOfType<GameManager>();
                }

                return m_Instance;
            }
        }

        public static bool IsAlive => m_Instance != null;

        private void Awake()
        {
            if(m_Instance == null)
            {
                m_Instance = this;
            }
            else if(m_Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void IncreaseEnemyCount()
        {
            m_EnemyCount++;
        }

        public void DecreaseEnemyCount()
        {
            m_EnemyCount--;
            if(m_EnemyCount == 0 && !m_HasWon)
            {
                m_HasWon = true;
                OnWin?.Invoke();
            }
        }

        public void MarkPlayerDeath()
        {
            if (!m_HasLost)
            {
                m_HasLost = true;
                OnLose?.Invoke();
            }
        }
    }
}
