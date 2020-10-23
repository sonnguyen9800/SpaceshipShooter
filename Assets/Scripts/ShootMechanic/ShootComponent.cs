using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private ProjectileType projectileType;

    private AudioSource audioSource;


    [SerializeField] private AudioClip shootSound;

    public float DamageBoost { get; set; }
    public CharacterType OwnerType { get; set; }
    private bool isActive = true;
    public bool IsActive { get => isActive; set => isActive = value; }
    public Action<Projectile> OnProjectileShoot = delegate { };


    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootSound;
    }
    
    IEnumerator SoundOnShoot()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }
    
    private ProjectilePooler pooler;
    private void Start()
    {
        pooler = ProjectilePooler.Instance;
    }
    public void Shoot()
    {
        if (!IsActive) return;

        if (shootSound != null) {
            StartCoroutine(SoundOnShoot());
        }

        Projectile p = ProjectilePooler.Instance.Get(projectileType);
        p.transform.position = transform.position;
        p.transform.rotation = transform.rotation;

        p.LoadFromSettings(new Projectile.Settings
        {
            InitialDirection = transform.up,
            OwnerType = this.OwnerType,
            DamageBoost = this.DamageBoost,
            ProjectileType = this.projectileType,
            Pooler = this.pooler
        });
        p.gameObject.SetActive(true);
        OnProjectileShoot?.Invoke(p);
    }
}


