using UnityEngine;

public class DobleSalto : MonoBehaviour
{
    [Header("Configuración de Salto")]
    public float fuerzaSalto = 7f;
    public float cooldownSalto = 0.5f; // Tiempo de espera obligatorio entre usos

    private Rigidbody2D rb;
    private bool puedeSaltoDoble = false;
    private float tiempoSiguienteSalto = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            if (EstaEnSuelo())
            {
                
                EjecutarSalto();
                puedeSaltoDoble = true; 
            }
            else if (puedeSaltoDoble && Time.time >= tiempoSiguienteSalto)
            {
                
                EjecutarSalto();
                puedeSaltoDoble = false; 
                tiempoSiguienteSalto = Time.time + cooldownSalto; // Activa el cooldown
            }
        }
    }

    void EjecutarSalto()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }

    // Comprobación básica de suelo (puedes adaptarla si usas otro método en tu PlayerController)
    bool EstaEnSuelo()
    {
        return Mathf.Abs(rb.linearVelocity.y) < 0.001f;
    }
}