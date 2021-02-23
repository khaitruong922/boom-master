using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private bool shouldDieAfterCollision = true;
    [SerializeField] private float damage;
    private CharacterType characterType;
    private void Awake()
    {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (health == null) return;
        ICharacter hitCharacter = health.GetComponent<ICharacter>();
        if (hitCharacter.CharacterType == characterType) return;
        health.TakeDamage(damage);
        if (shouldDieAfterCollision) GetComponent<Health>()?.Die();
    }
}
