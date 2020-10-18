using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    private Health health;
    [SerializeField]
    private Image healthBar;
    public Health Health { get => health; set => health = value; }

    private void Start()
    {
        health = Player.Instance.Health;
        health.OnHealthChanged += UpdateHealthBar;
    }
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health.Percentage;
    }
    private void OnDestroy()
    {
        health.OnHealthChanged -= UpdateHealthBar;
    }
}
