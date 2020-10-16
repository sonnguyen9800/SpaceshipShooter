using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotionSetter : MonoBehaviour
{
    public enum SpinDirection
    {
        CLOCKWISE = 1,
        ANTI_CLOCKWISE = -1
    }
    private ShootComponent shootComponent;
    [SerializeField]
    private float initialAngle;
    [SerializeField]
    private SpinDirection spinDirection = SpinDirection.CLOCKWISE;
    private void Awake()
    {
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.OnProjectileShoot += SetInitialAngle;
    }
    private void SetInitialAngle(Projectile p)
    {
        ProjectileCircleMotion motion = p.GetComponent<ProjectileCircleMotion>();
        motion?.SetSpinDirection(spinDirection);
        motion?.SetInitialAngle(initialAngle);
    }
    private void OnDestroy()
    {
        shootComponent.OnProjectileShoot -= SetInitialAngle;
    }
}
