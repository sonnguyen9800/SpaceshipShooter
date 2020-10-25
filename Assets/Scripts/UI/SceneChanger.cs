using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SceneChanger : MonoBehaviour
{
    private const string sceneSelectKey = "Scene";


    // Make this blank if dont' want immediate scene transition
    [SerializeField] private string SceneName;

    private void Start() {
        try{
        if (SceneName != null){
                LoadSceneByName(SceneName);
            }
        } catch (Exception e){
            // Do Nothing
        }
 
    }

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
    public void SelectScene(string name)
    {
        PlayerPrefs.SetString(sceneSelectKey, name);
    }
    public void LoadSelectedScene()
    {
        LoadSceneByName(PlayerPrefs.GetString(sceneSelectKey));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
