using UnityEngine;
public class Enemy : MonoBehaviour, ICharacter
{
    private Health health;

    public CharacterType CharacterType => CharacterType.Enemy;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += Die;
    }
    private void Update()
    {

    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
