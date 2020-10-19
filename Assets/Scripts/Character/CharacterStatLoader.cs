using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatLoader : MonoBehaviour
{
    [SerializeField]
    private CharacterStat stat;
    private void Awake()
    {
        IHealth health = GetComponent<IHealth>();
        if (health != null) health.MaxHP = stat.Health;
        ILife life = GetComponent<ILife>();
        if (life != null) life.Life = stat.Life;
        IDamageBoost damageBoost = GetComponent<IDamageBoost>();
        if (damageBoost != null) damageBoost.DamageBoost = stat.DamageBoost;
        IMoveSpeed moveSpeed = GetComponent<IMoveSpeed>();

    }
}
