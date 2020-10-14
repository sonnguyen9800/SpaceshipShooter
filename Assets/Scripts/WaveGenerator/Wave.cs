using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    private string LOG_TAG = typeof(Wave).Name;
    [SerializeField] private float spawningCooldown; 

    [SerializeField] private int numberEnemy = 5;
    [SerializeField] private List<Transform> moveLocations;
    [SerializeField] private Enemy enemyModel;

    private List<Enemy> enemyList = new List<Enemy>();
    void Awake(){
    }

    private IEnumerator spawningEnemy(){
        for (int i = 0 ; i < this.numberEnemy; i++ ){
            Enemy enemy = Instantiate(enemyModel, this.transform.position, this.transform.rotation);
            this.enemyList.Add(enemy);
            foreach(var transform in this.moveLocations){
                enemy.movePaths.Add(transform);
            }
            yield return new WaitForSeconds(spawningCooldown);
        }

    }
    void Start()
    {
        StartCoroutine(spawningEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        int aliveEnemy = 0;
        foreach(Enemy enemy in this.enemyList){
            if (enemy != null){
                aliveEnemy ++;
            }
        }
        if (aliveEnemy == 0){
            Debug.Log("The wave has been cleared");
            foreach(Transform transform in this.moveLocations){
                GameObject location = transform.gameObject;
                Destroy(location);
            }
            Destroy(gameObject);
        }
    }
}
