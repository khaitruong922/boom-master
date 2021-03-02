using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2Extensions;
using Pathfinding;

public class DashAbility : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 40;
    [SerializeField] private float dashDuration = 0.1f;
    private AIPath path;
    private float maxDashDistance = 1000;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        path = GetComponentInParent<AIPath>();
    }
    private void Dash(Vector2 direction)
    {
        StartCoroutine(Dashing(direction));
    }
    private IEnumerator Dashing(Vector2 direction)
    {
        float timeElapsed = 0;
        path.canMove = false;
        while (timeElapsed < dashDuration)
        {
            timeElapsed += Time.fixedDeltaTime;
            rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * dashSpeed);
            yield return null;
        }
        path.canMove = true;
    }
    public void DashRandom()
    {
        Dash(RandomDirection);
    }
    public void DashToPlayer()
    {
        Dash((Player.Instance.transform.position - transform.position).normalized);
    }
    public Vector2 RandomDirection => new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
}
