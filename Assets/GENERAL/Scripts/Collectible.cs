using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip collectSound;
    [SerializeField] [Range(0f, 1f)] private float soundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reproduce el sonido en la posición actual de la cámara o del mundo antes de destruir el objeto
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, soundVolume);
            }

            // Destruye el coleccionable de la escena
            Destroy(gameObject);
        }
    }
}