using UnityEngine;
public class Enemy : MonoBehaviour, ICharacter
{
    private Health health;

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
        Destroy(gameObject);
    }
}
