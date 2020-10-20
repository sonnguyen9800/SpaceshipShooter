using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatLoader : MonoBehaviour
{
    [SerializeField]
    private CharacterStat stat;
    private void Awake()
    {
        if (stat == null)
        {
            Debug.Log("<color=red>Error: </color>CharacterStat not found in GameObject:  " + name + ". Using default stat.");
            return;
        }
        Health health = GetComponent<Health>();
        if (health != null)
        {
            health.MaxHP = stat.Health;
            health.Life = stat.Life;
        }
        DamageBooster damageBooster = GetComponent<DamageBooster>();
        if (damageBooster != null) damageBooster.DamageBoost = stat.DamageBoost;
        MoveComponent moveComponent = GetComponent<MoveComponent>();
        if (moveComponent != null) moveComponent.MoveSpeed = stat.MoveSpeed;

    }
}
