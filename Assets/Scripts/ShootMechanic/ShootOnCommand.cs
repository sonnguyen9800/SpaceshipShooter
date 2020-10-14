using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnCommand : MonoBehaviour
{
    [SerializeField]
    private float baseCooldown;
    private float cooldown = 0;
    [SerializeField]
    private KeyCode shootKey;
    [SerializeField]
    private ShootComponent[] shootComponents;
    private void Awake()
    {
        foreach (ShootComponent shootComponent in shootComponents)
        {
            shootComponent.SetOwnerType(GetComponent<ICharacter>().GetCharacterType());
            print(gameObject.name);
        }
    }
    private void Update()
    {
        // Not on cooldown
        if (cooldown <= 0)
        {
            if (Input.GetKey(shootKey))
            {
                foreach (ShootComponent shootComponent in shootComponents)
                {
                    shootComponent.Shoot();
                }
                cooldown = baseCooldown;
            }
            return;
        }
        // On cooldown
        cooldown -= Time.deltaTime;
    }
}
