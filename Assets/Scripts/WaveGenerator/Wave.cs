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

    public enum WaveState {
        Ini,
        SpaningEnemy,
        FinishSpawning,
        End
    }
    private WaveState currentState = WaveState.Ini;
    void Awake(){
    }

    void Start()
    {
    }

    public void startWave(){
        this.currentState = WaveState.SpaningEnemy;

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
        this.hasFinishedSpawning = true;
        this.currentState = WaveState.FinishSpawning;

    }
    private void Update()
    {
        CleanUpNullObjects();
        if (!IsWaveCleared()) return;
        this.currentState = WaveState.End;

    }

    public WaveState GetState(){
        return currentState;
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
