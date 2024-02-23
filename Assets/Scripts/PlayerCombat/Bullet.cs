using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f; // Damage the bullet will deal
    public AudioClip hitSound; // The sound to play on hit

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            return;

        }
      
        // Play the hit sound for any collision
        if (hitSound != null)
        {
            // Play the sound at the bullet's current position
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        // Specific logic for hitting a zombie
        if (other.CompareTag("Zombie"))
        {
            ZombieCharacterControl zombie = other.GetComponent<ZombieCharacterControl>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage); // Apply damage to the zombie
            }
        }

        // Destroy the bullet immediately after playing the sound
        Destroy(gameObject);
    }
}

