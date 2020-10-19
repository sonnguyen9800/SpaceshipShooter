using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> itemList;
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

        int index = Random.Range(0, this.itemList.Count);
        GameObject item = Instantiate(itemList[index], transform.position, transform.rotation);
    }
}
