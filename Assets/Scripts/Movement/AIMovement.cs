using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MoveComponent))]
public class AIMovement : MonoBehaviour
{
    [SerializeField] private float stopDistance = 4, retreatDistance = 2;
    private MoveComponent moveComponent;
    private Transform targetTransform;

    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    private void Start()
    {
        targetTransform = Player.Instance.transform;
    }
    private void FollowPlayer()
    {
        float distance = Vector2.Distance(transform.position, targetTransform.position);
        if (distance > stopDistance)
        {
            moveComponent.MoveTowards(targetTransform.position);
            return;
        }
        if (distance <= stopDistance && distance > retreatDistance)
        {
            // Stand still
            return;
        }
        if (distance <= retreatDistance)
        {
            moveComponent.MoveAwayFrom(targetTransform.position);
        }
    }
    private void Update()
    {
        FollowPlayer();
    }
}
