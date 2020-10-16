using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardMouse : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField]
    private float minX = -3.5f, maxX = 3.5f, minY = -6.0f, maxY = 5.0f;
    private void Update()
    {
        Vector3 mousePosition = MouseLocator.Position;
        Vector3 moveVector = (mousePosition - transform.position).normalized;
        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}
