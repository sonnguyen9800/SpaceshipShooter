using UnityEngine;

public class Projectile : MonoBehaviour, ICollideBoundary
{
    [SerializeField]
    private float lifetime = 2.0f;
    private Rigidbody2D rb;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    private float elapsed;
    public CharacterType OwnerType { get; private set; }
    public Vector2 InitialDirection { get; private set; }
    public float DamageBoost { get; private set; }
    public ProjectileType ProjectileType { get; private set; }
    public Vector2 AdditionalDirection { get; set; }
    public ProjectilePooler Pooler { get; private set; }

    public class Settings
    {
        public CharacterType OwnerType { get; set; }
        public Vector2 InitialDirection { get; set; }
        public float DamageBoost { get; set; }
        public ProjectileType ProjectileType { get; set; }
        public ProjectilePooler Pooler { get; set; }
    }
    public void LoadFromSettings(Projectile.Settings settings)
    {
        InitialDirection = settings.InitialDirection;
        OwnerType = settings.OwnerType;
        DamageBoost = settings.DamageBoost;
        ProjectileType = settings.ProjectileType;
        Pooler = settings.Pooler;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private Vector2 Direction => (InitialDirection + AdditionalDirection).normalized;
    private void OnEnable()
    {
        elapsed = 0f;
    }
    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > lifetime)
        {
            ReturnToPool();
            return;
        }
        rb.velocity = Direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null) return;
        ICharacter character = other.GetComponent<ICharacter>();
        if (character == null) return;
        if (OwnerType == character.CharacterType) return;
        health.TakeDamage(TotalDamage);
        // print(TotalDamage);
        ReturnToPool();
    }
    private void ReturnToPool()
    {
        Pooler.ReturnToPool(this);
    }

    public void OnCollisionWithBoundary()
    {
        ReturnToPool();
    }

    private float TotalDamage => damage * (100 + DamageBoost) / 100;
}
