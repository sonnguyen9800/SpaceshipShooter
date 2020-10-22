using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        float duration = ps.main.duration;
        Debug.Log(duration);
        Destroy(gameObject, duration);
    }
}
