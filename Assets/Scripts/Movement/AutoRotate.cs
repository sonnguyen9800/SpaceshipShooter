using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedRotate = 200f;
    private GameObject owner; // Refer to the game object that has this scriptXS
    void Start()
    {
        // Get the parent game object
       owner =  transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,speedRotate*Time.deltaTime);
    }
}
