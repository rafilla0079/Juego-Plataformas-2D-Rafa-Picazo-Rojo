using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 3f;

    private Vector2 targetPos;

    void Start()
    {
        // Empieza dirigiéndose hacia el punto B
        targetPos = pointB.position;
    }

    void Update()
    {
        // Mueve la plataforma hacia el objetivo actual
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Si llega al punto objetivo, cambia de dirección
        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            if (targetPos == (Vector2)pointB.position)
            {
                targetPos = pointA.position;
            }
            else
            {
                targetPos = pointB.position;
            }
        }
    }

    // Hace que el jugador se mueva junto con la plataforma al subirse encima
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}