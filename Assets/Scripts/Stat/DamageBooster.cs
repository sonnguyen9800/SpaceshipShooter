using System;
using UnityEngine;

public class DamageBooster : MonoBehaviour
{
    [Header("Default - without stat loader")]
    [SerializeField]
    private float damageBoost;
    public float DamageBoost { get => damageBoost; set { damageBoost = value; OnDamageBoostChanged?.Invoke(); } }
    public Action OnDamageBoostChanged { get; set; }
}
