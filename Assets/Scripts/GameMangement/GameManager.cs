using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject completeGameUI;
    public TextMeshProUGUI starsText; // The text field for current level stars
    public TextMeshProUGUI totalStarsText; // The text field for total stars
    public PlayerStats playerStats;

    private void Awake()
    {
        // Make sure the UI is not visible when the game starts
        completeLevelUI.SetActive(false);
        completeGameUI.SetActive(false);
    }

    public void CompleteLevel()
    {
        playerStats.FinishLevel(); // Add the stars collected in the current level to the total
        UpdateUI(); // Update the UI elements
        completeLevelUI.SetActive(true); // Display the level completion UI
    }

    public void EndGame()
    {
        // Check if the FinishLevel has already been called to prevent double counting
        if (!playerStats.LevelFinished)
        {
            playerStats.FinishLevel(); // Add stars of the last level only if it wasn't finished
        }
        UpdateUI(); // Update the UI to show the correct total stars
        completeGameUI.SetActive(true); // Show the end game UI
    }

    // Call this method to update the UI elements for current and total stars
    private void UpdateUI()
    {
        UpdateCurrentLevelStarsUI();
        UpdateTotalStarsUI();
    }

    private void UpdateCurrentLevelStarsUI()
    {
        if (starsText != null)
        {
            starsText.text = "Stars Collected: " + playerStats.collectedStarsInEachLevel;
        }
    }

    private void UpdateTotalStarsUI()
    {
        if (totalStarsText != null)
        {
            totalStarsText.text = "Total Stars: " + PlayerStats.totalCollectedStars;
        }
    }
    
    // This can be called to reset the game state if needed, for example when replaying a level or restarting the game
    public void ResetGameState()
    {
        PlayerStats.totalCollectedStars = 0;
        playerStats.ResetLevel();
        UpdateUI();
        // Additional reset logic can be added here if required
    }
}
