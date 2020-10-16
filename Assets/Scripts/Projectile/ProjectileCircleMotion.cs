using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCircleMotion : MonoBehaviour
{
    private Projectile projectile;
    private Vector2 initialDirection;
    [SerializeField]
    private float radius = 0.3f;
    [SerializeField]
    private float spinRate = 2;
    private float directionMultiplier = 1f;
    private float initialTime;
    private float initialAngle;
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.OnVelocityInitialized += SetInitialDirection;
    }
    private void Start()
    {
        initialTime = Time.time;
    }
    private void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction;
    }
    public void SetInitialAngle(float angle)
    {
        initialAngle = angle;
    }
    public void SetSpinDirection(CircularMotionSetter.SpinDirection spinDirection)
    {
        directionMultiplier = (int)spinDirection;
    }
    private void Update()
    {
        projectile.SetFlyingDirection(initialDirection + new Vector2(X, Y));
    }
    private float CurrentTime => Time.time - initialTime;
    private float CurrentAngle => CurrentTime * spinRate * Mathf.PI * directionMultiplier + Mathf.Deg2Rad * initialAngle;
    private float X => radius * Mathf.Cos(CurrentAngle);
    private float Y => Mathf.Abs(radius * Mathf.Sin(CurrentAngle));

}
