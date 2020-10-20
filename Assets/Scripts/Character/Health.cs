using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(CharacterStatLoader))]
public class Health : MonoBehaviour, IHealth, ILife
{
    [SerializeField]
    private int maxHP = 200;
    [SerializeField]
    private int life = 1;
    private int currentHP;
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public int Life { get => life; set => life = value; }
    public Action OnLifeChanged = delegate { };
    public Action OnHealthChanged = delegate { };
    public Action<float> OnDamageTaken = delegate { };
    public Action<float> OnHeal = delegate { };
    public Action OnDead = delegate { };
    private void Start()
    {
        ResetHP();
    }
    private void Update()
    {
        if (currentHP <= 0) ReduceLife();
    }
    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        ClampHP();
        OnDamageTaken?.Invoke(amount);
        OnHealthChanged?.Invoke();
    }
    public void Heal(int amount)
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
        OnDead?.Invoke();
    }
    public float Percentage => currentHP / maxHP;

}
