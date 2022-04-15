using UnityEngine;

namespace Extensions
{
    public static class LookAtTransformExtension
    {
        public static void LookAt2D(this Transform me, Vector2 eye, Transform target)
        {
            me.LookAt2D(eye, target.position);
        }

        
        private static void LookAt2D(this Transform me, Vector2 eye, Vector2 target)
        {
            Vector2 look = target - (Vector2)me.position;

            float angle = Vector3.Angle(eye, look);

            Vector2 right = Vector3.Cross(Vector3.forward, look);

            int dir = 1;

            if (Vector3.Angle(right, eye) < 90)
            {
                dir = -1;
            }
            
            me.rotation = Quaternion.AngleAxis(angle * dir, Vector3.forward);
        }
    }
}