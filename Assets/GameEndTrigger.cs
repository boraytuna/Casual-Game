using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public GameComplete gameComplete;
    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Game Ended");
            gameComplete.CompleteGame();
        }  
    }
}
