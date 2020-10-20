using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "CharacterStat")]
public class CharacterStat : ScriptableObject
{
    [SerializeField]
    private int health = 100;
    public int Health => health;
    [SerializeField]
    private int life = 1;
    public int Life => life;
    [SerializeField]
    private float moveSpeed = 2;
    public float MoveSpeed => moveSpeed;
    [SerializeField]
    private int damageBoost = 0;
    public int DamageBoost => damageBoost;

}
public interface IHealth
{
    int MaxHP { get; set; }
}
public interface IMoveSpeed
{
    float MoveSpeed { get; set; }
}
public interface IDamageBoost
{
    int DamageBoost { get; set; }
}
public interface ILife
{
    int Life { get; set; }
}
