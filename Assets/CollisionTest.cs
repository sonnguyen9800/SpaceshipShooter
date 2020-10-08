using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
   
    private void OnTrigerEnter2D(Collider2D collider2D)
    {
        Debug.Log("Object Hit");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Object has been created");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
