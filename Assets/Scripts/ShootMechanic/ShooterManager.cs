using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    [SerializeField]
    private float baseCooldown;
    private float cooldown = 0;
    [SerializeField]
    private ShootComponent[] shootComponents;
    [SerializeField]
    private ShootCondition[] shootConditions;
    private void Awake()
    {
        foreach (ShootComponent shootComponent in shootComponents)
        {
            shootComponent.OwnerType = GetComponent<ICharacter>().GetCharacterType();
        }
    }
    private void Update()
    {
        CooldownTick();
        if (!ConditionMet()) return;
        foreach (ShootComponent shootComponent in shootComponents)
        {
            shootComponent.Shoot();
        }
        cooldown = baseCooldown;
    }
    private bool IsOnCooldown => cooldown > 0;
    private void CooldownTick()
    {
        if (IsOnCooldown) cooldown -= Time.deltaTime;
    }
    private bool ConditionMet()
    {
        if (IsOnCooldown) return false;
        foreach (var shootCondition in shootConditions)
        {
            if (!shootCondition.IsSatisfied()) return false;
        }
        return true;
    }
}
