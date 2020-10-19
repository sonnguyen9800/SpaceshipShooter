using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStatLoader))]
public class MoveTowardMouse : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, MouseLocator.Position, moveSpeed * Time.fixedDeltaTime));
    }
}
