using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPosition : MonoBehaviour
{
    public float Speed { get; set; }
    public Vector2 TargetPosition { get; set; }
    private void Update()
    {
        if (Vector2.Distance(transform.position, TargetPosition) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
        }
    }
}
