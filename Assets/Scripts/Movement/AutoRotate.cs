using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 200f;
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
