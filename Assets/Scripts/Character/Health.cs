using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 200f;
    private float currentHP;
    public Action OnHealthChanged = delegate { };
    public Action<float> OnDamageTaken = delegate { };
    public Action<float> OnHeal = delegate { };
    public Action OnDead = delegate { };
    private void Awake()
    {
        currentHP = maxHP;
    }
    private void Start()
    {
        OnHealthChanged?.Invoke();
    }
    private void Update()
    {
        if (currentHP <= 0) Die();
    }
    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        ClampHP();
        OnDamageTaken?.Invoke(amount);
        OnHealthChanged?.Invoke();
    }
    public void Heal(float amount)
    {
        currentHP += amount;
        ClampHP();
        OnHeal?.Invoke(amount);
        OnHealthChanged?.Invoke();
    }
    private void ClampHP()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    public void Die()
    {
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;
}
