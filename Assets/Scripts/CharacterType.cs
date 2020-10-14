using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    PLAYER,
    ENEMY
}
public interface ICharacter
{
    CharacterType GetCharacterType();
}
