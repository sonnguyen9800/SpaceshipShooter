using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void startCampaign()
    {
        SceneManager.LoadScene("Scene/Campaign List");
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
