using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource),typeof(ShootComponent))]

public class PlaySoundOnShoot : MonoBehaviour
{
    private AudioSource audioSource;
    private ShootComponent shootComponent;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.OnProjectileShoot += PlayAudio;
    }

    private void PlayAudio(Projectile obj)
    {
        if(audioSource.clip==null) return;
        if(audioSource.isPlaying) audioSource.Stop();
        audioSource.Play();
    }
}
