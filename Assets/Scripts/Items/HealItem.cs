using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class HealItem : MonoBehaviour
{
    [SerializeField]
    private float healAmount;
    private Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
        item.OnPick += Heal;
    }
    private void Heal(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        health.Heal(healAmount);
    }
}
