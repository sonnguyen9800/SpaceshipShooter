using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FlyAni : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    private float speed = 5f;
    //adjust this to change how high it goes
    [SerializeField]
    private float height = 0.5f;
    private float originalAngle;

    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        originalAngle = Random.Range(0f, 360f); // Random an angle in degree
        originalAngle = Mathf.Deg2Rad * originalAngle;
    }
    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed + originalAngle) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}