using UnityEngine;
using UnityEditor;
using System;

public class Item : MonoBehaviour
{
    private float lifeTime = 4.0f;
    public Action<Collider2D> OnPick = delegate { };
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICharacter character = other.GetComponent<Player>();
        if (character == null) return;
        OnPick?.Invoke(other);
        Destroy(gameObject);
    }
}