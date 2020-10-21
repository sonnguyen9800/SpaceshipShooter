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
    private ShooterManager primaryShootManager;
    private void Start()
    {
        OnLevelChanged += ProcessLevelPower;
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
        ProcessPrimaryShootManager();
    }
    private void ProcessPrimaryShootManager()
    {
        primaryShootManager.DisableAllShootComponent();
        for (int i = 0; i < Mathf.Min(primaryShootManager.ShootComponentCount, level); i++)
        {
            primaryShootManager.EnableShootComponent(i);
        }
    }
    private void OnDestroy()
    {
        OnLevelChanged -= ProcessLevelPower;
    }
}
