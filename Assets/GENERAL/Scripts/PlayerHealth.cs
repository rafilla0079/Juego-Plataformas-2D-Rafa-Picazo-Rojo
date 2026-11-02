using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;

    [Header("Configuración de Escena de Derrota")]
    [SerializeField] private string gameOverSceneName = "GameOverScene"; 

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
 
    // Método para restar vida
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Carga la escena de Game Over cuando la vida llega a 0
        SceneManager.LoadScene(gameOverSceneName);
    }

    // Detectar colisión con los Pinchos (Trampas) mediante Colisión física
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(1);
        }
    }

    // Detectar si choca con una bala del enemigo o cae al vacío (DeadZone)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("DeadZone"))
        {
            // Si cae al vacío, va directo al Game Over sin importar la vida restante
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}