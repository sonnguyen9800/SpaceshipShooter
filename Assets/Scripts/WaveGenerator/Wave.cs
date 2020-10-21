using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wave : MonoBehaviour
{
    [System.Serializable]
    private class InnerWave
    {
        [SerializeField]
        private GameObject enemyModel;
        [SerializeField]
        private int count;

        public GameObject EnemyModel => enemyModel;
        public int Count => count;
    }
    [SerializeField] private float spawningCooldown;
    [SerializeField] private int enemyCount;
    [SerializeField] private List<Transform> moveLocations;
    [SerializeField] private InnerWave[] innerWaves;
    public List<MoveTowardLocations> movingObjects = new List<MoveTowardLocations>();

    public enum WaveState
    {
        INITIAL,
        SPAWNING,
        FINISH_SPAWNING,
        END
    }
    private WaveState currentState = WaveState.INITIAL;
    public WaveState CurrentState => currentState;
    public void StartWave()
    {
        currentState = WaveState.SPAWNING;
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        foreach (var innerWave in innerWaves)
        {
            for (int i = 0; i < innerWave.Count; i++)
            {
                MoveTowardLocations movingObject = Instantiate(innerWave.EnemyModel, transform.position, transform.rotation).GetComponent<MoveTowardLocations>();
                movingObjects.Add(movingObject);
                movingObject.Locations = moveLocations;
                yield return new WaitForSeconds(spawningCooldown);
            }
        }
        currentState = WaveState.FINISH_SPAWNING;
    }
    private void Update()
    {
        CleanUpNullObjects();
        if (!IsWaveCleared) return;
        currentState = WaveState.END;

    }
    private void CleanUpNullObjects()
    {
        movingObjects.RemoveAll(m => m == null);
    }
    private bool IsWaveCleared => currentState == WaveState.FINISH_SPAWNING && movingObjects.Count == 0;
}
