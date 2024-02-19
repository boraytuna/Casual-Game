using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float health = 100f; // Player's health
    public GameObject bulletPrefab; // Bullet prefab to shoot
    public Transform bulletSpawnPoint; // Where the bullet is spawned on the player
    public float bulletForce = 20f; // Force applied to the bullet for shooting
    public float attackRate = 0.5f; // Rate of fire
    private float lastAttackTime = 0f; // Time since last shot

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime >= attackRate)
        {
            //Shoot();
            lastAttackTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.VelocityChange);
        Destroy(bullet, 2f); // Destroy the bullet after 2 seconds to clean up
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        // Implement health UI update logic here if needed
    }

    private void Die()
    {
        // Handle player death here (e.g., disable movement, show game over screen, etc.)
        Debug.Log("Player Died!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            // Assuming the zombie deals a fixed amount of damage
            TakeDamage(10f); // Example damage amount
        }
    }
}
