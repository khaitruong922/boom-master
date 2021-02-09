using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    [SerializeField] private float damage = 100;
    private CharacterType characterType;
    private void Awake() {
        characterType = GetComponentInParent<ICharacter>().CharacterType;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            ICharacter hitCharacter = other.GetComponent<ICharacter>();
            if (hitCharacter.CharacterType != characterType)
            {
                health.TakeDamage(damage);
            }
            return;
        }
    }    
}