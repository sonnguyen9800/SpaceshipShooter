using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class HealItem : MonoBehaviour
{
    [SerializeField]
    private int healAmount;

    private Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
        item.OnPick += OnHealEffect;

    }
    private void OnHealEffect(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        health?.Heal(healAmount);
    }

}
