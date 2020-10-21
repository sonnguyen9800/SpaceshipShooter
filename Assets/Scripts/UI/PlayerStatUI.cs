using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerStatUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI damageBoostText;
    [SerializeField] private TextMeshProUGUI moveSpeedText;
    [SerializeField] private TextMeshProUGUI levelText;

    private Health health;
    private MoveComponent moveComponent;
    private DamageBooster damageBooster;
    private PlayerLevel playerLevel;
    private void Start()
    {
        Player player = Player.Instance;
        health = player.GetComponent<Health>();
        moveComponent = player.GetComponent<MoveComponent>();
        damageBooster = player.GetComponent<DamageBooster>();
        playerLevel = player.GetComponent<PlayerLevel>();

        health.OnHealthChanged += UpdateHealthBar;
        health.OnLifeChanged += UpdateLifeText;
        moveComponent.OnMoveSpeedChanged += UpdateMoveSpeedText;
        damageBooster.OnDamageBoostChanged += UpdateDamageBoostText;
        playerLevel.OnLevelChanged += UpdateLevelText;
        UpdateAll();
    }

    private void UpdateAll()
    {
        UpdateDamageBoostText();
        UpdateMoveSpeedText();
        UpdateLifeText();
        UpdateHealthBar();
        UpdateLevelText();
    }
    private void UpdateLevelText()
    {
        levelText.SetText(playerLevel.Level.ToString());
    }

    private void UpdateDamageBoostText()
    {
        damageBoostText.SetText(String.Format("Damage: +{0}%", damageBooster.DamageBoost.ToString()));
    }

    private void UpdateMoveSpeedText()
    {
        moveSpeedText.SetText(String.Format("Speed: {0:0.00}", moveComponent.MoveSpeed));
    }

    private void UpdateLifeText()
    {
        lifeText.SetText(String.Format("Life: {0}", (int)health.Life));
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health.Percentage;
    }
    private void OnDestroy()
    {
        health.OnHealthChanged -= UpdateHealthBar;
        health.OnLifeChanged -= UpdateLifeText;
        moveComponent.OnMoveSpeedChanged -= UpdateMoveSpeedText;
        damageBooster.OnDamageBoostChanged -= UpdateDamageBoostText;
        playerLevel.OnLevelChanged -= UpdateLevelText;
    }
}
