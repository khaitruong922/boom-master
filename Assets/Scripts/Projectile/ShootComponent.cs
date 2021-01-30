#pragma warning disable 0649

using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float shootForce = 30;
    public void Shoot(Vector2 shootVector)
    {
        Projectile p = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        p.Init(shootVector * shootForce, GetComponentInParent<ICharacter>().CharacterType);
    }
}