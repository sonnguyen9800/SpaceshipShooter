using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private float speedRotate = 200f;
    void Update()
    {
        transform.Rotate(0, 0, speedRotate * Time.deltaTime);
    }
}
