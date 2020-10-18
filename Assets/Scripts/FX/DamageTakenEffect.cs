using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach it to game object, check if bullet hit to flash the object
public class DamageTakenEffect : MonoBehaviour
{
    [SerializeField]
    private float flashTime = 0.1f;
    private Color originalColor;
    private Health health;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    [SerializeField] private Color flashColor;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        health = GetComponent<Health>();
        health.OnDamageTaken += Flash;
    }
    private void Flash(float damage)
    {
        // Show damage popup
        StartCoroutine(Flashing());
    }

    private IEnumerator Flashing()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        ResetColor();
    }

    void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }
    private void OnDestroy()
    {
        health.OnDamageTaken -= Flash;
    }

}
