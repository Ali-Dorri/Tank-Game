using UnityEngine;

namespace ADOp.TankGame
{
    public static class RotationUtility
    {
        public static Quaternion Rotate(Vector3 from, Vector3 to, Vector3 axis, float maxRotation)
        {
            float targetRotationAngle = Vector3.SignedAngle(from, to, axis);
            float rotationSize = Mathf.Min(maxRotation, Mathf.Abs(targetRotationAngle));
            float rotationAngle = Mathf.Sign(targetRotationAngle) * rotationSize;
            return Quaternion.AngleAxis(rotationAngle, axis);
        }
    }
}
