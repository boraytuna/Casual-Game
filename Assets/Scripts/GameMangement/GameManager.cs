using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public PlayerStats playerStats;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        UpdateLevelCompleteUI();
    }

    private void UpdateLevelCompleteUI()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
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
}
