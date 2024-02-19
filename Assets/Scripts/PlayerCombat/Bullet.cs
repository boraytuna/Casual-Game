using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20f; // Damage the bullet will deal

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collides with a zombie
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Try to get the ZombieCharacterControl script on the collided object
            ZombieCharacterControl zombie = collision.gameObject.GetComponent<ZombieCharacterControl>();
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
