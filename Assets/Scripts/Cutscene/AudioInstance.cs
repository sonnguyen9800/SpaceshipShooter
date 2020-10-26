
using UnityEngine;

public class AudioInstance : MonoBehaviour
{
     private static AudioInstance instance = null;
    public static AudioInstance Instance {
        get { return instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

     void Awake() {
     if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
     DontDestroyOnLoad(this.gameObject);
    }
}
