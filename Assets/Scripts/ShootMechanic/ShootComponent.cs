using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    public CharacterType OwnerType { get; set; }
    public Action<Projectile> OnProjectileShoot = delegate { };
    public void Shoot()
    {
        Projectile p = Instantiate(projectile, transform.position, transform.rotation);
        p.SetInitialDirection(transform.up);
        p.SetOwnerType(OwnerType);
        OnProjectileShoot?.Invoke(p);
    }
}
