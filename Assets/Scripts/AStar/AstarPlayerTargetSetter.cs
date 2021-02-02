using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(AIPath))]
public class AstarPlayerTargetSetter : MonoBehaviour
{
    private Transform targetTransform;
    private AIPath aIPath;
    private void Awake()
    {
        aIPath = GetComponent<AIPath>();
    }
    private void Start()
    {
        targetTransform = Player.Instance.transform;
    }
    private void Update()
    {
        aIPath.destination = targetTransform.position;
    }
}
