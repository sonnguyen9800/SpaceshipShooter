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
    public CharacterType OwnerType => ownerType;
    private Vector2 direction;
    public Action<Vector2> OnVelocityInitialized = delegate { };
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    public void SetOwnerType(CharacterType ownerType) => this.ownerType = ownerType;

    public void SetInitialFlyingDirection(Vector2 shootVector)
    {
        SetFlyingDirection(shootVector);
        OnVelocityInitialized?.Invoke(shootVector);
    }
    public void SetFlyingDirection(Vector2 shootVector) => direction = shootVector;

    private void Update()
    {
        rb.velocity = direction * speed;
    }
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
