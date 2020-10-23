using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ICollideBoundary
{
    void OnCollisionWithBoundary();
}
public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var obj = other.GetComponent<ICollideBoundary>();
        if (obj == null) return;
        obj.OnCollisionWithBoundary();
    }
}
