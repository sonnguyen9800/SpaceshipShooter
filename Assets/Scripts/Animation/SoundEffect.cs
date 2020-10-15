using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource sourceSpeaker;
    [SerializeField] AudioClip audioClip;
    private ParticleSystem particleSystem;

    void Awake(){
        particleSystem = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (particleSystem.time <= .1f){
            sourceSpeaker.PlayOneShot(audioClip);
        }
    }
}
