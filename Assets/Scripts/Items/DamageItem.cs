using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Item))]
public class DamageItem : MonoBehaviour
{
    [SerializeField]
    private float damageBoost;
    private Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
        item.OnPick += IncreaseDamage;

    }
    private void IncreaseDamage(Collider2D other)
    {
        DamageBooster damageBooster = other.GetComponent<DamageBooster>();
        if (damageBooster == null) return;
        damageBooster.DamageBoost += damageBoost;
    }
}
