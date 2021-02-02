using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviourSingleton<Player>, ICharacter
{
    public CharacterType CharacterType => CharacterType.Player;
}
