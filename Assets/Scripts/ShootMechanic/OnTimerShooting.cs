using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimerShooting : MonoBehaviour
{
    [SerializeField]
    private float baseCooldown;
    private float cooldown = 0;
    [SerializeField]
    private ShootComponent[] shootComponents;
    private void Awake()
    {
        foreach (ShootComponent shootComponent in shootComponents)
        {
            shootComponent.SetOwnerType(GetComponent<ICharacter>().GetCharacterType());
        }
    }
    private void Update()
    {
        // Not on cooldown
        if (cooldown <= 0)
        {
            foreach (ShootComponent shootComponent in shootComponents)
            {
                shootComponent.Shoot();
            }
            cooldown = baseCooldown;
            return;
        }
        // On cooldown
        cooldown -= Time.deltaTime;
    }
}
