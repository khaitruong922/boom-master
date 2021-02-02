using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(AIPath))]
public class AstarAIMovementTrigger : MonoBehaviour
{
    [SerializeField] private float triggerRange=10;
    private AIPath aIPath;
    private void Awake()
    {
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
    }
    private void Update()
    {
        if (aIPath.remainingDistance > triggerRange) return;
        aIPath.canMove = true;
        Destroy(this);
    }
}
