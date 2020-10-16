﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    private CharacterType ownerType;
    public Action<Projectile> OnProjectileShoot = delegate { };
    public void SetOwnerType(CharacterType ownerType)
    {
        this.ownerType = ownerType;
    }
    public void Shoot()
    {
        Projectile p = Instantiate(projectile, transform.position, transform.rotation);
        p.SetInitialFlyingDirection(transform.up);
        p.SetOwnerType(ownerType);
        OnProjectileShoot?.Invoke(p);
    }
}
