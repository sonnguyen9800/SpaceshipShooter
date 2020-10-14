using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimerShooting : MonoBehaviour
{
    [SerializeField]
    private float baseCooldown;
    private float cooldown = 0;
    [SerializeField]
    private ShootComponent shootComponent;
    private void Update()
    {
        // Not on cooldown
        if (cooldown <= 0)
        {
            shootComponent.Shoot();
            cooldown = baseCooldown;
            return;
        }
        // On cooldown
        cooldown -= Time.deltaTime;
    }
}
