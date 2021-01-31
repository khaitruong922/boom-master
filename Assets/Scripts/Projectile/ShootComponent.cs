#pragma warning disable 0649

using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float shootForce = 15;
    [SerializeField] private float damage = 15;
    private CharacterType characterType;
    private void Awake()
    {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    public void Shoot(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Projectile p = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle)).GetComponent<Projectile>();
        p.SetVelocity(direction * shootForce);
        p.CharacterType = characterType;
        p.Damage = damage;
    }
    public void Shoot()
    {
        Shoot(transform.up);
    }
}