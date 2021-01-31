using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
public class AstarPlayerTargetSetter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AIDestinationSetter>().target = Player.Instance.transform;
    }
}
