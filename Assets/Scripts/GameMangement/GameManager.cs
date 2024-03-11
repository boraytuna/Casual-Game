using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public PlayerStats playerStats;
    public TextMeshProUGUI totalStarsTextUI;
    public ZombieCharacterControl zombieCharacterControl;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        UpdateLevelCompleteUI();
        //UpdateTotalStarsDisplay();
        DisableZombie();
    }

    public void DisableZombie()
    {
        if(zombieCharacterControl != null)
        {
            zombieCharacterControl.enabled = false;
        }
    }

    private void UpdateLevelCompleteUI()
    {
        
        if(playerStats != null)
        {
            TextMeshProUGUI levelCompleteText = completeLevelUI.GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI starsText = completeLevelUI.GetComponentInChildren<TextMeshProUGUI>();
            if(starsText != null)
            {
                starsText.text = "Stars Collected: " + playerStats.collectedStarPoints.ToString();
            }
        }
    }

    private void UpdateTotalStarsDisplay()
    {
        TextMeshProUGUI totalStarsText = completeLevelUI.GetComponentInChildren<TextMeshProUGUI>(true); 
        if(totalStarsText != null)
        {
            totalStarsText.text = "Total Stars Collected: " + PlayerStats.totalCollectedStars.ToString();
        }
    }

    public void UpdateTotalStars(int totalStars)
    {
        // Update the UI or perform any other actions with the total stars count
        if (totalStarsTextUI != null)
        {
            totalStarsTextUI.text = "Total Stars Collected: " + totalStars.ToString();
        }
    }
}
