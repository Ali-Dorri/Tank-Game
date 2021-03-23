using System.Collections;
using UnityEngine;
using Adop.TankGame.Utility;

namespace Adop.TankGame.TankShooting
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float m_LifeTime = 3f;
        [SerializeField] private float m_Speed = 10f;
        [SerializeField] private int m_Damage = 10;
        [SerializeField] private AutoDestroyParticle m_HitTankParticle;
        [SerializeField] private AutoDestroyParticle m_HitObstacleParticle;
        [SerializeField] private VolumedAudioClip m_HitSound = new VolumedAudioClip(null, 1);
        private Rigidbody m_Body;

        private void Awake()
        {
            m_Body = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Tank tank = collision.gameObject.GetComponent<Tank>();
            if(tank != null)
            {
                tank.GetDamage(m_Damage);
                DestroyBullet(m_HitTankParticle);
            }
            else
            {
                DestroyBullet(m_HitObstacleParticle, m_HitSound);
            }
        }

        public void Shoot(Vector3 direction)
        {
            m_Body.velocity = direction.normalized * m_Speed;
            StartCoroutine(DestroyAfterLifeTime());
        }

        private IEnumerator DestroyAfterLifeTime()
        {
            yield return new WaitForSeconds(m_LifeTime);
            DestroyBullet(null);
        }

        private void DestroyBullet(AutoDestroyParticle explosion, VolumedAudioClip hitSound)
        {
            AudioSource.PlayClipAtPoint(hitSound.m_Audio, transform.position, hitSound.m_Volume);
            DestroyBullet(explosion);
        }

        private void DestroyBullet(AutoDestroyParticle explosion)
        {
            if (explosion != null)
            {
                PlayExplosion(explosion);
            }
            Destroy(gameObject);
        }

        private void PlayExplosion(AutoDestroyParticle particle)
        {
            particle.transform.SetParent(null, true);
            particle.gameObject.SetActive(true);
            particle.Play(true);
        }
    }
}
