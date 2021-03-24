using UnityEngine;
using Adop.Demos.Clicking;
using Adop.TankGame.Utility;

namespace Adop.Demos.PhysicsDemos
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private Clicker3DRaycast m_Clicker;
        [SerializeField] private float m_Force = 10;
        [SerializeField] private float m_Radius = 2f;
        [SerializeField] private float m_UpwardModifier = 1f;
        [SerializeField] private AutoDestroyParticle m_ExplosionPrefab;
        private Collider[] m_AffectedColliders = new Collider[10];

        private void OnEnable()
        {
            m_Clicker.OnClick += Explode;
        }

        private void OnDisable()
        {
            m_Clicker.OnClick -= Explode;
        }

        private void Explode(RaycastHit hit)
        {
            PlayExplosion(hit.point);
            int collidersCount = Physics.OverlapSphereNonAlloc(hit.point, m_Radius, m_AffectedColliders);
            for(int i = 0; i < collidersCount; i++)
            {
                Rigidbody cube = m_AffectedColliders[i].GetComponent<Rigidbody>();
                if(cube != null)
                {
                    cube.AddExplosionForce(m_Force, hit.point, m_Radius, m_UpwardModifier, ForceMode.Impulse);
                }
            }
        }

        private void PlayExplosion(Vector3 position)
        {
            AutoDestroyParticle particle = Instantiate(m_ExplosionPrefab, position, Quaternion.identity);
            particle.Play(true);
        }
    }
}
