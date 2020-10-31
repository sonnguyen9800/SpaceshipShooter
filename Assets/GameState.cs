using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    Player player = null;
    private void Awake() {
        player = FindObjectOfType<Player>();
        if (player != null){
            Debug.Log("Good");
        }
    }
    void Start()
    {
        
    }
    IEnumerator wait(int second){
        yield return new WaitForSeconds(second);
                    SceneChanger sceneChanger = new SceneChanger();
            sceneChanger.LoadSceneByName("Defeat");
    }
    // Update is called once per frame
    void Update()
    {
        if (!player.isActiveAndEnabled){
            Debug.Log("Player has die");
            // player has been destroyed
            StartCoroutine(wait(3));

        }
    }
}
