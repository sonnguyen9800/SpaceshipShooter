using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocator : MonoBehaviour
{
    private static Camera cam;
    private static Vector3 offset;
    private void Awake()
    {
        cam = GetComponent<Camera>();
        offset = new Vector3(0, 0, cam.transform.position.z);
    }
    public static Vector3 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition) - offset;
    }
}
