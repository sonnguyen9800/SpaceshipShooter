using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnDead : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    private Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += TriggerExplosion;
    }
    private void TriggerExplosion()
    {
        GameObject fx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(fx, 1f);
    }
}