using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ShootComponent), typeof(AudioSource))]
public class PlaySoundOnShoot : MonoBehaviour
{
    private AudioSource audioSource;
    private ShootComponent shootComponent;
    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
        audioSource = GetComponent<AudioSource>();
        shootComponent.OnProjectileShoot += PlayAudioOnShoot;

    }
    private void PlayAudioOnShoot(Projectile p)
    {
        if (audioSource.clip == null) return;
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.Play();
    }
}
