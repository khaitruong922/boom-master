using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPosition : MonoBehaviour
{
    public float Speed { get; set; }
    public Vector2 TargetPosition { get; set; }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, TargetPosition) == 0)
        {
            Destroy(this);
        }
    }
}
