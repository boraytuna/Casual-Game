using System.Collections;
using UnityEngine;

public class GroundPairManager : MonoBehaviour
{
    public GameObject[] groundObjects; // Assign your ground objects in the Inspector
    public float minInvisibleTime = 2.0f; // Minimum time a pair stays invisible
    public float maxInvisibleTime = 5.0f; // Maximum time a pair stays invisible
    public float minVisibleTime = 2.0f; // Minimum time a pair stays visible
    public float maxVisibleTime = 5.0f; // Maximum time a pair stays visible

    private bool[] pairStates; // True if the pair is currently visible, false otherwise

    void Start()
    {
        int pairCount = groundObjects.Length / 2 + groundObjects.Length % 2; // Calculate the number of pairs, accounting for an odd number of objects
        pairStates = new bool[pairCount]; // Initialize the pair states
        for (int i = 0; i < pairStates.Length; i++)
        {
            pairStates[i] = true; // Initially, all pairs are considered visible
        }

        // Start managing ground objects in pairs
        for (int i = 0, pairIndex = 0; i < groundObjects.Length; i += 2, pairIndex++)
        {
            // Make sure there is a pair
            if (i + 1 < groundObjects.Length)
            {
                StartCoroutine(ManageGroundPair(groundObjects[i], groundObjects[i + 1], pairIndex));
            }
        }
    }

    IEnumerator ManageGroundPair(GameObject groundObject1, GameObject groundObject2, int pairIndex)
    {
        MeshRenderer renderer1 = groundObject1.GetComponent<MeshRenderer>();
        Collider collider1 = groundObject1.GetComponent<Collider>();
        MeshRenderer renderer2 = groundObject2.GetComponent<MeshRenderer>();
        Collider collider2 = groundObject2.GetComponent<Collider>();

        while (true)
        {
            // Wait for at least one other pair to be visible
            yield return new WaitUntil(() => AreAnyPairsVisible(pairIndex));

            // Make the ground pair invisible and non-interactable for a random duration
            renderer1.enabled = false;
            collider1.enabled = false;
            renderer2.enabled = false;
            collider2.enabled = false;
            pairStates[pairIndex] = false; // Update the state to invisible

            yield return new WaitForSeconds(Random.Range(minInvisibleTime, maxInvisibleTime));

            // Make the ground pair visible and interactable
            renderer1.enabled = true;
            collider1.enabled = true;
            renderer2.enabled = true;
            collider2.enabled = true;
            pairStates[pairIndex] = true; // Update the state to visible

            yield return new WaitForSeconds(Random.Range(minVisibleTime, maxVisibleTime));
        }
    }

    private bool AreAnyPairsVisible(int excludingPairIndex)
    {
        for (int i = 0; i < pairStates.Length; i++)
        {
            if (i != excludingPairIndex && pairStates[i]) // Check if any other pair is visible
            {
                return true;
            }
        }
        return false; // If no other pair is visible, return false
    }
}
