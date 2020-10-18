using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 2.0f;
    private Rigidbody2D rb;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    private CharacterType ownerType;
    private Vector2 initialDirection;
    private Vector2 additionalDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    public void SetOwnerType(CharacterType ownerType) => this.ownerType = ownerType;
    public void SetInitialDirection(Vector2 direction) => initialDirection = direction;
    public void SetAddtionalDirection(Vector2 direction) => additionalDirection = direction;
    private Vector2 Direction => initialDirection + additionalDirection;
    private void Update()
    {
        rb.velocity = Direction * speed;
    }
    public CharacterType GetOwnerType() => ownerType;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null) return;
        ICharacter character = other.GetComponent<ICharacter>();
        if (character == null) return;
        if (ownerType == character.GetCharacterType()) return;
        health.TakeDamage(damage);
        Destroy(gameObject);
    }
}
