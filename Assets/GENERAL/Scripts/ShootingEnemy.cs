using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private float bulletSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            
            // Dispara hacia la izquierda (puedes cambiar el sentido según hacia dónde mire)
            if (rbBullet != null)
            {
                rbBullet.linearVelocity = Vector2.left * bulletSpeed;
            }
        }
    }
}