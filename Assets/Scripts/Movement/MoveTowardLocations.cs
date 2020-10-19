using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStatLoader))]
public class MoveTowardLocations : MonoBehaviour, IMoveSpeed
{
    [SerializeField]
    private float moveSpeed;
    public List<Transform> Locations { get; set; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    private Rigidbody2D rb;
    private int currentLocationIndex = 0;
    private Vector2 destination;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Locations.Count == 0) return;
        if (HasReachedDestination()) ChangeDestination();
        Move();
    }
    private void Move()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.fixedDeltaTime));
    }
    private bool HasReachedDestination()
    {
        return Vector2.Distance(transform.position, destination) <= 0.2;
    }
    private void ChangeDestination()
    {
        currentLocationIndex++;
        if (currentLocationIndex == (Locations.Count - 1)) currentLocationIndex = 0;
        destination = Locations[currentLocationIndex].position;
    }

}
