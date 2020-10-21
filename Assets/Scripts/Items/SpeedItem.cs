using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class SpeedItem : MonoBehaviour
{
    [SerializeField]
    private float bonusSpeed;
    private Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
        item.OnPick += IncreaseSpeed;
    }
    private void IncreaseSpeed(Collider2D other)
    {
        MoveComponent moveComponent = other.GetComponent<MoveComponent>();
        if (moveComponent == null) return;
        moveComponent.MoveSpeed += bonusSpeed;
    }
}
