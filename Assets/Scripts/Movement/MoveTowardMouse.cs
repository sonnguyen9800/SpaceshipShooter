using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MoveComponent))]
public class MoveTowardMouse : MonoBehaviour
{
    private MoveComponent moveComponent;

    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    private void FixedUpdate()
    {
        moveComponent.MoveToward(MouseLocator.Position);
    }
}
