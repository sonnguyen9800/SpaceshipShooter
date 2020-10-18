using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class CircularProjectile : MonoBehaviour
{
    private Projectile projectile;
    public Vector2 InitialDirection { get; private set; }
    public CircularMotion Motion { get; set; }
    private float initialTime;
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        InitialDirection = projectile.InitialDirection;
        print(InitialDirection);
    }
    private void Start()
    {
        initialTime = Time.time;
    }
    private void Update()
    {
        projectile.SetDirection(InitialDirection + new Vector2(X, Y));
    }
    private float CurrentTime => Time.time - initialTime;
    private float CurrentAngle => CurrentTime * Motion.SpinRate * Mathf.PI * Motion.DirectionMultiplier + Mathf.Deg2Rad * Motion.InitialAngle;
    private float X => Motion.Radius * Mathf.Cos(CurrentAngle);
    private float Y => Mathf.Abs(Motion.Radius * Mathf.Sin(CurrentAngle));

}
