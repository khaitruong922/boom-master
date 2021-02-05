using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, ICharacter
{
    [SerializeField] private int score = 5;
    public static Action<int> OnAnyEnemyKilled { get; set; }
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
        OnAnyEnemyKilled?.Invoke(score);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        health.OnDead -= Die;

    }
}
