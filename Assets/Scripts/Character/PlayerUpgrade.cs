using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour, IUpgradeComponent
{
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private ShooterManager primaryShootManager;
    private void Start()
    {
        ProcessLevelPower();
    }
    public void Upgrade()
    {
        level++;
        ProcessLevelPower();
    }
    private void ProcessLevelPower()
    {
        primaryShootManager.DisableAllShootComponent();
        for (int i = 0; i < Mathf.Min(primaryShootManager.ShootComponentCount, level); i++)
        {
            primaryShootManager.EnableShootComponent(i);
        }
    }
}
