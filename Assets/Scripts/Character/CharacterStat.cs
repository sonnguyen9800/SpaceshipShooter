using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "CharacterStat")]
public class CharacterStat : ScriptableObject
{
    [SerializeField]
    private float health = 100;
    public float Health => health;
    [SerializeField]
    private int life = 1;
    public int Life => life;
    [SerializeField]
    private float moveSpeed = 2;
    public float MoveSpeed => moveSpeed;
    [SerializeField]
    private float damageBoost = 0;
    public float DamageBoost => damageBoost;

}
public interface IHealth
{
    float MaxHP { get; set; }
}
public interface IMoveSpeed
{
    float MoveSpeed { get; set; }
}
public interface IDamageBoost
{
    float DamageBoost { get; set; }
}
public interface ILife
{
    int Life { get; set; }
}
