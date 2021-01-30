#pragma warning disable 0649

using UnityEngine;
using System;
public enum CharacterType
{
    Player,
    Enemy,
}
public interface ICharacter
{
    CharacterType CharacterType { get; }
}