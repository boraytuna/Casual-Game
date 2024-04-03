using System.Collections;
using UnityEngine;

public class RotatingBladeAddingForce : MonoBehaviour
{
    [SerializeField]
    private float knockBackForce = 10f; // Adjust the force to suit the game's physics

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by rotating blade");

            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                Debug.Log("Applying force to player");
                // Apply an impulse force to the player
                Vector3 forceDirection = (other.transform.position - transform.position).normalized + Vector3.up; // Adding Vector3.up to knock the player upwards
                playerRigidbody.AddForce(forceDirection * knockBackForce, ForceMode.Impulse);

            }
        }
    }

}
