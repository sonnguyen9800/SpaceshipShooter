using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    private Health health;
    public CharacterType GetCharacterType()
    {
        return CharacterType.ENEMY;
    }

    // Start is called before the first frame update
    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += Die;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
