using UnityEngine;

namespace Extensions
{
    public static class LookAtRigidbody2DExtension
    {
        public static void LookAt2D(this Rigidbody2D me, Vector3 targetPosition)
        {
            Vector2 lookDirection = targetPosition - me.transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
            me.rotation = angle;
        }
    }
}