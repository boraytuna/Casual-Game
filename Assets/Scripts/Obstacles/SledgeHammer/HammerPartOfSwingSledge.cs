using System.Collections;
using UnityEngine;

public class HammerPartOfSwingSledge : MonoBehaviour
{
    [SerializeField]
    private float knockBackForce = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player body hit");

            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerRigidbody != null && playerMovement != null)
            {
                Debug.Log("Player rigidbody and movement script found");

                // Disable the PlayerMovement script to prevent input from interfering
                playerMovement.DisableMovement();

                // Wake up the Rigidbody in case it's sleeping
                playerRigidbody.WakeUp();

                // Temporarily disable 'Is Kinematic' to apply force
                playerRigidbody.isKinematic = false;

                // Determine the side of the hit
                float side = transform.position.x < other.transform.position.x ? 1f : -1f;

                // Apply force depending on the side of the hit
                Vector3 forceDirection = new Vector3(side, 0.5f, 0) * knockBackForce;
                playerRigidbody.AddForce(forceDirection, ForceMode.Impulse);

                // Start the coroutine to re-enable 'Is Kinematic' and the PlayerMovement script
                StartCoroutine(ReenableKinematicAndMovement(playerRigidbody, playerMovement));
            }
        }
    }

    private IEnumerator ReenableKinematicAndMovement(Rigidbody rb, PlayerMovement movement)
    {
        // Wait for the specified time before re-enabling 'Is Kinematic' and PlayerMovement
        yield return new WaitForSeconds(3.5f);
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        
        // Re-enable the PlayerMovement script
        movement.EnableMovement();
    }
}
