using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class EffectOnItemPick : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;
    private Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
        item.OnPick += GrantEffect;
    }

    private void GrantEffect(Collider2D other)
    {
        if (effect == null) return;
        Instantiate(effect, other.transform.position, other.transform.rotation, other.transform);
    }
    private void OnDestroy()
    {
        item.OnPick -= GrantEffect;
    }
}
