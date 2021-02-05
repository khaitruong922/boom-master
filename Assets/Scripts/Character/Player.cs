using UnityEngine;
using System;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviourSingleton<Player>, ICharacter
{
    public CharacterType CharacterType => CharacterType.Player;
    public Action OnPlayerDead { get; set; }
    private Health health;
    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<Health>();
    }
    private void Start()
    {
        health.OnDead += Die;
    }
    private void Die()
    {
        OnPlayerDead?.Invoke();
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        health.OnDead -= Die;
    }
}
