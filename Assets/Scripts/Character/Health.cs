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
    public float GetHealthPercentage()
    {
        return currentHP / maxHP;
    }

    public float getHealth(){
        return this.currentHP;
    }
}
