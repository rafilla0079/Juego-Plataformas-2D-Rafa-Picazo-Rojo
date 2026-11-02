using System.Collections;
using UnityEngine;

public class DisappearingWall : MonoBehaviour
{
    [Header("Tiempos (Segundos)")]
    [SerializeField] private float timeVisible = 3f;   // Tiempo que la pared está activa
    [SerializeField] private float timeHidden = 2f;    // Tiempo que la pared está invisible

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // Obtenemos los componentes visuales y físicos de la pared
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Iniciamos el ciclo de parpadeo
        StartCoroutine(WallRoutine());
    }

    IEnumerator WallRoutine()
    {
        while (true)
        {
            
            SetWallState(true);
            yield return new WaitForSeconds(timeVisible);

            
            SetWallState(false);
            yield return new WaitForSeconds(timeHidden);
        }
    }

    void SetWallState(bool isActive)
    {
        if (spriteRenderer != null) spriteRenderer.enabled = isActive;
        if (boxCollider != null) boxCollider.enabled = isActive;
    }
}