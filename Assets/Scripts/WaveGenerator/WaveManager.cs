using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Wave> allWaves;

    private int indexWave = 0;
    private bool repeate = true;
    private Wave currentWave;
    // Start is called before the first frame update
    private void Awake(){
        // Get the first wave
        currentWave = allWaves[indexWave];
    }
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {   
        if (currentWave == null) return;
        Debug.Log(currentWave.GetState());
        if (currentWave.GetState() == Wave.WaveState.Ini){
            // Start the state
            currentWave.startWave();
        } else if (currentWave.GetState() == Wave.WaveState.SpaningEnemy){
            return;
        } 
        else if (currentWave.GetState() == Wave.WaveState.End && indexWave < (this.allWaves.Count-1)){
            indexWave++;
            currentWave = this.allWaves[indexWave];
        } else if (currentWave.GetState() == Wave.WaveState.End && indexWave >= (this.allWaves.Count-1)) {
            foreach(Wave wave in this.allWaves){
                Destroy(wave.gameObject);
            }
        }
       
    }
}
