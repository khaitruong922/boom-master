using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, ICharacter
{
    public CharacterType CharacterType => CharacterType.Enemy;
    private Health health;
    private void Awake() {
        health = GetComponent<Health>();
    }
    private void Start()
    {
        health.OnDead += Die;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        health.OnDead -= Die;

    }
}
