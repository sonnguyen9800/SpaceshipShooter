using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;
    [SerializeField]
    private Transform shootTransform;
    public void Shoot()
    {
        Projectile p = Instantiate(projectile, shootTransform.position, shootTransform.rotation);
        p.SetFlyingDirection(shootTransform.up);
        p.SetOwner(GetComponent<ICharacter>().GetCharacterType());
    }
}
