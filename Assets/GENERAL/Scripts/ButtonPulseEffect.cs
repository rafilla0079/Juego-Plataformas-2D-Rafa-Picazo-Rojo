using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems; // Para detectar el ratón

public class ButtonPulseEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Configuración del Pulso")]
    [SerializeField] private float pulseScale = 1.25f; 
    [SerializeField] private float duration = 0.2f;    

    private Vector3 originalScale;
    private Coroutine pulseCoroutine;

    void Start()
    {
        
        originalScale = transform.localScale;
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (pulseCoroutine != null) StopCoroutine(pulseCoroutine);
        pulseCoroutine = StartCoroutine(ScaleRoutine(originalScale * pulseScale));
    }

    // Cuando el ratón sale, el botón vuelve a su tamaño original
    public void OnPointerExit(PointerEventData eventData)
    {
        if (pulseCoroutine != null) StopCoroutine(pulseCoroutine);
        pulseCoroutine = StartCoroutine(ScaleRoutine(originalScale));
    }

    private IEnumerator ScaleRoutine(Vector3 targetScale)
    {
        float elapsed = 0f;
        Vector3 startingScale = transform.localScale;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            
            transform.localScale = Vector3.Lerp(startingScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}