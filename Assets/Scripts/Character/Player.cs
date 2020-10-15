using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    private Health health;
    [SerializeField] GameObject explosionVFX;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += Die;
    
    }
    public CharacterType GetCharacterType()
    {
        return CharacterType.PLAYER;
    }

    private void Die()
    {
        //gameObject.SetActive(false);
        StartCoroutine(triggerExplosion());
        print("Player die.");
    }

    private IEnumerator triggerExplosion(){
        GameObject game = Instantiate(explosionVFX, transform.position, transform.rotation);
        gameObject.SetActive(false);
        yield return null;
    }
}
