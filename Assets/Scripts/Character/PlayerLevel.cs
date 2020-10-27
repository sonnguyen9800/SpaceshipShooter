using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerLevel : MonoBehaviour, IUpgradeComponent
{
    [SerializeField]
    private int level = 1;
    public int Level => level;
    public Action OnLevelChanged { get; set; }
    [SerializeField]
    private ShooterManager left;
    [SerializeField]
    private ShooterManager right;
    private void Start()
    {
        OnLevelChanged += ProcessLevelPower;
        left.DisableAllShootComponent();
        right.DisableAllShootComponent();
        ProcessLevelPower();
    }
    public void Upgrade()
    {
        LevelUp();
    }
    public void LevelUp()
    {
        level++;
        OnLevelChanged?.Invoke();
    }
    private void ProcessLevelPower()
    {
        if (level == 1)
        {
            left.EnableShootComponent(0);
            right.EnableShootComponent(0);
            return;
        }
        if (level == 2)
        {
            left.EnableShootComponent(1);
            return;
        }
        if (level == 3)
        {
            left.EnableShootComponent(2);

            return;
        }
        if (level == 4)
        {
            right.EnableShootComponent(1);
            right.EnableShootComponent(2);
            return;
        }
        if (level == 5)
        {
            right.EnableShootComponent(3);
            right.EnableShootComponent(4);
            return;
        }
        if (level == 6)
        {
            right.EnableShootComponent(5);
            right.EnableShootComponent(6);
            return;
        }
        if (level == 7)
        {
            left.ApplyCooldownReduction(0.1f);
            right.ApplyCooldownReduction(0.1f);
            return;
        }
        if (level == 8)
        {
            left.ApplyCooldownReduction(0.2f);
            right.ApplyCooldownReduction(0.2f);
            return;
        }
        if (level == 9)
        {
            left.ApplyCooldownReduction(0.3f);
            right.ApplyCooldownReduction(0.3f);
            return;
        }
        if (level == 10)
        {
            left.SetShootComponentProjectile(0, ProjectileType.PlayerLeftS1);
            return;
        }
        if (level == 11)
        {
            left.SetShootComponentProjectile(1, ProjectileType.PlayerLeftS1);
            left.SetShootComponentProjectile(2, ProjectileType.PlayerLeftS1);
            return;
        }
        if (level == 12)
        {
            right.SetShootComponentProjectile(0, ProjectileType.PlayerRightS1);
            return;
        }
        if (level == 13)
        {
            right.SetShootComponentProjectile(1, ProjectileType.PlayerRightS1);
            right.SetShootComponentProjectile(2, ProjectileType.PlayerRightS1);
            return;
        }
        if (level == 14)
        {
            right.SetShootComponentProjectile(3, ProjectileType.PlayerRightS1);
            right.SetShootComponentProjectile(4, ProjectileType.PlayerRightS1);
            return;
        }
        if (level == 15)
        {
            right.SetShootComponentProjectile(5, ProjectileType.PlayerRightS1);
            right.SetShootComponentProjectile(6, ProjectileType.PlayerRightS1);
            return;
        }
    }
    private void OnDestroy()
    {
        OnLevelChanged -= ProcessLevelPower;
    }

}
