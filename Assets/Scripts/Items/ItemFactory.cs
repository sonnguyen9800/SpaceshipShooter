using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ItemFactory", fileName = "ItemFactory")]
public class ItemFactory : ScriptableObject
{
    [System.Serializable]
    private class ItemDrop
    {
        [SerializeField]
        private GameObject item;
        public GameObject Item => item;
        [SerializeField]
        private float dropRate;
        public float DropRate => dropRate;


    }

    [SerializeField]
    private ItemDrop[] itemDrops;

    public GameObject GetRandomItem()
    {   
        float randomRate = Random.Range(0f, 1f);
        return itemDrops[0].Item;
    }

    public List<GameObject> GetRandomItems(){
        List<GameObject> spawnedObject = new List<GameObject>();
        for (int i = 0; i < itemDrops.Length; i++){
            float randomResult = Random.Range(0f, 1f);
            if (randomResult < itemDrops[i].DropRate){
                spawnedObject.Add(itemDrops[i].Item);
            }
        }   
        return spawnedObject;
    }
}
