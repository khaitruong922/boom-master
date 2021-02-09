using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, ICharacter
{
    [SerializeField] private int score = 5;
    public static Action<int, Vector3> OnAnyEnemyKilled { get; set; }
    public CharacterType CharacterType => CharacterType.Enemy;
    private Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    private void Start()
    {
        health.OnDead += Die;
    }
    private void Die()
    {
        OnAnyEnemyKilled?.Invoke(score, transform.position);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        health.OnDead -= Die;

    }
}
