using UnityEngine;
using Adop.Demos.Clicking;

namespace Adop.Demos.PhysicsDemos
{
    public class BallPusher2D : MonoBehaviour
    {
        [SerializeField] private Clicker2D m_Clicker;
        [SerializeField] private Rigidbody2D m_Ball;
        [SerializeField] private Vector2 m_Force = new Vector2(-5, 2.5f);
        Collider2D[] m_HittedCollders = new Collider2D[10];

        private void OnEnable()
        {
            m_Clicker.OnClick += PushBall;   
        }

        private void OnDisable()
        {
            m_Clicker.OnClick -= PushBall;
        }

        private void PushBall(Vector3 position)
        {
            int hitCount = Physics2D.OverlapCircleNonAlloc(position, 1, m_HittedCollders);
            bool isAnyBallHitted = false;
            for(int i = 0; i < hitCount; i++)
            {
                Rigidbody2D hittedBall = m_HittedCollders[i].GetComponent<Rigidbody2D>();
                if(hittedBall != null)
                {
                    isAnyBallHitted = true;
                    PushBall(hittedBall);
                }
            }

            if (!isAnyBallHitted)
            {
                Rigidbody2D ball = Instantiate(m_Ball, position, Quaternion.identity);
                PushBall(ball);
            }
        }

        private void PushBall(Rigidbody2D ball)
        {
            Vector2 force;
            int randomIndex = Random.Range(0, 2);
            if(randomIndex == 0)
            {
                force = m_Force;
            }
            else
            {
                force = new Vector2(-m_Force.x, m_Force.y);
            }

            ball.AddForce(force, ForceMode2D.Impulse);
        }
    }
}