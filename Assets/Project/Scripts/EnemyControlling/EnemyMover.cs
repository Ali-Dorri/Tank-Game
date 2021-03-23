using UnityEngine;
using Adop.TankGame.TankControlling;

namespace Adop.TankGame.EnemyControlling
{
    public class EnemyMover : MonoBehaviour
    {
        private const int FindDirectionAttempts = 5;

        [SerializeField] private TankMover m_Mover;

        [Header("Moving")]
        [SerializeField] private float m_MinMoveDistance = 5f;
        [SerializeField] private float m_MaxMoveDistance = 10f;
        [SerializeField] private float m_ReachDistance = 1f;
        [SerializeField] private float m_MaxReachDuration = 6f;

        [Header("Waiting")]
        [SerializeField] private float m_MinStopWaitTime = 1;
        [SerializeField] private float m_MaxStopWaitTime = 5;
        [SerializeField] private float m_MinInitialMoveDelay = 0.1f;
        [SerializeField] private float m_MaxInitialMoveDelay = 2f;
        private bool m_IsMoving;
        private float m_StartWaitTime;
        private Vector3 m_MoveTarget;
        private float m_StopWaitTime;
        private Vector3 m_MoveDirection;

        private void Start()
        {
            m_IsMoving = false;
            StartWaiting(m_MinInitialMoveDelay, m_MaxInitialMoveDelay);
        }

        private void Update()
        {
            if (!m_IsMoving)
            {
                if(Time.time - m_StartWaitTime > m_StopWaitTime)
                {
                    MoveToNewDirection();
                }
            }
            else
            {
                Move();
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Color previousColor = Gizmos.color;
            Gizmos.color = Color.blue;
            Vector3 currentPoint = transform.position + Vector3.up;
            Gizmos.DrawLine(currentPoint, currentPoint + m_MoveDirection);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(currentPoint, m_MoveTarget + Vector3.up);
            Gizmos.color = previousColor;
        }
#endif

        private void Move()
        {
            Vector3 targetToTank = transform.position - m_MoveTarget;
            bool isPassedTarget = Vector3.Dot(m_MoveDirection, targetToTank) > 0;
            bool isReachedTarget = isPassedTarget || targetToTank.magnitude <= m_ReachDistance;

            if (isReachedTarget)
            {
                StopMoving();
            }
            else
            {
                if(Time.time - m_StartWaitTime > m_MaxReachDuration)
                {
                    StopMoving();
                }
                else
                {
                    Vector3 direction = m_MoveTarget - transform.position;
                    Vector2 topDownDirection = new Vector2(direction.x, direction.z);
                    m_Mover.Move(topDownDirection);
                }
            }
        }

        private void MoveToNewDirection()
        {
            for (int i = 0; i < FindDirectionAttempts; i++)
            {
                bool isDirectionFound = FindDirection(out m_MoveDirection);
                if (isDirectionFound)
                {
                    m_IsMoving = true;
                    m_MoveTarget = transform.position + m_MoveDirection;
                    m_StartWaitTime = Time.time;
                    break;
                }
            }
        }

        private bool FindDirection(out Vector3 direction)
        {
            //find direction
            Vector2 topDownDirection = Random.insideUnitCircle;
            float directionSize = topDownDirection.magnitude * (m_MaxMoveDistance - m_MinMoveDistance) + m_MinMoveDistance;
            topDownDirection = topDownDirection.normalized * directionSize;
            direction = new Vector3(topDownDirection.x, 0, topDownDirection.y);

            //check obstacle
            Ray moveRay = new Ray(transform.position, direction);
            bool isHittedObstacle = Physics.Raycast(moveRay, out RaycastHit hitInfo, direction.magnitude);
            if (isHittedObstacle)
            {
                float obstacleDistance = Vector3.Distance(transform.position, hitInfo.point);
                if(obstacleDistance < m_MinMoveDistance)
                {
                    //can not move to less than allowed distance
                    return false;
                }

                direction = direction.normalized * obstacleDistance;
            }

            return true;
        }

        private void StopMoving()
        {
            m_Mover.Move(Vector2.zero);
            m_IsMoving = false;
            StartWaiting(m_MinStopWaitTime, m_MaxStopWaitTime);
        }

        private void StartWaiting(float minWait, float maxWait)
        {
            m_StartWaitTime = Time.time;
            m_StopWaitTime = Random.Range(minWait, maxWait);
        }
    }
}
