using UnityEngine;
using UnityEngine.UI;
using Adop.TankGame.Utility;

namespace Adop.TankGame.UI
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform m_Panel;
        [SerializeField] private Text m_Title;
        [SerializeField] private string m_WinTitle = "YOU WON!";
        [SerializeField] private string m_LoseTitle = "YOU LOST!";
        [SerializeField] private Button m_RestartButton;
        [SerializeField] private Button m_NextButton;

        private void OnEnable()
        {
            m_RestartButton.onClick.AddListener(LevelManager.RestartLevel);
            m_NextButton.onClick.AddListener(LevelManager.GotoNextLevel);

            GameManager.Instance.OnWin += ShowWinPanel;
            GameManager.Instance.OnLose += ShowLosePanel;
        }

        private void OnDisable()
        {
            m_RestartButton.onClick.RemoveListener(LevelManager.RestartLevel);
            m_NextButton.onClick.RemoveListener(LevelManager.GotoNextLevel);

            if (GameManager.IsAlive)
            {
                GameManager.Instance.OnWin -= ShowWinPanel;
                GameManager.Instance.OnLose -= ShowLosePanel;
            }
        }

        private void ShowWinPanel()
        {
            m_Panel.gameObject.SetActive(true);
            m_Title.text = m_WinTitle;
        }

        private void ShowLosePanel()
        {
            m_Panel.gameObject.SetActive(true);
            m_Title.text = m_LoseTitle;
            m_NextButton.gameObject.SetActive(false);
        }
    }
}
