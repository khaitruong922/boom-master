using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameObjectExtensions
{
    public static class GameObjectExtensions
    {
        public static GameObject Active(this GameObject g)
        {
            g.SetActive(true);
            return g;
        }
    }
}

