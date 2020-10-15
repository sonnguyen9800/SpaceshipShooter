using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    [SerializeField] private float spawningCooldown;
    [SerializeField] private int enemyCount;
    [SerializeField] private List<Transform> moveLocations;
    [SerializeField] private GameObject enemyModel;
    private List<MoveTowardLocations> movingObjects = new List<MoveTowardLocations>();

    public enum WaveState
    {
        INITIAL,
        SPAWNING,
        FINISH_SPAWNING,
        END
    }
    private WaveState currentState = WaveState.INITIAL;
    public WaveState CurrentState => currentState;
    void Awake()
    {
    }

    void Start()
    {
    }

    public void StartWave()
    {
        currentState = WaveState.SPAWNING;
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
        this.currentState = WaveState.FINISH_SPAWNING;

    }
    private void Update()
    {
        CleanUpNullObjects();
        if (!IsWaveCleared()) return;
        this.currentState = WaveState.END;

    }
    private void CleanUpNullObjects()
    {
        movingObjects.RemoveAll(m => m == null);
    }
    private bool IsWaveCleared()
    {
        return currentState == WaveState.FINISH_SPAWNING && movingObjects.Count == 0;
    }
}
