using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ItemFactory itemFactory;
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += DropItem;
    }

    private void DropItem()
    {
        GameObject g = itemFactory.GetRandomItem();
        if (g == null) return;
        Instantiate(g, transform.position, transform.rotation);
    }
    private void OnDestroy()
    {
        health.OnDead -= DropItem;
    }
}
