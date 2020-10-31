using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(CharacterStatLoader))]
public class Health : MonoBehaviour
{
    [Header("Default - without stat loader")]
    [SerializeField]
    private float maxHP = 200f;
    [Header("Default - without stat loader")]
    [SerializeField]
    private int life = 1;
    private float currentHP;
    public float MaxHP { get => maxHP; set => maxHP = value; }
    public int Life { get => life; set => life = value; }
    public Action OnLifeChanged { get; set; }
    public Action OnHealthChanged { get; set; }
    public Action<float> OnDamageTaken = delegate { };
    public Action<float> OnHeal = delegate { };
    public Action OnDead = delegate { };
    private bool isAlive = true;
    private void Start()
    {
        ResetHP();
    }
    private void Update()
    {
        if (currentHP <= 0) ReduceLife();
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
    private void ReduceLife()
    {
        Life--;
        OnLifeChanged?.Invoke();
        if (Life > 0)
        {
            ResetHP();
        }
        else
        {
            Die();
        }
    }
    private void ResetHP()
    {
        currentHP = maxHP;
        OnHealthChanged?.Invoke();
    }
    private void ClampHP()
    {
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
    public void Die()
    {
        if(!isAlive) return;
        OnDead?.Invoke();
        isAlive = false;
    }
    public float Percentage => currentHP / maxHP;


}
