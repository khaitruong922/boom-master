using UnityEngine;

namespace Vector3Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 RoundToInt(this Vector3 v)
        {
            return new Vector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
        }
        public static Vector3 FloorToInt(this Vector3 v)
        {
            return new Vector3(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z));
        }
        public static Vector3 ToCellCenter(this Vector3 v)
        {
            return new Vector3(Mathf.FloorToInt(v.x) + 0.5f, Mathf.FloorToInt(v.y) + 0.5f, Mathf.FloorToInt(v.z));
        }
    }
}
