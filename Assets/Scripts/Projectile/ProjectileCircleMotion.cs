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
    private float motionSpeed = Mathf.PI;
    private float initialTime;
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.OnVelocityInitialized += SetInitialDirection;
    }
    private void Start()
    {
        initialTime = Time.time;
    }
    private float GetCurrentTime() => Time.time - initialTime;
    private void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction;
    }
    void Update()
    {
        projectile.SetFlyingDirection(initialDirection + new Vector2(X, Y));
    }
    private float X => radius * Mathf.Cos(GetCurrentTime() * motionSpeed);
    private float Y => radius * Mathf.Sin(GetCurrentTime() * motionSpeed);

}
