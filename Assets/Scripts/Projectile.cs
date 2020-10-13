using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetFlyingDirection(Vector2 shootVector)
    {
        rb.velocity = shootVector * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
