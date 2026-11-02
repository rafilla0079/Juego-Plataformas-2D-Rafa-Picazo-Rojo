using System.Collections;
using UnityEngine;

public class PlayerDamageEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    [Header("Efecto Visual (Parpadeo)")]
    [SerializeField] private Color damageColor = Color.red; 
    [SerializeField] private float flashDuration = 0.15f;   
    [SerializeField] private int numberOfFlashes = 3;       

    [Header("Efecto de Sonido")]
    [SerializeField] private AudioSource audioSource;       // El componente que reproduce el audio
    [SerializeField] private AudioClip damageSound;         

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    
    public void TriggerDamageEffect()
    {
        
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        // 2. Activar el parpadeo visual
        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRoutine());
        }
    }

    private IEnumerator FlashRoutine()
    {
        Color originalColor = spriteRenderer.color;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}