using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public GameComplete gameComplete;
    public GameManager gameManager;
    public PlayerStats playerStats;
    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameComplete.CompleteGame();
            playerStats.FinishLevel();
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
