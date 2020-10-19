using UnityEngine;
using UnityEditor;
using System;

public class Item : MonoBehaviour
{
    private float lifeTime = 4.0f;
    private ItemType itemType;
    public Action<Collider2D> OnPick = delegate { };
    public void SetItemType(ItemType type) => this.itemType = type;
    public ItemType GetItemType() => this.itemType;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICharacter character = other.GetComponent<Player>();
        if (character == null) return;
        // Not null character
        OnPick?.Invoke(other);
        Destroy(gameObject);
    }
}