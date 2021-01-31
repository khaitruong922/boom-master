#pragma warning disable 0649

using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float shootForce = 30;
    public void Shoot(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Projectile p = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle)).GetComponent<Projectile>();
        p.Init(direction * shootForce, GetComponentInParent<ICharacter>().CharacterType);
    }
    public void Shoot()
    {
        Shoot(transform.up);
    }
}