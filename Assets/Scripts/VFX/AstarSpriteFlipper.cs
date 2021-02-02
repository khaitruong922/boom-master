using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AstarSpriteFlipper : MonoBehaviour
{
    private AIPath aIPath;
    private bool isFlipped = false;
    [SerializeField] private float velocityToFlip = 0.2f;
    private Vector3 normalScale = new Vector3(1, 1, 1);
    private Vector3 flippedScale = new Vector3(-1, 1, 1);
    private void Awake()
    {
        aIPath = GetComponentInParent<AIPath>();
    }
    private void Update()
    {
        if (!isFlipped & aIPath.desiredVelocity.x < velocityToFlip)
        {
            transform.localScale = flippedScale;
            isFlipped = true;
            return;

        }
        if (isFlipped & aIPath.desiredVelocity.x > velocityToFlip)
        {
            transform.localScale = normalScale;
            isFlipped = false;
            return;
        }
    }
}
