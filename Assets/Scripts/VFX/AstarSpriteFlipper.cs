using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AstarSpriteFlipper : MonoBehaviour
{
    private AIPath aIPath;
    private bool isFlipped = false;
    [SerializeField] private float velocityToFlip = 0.2f;
    private Quaternion normalQuaternion = Quaternion.Euler(0, 0, 0);
    private Quaternion flippedQuaternion = Quaternion.Euler(0, 180, 0);
    private void Awake()
    {
        aIPath = GetComponentInParent<AIPath>();
    }
    private void Update()
    {
        if (!isFlipped & aIPath.desiredVelocity.x < -velocityToFlip)
        {
            transform.rotation = flippedQuaternion;
            isFlipped = true;
            return;

        }
        if (isFlipped & aIPath.desiredVelocity.x > velocityToFlip)
        {
            transform.rotation = normalQuaternion;
            isFlipped = false;
            return;
        }
    }
}
