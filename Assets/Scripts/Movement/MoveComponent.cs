using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [Header("Default - without stat loader")]
    [SerializeField]
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; OnMoveSpeedChanged?.Invoke(); } }
    public Action OnMoveSpeedChanged { get; set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveToward(Vector2 destination)
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.fixedDeltaTime));
    }
}
