using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador toca la puerta
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                // Comprobamos si el jugador tiene la llave
                if (player.hasKey)
                {
                    Debug.Log("¡Llave usada! Puerta abierta.");
                    
                    
                    Destroy(gameObject); 
                }
                else
                {
                    Debug.Log("¡Necesitas la llave para abrir esta puerta!");
                }
            }
        }
    }
}