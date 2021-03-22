using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADOp.TankGame.TankShooting
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float m_LifeTime = 3f;
        [SerializeField] private float m_Speed = 10f;
        [SerializeField] private int m_Damage = 10;
        private Rigidbody m_Body;

        private void Awake()
        {
            m_Body = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void Shoot(Vector3 direction)
        {
            m_Body.velocity = direction.normalized * m_Speed;
            Destroy(gameObject, m_LifeTime);
        }
    }
}
