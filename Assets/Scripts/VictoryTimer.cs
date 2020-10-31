using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTimer : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        SceneChanger.LoadSceneByName("VictoryScene");
    }

}
