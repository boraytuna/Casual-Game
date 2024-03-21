// using UnityEngine;

// public class SwingSledgeHammer : MonoBehaviour
// {
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Touched player");
//             Rigidbody playerRb = other.GetComponentInChildren<Rigidbody>();

//             if (playerRb != null)
//             {
//                 Debug.Log("Player has rb");

//                 // Calculate direction with zero Y to keep the force horizontal
//                 Vector3 direction = (other.transform.position - transform.position);
//                 direction.y = 0; // Ignore vertical difference
//                 direction = direction.normalized;

//                 playerRb.AddForce(direction * 10000, ForceMode.Impulse);
//                 Debug.DrawLine(transform.position, transform.position + direction * 10, Color.red, 5f);
//             }
//             else
//             {
//                 Debug.Log("No Rigidbody found on Player");
//             }
//         }
//     }
// }

using UnityEngine;
using System.Collections;

public class SwingSledgeHammer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touched player");
            Rigidbody playerRb = other.GetComponentInChildren<Rigidbody>();

            if (playerRb != null)
            {
                Debug.Log("Player has Rigidbody.");
                // Ensure the Rigidbody is not kinematic to apply force
                StartCoroutine(ApplyForce(playerRb));
            }
            else
            {
                Debug.Log("No Rigidbody found on Player");
            }
        }
    }

    IEnumerator ApplyForce(Rigidbody playerRb)
    {
        // Temporarily make Rigidbody non-kinematic if it was kinematic
        bool wasKinematic = playerRb.isKinematic;
        playerRb.isKinematic = false;

        // Calculate direction, ignoring vertical difference for horizontal force
        Vector3 direction = (playerRb.transform.position - transform.position);
        direction.y = 0;
        direction = direction.normalized;

        // Apply force
        playerRb.AddForce(direction * 10000, ForceMode.Impulse);
        Debug.DrawLine(transform.position, transform.position + direction * 10, Color.red, 5f);

        // Wait for a short period before resetting kinematic state
        yield return new WaitForSeconds(1);

        // Reset kinematic state to its original setting
        playerRb.isKinematic = wasKinematic;
        Debug.Log("Rigidbody state reset to original.");
    }
}

