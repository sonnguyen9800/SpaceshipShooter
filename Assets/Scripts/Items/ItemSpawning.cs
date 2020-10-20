using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> itemList;
    [SerializeField] int rateToSpawn;
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += DropItem;
    }

    private void DropItem()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > rateToSpawn) return;
        int randomIndex = Random.Range(0, itemList.Count);
        Instantiate(itemList[randomIndex], transform.position, transform.rotation);
    }
    private void OnDestroy()
    {
        health.OnDead -= DropItem;
    }
}
