using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach it to game object, check if bullet hit to flash the object
public class DamageTakenEffect : MonoBehaviour
{
    public float flashTime;
    private Color originalColor;
    private Health health;
    private float lastHealth;
    private new SpriteRenderer renderer;
    // Start is called before the first frame update
    [SerializeField] private Color flashColor;
    void Start()
    {
        // Set default render and color
        renderer = GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
        health = GetComponent<Health>();
        lastHealth = health.getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.getHealth() < this.lastHealth){
            Debug.Log("Heal is reduced");
            this.lastHealth = health.getHealth();
            // Health is reduced -> Do animation
            StartCoroutine(Flash());
        }

    }

    private IEnumerator Flash(){
        renderer.color = this.flashColor;
        Invoke("ResetColor", flashTime);
        yield return null;
    }

     void ResetColor()
    {
      renderer.color = originalColor;
    }
    
}
