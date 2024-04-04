using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private bool levelIsAlreadyEnded = false; // This flag ensures that the end level logic is only called once.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !levelIsAlreadyEnded)
        {
            gameManager.CompleteLevel();
            levelIsAlreadyEnded = true; // Set the flag so it doesn't run again.
            // Optionally, deactivate the trigger to prevent further collisions.
            this.gameObject.SetActive(false);
            zombieAudioStop();
        }
    }

    public void zombieAudioStop()
    {
        ZombieCharacterControl[] zombies = FindObjectsOfType<ZombieCharacterControl>();
        foreach (ZombieCharacterControl zombie in zombies)
        {
            zombie.StopZombieSound();
        }
    }
}

