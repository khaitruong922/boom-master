using UnityEngine;

public class ColorFlash : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float duration = 0.2f;
    private float durationLeft;
    private bool isOriginalColor;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    private void Update()
    {
        if (isOriginalColor) return;
        if (durationLeft > 0)
        {
            durationLeft -= Time.deltaTime;
            return;
        }
        Reset();
    }
    public void Flash()
    {
        spriteRenderer.color = flashColor;
        isOriginalColor = false;
        durationLeft = duration;
    }
    private void Reset()
    {
        spriteRenderer.color = originalColor;
        isOriginalColor = true;
        durationLeft = 0;
    }
}
