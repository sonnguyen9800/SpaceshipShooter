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
    private Health health;
    private MoveComponent moveComponent;
    private DamageBooster damageBooster;
    private void Start()
    {
        Player player = Player.Instance;
        health = player.GetComponent<Health>();
        moveComponent = player.GetComponent<MoveComponent>();
        damageBooster = player.GetComponent<DamageBooster>();

        health.OnHealthChanged += UpdateHealthBar;
        health.OnLifeChanged += UpdateLifeText;
        moveComponent.OnMoveSpeedChanged += UpdateMoveSpeedText;
        damageBooster.OnDamageBoostChanged += UpdateDamageBoostText;
        UpdateAll();
    }

    private void UpdateAll()
    {
        UpdateDamageBoostText();
        UpdateMoveSpeedText();
        UpdateLifeText();
        UpdateHealthBar();
    }

    private void UpdateDamageBoostText()
    {
        damageBoostText.SetText(String.Format("Damage: +{0}%", damageBooster.DamageBoost.ToString()));
    }

    private void UpdateMoveSpeedText()
    {
        moveSpeedText.SetText(String.Format("Speed: {0}", moveComponent.MoveSpeed.ToString()));
    }

    private void UpdateLifeText()
    {
        lifeText.SetText(String.Format("Life: {0}", health.Life.ToString()));
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
    }
}
