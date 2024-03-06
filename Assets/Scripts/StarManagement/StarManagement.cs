using UnityEngine;

public class StarManagement : MonoBehaviour
{
    public AudioSource starAudioSource;

    private void Start()
    {
        // Get the AudioSource component
        starAudioSource = GetComponent<AudioSource>();
        // Start playing the music as soon as the star is instantiated
        if (starAudioSource != null)
        {
            starAudioSource.Play();
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
            if (starAudioSource != null)
            {
                starAudioSource.Stop();
            }
            Destroy(gameObject);
            
        }
    }
}
