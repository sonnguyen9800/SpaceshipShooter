using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardLocations : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private List<Transform> locations;
    private int currentLocationIndex = 0;
    private Vector2 destination;
    public void SetLocations(List<Transform> locations)
    {
        this.locations = locations;
    }
    private void Update()
    {
        if (locations.Count == 0) return;
        Move();
        if (HasReachedDestination()) ChangeDestination();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
    }
    private bool HasReachedDestination()
    {
        return Vector2.Distance(transform.position, destination) <= 0.2;
    }
    private void ChangeDestination()
    {
        currentLocationIndex++;
        if (currentLocationIndex == (locations.Count - 1)) currentLocationIndex = 0;
        destination = locations[currentLocationIndex].position;
    }

}
