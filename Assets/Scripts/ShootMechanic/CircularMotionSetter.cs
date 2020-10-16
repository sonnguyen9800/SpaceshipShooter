using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotionSetter : MonoBehaviour
{
    private ShootComponent shootComponent;
    [SerializeField]
    private float initialAngle = 0f;
    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.OnProjectileShoot += SetInitialAngle;
    }
    private void SetInitialAngle(Projectile p)
    {
        ProjectileCircleMotion motion = p.GetComponent<ProjectileCircleMotion>();
        motion?.SetInitialAngle(initialAngle);
    }
}
