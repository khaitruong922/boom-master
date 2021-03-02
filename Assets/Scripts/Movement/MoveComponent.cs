using UnityEngine;
using System;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    public Action OnMoveSpeedChanged { get; set; }
    public float MoveSpeed
    {
        get => moveSpeed; set
        {
            moveSpeed = value;
            OnMoveSpeedChanged?.Invoke();
        }
    }
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    public void Move(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
    }
    public void MoveTowards(Vector2 destination)
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, destination, moveSpeed * Time.deltaTime));
    }
    public void MoveAwayFrom(Vector2 destination)
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, destination, -moveSpeed * Time.deltaTime));
    }
}