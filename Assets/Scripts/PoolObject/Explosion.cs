using UnityEngine;

public class Explosion : PoolObject
{
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter.CharacterType != CharacterType)
            {
                health.TakeDamage(Damage);
            }
            return;
        }
        DestructibleTilemap destructibleTilemap = other.GetComponent<DestructibleTilemap>();
        if (destructibleTilemap != null)
        {
            destructibleTilemap.DestroyTile(transform.position);
            return;
        }
        Bomb bomb = other.GetComponent<Bomb>();
        if (bomb != null && bomb.CharacterType == CharacterType && bomb.Destination == null) bomb.Explode();
    }
}

