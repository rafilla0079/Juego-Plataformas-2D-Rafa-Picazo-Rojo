using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;
    
    [Header("UI y Progresión de Coleccionables")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int targetCollectibles = 5; 
    private int score = 0;

    [Header("Sistema de Llave (Secretos)")]
    [HideInInspector] public bool hasKey = false; 

    private Rigidbody2D rb;
    private bool levelFinished = false; // Seguro para evitar congelamientos

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }

    void Update()
    {
        if (levelFinished) return;

        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelFinished) return;

        
        if (collision.CompareTag("Collectible"))
        {
            score++;
            UpdateScoreText();
            Destroy(collision.gameObject);

            if (score >= targetCollectibles)
            {
                levelFinished = true; // Activamos el seguro para evitar bloqueos
                Debug.Log("¡Nivel completado! Cargando siguiente nivel...");
                AvanceSiguienteNivel();
            }
        }

        // 2. Daño exclusivo por trampas/pinchos (Tag "Trap")
        if (collision.CompareTag("Trap"))
        {
            GetComponent<PlayerDamageEffect>()?.TriggerDamageEffect();
            Debug.Log("¡Has tocado una trampa y recibido daño!");
        }
    }

    
    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("¡Llave secreta recogida!");
    }

    
    public void TryOpenDoor()
    {
        if (levelFinished) return;
        Debug.Log("¡Puerta secreta abierta con éxito!");
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score + " / " + targetCollectibles;
        }
    }

    
    void AvanceSiguienteNivel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("WinScene"); 
        }
    }
}