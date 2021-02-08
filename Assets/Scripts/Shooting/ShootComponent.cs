#pragma warning disable 0649

using UnityEngine;
public class ShootComponent : MonoBehaviour
{
    [SerializeField] private PoolObjectFactory projectileFactory;
    [SerializeField] private PoolObjectFactory explosionVFXFactory;
    [SerializeField] private float shootForce = 15;
    [SerializeField] private float damage = 15;
    private CharacterType characterType;
    private void Awake()
    {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    public void Shoot(Vector2 direction, float angleOffset = 0)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset - 90;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Projectile p = projectileFactory.Get(transform.position, rotation).GetComponent<Projectile>();
        p.SetVelocity(p.transform.up * shootForce);
        p.ExplosionVFXFactory = explosionVFXFactory;
        p.CharacterType = characterType;
        p.Damage = damage;
    }
    public void Shoot()
    {
        Shoot(transform.up);
    }
}