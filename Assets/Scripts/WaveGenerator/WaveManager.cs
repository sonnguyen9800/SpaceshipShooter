using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    private Wave currentWave;
    void Start()
    {
        NextWave();
    }
    void Update()
    {
        ProcessState();
        if (currentWave == null) return;
        Debug.Log(currentWave.gameObject.name + ' ' + currentWave.CurrentState);

        if (currentWave.CurrentState == Wave.WaveState.INITIAL)
        {
            currentWave.StartWave();
            return;
        }
        if (currentWave.CurrentState == Wave.WaveState.SPAWNING)
        {
            return;
        }
        if (currentWave.CurrentState == Wave.WaveState.FINISH_SPAWNING)
        {
            return;
        }
        if (currentWave.CurrentState == Wave.WaveState.END)
        {
            DestroyCurrentWave();
            NextWave();
        }


    }
    private void DestroyCurrentWave()
    {
        // Remove first wave so next wave will be the first wave.
        waves.Remove(currentWave);
        Destroy(currentWave.gameObject);
    }
    private void NextWave()
    {
        if (IsAllWavesCleared) return;
        currentWave = waves[0];
    }
    private bool IsAllWavesCleared => waves.Count == 0;
    private void ProcessState()
    {
        if (!IsAllWavesCleared) return;
        DestroyWaveManager();
    }
    private void DestroyWaveManager()
    {
        Debug.Log("Wave cleared");
        Destroy(gameObject);
    }
}
