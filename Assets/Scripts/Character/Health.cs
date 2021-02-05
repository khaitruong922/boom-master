#pragma warning disable 0649

using UnityEngine;
using System;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public static Action<float, Health> OnAnyCharacterHealthChanged { get; set; }
    public Action<float> OnHealthChanged { get; set; }
    public Action OnDead { get; set; }
    [SerializeField] private float maxHP = 200;
    [SerializeField] private UnityEvent<float> onDamageTaken;
    [SerializeField] private UnityEvent<float> onHeal;
    private bool isDead = false;
    private float currentHP;
    private void Awake()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        if (isDead) return;
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        ClampHP();
        OnHealthChanged?.Invoke(-damage);
        OnAnyCharacterHealthChanged?.Invoke(-damage, this);
        onDamageTaken?.Invoke(damage);
    }
    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        ClampHP();
        OnHealthChanged?.Invoke(healAmount);
        OnAnyCharacterHealthChanged?.Invoke(healAmount, this);
    }
    private void ClampHP()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    private void Die()
    {
        isDead = true;
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;
    public bool IsFull => currentHP == maxHP;
    public bool IsDead => currentHP == 0;
}