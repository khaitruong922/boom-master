  
#pragma warning disable 0649

using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class MoveOnInput : MonoBehaviour
{
    private MoveComponent moveComponent;
    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    private void Update()
    {
        moveComponent.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized);
    }
}