using UnityEngine;

public class StarManagement : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        // Start playing the music as soon as the star is instantiated
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player GameObject has the tag "Player"
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.AddStarPoint();
            }

            // Stop the music and destroy the star
            if (audioSource != null)
            {
                audioSource.Stop();
            }
            Destroy(gameObject);
        }
    }
}
