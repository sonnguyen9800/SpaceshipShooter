using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> itemList;
    [SerializeField] int rateToSpawn;
    private Health health ;

    void Awake(){
        health = GetComponent<Health>();
    }

    void Start()
    {
        health.OnDead += DropItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropItem(){
        int indexDrop = Random.Range(0, 10); Debug.Log("Value Index" + indexDrop); if (indexDrop > this.rateToSpawn) return;
        int index = Random.Range(0, this.itemList.Count);
        GameObject item = Instantiate(itemList[index], transform.position, transform.rotation);
    }
}
