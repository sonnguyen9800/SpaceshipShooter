using System.Collections;
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
        return itemDrops[0].Item;
    }
}
