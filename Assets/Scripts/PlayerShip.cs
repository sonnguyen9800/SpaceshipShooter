using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private Rigidbody2D rb;

    // Set maximum life point to 1000
    [SerializeField] private int maxLifePoint = 1000;

    // Important Attributes
    [SerializeField] [Range(10,100)] private float movespeed;
    // Life Point - Die if this becomes 0
    [SerializeField] private int lifepoint;
    [SerializeField] private int armor;
    [SerializeField] private float fireRate;

    [SerializeField] private PlayerBullet playerBullet;

    private Camera camMain;


    private Vector3 mousePosition;
    private float minX = (float)-3.5, maxX = (float)3.5, minY = (float)-6.0, maxY= (float)5.0;

    private void Awake()
    {
        camMain = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 12;
       
    }

    // Update is called once per frame
    void Update()
    {
        this.moveSpaceshipOnMouse();

        // Button pressed => Player Fire at fire rate
        if (Input.GetMouseButtonDown(0)){
            playerFire();
        }
    }

    private void playerFire()
    {

        throw new NotImplementedException();
    }


    // Move the spaceship on mouse
    private void moveSpaceshipOnMouse()
    {
        mousePosition = camMain.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);

       
        transform.position = Vector2.Lerp(transform.position, mousePosition, (float)movespeed / 100);
    }
}
