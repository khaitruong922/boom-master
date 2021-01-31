using UnityEngine;

namespace Vector2Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 Rotate(this Vector2 v, float delta)
        {
            return new Vector2(
                v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
                v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
            );
        }
        public static Vector2 Extend(this Vector2 v, float length)
        {
            float distance = v.magnitude;
            return v / distance * (distance + length);
        }
        public static Vector2 ToCellCenter(this Vector2 v)
        {
            return new Vector2(Mathf.FloorToInt(v.x) + 0.5f, Mathf.FloorToInt(v.y) + 0.5f);
        }
    }
}