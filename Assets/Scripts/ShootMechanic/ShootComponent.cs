using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    public float DamageBoost { get; set; }
    public CharacterType OwnerType { get; set; }
    public Action<Projectile> OnProjectileShoot = delegate { };
    public void Shoot()
    {
        Projectile p = Instantiate(projectile, transform.position, transform.rotation);
        p.InitialDirection = transform.up;
        p.OwnerType = OwnerType;
        p.DamageBoost = DamageBoost;
        OnProjectileShoot?.Invoke(p);
    }
}
