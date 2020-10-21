using System.Collections.Generic;
using UnityEngine;
public class ItemSpawning : MonoBehaviour
{
    [SerializeField] private ItemFactory itemFactory;
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += DropItem;
    }

    private void DropItem()
    {
        List<GameObject> items = itemFactory.GetRandomItems();
        if (items == null || items.Count == 0) return;
        foreach (GameObject item in items)
        {
            GameObject g = Instantiate(item, transform.position, transform.rotation);
            Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-1.5f, 1.5f), 0), ForceMode2D.Impulse);
        }

    }
    private void OnDestroy()
    {
        health.OnDead -= DropItem;

    }
}
