using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageBooster))]
public class ShooterManager : MonoBehaviour
{
    [SerializeField]
    private float baseCooldown;
    private float cooldown = 0;
    private DamageBooster damageBooster;
    [SerializeField]
    private ShootComponent[] shootComponents;
    [SerializeField]
    private ShootCondition[] shootConditions;
    private void Awake()
    {
        foreach (var shootComponent in shootComponents)
        {
            shootComponent.OwnerType = GetComponent<ICharacter>().CharacterType;
        }
        damageBooster = GetComponent<DamageBooster>();
        damageBooster.OnDamageBoostChanged += OnDamageBoostChanged;
        // Fetch initial value
        OnDamageBoostChanged();
    }
    private void Update()
    {
        CooldownTick();
        if (!ConditionMet()) return;
        foreach (var shootComponent in shootComponents)
        {
            shootComponent.Shoot();
        }
        cooldown = baseCooldown;
    }
    private bool IsOnCooldown => cooldown > 0;
    private void OnDamageBoostChanged()
    {
        foreach (var shootComponent in shootComponents)
        {
            shootComponent.DamageBoost = damageBooster.DamageBoost;
        }
    }
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
    private void OnDestroy()
    {
        damageBooster.OnDamageBoostChanged -= OnDamageBoostChanged;
    }
}
