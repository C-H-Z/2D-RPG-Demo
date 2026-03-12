using UnityEngine;

public class SpriteFlashURP : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    [Header("…¡∫Ï…Ë÷√")]
    public Color flashColor = Color.red;
    public float flashDuration = 0.2f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    private System.Collections.IEnumerator FlashRoutine()
    {
       
        spriteRenderer.color = flashColor;

        
        yield return new WaitForSeconds(flashDuration);

        
        spriteRenderer.color = originalColor;
    }

    
    public void Flash(float intensity, Color color)
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine(intensity, color));
    }

    private System.Collections.IEnumerator FlashRoutine(float intensity, Color color)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(flashDuration * intensity);
        spriteRenderer.color = originalColor;
    }
}