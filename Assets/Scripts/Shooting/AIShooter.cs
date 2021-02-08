using UnityEngine;

[RequireComponent(typeof(ShootComponent))]
public class AIShooter : MonoBehaviour
{
    [SerializeField] private float shootRange = 30;
    private ShootComponent shootComponent;
    private Transform targetTransform;

    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
    }
    private void Start()
    {
        targetTransform = Player.Instance.transform;
    }
    public void Shoot(float angleOffset = 0)
    {
        Vector3 diff = targetTransform.position - transform.position;
        if (diff.magnitude > shootRange) return;
        Vector3 direction = diff.normalized;
        shootComponent.Shoot(direction, angleOffset);
    }
}
