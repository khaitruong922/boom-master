using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, ICharacter
{
    public CharacterType CharacterType => CharacterType.Enemy;
}
