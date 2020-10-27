using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectilePool")]
[System.Serializable]
public class ProjectilePoolerProperties : ScriptableObject
{
    [System.Serializable]
    public class Pool
    {
        [SerializeField]
        private ProjectileType type;

        public ProjectileType Type => type;
        [SerializeField]
        private Projectile projectile;
        public Projectile Projectile => projectile;
        [SerializeField]
        private int initialCount;
        public int InitialCount => initialCount;
    }

    [SerializeField]
    private Pool[] pools;
    public Pool[] Pools => pools;
}
