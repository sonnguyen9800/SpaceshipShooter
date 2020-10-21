using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private ProjectileType projectileType;
    public float DamageBoost { get; set; }
    public CharacterType OwnerType { get; set; }
    public Action<Projectile> OnProjectileShoot = delegate { };
    public void Shoot()
    {
        Projectile p = ProjectilePooler.Instance.Get(projectileType);
        p.transform.position = transform.position;
        p.transform.rotation = transform.rotation;
        p.LoadFromSettings(new Projectile.Settings
        {
            InitialDirection = transform.up,
            OwnerType = this.OwnerType,
            DamageBoost = this.DamageBoost,
            ProjectileType = this.projectileType
        });
        p.gameObject.SetActive(true);
        OnProjectileShoot?.Invoke(p);
    }
}
