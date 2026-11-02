using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    [Header("Configuración de Flotación")]
    [SerializeField] private float amplitude = 0.5f; // Altura del movimiento
    [SerializeField] private float frequency = 2f;   // Velocidad del movimiento

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}