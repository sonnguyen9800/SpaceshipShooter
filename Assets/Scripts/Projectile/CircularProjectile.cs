using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class CircularProjectile : MonoBehaviour
{
    private Projectile projectile;
    public CircularMotion Motion { get; set; }
    private float initialTime;
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
    }
    private void Start()
    {
        initialTime = Time.time;
    }
    private void Update()
    {
        projectile.AdditionalDirection = new Vector2(X, Y);
    }
    private float CurrentTime => Time.time - initialTime;
    private float CurrentAngle => CurrentTime * Motion.SpinRate * Mathf.PI + Mathf.Deg2Rad * Motion.InitialAngle;
    private float X => Motion.Radius * Mathf.Cos(CurrentAngle);
    private float Y => Mathf.Abs(Motion.Radius * Mathf.Sin(CurrentAngle));
}
