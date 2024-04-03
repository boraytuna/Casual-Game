using System.Collections;
using UnityEngine;

public class BallImpact : MonoBehaviour
{
    public float impactForce = 500f; // The force applied to the player upon impact

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by ball");

            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            // Replace this with your player movement script if it's different
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
                Vector3 forceDirection = new Vector3(side, 0.1f, 0) * impactForce;
                playerRigidbody.AddForce(forceDirection, ForceMode.Impulse);

                // Start the coroutine to re-enable 'Is Kinematic' and the PlayerMovement script
                StartCoroutine(ReenablePlayerControls(playerRigidbody, playerMovement));
            }
        }
    }

    private IEnumerator ReenablePlayerControls(Rigidbody rb, PlayerMovement movement)
    {
        // Wait for the specified time before re-enabling controls
        yield return new WaitForSeconds(2.0f); // Adjust the time as needed

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Re-enable the PlayerMovement script
        movement.EnableMovement();
    }
}
