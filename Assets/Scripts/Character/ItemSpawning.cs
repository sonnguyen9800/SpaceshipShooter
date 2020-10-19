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
        int indexDrop = Random.Range(0, 10); if (indexDrop > this.rateToSpawn) return;
        int index = Random.Range(0, this.itemList.Count);
        GameObject item = Instantiate(itemList[index], transform.position, transform.rotation);

        Item itemProperty = item.GetComponent<Item>();
        itemProperty.SetItemType(this.GetItemByIndex(index));
        


    }

    ItemType GetItemByIndex(int number)
    {
        switch(number){
            case 0: return ItemType.HPPack;
            case 1: return ItemType.PowerPack;
            case 2: return ItemType.ShieldPack;
        }
        return ItemType.HPPack; // Default
    }
}
