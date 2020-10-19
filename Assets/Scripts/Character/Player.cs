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
        SingletonCheck();
        health = GetComponent<Health>();
        health.OnDead += Die;
    }
    private void Start()
    {

    }
    private void SingletonCheck()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
