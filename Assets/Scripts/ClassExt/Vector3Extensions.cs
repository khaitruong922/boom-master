using UnityEngine;
using System.Collections.Generic;


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
    // public static bool Contains(this List<Vector3> positions, Vector3 target)
    // {

    // }
}