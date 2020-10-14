using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    // Default number of enemy = 5
    [SerializeField] private int numberEnemy = 5;
    [SerializeField] private List<Transform> moveLocations;

    // Cooldown time between each enemy spawning
    [SerializeField] private float spawnningRate = 0.1f;
    // Start is called before the first frame update
<<<<<<< HEAD
    [SerializeField] private Enemy enemy = 
=======
>>>>>>> b7b7067d3014d7270297af79a1e79b507094c3db
    void Start()
    {
        Quaternion rotationDown = new Quaternion(180, 0, 0,0);
        for (int i = 0 ; i < this.numberEnemy; i++ ){
            Enemy enemy = Instantiate(enemy, transform.position,rotationDown );
           // wait
        }
        //Enemy enemy = Instantiate(enemy, shootTransform.position, shootTransform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
