using UnityEngine;

namespace Adop.TankGame.Utility
{
    [System.Serializable]
    public struct VolumedAudioClip
    {
        public AudioClip m_Audio;
        [Range(0f, 1f)]
        public float m_Volume;

        public VolumedAudioClip(AudioClip audio, float volume)
        {
            m_Audio = audio;
            m_Volume = volume;
        }
    }
}
