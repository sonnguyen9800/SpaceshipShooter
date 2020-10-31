using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    Player player = null;
    WaveManager waveManager = null;

    private void Awake() {
        player = FindObjectOfType<Player>();
        if (player != null){
            Debug.Log("Good");
        }
        waveManager = FindObjectOfType<WaveManager>();
        if (waveManager != null){
            Debug.Log("Found wave mana");
        }
    }
    void Start()
    {
        
    }
    IEnumerator wait(int second, string scenename){
        yield return new WaitForSeconds(second);
        SceneChanger sceneChanger = new SceneChanger();
            sceneChanger.LoadSceneByName(scenename);
    }
    // Update is called once per frame
    void Update()
    {
        if (!player.isActiveAndEnabled){
            Debug.Log("Player has die");
            // player has been destroyed
            StartCoroutine(wait(3, "Defeat"));
        }

        if (waveManager == null){
            Debug.Log("Hello");
            StartCoroutine(wait(5, "VictoryScene"));
        }
    }
}
