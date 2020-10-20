using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
[CreateAssetMenu(menuName = "CharacterStat")]
public class CharacterStat : ScriptableObject
{
    [SerializeField]
    private float health = 100;
    public float Health => health;
    [SerializeField]
    private int life = 1;
    public int Life => life;
    [SerializeField]
    private float moveSpeed = 2;
    public float MoveSpeed => moveSpeed;
    [SerializeField]
    private float damageBoost = 0;
    public float DamageBoost => damageBoost;
}
