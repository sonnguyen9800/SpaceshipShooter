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
        // GameObject g = itemFactory.GetRandomItem();
        // if (g == null) return;
        // Instantiate(g, transform.position, transform.rotation);

        List<GameObject> items = itemFactory.GetRandomItems();
        if (items == null || items.Count == 0) return;
        foreach (GameObject item in items){
            GameObject i =  Instantiate(item, transform.position, transform.rotation );
            Rigidbody2D body = i.GetComponent<Rigidbody2D>();
            body.AddForce(new Vector2(Random.Range(-1f,1f), 0), ForceMode2D.Impulse);
        }
    }
    private void OnDestroy()
    {
        health.OnDead -= DropItem;
    }
}
