#pragma warning disable 0649

using UnityEngine;
using System;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public Action OnHealthChanged { get; set; }
    public Action OnDead { get; set; }
    [SerializeField] private float maxHP = 200;
    [SerializeField] private UnityEvent<float> onDamageTaken;
    private float currentHP;
    private void Awake()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        ClampHP();
        OnHealthChanged?.Invoke();
        onDamageTaken?.Invoke(damage);
        print(currentHP);
    }
    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        ClampHP();
        OnHealthChanged?.Invoke();
    }
    private void ClampHP()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    private void Die()
    {
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;
    public bool IsFull => currentHP == maxHP;
    public bool IsDead => currentHP == 0;
}