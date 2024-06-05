using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int totalCollectedStars = 0;
    public int collectedStarsInEachLevel = 0;
    public TextMeshProUGUI noOfStars;
    private bool levelFinished = false;

    public bool LevelFinished
    {
        get { return levelFinished; }
    }

    private void Start()
    {
        ResetLevel();
    }

    public void AddStarPoint()
    {
        collectedStarsInEachLevel++;
        UpdateStarCountUI();
    }

    private void UpdateStarCountUI()
    {
        if (noOfStars != null)
        {
            noOfStars.text = collectedStarsInEachLevel.ToString();
        }
    }

    public void FinishLevel()
    {
        if (!levelFinished) // Check if the level has already been finished
        {
            totalCollectedStars += collectedStarsInEachLevel;
            levelFinished = true; // Set the flag
        }
        // Update UI accordingly, if necessary
    }

    public void ResetLevel()
    {
        collectedStarsInEachLevel = 0;
        levelFinished = false; // Reset the flag
        UpdateStarCountUI();
    }

}
