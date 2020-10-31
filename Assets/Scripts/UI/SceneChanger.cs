using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SceneChanger : MonoBehaviour
{

    private const string sceneSelectKey = "Scene";

    public static void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
        //
        //SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }
    public static void SelectScene(string name)
    {
        PlayerPrefs.SetString(sceneSelectKey, name);
    }
    public static void LoadSelectedScene()
    {
        LoadSceneByName(PlayerPrefs.GetString(sceneSelectKey));
    }
    public static void Quit()
    {
        Application.Quit();
    }


}
