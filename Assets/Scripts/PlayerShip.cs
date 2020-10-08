using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField]
    [Range(10,100)]
    private float movespeed;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 12;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = movespeed / 100;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        //rb.velocity = transform.forward*Time.deltaTime*
       
            
    }
}
