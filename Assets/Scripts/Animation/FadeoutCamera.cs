using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeoutCamera : MonoBehaviour
{
    [SerializeField]
    private Texture2D fadeTexture;

    [SerializeField]
    [Range(0.1f, 1f)]
    private float fadespeed;
    [SerializeField]
    private int drawDepth = -1000;

    private float alpha = 1f;
    private float fadeDir = -1f;

    private void OnGUI()
    {

        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

    }



}