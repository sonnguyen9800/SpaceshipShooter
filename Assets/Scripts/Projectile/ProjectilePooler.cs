using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{

    [SerializeField]
    private ProjectilePoolerProperties properties;
    private Dictionary<ProjectileType, Queue<Projectile>> poolDictionary;
    private Dictionary<ProjectileType, Projectile> projectileDictionary;
    public static ProjectilePooler Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        projectileDictionary = new Dictionary<ProjectileType, Projectile>();
        poolDictionary = new Dictionary<ProjectileType, Queue<Projectile>>();
        foreach (var pool in properties.Pools)
        {
            projectileDictionary.Add(pool.Type, pool.Projectile);
            Queue<Projectile> queue = new Queue<Projectile>();
            poolDictionary.Add(pool.Type, queue);
            AddToPool(pool.Type, pool.InitialCount);
            print(pool.InitialCount);
        }
    }
    public Projectile Get(ProjectileType type)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            Debug.Log("Pool of type " + type + " does not exist");
            return null;
        }
        Queue<Projectile> pool = poolDictionary[type];
        if (pool.Count == 0)
        {
            AddToPool(type);
        }
        return pool.Dequeue();
    }
    private void AddToPool(ProjectileType type, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Projectile p = Instantiate(projectileDictionary[type], transform);
            p.gameObject.SetActive(false);
            poolDictionary[type].Enqueue(p);
        }

    }
    public void ReturnToPool(Projectile p)
    {
        p.gameObject.SetActive(false);
        poolDictionary[p.ProjectileType].Enqueue(p);
    }
}
