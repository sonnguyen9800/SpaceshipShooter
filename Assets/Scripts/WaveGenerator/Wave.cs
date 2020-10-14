using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    [SerializeField] private float spawningCooldown;
    [SerializeField] private int enemyCount;
    private bool hasFinishedSpawning = false;
    [SerializeField] private List<Transform> moveLocations;
    [SerializeField] private GameObject enemyModel;
    private List<MoveTowardLocations> movingObjects = new List<MoveTowardLocations>();

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            MoveTowardLocations movingObject = Instantiate(enemyModel, transform.position, transform.rotation).GetComponent<MoveTowardLocations>();
            movingObjects.Add(movingObject);
            movingObject.SetLocations(moveLocations);
            yield return new WaitForSeconds(spawningCooldown);
        }
        hasFinishedSpawning = true;
    }
    private void Update()
    {
        CleanUpNullObjects();
        if (!IsWaveCleared()) return;
        Debug.Log("Wave cleared");
        Destroy(gameObject);
    }

    private void CleanUpNullObjects()
    {
        movingObjects.RemoveAll(m => m == null);
    }
    private bool IsWaveCleared()
    {
        return hasFinishedSpawning && movingObjects.Count == 0;
    }
}
