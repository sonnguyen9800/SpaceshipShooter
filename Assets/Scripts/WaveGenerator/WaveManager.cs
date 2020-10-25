using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    private Wave currentWave;
    public int CurrentWaveIndex { get; private set; }
    public Action OnWaveChanged { get; set; }
    public Action OnFinished;
    public int WaveCount => waves.Count;
    void Start()
    {
        CurrentWaveIndex = 0;
        currentWave = waves[CurrentWaveIndex];
    }
    void Update()
    {
        ProcessState();
        if (currentWave == null) return;
        //Debug.Log(currentWave.gameObject.name + ' ' + currentWave.CurrentState);

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
        Destroy(currentWave.gameObject);
    }
    private void NextWave()
    {
        CurrentWaveIndex++;
        if (IsAllWavesCleared) return;
        currentWave = waves[CurrentWaveIndex];
        OnWaveChanged?.Invoke();
    }
    private bool IsAllWavesCleared => CurrentWaveIndex == waves.Count - 1;
    private void ProcessState()
    {
        if (!IsAllWavesCleared) return;
        OnFinished?.Invoke();
        DestroyWaveManager();
    }
    private void DestroyWaveManager()
    {
        //  Debug.Log("All waves cleared.");
        SceneChanger scene = new SceneChanger();
        scene.LoadSceneByName("VictoryScene");
        Destroy(gameObject);
    }
}
