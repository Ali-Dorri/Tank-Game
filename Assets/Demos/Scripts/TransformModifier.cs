using UnityEngine;

namespace Adop.Demos
{
    public class TransformModifier : MonoBehaviour
    {
        [SerializeField] private KeyCode m_RotateKey = KeyCode.Mouse0;
        [SerializeField] private KeyCode m_ScaleKey = KeyCode.Mouse1;
        [SerializeField] private float m_MoveSpeed = 3f;
        [SerializeField] private float m_RotateSpeed = 30f;
        [SerializeField] private float m_ScaleSpeed = 0.2f;

        private void Update()
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            if (Input.GetKey(m_RotateKey))
            {
                Rotate(xInput, yInput);
            }
            else if (Input.GetKey(m_ScaleKey))
            {
                Scale(xInput, yInput);
            }
            else
            {
                Move(xInput, yInput);
            }
        }

        private void Move(float xInput, float yInput)
        {
            transform.Translate(new Vector3(xInput, 0, yInput) * m_MoveSpeed * Time.deltaTime);
        }

        private void Rotate(float xInput, float yInput)
        {
            float rotationStep = m_RotateSpeed * Time.deltaTime;
            Quaternion horizontalRotation = Quaternion.AngleAxis(xInput * rotationStep, Vector3.up);
            Quaternion verticalRotation = Quaternion.AngleAxis(yInput * rotationStep, Vector3.right);
            transform.rotation *= horizontalRotation * verticalRotation;
        }

        private void Scale(float xInput, float yInput)
        {
            float scaleStep = m_ScaleSpeed * Time.deltaTime;
            Vector3 scale = transform.localScale;
            scale.x += xInput * scaleStep;
            scale.y += yInput * scaleStep;
            transform.localScale = scale;
        }
    }
}
