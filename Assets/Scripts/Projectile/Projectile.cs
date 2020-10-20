using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 2.0f;
    private Rigidbody2D rb;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    public CharacterType OwnerType { get; set; }
    public Vector2 InitialDirection { get; set; }
    public Vector2 AdditionalDirection { get; set; }
    public float DamageBoost { get; set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    private Vector2 Direction => InitialDirection + AdditionalDirection;
    private void Update()
    {
        rb.velocity = Direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null) return;
        ICharacter character = other.GetComponent<ICharacter>();
        if (character == null) return;
        if (OwnerType == character.GetCharacterType()) return;
        health.TakeDamage(TotalDamage);
        print(TotalDamage);
        Destroy(gameObject);
    }
    private float TotalDamage => damage * (100 + DamageBoost) / 100;
}
