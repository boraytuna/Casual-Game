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
            Debug.Log("Game Ended");
            gameComplete.CompleteGame();
            playerStats.FinishLevel();
        }  
    }

    public void UpdateTotalStars(int totalStars)
    {
        // Assuming GameManager has a method to handle the total stars.
        // You might need to adjust this line to match your actual method signature.
        gameManager.UpdateTotalStars(totalStars);
    }
}
