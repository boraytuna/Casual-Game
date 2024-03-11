using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public bool levelCompleted = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.CompleteLevel();
            levelCompleted = true;
            AudioManager.instance.Stop("StarSound");
            zombieAudioStop();
        }  
    }

    public void UpdateTotalStars(int totalStars)
    {
        gameManager.UpdateTotalStars(totalStars);
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
