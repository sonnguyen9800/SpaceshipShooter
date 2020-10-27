using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageBooster))]
public class ShooterManager : MonoBehaviour
{
    [SerializeField]
    private float baseCooldown;
    private float cooldown = 0;
    private float cooldownReduction = 0;
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
    public void ApplyCooldownReduction(float cooldownReduction)
    {
        this.cooldownReduction = cooldownReduction;
    }

    private void Update()
    {
        CooldownTick();
        if (!ConditionMet()) return;
        foreach (var shootComponent in shootComponents)
        {
            shootComponent.Shoot();
        }
        cooldown = baseCooldown * (1 - cooldownReduction);
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
    public void DisableAllShootComponent()
    {
        for (int i = 0; i < ShootComponentCount; i++)
        {
            shootComponents[i].IsActive = false;

        }
    }
    public void EnableShootComponent(int index)
    {
        shootComponents[Mathf.Min(ShootComponentCount - 1, index)].IsActive = true;
    }
    public void SetShootComponentProjectile(int index, ProjectileType type)
    {
        shootComponents[Mathf.Min(ShootComponentCount - 1, index)].ProjectileType = type;
    }
    public int ShootComponentCount => shootComponents.Length;
}
