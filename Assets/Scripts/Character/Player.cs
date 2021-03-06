﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public static Player Instance { get; private set; }
    public CharacterType CharacterType => CharacterType.Player;
    private Health health;
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

    private void Die()
    {
        GameObject loseTimer = new GameObject("LoseTimer",typeof(LoseTimer));
        gameObject.SetActive(false);

    }


}
