using UnityEngine;
using System;
public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private ProjectileType projectileType;
    public float DamageBoost { get; set; }
    public CharacterType OwnerType { get; set; }
    private bool isActive = true;
    public bool IsActive { get => isActive; set => isActive = value; }
    public Action<Projectile> OnProjectileShoot = delegate { };
    public void Shoot()
    {
        if (!IsActive) return;
        Projectile p = ProjectilePooler.Instance.Get(projectileType);
        p.transform.position = transform.position;
        p.transform.rotation = transform.rotation;


        p.LoadFromSettings(new Projectile.Settings
        {
            InitialDirection = transform.up,
            OwnerType = this.OwnerType,
            DamageBoost = this.DamageBoost,
            ProjectileType = this.projectileType
        });
        p.gameObject.SetActive(true);

        if (this.projectileType == ProjectileType.PlayerBase){
            Debug.Log("Activate");
            Rigidbody2D Prb = p.GetComponent<Rigidbody2D>();
            Prb.AddForce(new Vector2(40000, 4000f), ForceMode2D.Impulse);

        }

        OnProjectileShoot?.Invoke(p);
    }
}
