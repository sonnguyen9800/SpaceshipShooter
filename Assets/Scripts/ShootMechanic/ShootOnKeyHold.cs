using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootOnKeyHold : ShootCondition
{

    [SerializeField]
    private KeyCode keyCode = KeyCode.Mouse0;

    public override bool IsSatisfied() => Input.GetKey(keyCode);
}
