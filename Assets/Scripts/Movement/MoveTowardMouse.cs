using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardMouse : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, MouseLocator.Position, moveSpeed * Time.deltaTime));
    }
}
