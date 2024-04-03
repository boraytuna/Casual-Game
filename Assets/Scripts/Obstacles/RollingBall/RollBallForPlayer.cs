using UnityEngine;

public class RollBallForPlayer : MonoBehaviour
{
    public GameObject ballPrefab; // Assign this in the Inspector with your ball prefab
    public float minSpawnInterval = 1.0f; // Minimum time between ball spawns
    public float maxSpawnInterval = 3.0f; // Maximum time between ball spawns
    public Transform[] spawnPoints; // An array of points from which balls will be instantiated
    public Vector3 ballDirection = new Vector3(1, 0, 0); // Direction for the ball to move towards
    public float ballForce = 500f; // The force applied to balls
    private bool playerInRange = false; // Flag to check if player is in range
    private float timer; // Timer to track spawn intervals

    void Update()
    {
        // If the player is in range and the timer has reached a random spawn interval
        if (playerInRange && timer >= Random.Range(minSpawnInterval, maxSpawnInterval))
        {
            SpawnBall();
            // Reset the timer to a new random interval after spawning a ball
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime; // Update the timer
        }
    }

    private void SpawnBall()
    {
        if (ballPrefab != null && spawnPoints.Length > 0)
        {
            // Randomly select one of the spawn points to instantiate the ball
            Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the ball at the selected spawn point position and rotation
            GameObject ball = Instantiate(ballPrefab, selectedSpawnPoint.position, Quaternion.identity);

            // Apply force to the ball in the specified direction
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.AddForce(ballDirection.normalized * ballForce, ForceMode.Impulse);
            }

            // Destroy the ball after 5 seconds
            Destroy(ball, 5f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject is tagged as "Player"
        {
            Debug.Log("Player is in range");
            playerInRange = true;
            // Reset the timer as soon as the player enters the range to spawn the first ball quickly
            timer = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is out of range");
            playerInRange = false;
            timer = 0; // Reset the timer when the player leaves the range
        }
    }
}
