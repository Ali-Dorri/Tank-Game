using UnityEngine;
using UnityEngine.UI;

namespace Adop.Demos
{
    public class SoundPlayerButton : MonoBehaviour
    {
        private const string PlaySoundName = "PLAY SOUND";
        private const string PlayShotName = "PLAY SHOT";
        private const string PlayMusicName = "PLAY MUSIC";
        private const string PauseMusicName = "PAUSE MUSIC";
        private const string StopName = "STOP SOUND";

        [SerializeField] private Button m_Button;
        [SerializeField] private Text m_ButtonName;
        [SerializeField] private AudioSource m_SoundPlayer;
        [SerializeField] private AudioClip m_Sound;
        [SerializeField] private bool m_PlayOneShot = true;
        [SerializeField] private bool m_PauseWhenPlaying = false;

        private void OnEnable()
        {
            m_Button.onClick.AddListener(PlaySound);
        }

        private void OnDisable()
        {
            m_Button.onClick.RemoveListener(PlaySound);
        }

        private void Awake()
        {
            m_SoundPlayer.clip = m_Sound;
            SetName();
        }

        private void PlaySound()
        {
            if (m_PlayOneShot)
            {
                m_SoundPlayer.PlayOneShot(m_Sound);
            }
            else
            {
                if (m_SoundPlayer.isPlaying)
                {
                    if (m_PauseWhenPlaying)
                    {
                        m_SoundPlayer.Pause();
                    }
                    else
                    {
                        m_SoundPlayer.Stop();
                    }
                }
                else
                {
                    m_SoundPlayer.Play();
                }
            }

            SetName();
        }

        private void SetName()
        {
            if (m_PlayOneShot)
            {
                m_ButtonName.text = PlayShotName;
            }
            else
            {
                if (m_SoundPlayer.isPlaying)
                {
                    if (m_PauseWhenPlaying)
                    {
                        m_ButtonName.text = PauseMusicName;
                    }
                    else
                    {
                        m_ButtonName.text = StopName;
                    }
                }
                else
                {
                    if (m_PauseWhenPlaying)
                    {
                        m_ButtonName.text = PlayMusicName;
                    }
                    else
                    {
                        m_ButtonName.text = PlaySoundName;
                    }
                }
            }
        }
    }
}
