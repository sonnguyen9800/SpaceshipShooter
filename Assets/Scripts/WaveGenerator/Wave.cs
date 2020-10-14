using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    private string LOG_TAG = typeof(Wave).Name;
    [SerializeField] private float baseCooldown = 2.0f;
    [SerializeField] private float cooldown = 0;

    // Default number of enemy = 5
    [SerializeField] private int numberEnemy = 5;
    [SerializeField] private List<Transform> moveLocations;

    // Cooldown time between each enemy spawning
    [SerializeField] private float spawnningRate = 0.1f;
    // Start is called before the first frame update

    [SerializeField] private Enemy enemy1 = new Enemy();

    void Awake(){
        Debug.Log(LOG_TAG + "Create wave" + this.transform.position);
    }
    void Start()
    {
        Quaternion rotationDown = new Quaternion(180, 0, 0,0);
        for (int i = 0 ; i < this.numberEnemy; i++ ){
            Debug.Log(LOG_TAG + " Spawning enemy number: " + i);
           Enemy enemy = Instantiate(enemy1, this.transform.position, this.transform.rotation);
           // wait
           while (true){
            cooldown -= Time.deltaTime;
            if (cooldown <= this.baseCooldown){
                cooldown = this.baseCooldown;
                break;
            }
           }
        }
        //Enemy enemy = Instantiate(enemy, shootTransform.position, shootTransform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
