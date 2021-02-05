#pragma warning disable 0649

using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class MoveOnInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode upKey = KeyCode.W, leftKey = KeyCode.A, downKey = KeyCode.S, rightKey = KeyCode.D;
    private KeyCode latestKey = KeyCode.None;
    private MoveComponent moveComponent;
    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    private Vector2 KeyToVector2(KeyCode keyCode)
    {
        if (keyCode == leftKey) return new Vector2(-1, 0);
        if (keyCode == rightKey) return new Vector2(1, 0);
        if (keyCode == upKey) return new Vector2(0, 1);
        if (keyCode == downKey) return new Vector2(0, -1);
        return Vector2.zero;
    }
    private void ComputeLatestKey()
    {
        if (Input.GetKeyDown(leftKey)) latestKey = leftKey;
        if (Input.GetKeyDown(rightKey)) latestKey = rightKey;
        if (Input.GetKeyDown(upKey)) latestKey = upKey;
        if (Input.GetKeyDown(downKey)) latestKey = downKey;
    }
    private void Update()
    {
        if (Time.timeScale == 0) return;
        ComputeLatestKey();
        Vector2 direction = Vector2.zero;
        int keyCount = 0;

        if (Input.GetKey(leftKey))
        {
            keyCount++;
            direction += KeyToVector2(leftKey);
        }
        if (Input.GetKey(rightKey))
        {
            keyCount++;
            direction += KeyToVector2(rightKey);
        }
        if (Input.GetKey(upKey))
        {
            keyCount++;
            direction += KeyToVector2(upKey);
        }
        ;
        if (Input.GetKey(downKey))
        {
            keyCount++;
            direction += KeyToVector2(downKey);
        }

        if (keyCount <= 1)
        {
            moveComponent.Move(direction);
            return;
        }
        moveComponent.Move(KeyToVector2(latestKey));
    }
}