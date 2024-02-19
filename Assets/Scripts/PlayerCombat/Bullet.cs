using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f; // Adjust this value as needed

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with a zombie
        if (other.gameObject.CompareTag("Zombie"))
        {
            // Get the ZombieCharacterControl script on the collided object
            ZombieCharacterControl zombie = other.gameObject.GetComponent<ZombieCharacterControl>();
            if (zombie != null)
            {
                // Call the TakeDamage method on the zombie
                zombie.TakeDamage(damage);
            }

            // Destroy the bullet after it hits something
            Destroy(gameObject);
        }
        else
        {
            // Optionally destroy the bullet on hitting any object, not just zombies
            Destroy(gameObject);
        }
    }
}
