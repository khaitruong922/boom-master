using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, ICharacter
{
    public CharacterType CharacterType => CharacterType.Player;

}
