using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFlipped = false;
    private Vector3 normalScale = new Vector3(1, 1, 1);
    private Vector3 flippedScale = new Vector3(-1, 1, 1);
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isFlipped & rb.velocity.x < 0)
        {
            transform.localScale = flippedScale;
            isFlipped = true;
            return;

        }
        if (isFlipped & rb.velocity.x > 0)
        {
            transform.localScale = normalScale;
            isFlipped = false;
            return;
        }

    }
}
