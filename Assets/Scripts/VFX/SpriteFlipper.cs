using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFlipped = false;
    private Quaternion normalQuaternion = Quaternion.Euler(0, 0, 0);
    private Quaternion flippedQuaternion = Quaternion.Euler(0, 180, 0);
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isFlipped & rb.velocity.x < -0.1f)
        {
            transform.rotation = flippedQuaternion;
            isFlipped = true;
            return;

        }
        if (isFlipped & rb.velocity.x > 0.1f)
        {
            transform.rotation = normalQuaternion;
            isFlipped = false;
            return;
        }
    }
}
