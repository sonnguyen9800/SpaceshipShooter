using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int lifepoint;
    [SerializeField] private int armor;
    [SerializeField] private float fireRate;
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
