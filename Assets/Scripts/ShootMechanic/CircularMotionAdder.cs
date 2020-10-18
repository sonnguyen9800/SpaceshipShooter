using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotionAdder : MonoBehaviour
{
    [SerializeField]
    private CircularMotion circularMotion;
    private ShootComponent shootComponent;

    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.OnProjectileShoot += AddCircularMotion;
    }
    private void AddCircularMotion(Projectile p)
    {
        CircularProjectile circularProjectile = p.gameObject.AddComponent<CircularProjectile>();
        circularProjectile.Motion = circularMotion;
    }
    private void OnDestroy()
    {
        shootComponent.OnProjectileShoot -= AddCircularMotion;
    }
}
