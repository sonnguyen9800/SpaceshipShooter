using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public static Player Instance { get; private set; }
    private Health health;
    public Health Health => health;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
