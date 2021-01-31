using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2P : MonoBehaviour, ICharacter
{
    [SerializeField] private CharacterType characterType = CharacterType.Player1;
    public CharacterType CharacterType => characterType;

}
