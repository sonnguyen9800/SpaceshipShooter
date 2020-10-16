using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    private Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += Die;

    }
    public CharacterType GetCharacterType()
    {
        return CharacterType.PLAYER;
    }

    private void Die()
    {
        gameObject.SetActive(false);
        print("Player die.");
    }
}
