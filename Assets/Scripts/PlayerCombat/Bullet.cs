using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f; // Damage the bullet will deal

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with a zombie
        if (other.CompareTag("Zombie"))
        {
            // Try to get the ZombieCharacterControl script on the collided object
            ZombieCharacterControl zombie = other.GetComponent<ZombieCharacterControl>();
            if (zombie != null)
            {
                // Call the TakeDamage method on the zombie
                zombie.TakeDamage(damage);
            }

            // Destroy the bullet after dealing damage
            Destroy(gameObject);
        }
    }
}
