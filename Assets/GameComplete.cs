using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameComplete : MonoBehaviour
{
    public GameObject completeGameUI;
    public PlayerStats playerStats; 

    public void CompleteGame()
    {
        UpdateGameEndedUI();
        completeGameUI.SetActive(true); 
    }

    public void UpdateGameEndedUI()
    {
        TextMeshProUGUI totalStarsText = completeGameUI.GetComponentInChildren<TextMeshProUGUI>();

        if (totalStarsText != null)
        {
            totalStarsText.text = "Total Stars Collected: " + PlayerStats.totalCollectedStars.ToString();
        }
    }

    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit the game"); 
    }
}
