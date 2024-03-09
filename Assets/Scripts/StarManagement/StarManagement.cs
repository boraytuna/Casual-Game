using UnityEngine;

public class StarManagement : MonoBehaviour
{
    public AudioSource starAudioSource;

    private void Start()
    {
        PlayStarSound();
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
            // if (starAudioSource != null)
            // {
            //     starAudioSource.Stop();
            //     Destroy(starAudioSource.gameObject, 0.1f); // Destroy the GameObject containing the audio source
            // }
            AudioManager.instance.Stop("StarSound");
            Destroy(gameObject);
        }
    }

    private void PlayStarSound()
    {
        AudioManager.instance.Play("StarSound");
    }

    // Add methods to pause and resume star audio sources
public void PauseAudio()
{
    if (starAudioSource != null && starAudioSource.isPlaying)
    {
        starAudioSource.Pause();
    }
}

public void ResumeAudio()
{
    if (starAudioSource != null && !starAudioSource.isPlaying)
    {
        starAudioSource.UnPause();
    }
}

}
