using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MoveComponent))]
public class MoveTowardLocations : MonoBehaviour
{
    public Transform[] Locations { get; set; }
    private int currentLocationIndex = 0;
    private Vector2 destination;
    private MoveComponent moveComponent;

    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    private void Start()
    {
        ChangeDestination();
    }
    private void FixedUpdate()
    {
        if (Locations.Length == 0) return;
        if (HasReachedDestination()) ChangeDestination();
        moveComponent.MoveToward(destination);
    }

    private bool HasReachedDestination()
    {
        return Vector2.Distance(transform.position, destination) <= 0.2;
    }
    private void ChangeDestination()
    {
        destination = Locations[UnityEngine.Random.Range(0, Locations.Length - 1)].position;
    }

}
