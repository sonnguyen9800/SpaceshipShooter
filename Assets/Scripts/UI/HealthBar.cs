using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private Image healthBar;
    private void Awake()
    {
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
