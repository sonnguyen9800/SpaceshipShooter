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
    private float initialAngle = 0;
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
    private void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction;
    }
    public void SetInitialAngle(float angle)
    {
        initialAngle = angle;
    }
    void Update()
    {
        projectile.SetFlyingDirection(initialDirection + new Vector2(X, Y));
    }
    private float CurrentTime => Time.time - initialTime;
    private float X => radius * Mathf.Cos(CurrentTime * spinRate * Mathf.PI + Mathf.Deg2Rad * initialAngle);
    private float Y => radius * Mathf.Sin(CurrentTime * spinRate * Mathf.PI + Mathf.Deg2Rad * initialAngle);

}
