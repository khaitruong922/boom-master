#pragma warning disable 0649

using UnityEngine;
using System;
public enum CharacterType
{
    Player,
    Enemy,
    Player1,
    Player2
}
public interface ICharacter
{
    CharacterType CharacterType { get; }
}