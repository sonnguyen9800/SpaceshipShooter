using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    // Set maximum life point to 1000
    [SerializeField] private int maxLifePoint = 1000;

    // Important Attributes

    // Life Point - Die if this becomes 0
    [SerializeField] private int lifepoint;
    [SerializeField] private int armor;
    [SerializeField] private float fireRate;
    private void Update()
    {
    }
}
