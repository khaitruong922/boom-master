using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int length = 2;
    [SerializeField] private UnityEvent onExploded;
    public float Damage { get; set; }
    public CharacterType CharacterType { get; set; }
    public BombPlacer BombPlacer { get; set; }
    private bool hasExploded = false;
    private Collider2D bombCollider;
    private void Awake()
    {
        bombCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Explosion explosion = other.GetComponent<Explosion>();
        if (explosion != null) Explode();
    }
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime > 0) return;
        Explode();
    }
    public void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        CreateExplosions(Vector2.up);
        CreateExplosions(Vector2.down);
        CreateExplosions(Vector2.left);
        CreateExplosions(Vector2.right);
        onExploded?.Invoke();
        BombPlacer.RemoveBombPosition(transform.position);
        Destroy(gameObject);
    }
    private void CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i <= length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, i, wallLayerMask);
            Collider2D collider = hit.collider;
            Vector3 position = transform.position + (i * direction);
            bool collidedWithDestructible = false;
            if (collider)
            {
                if (collider.GetComponent<DestructibleTilemap>() != null) collidedWithDestructible = true;
                if (!collidedWithDestructible) break;
            }
            SpawnExplosion(position);
            if (collidedWithDestructible) break;
        }
    }
    private void SpawnExplosion(Vector3 position)
    {
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity).GetComponent<Explosion>();
        explosion.CharacterType = CharacterType;
        explosion.Damage = Damage;
    }
}
