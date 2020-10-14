using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    public void SetOwnerType(CharacterType ownerType)
    {
        this.ownerType = ownerType;
    }
    public void SetFlyingDirection(Vector2 shootVector)
    {
        rb.velocity = shootVector * speed;
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
