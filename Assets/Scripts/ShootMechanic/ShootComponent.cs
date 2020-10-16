using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    private CharacterType ownerType;
    public void SetOwnerType(CharacterType ownerType)
    {
        this.ownerType = ownerType;
    }
    public void Shoot()
    {
        Projectile p = Instantiate(projectile, transform.position, transform.rotation);
        p.SetInitialFlyingDirection(transform.up);
        p.SetOwnerType(ownerType);
    }
}
