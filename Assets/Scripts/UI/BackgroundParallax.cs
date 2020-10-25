using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BackgroundParallax : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 0.5f;
    private Material material;
    private Vector2 offset;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, speed);
    }

    // Update is called once per frame
    private void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
