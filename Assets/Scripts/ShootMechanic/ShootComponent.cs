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
        OnProjectileShoot?.Invoke(p);
    }
}
