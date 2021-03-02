using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private void Start() {
        playerTransform = Player.Instance.transform;
    }
    private void LateUpdate() {
        transform.position = playerTransform.position;
    }
}
