using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CircularMotion")]
[System.Serializable]
public class CircularMotion : ScriptableObject
{
    public enum SpinDirection
    {
        Clockwise = -1,
        AntiClockwise = 1
    }
    [SerializeField]
    private SpinDirection spinDirection = SpinDirection.Clockwise;
    [SerializeField]
    private float initialAngle = -90;
    [SerializeField]
    private float radius = 1;
    [SerializeField]
    private float spinRate = 2;
    public int DirectionMultiplier => (int)spinDirection;
    public float InitialAngle => initialAngle;
    public float Radius => radius;
    public float SpinRate => spinRate;
}
