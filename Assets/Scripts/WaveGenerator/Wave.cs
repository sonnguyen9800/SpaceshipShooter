using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    private string LOG_TAG = typeof(Wave).Name;
    [SerializeField] private float baseCooldown = 5.0f;
    private float cooldown = 0.1f;

    // Default number of enemy = 5
    [SerializeField] private int numberEnemy = 5;
    [SerializeField] private List<Transform> moveLocations;
    [SerializeField] private Enemy enemy1;
    void Awake(){
      for (int i = 0 ; i < this.numberEnemy; i++ ){
            Debug.Log(LOG_TAG + " Spawning enemy number: " + i);
            Enemy enemy = Instantiate(enemy1, this.transform.position, this.transform.rotation);

            enemy.movePaths = this.moveLocations;
            Debug.Log(LOG_TAG + " There are " + enemy.movePaths.Count + " locations to move");

        
        }
    }

    void Start()
    {
       // Quaternion rotationDown = new Quaternion(180, 0, 0,0);
  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
