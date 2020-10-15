using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour, ICharacter
{
    private Health health;
    [SerializeField] private GameObject explodingGameObject;
    public CharacterType GetCharacterType()
    {
        return CharacterType.ENEMY;
    }
    void Awake()
    {   
        health = GetComponent<Health>();
        health.OnDead += Die;
    }
    void Update()
    {

    }
    private void Die()
    {
        Debug.Log("Enemy Die");
        GameObject exploding = Instantiate(explodingGameObject, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
