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
        OnHealthChanged?.Invoke();
    }
    public void Die()
    {
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;
}
